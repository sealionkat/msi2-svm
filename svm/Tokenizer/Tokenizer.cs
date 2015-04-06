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
        private List<string> uselessWords = null;

        public void readUselessWords(string filename)
        {
            using (StreamReader txt = File.OpenText(filename))
            {
                List<string> words = new List<string>();
                string str = "";
                while((str = txt.ReadLine()) != null)
                {
                    words.Add(str);
                }

                uselessWords = words;
            }
        }

        public string[] tokenizeString(string filename)
        {
            return null;
        }


    }
}
