using LibSVMPort;
using MiniSVM.Classifier;
using MiniSVM.Tokenizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MiniSVM.SpamClassifier
{
    public class SpamClassifierModel
    {
        public Dictionary<string, Dictionary<MailType, int>> TrainingWordCounts { get { return Reader.TrainingWordCounts; } }
        private HashSet<string> SelectedFeaturesSet { get; set; }
        public IClassifier Classifier { get; set; }
        public IHypothesis CurrentHypothesis { get; set; }

        public SpamClassifierModel()
        {
            Tokenizer = new MailTokenizer();
            Reader = new TrainingSetReader(Tokenizer);
            ClearSet();
        }
        private MailTokenizer Tokenizer { get; set; }

        private TrainingSetReader Reader { get; set; }

        public void ClearSet()
        {
            Reader.ClearSet();
            SelectedFeaturesSet = new HashSet<string>();
        }

        public void ReadDirectoryContent(string directory, 
            MailType type, bool recursive, EventHandler<TrainingSetReader.ProgressEventArgs> progressHandler, 
            EventHandler<TrainingSetReader.ProcessingDirectoryEventArgs> directoryHandler)
        {
            Reader.ProgressChanged += progressHandler;
            Reader.ProcessingDirectory += directoryHandler;
            Reader.ReadDirectoryFiles(directory, type, recursive);
            Reader.ProgressChanged -= progressHandler;
            Reader.ProcessingDirectory -= directoryHandler;
        }

        public void AutoSelectFeatures(int spamTh, int hamTh)
        {
            foreach (var item in TrainingWordCounts)
            {
                if (item.Value[MailType.Ham] > hamTh)
                    SelectedFeaturesSet.Add(item.Key);
                if (item.Value[MailType.Spam] > spamTh)
                    SelectedFeaturesSet.Add(item.Key);
            }
        }

        public void AddSelectedFeature(string feature)
        {
            SelectedFeaturesSet.Add(feature);
        }

        public int SelectedFeaturesCount { get { return SelectedFeaturesSet.Count; } }

        public void ClearSelectedFeatures()
        {
            SelectedFeaturesSet.Clear();
        }

        public void ReadUselessWords(string filename)
        {
            Tokenizer.ReadUselessWords(filename);
        }

        public IEnumerable<string> UselessWords
        {
            get
            {
                foreach (var item in Tokenizer.UselessWords)
                {
                    yield return item;
                }
            }
        }

        public void ClearUselessWords()
        {
            Tokenizer.UselessWords.Clear();
        }

        public MailType Predict(string mail)
        {
            var tokenizedMail = Tokenizer.TokenizeString(mail);
            var features = new SvmDataManager().TokenizedMailToFeatures(SelectedFeaturesSet, tokenizedMail);
            return CurrentHypothesis.Predict(features) > 0 ? MailType.Ham : MailType.Spam;
        }
        public MailType Predict(SparseVector<double> mail)
        {
            return CurrentHypothesis.Predict(mail) > 0 ? MailType.Ham : MailType.Spam;
        }

        public float Train(KernelType type, double gamma, double cost, int testSetPercent, TrainingStepCallback callback)
        {
            callback(TrainingStep.PreparingSet);
            var svmData = new SvmDataManager(Reader.RawSpamTrainingSet, Reader.RawHamTrainingSet, SelectedFeaturesSet);
            svmData.CalculateTrainingData(testSetPercent);
            callback(TrainingStep.TrainingClassifier);
            Classifier = CreateClassifier(type, gamma, cost);
            if (Classifier.Compute(svmData.TrainingData, svmData.TrainingLabels))
            {
                CurrentHypothesis = Classifier.GetHypothesis();
                callback(TrainingStep.TestingClassifier);
                return Test(svmData.TestData, svmData.TestLabels);
            }
            return -1;
        }

        private float Test(SparseVector<double>[] testData, double[] testLabels)
        {
            int errors = 0;
            for (int i = 0; i < testData.Length; i++)
            {
                var result = Predict(testData[i]);
                var expected = (testLabels[i] > 0) ? MailType.Ham : MailType.Spam;
                if (result!=expected)
                {
                    errors++;
                }
            }
            return 1 - (((float)errors) / testData.Length);
        }

        private IClassifier CreateClassifier(KernelType type, double gamma, double cost)
        {
            return new LibSVM()
            {
                SVMParameters = CreateParameters(type, gamma, cost)
            };
        }
        private SVMParams CreateParameters(KernelType type, double gamma, double cost)
        {
            return new SVMParams()
            {
                Cost = cost,
                Kernel = (type == KernelType.Gaussian) ? 
                    (Kernel)new GaussianKernel(gamma) : 
                    (Kernel)new LinearKernel()
            };
        }

        public bool SaveModel(string filename)
        {
            try
            {
                CurrentHypothesis.Save(filename);
                string featuresPath = Path.ChangeExtension(filename, ".ftr");
                File.WriteAllText(featuresPath, SelectedFeaturesSet.ToXmlString());
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool LoadModel(string filename)
        {
            try
            {
                CurrentHypothesis = new LibSVMHypothesis();
                CurrentHypothesis.Load(filename);
                string featuresPath = Path.ChangeExtension(filename, ".ftr");
                SelectedFeaturesSet = File.ReadAllText(featuresPath).FromXmlString<HashSet<string>>();
                return true;
            }
            catch (Exception)
            {
                CurrentHypothesis = null;
                SelectedFeaturesSet = new HashSet<string>();
                return false;
            }
        }
    }

    public delegate void TrainingStepCallback(TrainingStep step);

    public enum TrainingStep
    {
        PreparingSet,
        TrainingClassifier,
        TestingClassifier
    }
}
