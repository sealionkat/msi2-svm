using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace MiniSVM.Tokenizer
{
    public class MailTokenizer
    {
        public HashSet<string> UselessWords { get; private set; }
        private string uselessWordsFile = "";
        private string[] mailHeaders = { "Accept-Language", "Alternate-Recipient", "Archived-At", "Authentication-Results", "Auto-Submitted", "Autoforwarded", "Autosubmitted", "Bcc", "Cc", "Comments", "Content-Identifier", "Content-Return", "Conversion", "Conversion-With-Loss", "DL-Expansion-History", "Date", "Deferred-Delivery", "Delivery-Date", "Discarded-X400-IPMS-Extensions", "Discarded-X400-MTS-Extensions", "Disclose-Recipients", "Disposition-Notification-Options", "Disposition-Notification-To", "DKIM-Signature", "Downgraded-Final-Recipient", "Downgraded-In-Reply-To", "Downgraded-Message-Id", "Downgraded-Original-Recipient", "Downgraded-References", "Encoding", "Encrypted", "Expires", "Expiry-Date", "From", "Generate-Delivery-Report", "Importance", "In-Reply-To", "Incomplete-Copy", "Keywords", "Language", "Latest-Delivery-Time", "List-Archive", "List-Help", "List-ID", "List-Owner", "List-Post", "List-Subscribe", "List-Unsubscribe", "Message-Context", "Message-ID", "Message-Type", "MMHS-Exempted-Address", "MMHS-Extended-Authorisation-Info", "MMHS-Subject-Indicator-Codes", "MMHS-Handling-Instructions", "MMHS-Message-Instructions", "MMHS-Codress-Message-Indicator", "MMHS-Originator-Reference", "MMHS-Primary-Precedence", "MMHS-Copy-Precedence", "MMHS-Message-Type", "MMHS-Other-Recipients-Indicator-To", "MMHS-Other-Recipients-Indicator-CC", "MMHS-Acp127-Message-Identifier", "MMHS-Originator-PLAD", "MT-Priority", "Obsoletes", "Original-Encoded-Information-Types", "Original-From", "Original-Message-ID", "Original-Recipient", "Originator-Return-Address", "Original-Subject", "PICS-Label", "Prevent-NonDelivery-Report", "Priority", "Received", "Received-SPF", "References", "Reply-By", "Reply-To", "Require-Recipient-Valid-Since", "Resent-Bcc", "Resent-Cc", "Resent-Date", "Resent-From", "Resent-Message-ID", "Resent-Sender", "Resent-To", "Return-Path", "Sender", "Sensitivity", "Solicitation", "Subject", "Supersedes", "To", "VBR-Info", "X400-Content-Identifier", "X400-Content-Return", "X400-Content-Type", "X400-MTS-Identifier", "X400-Originator", "X400-Received", "X400-Recipients", "X400-Trace" };
        private string[] mimeHeaders = { "Base", "Content-Alternative", "Content-Base", "Content-Description", "Content-Disposition", "Content-Duration", "Content-features", "Content-ID", "Content-Language", "Content-Location", "Content-MD5", "Content-Transfer-Encoding", "Content-Type", "MIME-Version" };
        
        public MailTokenizer() //constructor
        {
            uselessWordsFile = ConfigurationManager.AppSettings["uselessWordsFile"];
            if (uselessWordsFile != null && uselessWordsFile.Length > 0)
            {
                ReadUselessWords(uselessWordsFile);
            }
        }

        public void ReadUselessWords(string filename)
        {
            using (StreamReader txt = File.OpenText(filename))
            {
                HashSet<string> words = new HashSet<string>();
                string str = "";
                while ((str = txt.ReadLine()) != null)
                {
                    words.Add(str);
                }

                UselessWords = words;
            }
        }

        public void ClearUselessWords()
        {
            UselessWords = new HashSet<string>();
        }

        public string RemoveHeaders(string mail)
        {
            mail.Replace("\r\n", "\n");
            string lowerMail = mail.ToLower();
            string endMailPattern = "-{4}\\d+-{2}"; //i.e. ----12312987319286--

            /*
             * Assumptions:
             * mail headers are separated from subsequent part with an empty line
             * 
             * mime headers are in form of
             * ----NUMBERS
             * mime headers
             * empty line
             * 
             * then there is a subject of mail
             * ----NUMBERS--
             */

            foreach (var header in mailHeaders) //checking whether there are any mail headers
            {
                if (lowerMail.Contains(header.ToLower()))
                {
                    var emptyLine = lowerMail.IndexOf("\n\n");
                    mail = mail.Substring(emptyLine + 2);
                    lowerMail = mail.ToLower();
                    break;
                }
            }

            foreach (var header in mimeHeaders) //checking whether there are any mime headers
            {
                if (lowerMail.Contains(header.ToLower()))
                {
                    var emptyLine = lowerMail.IndexOf("\n\n");
                    mail = mail.Substring(emptyLine + 2);
                    lowerMail = mail.ToLower();
                    break;
                }
            }

            var match = Regex.Match(mail, endMailPattern);
            if (match.Success)
            {
                mail = mail.Substring(0, match.Index);
            }
            
            return mail;
        }

        public string RemoveHTML(string mail)
        {
            var output = Regex.Replace(mail, "<STYLE>.*</STYLE>", "", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "</?TR[^>]*>", " ", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "</?TD[^>]*>", " ", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "</?BR[^>]*>", " ", RegexOptions.IgnoreCase);
            output = Regex.Replace(output, "&nbsp;", " ");
            return Regex.Replace(output, "<[^>]*>", "");
        }

        public List<string> TokenizeString(string text)
        {
            string processingString = text.Trim().ToLower();
            HashSet<string> spetialNotToRemove = new HashSet<string>(new []
            {
                "$",
                "€"
            });
            var removeRegex = new Regex(
                "([\n\r])|" + // whitespaces characters
                "(\\d)|" + // digits
                "(&lt)|(&gt)|" + // <> signs
                "(\\S*[\\\\/]\\S*)|" + // paths, websites
                "(([a-zA-Z0-9.-])+@([a-zA-Z0-9.-])+)" //emails
                );
            var interpunctionRegex = new Regex(
                "('s)|" + //'s
                "('re)|('m)|" + 
                "([.,!?:;_\\(\\)\\[\\]\\{\\}\\%\\&\\#'\"\\-\\=\\+\\*])" // interpunction characters
                );
            processingString = removeRegex.Replace(processingString, " ");
            processingString = interpunctionRegex.Replace(processingString, " ");
            List<string> words = new List<string>(processingString.Split(new Char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries));
            List<string> outputWords = new List<string>();
            foreach (var word in words)
            {
                if ((UselessWords==null || !UselessWords.Contains(word)) &&
                    (word.Length > 1 || spetialNotToRemove.Contains(word)))
                {
                    outputWords.Add(word);
                }
            }

            return outputWords;
        }
    }
}
