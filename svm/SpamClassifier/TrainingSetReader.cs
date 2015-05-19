using MiniSVM.Tokenizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSVM.SpamClassifier
{
    public class TrainingSetReader
    {
        public Dictionary<string, Dictionary<MailType, int>> TrainingWordCounts { get; set; }
        public List<Dictionary<string, int>> RawSpamTrainingSet { get; set; }
        public List<Dictionary<string, int>> RawHamTrainingSet { get; set; }

        private MailTokenizer Tokenizer { get; set; }

        public TrainingSetReader(MailTokenizer tokenizer)
        {
            Tokenizer = tokenizer;
            ClearSet();
        }

        public void ClearSet()
        {
            TrainingWordCounts = new Dictionary<string, Dictionary<MailType, int>>();
            RawSpamTrainingSet = new List<Dictionary<string, int>>();
            RawHamTrainingSet = new List<Dictionary<string, int>>();
        }

        private void ProcessMail(string mail, MailType type)
        {
            //tokenization
            var nonheadersMail = Tokenizer.RemoveHeaders(mail);
            var cleanedMail = Tokenizer.RemoveHTML(nonheadersMail);
            var tokenizedMail = Tokenizer.TokenizeString(cleanedMail);

            //update training matrix
            var trainingSetItem = new Dictionary<string, int>();
            foreach (var word in tokenizedMail)
            {
                if (!trainingSetItem.ContainsKey(word))
                    trainingSetItem.Add(word, 0);
                trainingSetItem[word]++;
                UpdateTrainingWordCount(word, type);
            }
            if (type==MailType.Ham)
            {
                RawHamTrainingSet.Add(trainingSetItem);
            }
            else
            {
                RawSpamTrainingSet.Add(trainingSetItem);
            }
        }

        private void UpdateTrainingWordCount(string word, MailType type)
        {
            if (TrainingWordCounts != null && word != null)
            {
                if (TrainingWordCounts.ContainsKey(word.ToLower()))
                {
                    var vecValue = TrainingWordCounts[word];
                    ++vecValue[type];
                    TrainingWordCounts[word] = vecValue;
                }
                else //new word
                {
                    var vecValue = new Dictionary<MailType, int>();
                    vecValue.Add(MailType.Ham, 0);
                    vecValue.Add(MailType.Spam, 0);
                    vecValue[type] = 1;
                    TrainingWordCounts.Add(word.ToLower(), vecValue);
                }
            }
        }

        public void ReadDirectoryFiles(string directory, MailType type, bool recursive)
        {
            const int cutThreshold = 30;
            var count = Directory.GetFiles(directory).Length;
            int current = 0;
            if (recursive)
            {
                foreach (string dir in Directory.EnumerateDirectories(directory))
                {
                    ReadDirectoryFiles(dir, type, recursive);
                }
                string workingDirectoryInfo = directory;
                if (workingDirectoryInfo.Length > cutThreshold)
                {
                    workingDirectoryInfo = workingDirectoryInfo.Substring(workingDirectoryInfo.Length - cutThreshold, cutThreshold);
                    workingDirectoryInfo = "..." + workingDirectoryInfo.Substring(workingDirectoryInfo.IndexOfAny(new[] { '\\', '/' }));
                }
                NotifyProcessingDirectory(workingDirectoryInfo);
            }
            foreach (string file in Directory.EnumerateFiles(directory))
            {
                ChangeProgress(current * 100 / count);
                ProcessMail(File.ReadAllText(file), type);
                ++current;
            }
        }

        private void ChangeProgress(int progress)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, new ProgressEventArgs() { Progress = progress });
        }
        private void NotifyProcessingDirectory(string directory)
        {
            if (ProcessingDirectory != null)
                ProcessingDirectory(this, new ProcessingDirectoryEventArgs() { CurrentDirectory = directory });
        }

        public event EventHandler<ProcessingDirectoryEventArgs> ProcessingDirectory;

        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public class ProcessingDirectoryEventArgs : EventArgs
        {
            public string CurrentDirectory { get; set; }
        }

        public class ProgressEventArgs : EventArgs
        {
            public int Progress { get; set; }
        }
    }
}
