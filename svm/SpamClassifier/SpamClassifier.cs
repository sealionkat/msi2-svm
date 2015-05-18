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

        public SpamClassifierModel Model { get; set; }

        public SpamClassifier()
        {
            InitializeComponent();
            Model = new SpamClassifierModel();
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

        private void ClearSet()
        {
            Model.ClearSet();
            dataGridViewHam.Rows.Clear();
            dataGridViewSpam.Rows.Clear();
        }

        private void UpdateGridViews()
        {
            var hamRows = new List<object[]>();
            var spamRows = new List<object[]>();
            dataGridViewHam.Rows.Clear();
            dataGridViewSpam.Rows.Clear();

            foreach (KeyValuePair<string, Dictionary<MailType, int>> entry in Model.TrainingWordCounts)
            {
                var value = entry.Value;
                var key = entry.Key;
                hamRows.Add(new object[] { key, value[MailType.Ham] });
                spamRows.Add(new object[] { key, value[MailType.Spam] });
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
            MessageBox.Show(this, Model.TrainingWordCounts.Count.ToString() + " different words found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                new ProgressWorker<ProgessWorkerArgument, object>((snd, args) =>
                    {
                        Model.ReadDirectoryContent(args.Argument.Directory,
                            type, checkBoxRecursive.Checked,
                            (snd2, args2) =>
                            {
                                args.ReportProgress(args2.Progress);
                            }, (snd2, args2) =>
                            {
                                args.ChangeProgressInfo("Processing directory: " + args2.CurrentDirectory);
                            });
                    }, argument, completedHandler, "Reading set", true, true).ShowDialog(this);
            }
        }

        private void buttonLoadUseless_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                Model.ReadUselessWords(dialog.FileName);
            }
        }

        private void buttonShowUseless_Click(object sender, EventArgs e)
        {
            //todo: show data in new dialog
            var uselessWords = Model.UselessWords;
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
            Model.ClearUselessWords();
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
            if (Model.CurrentHypothesis == null)
            {
                MessageBox.Show("No classifier learned yet!", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            labelClassificationResult.Text = Model.Predict(richTextBoxEmail.Text).ToString();
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

        private void buttonAddFromSelection_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewHam.SelectedRows)
            {
                Model.AddSelectedFeature(row.Cells[0].Value.ToString());
            }
            foreach (DataGridViewRow row in dataGridViewSpam.SelectedRows)
            {
                Model.AddSelectedFeature(row.Cells[0].Value.ToString());
            }
            UpdateSelectedFeaturesCount();
        }

        private void UpdateSelectedFeaturesCount()
        {
            if (Model.SelectedFeaturesCount != 0)
            {
                labelSelectedFeaturesCount.Text = Model.SelectedFeaturesCount.ToString();
            }
            else labelSelectedFeaturesCount.Text = "NA";
        }

        private void buttonClearFeatures_Click(object sender, EventArgs e)
        {
            Model.ClearSelectedFeatures();
            UpdateSelectedFeaturesCount();
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (Model.TrainingWordCounts.Count == 0)
            {
                MessageBox.Show(this, "No set loaded yet!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Model.SelectedFeaturesCount == 0)
            {
                MessageBox.Show(this, "No features selected!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            double gamma = 0, cost = 0;
            double.TryParse(numericGamma.Text, out gamma);
            double.TryParse(numericCost.Text, out cost);
            KernelType type = KernelType.Linear;
            if (comboBoxKernelType.SelectedIndex == 1)
            {
                type = KernelType.Gaussian;
            }
            new ProgressWorker<object, object>(Train, new object[]
                {
                    type,
                    gamma,
                    cost
                }, TrainCompleted, null, false, true).ShowDialog(this);
        }

        public void Train(object sender, ProgressWorker<object, object>.ProgressWorkerEventArgs arg)
        {
            double gamma, cost;
            KernelType type;
            type = (KernelType)(arg.Argument as object[])[0];
            gamma = (double)(arg.Argument as object[])[1];
            cost = (double)(arg.Argument as object[])[2];
            arg.Result = Model.Train(type, gamma, cost, (s) =>
                {
                    switch (s)
                    {
                        case TrainingStep.PreparingSet:
                            arg.ChangeProgressInfo("Preparing set...");
                            break;
                        case TrainingStep.TrainingClassifier:
                            arg.ChangeProgressInfo("Training SVM...");
                            break;
                    }
                });
        }

        public void TrainCompleted(object sender, ProgressWorker<object, object>.ProgressWorkCompletedArgs result)
        {
            if (!(result.Result as bool? ?? false))
                MessageBox.Show(this, "Training Model failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show(this, "Training Model finished", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void comboBoxKernelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericGamma.Enabled = comboBoxKernelType.SelectedIndex != 0;
        }

        private void buttonAutoselectFeatures_Click(object sender, EventArgs e)
        {
            int spamTh = 0, hamTh = 0;
            int.TryParse(numericHamFeatures.Text, out hamTh);
            int.TryParse(numericSpamFeatures.Text, out spamTh);
            Model.AutoSelectFeatures(spamTh, hamTh);
            UpdateSelectedFeaturesCount();
        }
    }
}
