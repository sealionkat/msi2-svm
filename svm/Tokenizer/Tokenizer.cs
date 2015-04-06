using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;

namespace MiniSVM.Tokenizer
{
    public class Tokenizer
    {
        private List<string> uselessWords = null;

        public Tokenizer() //constructor
        {
            var uselessWordsFile = ConfigurationManager.AppSettings["uselessWordsFile"];
            
        }

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

        public string[] tokenizeString(string text)
        {
            string processingString = text.ToLower();
            return null;
        }


    }
}
