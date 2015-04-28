using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MiniSVM.TokenizerNms
{
    public class Tokenizer
    {
        private List<string> uselessWords = null;
        private string uselessWordsFile = "";
        private string[] mailHeaders = { "Accept-Language", "Alternate-Recipient", "Archived-At", "Authentication-Results", "Auto-Submitted", "Autoforwarded", "Autosubmitted", "Bcc", "Cc", "Comments", "Content-Identifier", "Content-Return", "Conversion", "Conversion-With-Loss", "DL-Expansion-History", "Date", "Deferred-Delivery", "Delivery-Date", "Discarded-X400-IPMS-Extensions", "Discarded-X400-MTS-Extensions", "Disclose-Recipients", "Disposition-Notification-Options", "Disposition-Notification-To", "DKIM-Signature", "Downgraded-Final-Recipient", "Downgraded-In-Reply-To", "Downgraded-Message-Id", "Downgraded-Original-Recipient", "Downgraded-References", "Encoding", "Encrypted", "Expires", "Expiry-Date", "From", "Generate-Delivery-Report", "Importance", "In-Reply-To", "Incomplete-Copy", "Keywords", "Language", "Latest-Delivery-Time", "List-Archive", "List-Help", "List-ID", "List-Owner", "List-Post", "List-Subscribe", "List-Unsubscribe", "Message-Context", "Message-ID", "Message-Type", "MMHS-Exempted-Address", "MMHS-Extended-Authorisation-Info", "MMHS-Subject-Indicator-Codes", "MMHS-Handling-Instructions", "MMHS-Message-Instructions", "MMHS-Codress-Message-Indicator", "MMHS-Originator-Reference", "MMHS-Primary-Precedence", "MMHS-Copy-Precedence", "MMHS-Message-Type", "MMHS-Other-Recipients-Indicator-To", "MMHS-Other-Recipients-Indicator-CC", "MMHS-Acp127-Message-Identifier", "MMHS-Originator-PLAD", "MT-Priority", "Obsoletes", "Original-Encoded-Information-Types", "Original-From", "Original-Message-ID", "Original-Recipient", "Originator-Return-Address", "Original-Subject", "PICS-Label", "Prevent-NonDelivery-Report", "Priority", "Received", "Received-SPF", "References", "Reply-By", "Reply-To", "Require-Recipient-Valid-Since", "Resent-Bcc", "Resent-Cc", "Resent-Date", "Resent-From", "Resent-Message-ID", "Resent-Sender", "Resent-To", "Return-Path", "Sender", "Sensitivity", "Solicitation", "Subject", "Supersedes", "To", "VBR-Info", "X400-Content-Identifier", "X400-Content-Return", "X400-Content-Type", "X400-MTS-Identifier", "X400-Originator", "X400-Received", "X400-Recipients", "X400-Trace", "Base", "Content-Alternative", "Content-Base", "Content-Description", "Content-Disposition", "Content-Duration", "Content-features", "Content-ID", "Content-Language", "Content-Location", "Content-MD5", "Content-Transfer-Encoding", "Content-Type", "MIME-Version" };
        

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

        public List<string> getUselessWords()
        {
            return uselessWords;
        }

        public string removeHeaders(string mail)
        {
            
            return mail;
        }

        public string removeHTML(string mail)
        {
            var output = Regex.Replace(mail, "<STYLE>.*</STYLE>", "", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "</?TR[^>]*>", " ", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "</?TD[^>]*>", " ", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "</?BR[^>]*>", " ", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "&nbsp;", " ");
            return Regex.Replace(output, "<[^>]*>", "");
        }

        public List<string> tokenizeString(string text)
        {
            string processingString = text.Trim().ToLower().Replace(",","").Replace(".", "").Replace(";", "").Replace("(", "").Replace(")", "").Replace("\"", "").Replace("\n", " ");
            List<string> words = new List<string>(processingString.Split(new Char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries));

            if (uselessWords != null)
            {
                var i = 0;
                while (i < words.Count)
                {
                    var word = words[i];
                    var removed = false;

                    foreach (var uselessWord in uselessWords)
                    {
                        if (word.ToLower() == uselessWord.ToLower())
                        {
                            words.Remove(word);
                            removed = true;
                            break;
                        }
                    }

                    i = removed ? i : (i + 1);
                }                
            }

            return words;
        }


    }
}
