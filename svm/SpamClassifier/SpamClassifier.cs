using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSVM.Tokenizer;
using System.IO;
using System.Configuration;

namespace MiniSVM.SpamClassifier
{
    public partial class SpamClassifier : Form
    {
        private MailTokenizer Tokenizer = null;
        public Dictionary<string, Dictionary<MailType, int>> TrainingWordCounts { get; set; }
        public List<Dictionary<string, int>> RawTrainingSet { get; set; }
        public List<MailType> RawTrainingLabels { get; set; }

        public SpamClassifier()
        {
            InitializeComponent();
            Tokenizer = new MailTokenizer();
            ClearSet();
        }

        class ProgessWorkerArgument
        {
            public string Directory { get; set; }
            public MailType Type { get; set; }
        }

        private void buttonLoadSpam_Click(object sender, EventArgs e)
        {
            ReadDirectory(MailType.Spam, ReadSpamCompleted);
        }

        private void ReadSpamCompleted(object sender, ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkCompletedArgs<object> eventArgs)
        {
        }

        private void buttonLoadHam_Click(object sender, EventArgs e)
        {
            ReadDirectory(MailType.Ham, ReadHamCompleted);
        }

        private void ReadHamCompleted(object sender, ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkCompletedArgs<object> eventArgs)
        {
        }

        private void ReadTrainingMatrix()
        {
            //xml deserialization
        }

        private void SaveTrainingSet()
        {
            //xml serialization
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

        private void ClearSet()
        {
            TrainingWordCounts = new Dictionary<string, Dictionary<MailType, int>>();
            RawTrainingSet = new List<Dictionary<string, int>>();
            RawTrainingLabels = new List<MailType>();
        }

        private void ProcessMail(string mail, MailType type)
        {
            //tokenization
            var nonheadersMail = Tokenizer.RemoveHeaders(mail);
            var cleanedMail = Tokenizer.RemoveHTML(nonheadersMail);
            var tokenizedMail = Tokenizer.tokenizeString(cleanedMail);

            //update training matrix
            var trainingSetItem = new Dictionary<string, int>();
            foreach (var word in tokenizedMail)
            {
                if (!trainingSetItem.ContainsKey(word))
                    trainingSetItem.Add(word, 0);
                trainingSetItem[word]++;
                UpdateTrainingWordCount(word, type);
            }
            RawTrainingSet.Add(trainingSetItem);
            RawTrainingLabels.Add(type);
        }

        private void ReadDirectory(MailType type, ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkCompleted<object> completedHandler)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog(this);
            var argument = new ProgessWorkerArgument()
            {
                Directory = dialog.SelectedPath,
                Type = type
            };
            if (result == DialogResult.OK)
            {
                new ProgressWorker<ProgessWorkerArgument, object>(
                    ReadDirectoryContent, argument, completedHandler, "Reading set", true, true).ShowDialog(this);
            }
        }

        private void ReadDirectoryContent(object sender,
            ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkerEventArgs<ProgessWorkerArgument, object> args)
        {
            ReadDirectoryFiles(args.Argument.Directory, args.Argument.Type, args);
        }

        private void ReadDirectoryFiles(string workingDirectory, MailType mailType,
            ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkerEventArgs<ProgessWorkerArgument, object> args)
        {
            const int cutThreshold = 30;
            var count = Directory.GetFiles(workingDirectory).Length;
            int current = 0;
            if (checkBoxRecursive.Checked)
            {
                foreach (string dir in Directory.EnumerateDirectories(workingDirectory))
                {
                    ReadDirectoryFiles(dir, mailType, args);
                }
                string workingDirectoryInfo = workingDirectory;
                if (workingDirectoryInfo.Length > cutThreshold)
                {
                    workingDirectoryInfo = workingDirectoryInfo.Substring(workingDirectoryInfo.Length - cutThreshold, cutThreshold);
                    workingDirectoryInfo = "..." + workingDirectoryInfo.Substring(workingDirectoryInfo.IndexOfAny(new[] { '\\', '/' }));
                }
                args.ChangeProgressInfo("Processing directory: " + workingDirectoryInfo);
            }
            foreach (string file in Directory.EnumerateFiles(workingDirectory))
            {
                args.ReportProgress(current * 100 / count);
                ProcessMail(File.ReadAllText(file), mailType);
                ++current;
            }
        }

        private void ReadUselessWordsFile(object sender)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Tokenizer.ReadUselessWords(dialog.FileName);
            }
        }

        private void buttonLoadUseless_Click(object sender, EventArgs e)
        {
            ReadUselessWordsFile(sender);
        }

        private void buttonShowUseless_Click(object sender, EventArgs e)
        {
            //todo: show data in new dialog
            var uselessWords = Tokenizer.UselessWords;
            if (uselessWords == null)
                MessageBox.Show("No useless words loaded yet!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                var wordsList = "";
                foreach (var word in uselessWords)
                {
                    wordsList += word + '\n';
                }
                MessageBox.Show(wordsList);
            }
        }

        private void buttonClearUseless_Click(object sender, EventArgs e)
        {
            Tokenizer.ClearUselessWords();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearSet();
        }

        private void richTextBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClearTxt_Click(object sender, EventArgs e)
        {
            richTextBoxEmail.Text = "";
        }

        private void buttonClassifyTxt_Click(object sender, EventArgs e)
        {
            if (richTextBoxEmail.Text.Length == 0)
            {
                MessageBox.Show("No mail loaded yet!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void dataGridViewSpam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonLoadEmail_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                richTextBoxEmail.Text = File.ReadAllText(dialog.FileName);
            }
        }
    }
}
