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

        public SpamClassifier()
        {
            InitializeComponent();
            MailTokenizer = new MailTokenizer();
            TrainingWordCounts = new Dictionary<string, Dictionary<MailType, int>>();
            RawTrainingSet = new List<Dictionary<string, int>>();
            if (ConfigurationManager.AppSettings["spamCount"] != null && ConfigurationManager.AppSettings["spamCount"].Length > 0)
            {
                labelSpamCnt.Text = ConfigurationManager.AppSettings["spamCount"];
            }
            if (ConfigurationManager.AppSettings["hamCount"] != null && ConfigurationManager.AppSettings["hamCount"].Length > 0)
            {
                labelHamCnt.Text = ConfigurationManager.AppSettings["hamCount"];
            }

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

        private void ProcessMails(MailType type)
        {
            var mails = (type == MailType.Spam) ? Spam : Ham;
            foreach (var mail in mails)
            {
                //tokenization
                var cleanedMail = MailTokenizer.removeHTML(mail);
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
            }
            labelLastUpdate.Text = DateTime.Now.ToString();
        }

        private void ReadDirectory(ProgressWorker<string, List<string>>.ProgressWorkCompleted<List<string>> completedHandler)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                new ProgressWorker<string, List<string>>(
                    ReadDirectoryContent, dialog.SelectedPath, completedHandler, "Reading set", true).ShowDialog(this);
            }
        }

        private void ReadDirectoryContent(object sender,
            ProgressWorker<string, List<string>>.ProgressWorkerEventArgs<string, List<string>> args)
        {
            var strings = new List<string>();
            var count = Directory.GetFiles(args.Argument).Length;
            int current = 0;
            foreach (string file in Directory.EnumerateFiles(args.Argument))
            {
                args.ReportProgress(current * 100 / count);
                strings.Add(File.ReadAllText(file));
                ++current;
            }
            args.Result = strings;
        }

        private void ReadUselessWordsFile(object sender)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MailTokenizer.readUselessWords(dialog.FileName);
            }
        }

        private void buttonLoadUseless_Click(object sender, EventArgs e)
        {
            ReadUselessWordsFile(sender);
        }

        private void buttonShowUseless_Click(object sender, EventArgs e)
        {
            //todo: show data in new dialog
            var uselessWords = MailTokenizer.getUselessWords();
            var wordsList = "";
            foreach(var word in uselessWords) {
                wordsList += word + '\n';
            }
            MessageBox.Show(wordsList);
        }

        private void buttonClearUseless_Click(object sender, EventArgs e)
        {
            MailTokenizer.clearUselessWords();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            //reset labels
            //reset training set
            labelSpamCnt.Text = "NA";
            labelHamCnt.Text = "NA";
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
