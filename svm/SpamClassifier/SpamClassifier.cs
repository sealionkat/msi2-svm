﻿using System;
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

        public SpamClassifier()
        {
            InitializeComponent();
            tokenizer = new TokenizerNms.Tokenizer();
        }

        private void buttonLoadSpam_Click(object sender, EventArgs e)
        {
            ReadDirectory(ReadSpamCompleted);
        }

        private void ReadSpamCompleted(object sender, ProgressWorker<string, List<string>>.ProgressWorkCompletedArgs<List<string>> eventArgs)
        {
            var result = eventArgs.Result;
            if (result!=null)
                Spam = result;
        }

        private void buttonLoadHam_Click(object sender, EventArgs e)
        {
            ReadDirectory(ReadHamCompleted);
        }

        private void ReadHamCompleted(object sender, ProgressWorker<string, List<string>>.ProgressWorkCompletedArgs<List<string>> eventArgs)
        {
            var result = eventArgs.Result;
            if (result != null)
                Ham = result;
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
    }
}
