using LibSVMPort;
using MiniSVM.Classifier;
using MiniSVM.Tokenizer;
using System;
using System.Collections.Generic;

namespace MiniSVM.SpamClassifier
{
    public class SpamClassifierModel
    {
        public Dictionary<string, Dictionary<MailType, int>> TrainingWordCounts { get { return Reader.TrainingWordCounts; } }
        private List<Dictionary<string, int>> RawTrainingSet { get { return Reader.RawTrainingSet; } }
        private List<MailType> RawTrainingLabels { get { return Reader.RawTrainingLabels; } }
        private HashSet<string> SelectedFeaturesSet { get; set; }
        public IClassifier<DoubleSparseVector> Classifier { get; set; }
        public IHypothesis<DoubleSparseVector> CurrentHypothesis { get; set; }

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

        private DoubleSparseVector TokenizedMailToFeatures(List<string> tokenizedMail)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            DoubleSparseVector result = new DoubleSparseVector();
            foreach (var word in tokenizedMail)
            {
                if (!wordCounts.ContainsKey(word))
                    wordCounts.Add(word, 0);
                wordCounts[word]++;
            }
            int j = 0;
            foreach (var word in SelectedFeaturesSet)
            {
                result[j++] = (wordCounts.ContainsKey(word)) ? wordCounts[word] : 0;
            }
            return result;
        }
        
        public void GetTrainingData(out DoubleSparseVector[] trainingData, out double[] trainingLabels)
        {
            trainingData = new DoubleSparseVector[RawTrainingSet.Count];
            trainingLabels = new double[RawTrainingLabels.Count];
            for (int i = 0; i < RawTrainingSet.Count; i++)
            {
                trainingData[i] = new DoubleSparseVector();
                int j = 0;
                foreach (var word in SelectedFeaturesSet)
                {
                    trainingData[i][j++] = (RawTrainingSet[i].ContainsKey(word)) ? RawTrainingSet[i][word] : 0;
                }
                trainingLabels[i] = (int)RawTrainingLabels[i];
            }
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
            var features = TokenizedMailToFeatures(tokenizedMail);
            return CurrentHypothesis.Predict(features) > 0 ? MailType.Ham : MailType.Spam;
        }

        public bool Train(double gamma, double cost, TrainingStepCallback callback)
        {
            DoubleSparseVector[] trainingData;
            double[] trainingLabels;
            callback(TrainingStep.PreparingSet);
            GetTrainingData(out trainingData, out trainingLabels);
            callback(TrainingStep.TrainingClassifier);
            Classifier = CreateClassifier(gamma, cost);
            if (Classifier.Compute(trainingData, trainingLabels))
            {
                CurrentHypothesis = Classifier.GetHypothesis();
                return true;
            }
            return false;
        }
        private IClassifier<DoubleSparseVector> CreateClassifier(double gamma, double cost)
        {
            return new LibSVM<DoubleSparseVector>()
            {
                SVMParameters = CreateParameters(gamma, cost)
            };
        }
        private SVMParams<DoubleSparseVector> CreateParameters(double gamma, double cost)
        {
            return new SVMParams<DoubleSparseVector>()
            {
                Cost = cost,
                Gamma = gamma,
                Kernel = DoubleSparseVector.Multiply
            };
        }
    }

    public delegate void TrainingStepCallback(TrainingStep step);

    public enum TrainingStep
    {
        PreparingSet,
        TrainingClassifier
    }
}
