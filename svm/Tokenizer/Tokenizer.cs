using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniSVM.Tokenizer
{
    public static class Tokenizer
    {
        private static List<string> uselessWords = null;

        public static void readUselessWords(string filename)
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

        public static string[] tokenizeString(string filename)
        {
            return null;
        }


    }
}
