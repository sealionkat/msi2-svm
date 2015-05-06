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
        private MailTokenizer MailTokenizer = null;
        public List<string> Spam { get; set; }
        public List<string> Ham { get; set; }
        public Dictionary<string, Dictionary<MailType, int>> TrainingWordCounts { get; set; }
        public List<Dictionary<string, int>> RawTrainingSet { get; set; }
        public List<MailType> RawTrainingLabels { get; set; }

        public SpamClassifier()
        {
            InitializeComponent();
            MailTokenizer = new MailTokenizer();
            ClearSet();

        }

        private void buttonLoadSpam_Click(object sender, EventArgs e)
        {
            ReadDirectory(ReadSpamCompleted);
        }

        private void ReadSpamCompleted(object sender, ProgressWorker<string, List<string>>.ProgressWorkCompletedArgs<List<string>> eventArgs)
        {
            var result = eventArgs.Result;
            if (result != null)
            {
                Spam = result;
                ProcessMails(MailType.Spam);
            }
        }

        private void buttonLoadHam_Click(object sender, EventArgs e)
        {
            ReadDirectory(ReadHamCompleted);
        }

        private void ReadHamCompleted(object sender, ProgressWorker<string, List<string>>.ProgressWorkCompletedArgs<List<string>> eventArgs)
        {
            var result = eventArgs.Result;
            if (result != null)
            {
                Ham = result;
                ProcessMails(MailType.Ham);
            }
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

        private void ProcessMails(MailType type)
        {
            var mails = (type == MailType.Spam) ? Spam : Ham;
            foreach (var mail in mails)
            {
                //tokenization
                var nonheadersMail = MailTokenizer.RemoveHeaders(mail);
                var cleanedMail = MailTokenizer.RemoveHTML(nonheadersMail);
                var tokenizedMail = MailTokenizer.tokenizeString(cleanedMail);

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
        }

        private void ReadDirectory(ProgressWorker<string, List<string>>.ProgressWorkCompleted<List<string>> completedHandler)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                new ProgressWorker<string, List<string>>(
                    ReadDirectoryContent, dialog.SelectedPath, completedHandler, "Reading set", true, true).ShowDialog(this);
            }
        }

        private void ReadDirectoryContent(object sender,
            ProgressWorker<string, List<string>>.ProgressWorkerEventArgs<string, List<string>> args)
        {
            var strings = new List<string>();
            ReadDirectoryFiles(args.Argument, ref strings, args);
            args.Result = strings;
        }

        private void ReadDirectoryFiles(string workingDirectory, ref List<string> output,
            ProgressWorker<string, List<string>>.ProgressWorkerEventArgs<string, List<string>> args)
        {
            const int cutThreshold = 30;
            var count = Directory.GetFiles(workingDirectory).Length;
            int current = 0;
            if (checkBoxRecursive.Checked)
            {
                foreach (string dir in Directory.EnumerateDirectories(workingDirectory))
                {
                    ReadDirectoryFiles(dir, ref output, args);
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
                output.Add(File.ReadAllText(file));
                ++current;
            }
        }

        private void ReadUselessWordsFile(object sender)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MailTokenizer.ReadUselessWords(dialog.FileName);
            }
        }

        private void buttonLoadUseless_Click(object sender, EventArgs e)
        {
            ReadUselessWordsFile(sender);
        }

        private void buttonShowUseless_Click(object sender, EventArgs e)
        {
            //todo: show data in new dialog
            var uselessWords = MailTokenizer.UselessWords;
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
            MailTokenizer.ClearUselessWords();
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
            if (richTextBoxEmail.Text.Length > 0)
            {
                labelClassificationResult.Text = "processing...";
            }
            labelClassificationResult.Text = "NA";
        }
    }
}
