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
using MiniSVM.Classifier;
using LibSVMPort;

namespace MiniSVM.SpamClassifier
{
    public partial class SpamClassifier : Form
    {
        private MailTokenizer Tokenizer {get; set;}
        public Dictionary<string, Dictionary<MailType, int>> TrainingWordCounts { get; set; }
        public List<Dictionary<string, int>> RawTrainingSet { get; set; }
        public List<MailType> RawTrainingLabels { get; set; }
        public IClassifier<DoubleSparseVector> Classifier { get; set; }
        public IHypothesis<DoubleSparseVector> CurrentHypothesis { get; set; }
        public HashSet<string> SelectedFeatures { get; set; }
        public SpamClassifier()
        {
            InitializeComponent();
            Tokenizer = new MailTokenizer();
            SelectedFeatures = new HashSet<string>();
            ClearSet();
            comboBoxKernelType.SelectedIndex = 0;
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

        private void ReadSpamCompleted(object sender, ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkCompletedArgs eventArgs)
        {
            UpdateGridViews();
        }

        private void buttonLoadHam_Click(object sender, EventArgs e)
        {
            ReadDirectory(MailType.Ham, ReadHamCompleted);
        }

        private void ReadHamCompleted(object sender, ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkCompletedArgs eventArgs)
        {
            UpdateGridViews();
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
            dataGridViewHam.Rows.Clear();
            dataGridViewSpam.Rows.Clear();
        }
        
        private void UpdateGridViews()
        {
            var hamRows = new List<object[]>();
            var spamRows = new List<object[]>();
            dataGridViewHam.Rows.Clear();
            dataGridViewSpam.Rows.Clear();

            foreach (KeyValuePair<string, Dictionary<MailType, int>> entry in TrainingWordCounts)
            {
                var value = entry.Value;
                var key = entry.Key;
                hamRows.Add(new object[] { key, value[MailType.Ham]});
                spamRows.Add(new object[] { key, value[MailType.Spam]});
            }

            spamRows = spamRows.OrderByDescending(o => o[1]).ToList();
            hamRows = hamRows.OrderByDescending(o => o[1]).ToList();

            var spamGridRows = spamRows.ToArray<object[]>();
            var hamGridRows = hamRows.ToArray<object[]>();

            foreach (object[] row in spamGridRows)
            {
                dataGridViewSpam.Rows.Add(row);
            }

            foreach (object[] row in hamGridRows)
            {
                dataGridViewHam.Rows.Add(row);
            }
            MessageBox.Show(this, TrainingWordCounts.Count.ToString() + " different words found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            RawTrainingSet.Add(trainingSetItem);
            RawTrainingLabels.Add(type);
        }

        private void ReadDirectory(MailType type, ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkCompleted completedHandler)
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
            ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkerEventArgs args)
        {
            ReadDirectoryFiles(args.Argument.Directory, args.Argument.Type, args);
        }

        private void ReadDirectoryFiles(string workingDirectory, MailType mailType,
            ProgressWorker<ProgessWorkerArgument, object>.ProgressWorkerEventArgs args)
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
            if (CurrentHypothesis == null)
            {
                MessageBox.Show("No classifier learned yet!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var tokenizedMail = Tokenizer.TokenizeString(richTextBoxEmail.Text);
            var features = TokenizedMailToFeatures(tokenizedMail);
            var result = CurrentHypothesis.Predict(features) > 0 ? MailType.Ham : MailType.Spam;
            labelClassificationResult.Text = result.ToString();
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
            foreach (var word in SelectedFeatures)
            {
                result[j++] = (wordCounts.ContainsKey(word)) ? wordCounts[word] : 0;
            }
            return result;
        }

        private void buttonAddFromSelection_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewHam.SelectedRows)
            {
                SelectedFeatures.Add(row.Cells[0].Value.ToString());
            }
            foreach (DataGridViewRow row in dataGridViewSpam.SelectedRows)
            {
                SelectedFeatures.Add(row.Cells[0].Value.ToString());
            }
            UpdateSelectedFeaturesCount();
        }

        private void UpdateSelectedFeaturesCount()
        {
            if (SelectedFeatures.Count != 0)
            {
                labelSelectedFeaturesCount.Text = SelectedFeatures.Count.ToString();
            }
            else labelSelectedFeaturesCount.Text = "NA";
        }

        private void buttonClearFeatures_Click(object sender, EventArgs e)
        {
            SelectedFeatures.Clear();
            UpdateSelectedFeaturesCount();
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            new ProgressWorker<object, object>(Train, null, TrainCompleted, null, false, true).ShowDialog(this);
        }

        public void Train(object sender, ProgressWorker<object, object>.ProgressWorkerEventArgs arg)
        {
            DoubleSparseVector[] trainingData;
            double[] trainingLabels;
            arg.ChangeProgressInfo("Preparing learning data...");
            GetTrainingData(out trainingData, out trainingLabels);
            arg.ChangeProgressInfo("Training SVM...");
            Classifier = CreateClassifier();
            arg.Result = Classifier.Compute(trainingData, trainingLabels);
        }

        public void TrainCompleted(object sender, ProgressWorker<object, object>.ProgressWorkCompletedArgs result)
        {
            if (!(result.Result as bool? ?? false))
                MessageBox.Show(this, "Training model failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                CurrentHypothesis = Classifier.GetHypothesis();
                MessageBox.Show(this, "Training model finished", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private IClassifier<DoubleSparseVector> CreateClassifier()
        {
            return new LibSVM<DoubleSparseVector>()
            {
                SVMParameters = CreateParameters()
            };
        }

        private void GetTrainingData(out DoubleSparseVector[] trainingData, out double[] trainingLabels)
        {
            trainingData = new DoubleSparseVector[RawTrainingSet.Count];
            trainingLabels = new double[RawTrainingLabels.Count];
            for (int i = 0; i < RawTrainingSet.Count; i++)
            {
                trainingData[i] = new DoubleSparseVector();
                int j = 0;
                foreach (var word in SelectedFeatures)
                {
                    trainingData[i][j++] = (RawTrainingSet[i].ContainsKey(word)) ? RawTrainingSet[i][word] : 0;
                }
                trainingLabels[i] = (int)RawTrainingLabels[i];
            }
        }

        private void comboBoxKernelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericGamma.Enabled = comboBoxKernelType.SelectedIndex != 0;
        }

        private SVMParams<DoubleSparseVector> CreateParameters()
        {
            double gamma = 0, cost = 0;
            double.TryParse(numericGamma.Text, out gamma);
            double.TryParse(numericCost.Text, out cost);
            return new SVMParams<DoubleSparseVector>()
            {
                Cost = cost,
                Gamma = gamma,
                Kernel = DoubleSparseVector.Multiply
            };
        }

        private void buttonAutoselectFeatures_Click(object sender, EventArgs e)
        {
            int spamTh = 0, hamTh = 0;
            int.TryParse(numericHamFeatures.Text, out hamTh);
            int.TryParse(numericSpamFeatures.Text, out spamTh);
            foreach (var item in TrainingWordCounts)
            {
                if (item.Value[MailType.Ham] > hamTh)
                    SelectedFeatures.Add(item.Key);
                if (item.Value[MailType.Spam] > spamTh)
                    SelectedFeatures.Add(item.Key);
                UpdateSelectedFeaturesCount();
            }
        }
    }
}
