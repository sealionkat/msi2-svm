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

namespace MiniSVM.SpamClassifier
{
    public partial class SpamClassifier : Form
    {
        private TokenizerNms.Tokenizer tokenizer = null;


        public SpamClassifier()
        {
            InitializeComponent();
            tokenizer = new TokenizerNms.Tokenizer();

        }
        

        private void loadDatasetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
