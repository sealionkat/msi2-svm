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

        public SpamClassifier()
        {
            InitializeComponent();
            tokenizer = new TokenizerNms.Tokenizer();
        }

        private void buttonLoadSpam_Click(object sender, EventArgs e)
        {
            var result = ReadDirectory();
            if (result!=null)
                Spam = result;
        }

        private void buttonLoadHam_Click(object sender, EventArgs e)
        {
            var result = ReadDirectory();
            if (result != null)
                Ham = result;
        }

        private List<string> ReadDirectory()
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                return ReadDirectoryContent(dialog.SelectedPath);
            }
            return null;
        }

        private List<string> ReadDirectoryContent(string path)
        {
            var strings = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path))
            {
                strings.Add(File.ReadAllText(file));
            }
            return strings;
        }
    }
}
