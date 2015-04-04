using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniSVM.Tokenizer
{
    public class Tokenizer
    {
        private string[] uselessWords = null;

        public void readUselessWords(string filename)
        {
            var readedTxt = File.OpenText(filename);
        }

        public string[] tokenizeString(string filename)
        {
            return null;
        }


    }
}
