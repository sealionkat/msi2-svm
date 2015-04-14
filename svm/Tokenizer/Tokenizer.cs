using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace MiniSVM.TokenizerNms
{
    public class Tokenizer
    {
        private List<string> uselessWords = null;
        private string uselessWordsFile = "";

        public Tokenizer() //constructor
        {
            uselessWordsFile = ConfigurationManager.AppSettings["uselessWordsFile"];
            if (uselessWordsFile != null && uselessWordsFile.Length > 0)
            {
                readUselessWords(uselessWordsFile);
            }
        }

        public void readUselessWords(string filename)
        {
            if (filename.Length > 0)
            {
                using (StreamReader txt = File.OpenText(filename))
                {
                    List<string> words = new List<string>();
                    string str = "";
                    ConfigurationManager.AppSettings["uselessWordsFile"] = filename;
                    while ((str = txt.ReadLine()) != null)
                    {
                        words.Add(str);
                    }

                    uselessWords = words;
                }
            }
        }

        public List<string> tokenizeString(string text)
        {
            string processingString = text.Trim().ToLower().Replace(",","").Replace(".", "").Replace(";", "").Replace("(", "").Replace(")", "");
            List<string> words = new List<string>(processingString.Split(new Char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries));

            if (uselessWords != null)
            {
                foreach (var word in words)
                {

                }
            }

            

            return words;
        }


    }
}
