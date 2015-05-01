using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniSVM.TokenizerNms;
using System.IO;

namespace MiniSVM.SpamClassifier
{
    public partial class SpamClassifier : Form
    {
        private TokenizerNms.Tokenizer tokenizer = null;
        public List<string> Spam { get; set; }
        public List<string> Ham { get; set; }
        public Dictionary<string, int[]> trainingSet;

        public SpamClassifier()
        {
            InitializeComponent();
            tokenizer = new TokenizerNms.Tokenizer();
            trainingSet = new Dictionary<string,int[]>();
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
                ProcessMails(1);
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
                ProcessMails(0);
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

        private void UpdateTrainingSet(string word, int type) //type: 0 - ham, 1 - spam
        {
            if (trainingSet != null && word != null)
            {
                if (trainingSet.ContainsKey(word.ToLower()))
                {
                    var vecValue = trainingSet[word];
                    ++vecValue[type];
                    trainingSet[word] = vecValue;
                }
                else //new word
                {
                    var vecValue = new int[2];
                    vecValue[type] = 1;
                    trainingSet.Add(word.ToLower(), vecValue);
                }
            }
        }

        

        private void ProcessMails(int type) //type: 0 - ham, 1 - spam
        {
            var mails = (type == 1) ? Spam : Ham;
            foreach (var mail in mails)
            {
                //tokenization
                var cleanedMail = tokenizer.removeHTML(mail);
                var tokenizedMail = tokenizer.tokenizeString(cleanedMail);

                //update training matrix
                foreach (var word in tokenizedMail)
                {
                    UpdateTrainingSet(word, type);
                } 
            }

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
                //MessageBox.Show(dialog.ToString());
                //dialog.FileName
                tokenizer.readUselessWords(dialog.FileName);
            }
        }

        private void buttonLoadUseless_Click(object sender, EventArgs e)
        {
            //tokenizer.readUselessWords()
            ReadUselessWordsFile(sender);
        }

        private void buttonShowUseless_Click(object sender, EventArgs e)
        {
            var uselessWords = tokenizer.getUselessWords();
            var wordsList = "";
            foreach(var word in uselessWords) {
                wordsList += word + '\n';
            }
            MessageBox.Show(wordsList);
        }

        private void buttonClearUseless_Click(object sender, EventArgs e)
        {
            tokenizer.clearUselessWords();
        }
    }
}
