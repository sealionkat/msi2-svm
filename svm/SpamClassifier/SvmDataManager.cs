using MiniSVM.Classifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.SpamClassifier
{
    public class SvmDataManager
    {
        public List<Dictionary<string, int>> SpamTrainingSet { get; set; }
        public List<Dictionary<string, int>> HamTrainingSet { get; set; }
        public HashSet<string> SelectedFeatures { get; set; }

        public SparseVector<double>[] TrainingData { get; set; }
        public double[] TrainingLabels { get; set; }
        public SparseVector<double>[] TestData { get; set; }
        public double[] TestLabels { get; set; }

        public SvmDataManager(List<Dictionary<string, int>> spamTrainingSet,
            List<Dictionary<string, int>> hamTrainingSet,
            HashSet<string> selectedFeatures)
        {
            SpamTrainingSet = spamTrainingSet;
            HamTrainingSet = hamTrainingSet;
            SelectedFeatures = selectedFeatures;
        }

        public SvmDataManager()
        {
            SpamTrainingSet = new List<Dictionary<string, int>>();
            HamTrainingSet = new List<Dictionary<string, int>>();
            SelectedFeatures = new HashSet<string>();
        }

        public void CalculateTrainingData(int testSetPercent)
        {
            int totalSetSize = SpamTrainingSet.Count + HamTrainingSet.Count;
            int spamTestSetSize = (testSetPercent * SpamTrainingSet.Count) / 100;
            int hamTestSetSize = (testSetPercent * HamTrainingSet.Count) / 100;
            int spamTrainingSetSize = SpamTrainingSet.Count - spamTestSetSize;
            int hamTrainingSetSize = HamTrainingSet.Count - hamTestSetSize;
            int[] permutation = Enumerable.Range(0, hamTrainingSetSize).ToArray();
            var random = new Random();
            TrainingData = new SparseVector<double>[spamTrainingSetSize + hamTrainingSetSize];
            TrainingLabels = new double[spamTrainingSetSize + hamTrainingSetSize];
            TestData = new SparseVector<double>[totalSetSize - TrainingData.Length];
            TestLabels = new double[totalSetSize - TrainingData.Length];

            int currentElement = 0;
            foreach (int index in Permutation.Sequence(HamTrainingSet.Count))
            {
                var item = TokenizedMailToFeatures(HamTrainingSet[index]);
                if (currentElement < hamTrainingSetSize)
                {
                    TrainingData[currentElement] = item;
                    TrainingLabels[currentElement] = (double)MailType.Ham;
                }
                else
                {
                    TestData[currentElement - hamTrainingSetSize] = item;
                    TestLabels[currentElement - hamTrainingSetSize] = (double)MailType.Ham;
                }
                ++currentElement;
            }
            currentElement = 0;
            foreach (int index in Permutation.Sequence(SpamTrainingSet.Count))
            {
                var item = TokenizedMailToFeatures(SpamTrainingSet[index]);
                if (currentElement < spamTrainingSetSize)
                {
                    TrainingData[hamTrainingSetSize + currentElement] = item;
                    TrainingLabels[hamTrainingSetSize + currentElement] = (double)MailType.Spam;
                }
                else
                {
                    TestData[hamTestSetSize + currentElement - spamTrainingSetSize] = item;
                    TestLabels[hamTestSetSize + currentElement - spamTrainingSetSize] = (double)MailType.Spam;
                }
                ++currentElement;
            }
        }
        public SparseVector<double> TokenizedMailToFeatures(List<string> tokenizedMail)
        {
            return TokenizedMailToFeatures(SelectedFeatures, tokenizedMail);
        }
        public SparseVector<double> TokenizedMailToFeatures(Dictionary<string, int> tokenizedMail)
        {
            return TokenizedMailToFeatures(SelectedFeatures, tokenizedMail);
        }

        public SparseVector<double> TokenizedMailToFeatures(HashSet<string> features, List<string> tokenizedMail)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            SparseVector<double> result = new SparseVector<double>();
            foreach (var word in tokenizedMail)
            {
                if (!wordCounts.ContainsKey(word))
                    wordCounts.Add(word, 0);
                wordCounts[word]++;
            }
            return TokenizedMailToFeatures(features, wordCounts);
        }

        public SparseVector<double> TokenizedMailToFeatures(HashSet<string> features, Dictionary<string, int> tokenizedMail)
        {
            SparseVector<double> result = new SparseVector<double>();
            int j = 0;
            foreach (var word in features)
            {
                result[j++] = (tokenizedMail.ContainsKey(word)) ? tokenizedMail[word] : 0;
            }
            return result;
        }
    }
}
