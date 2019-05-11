using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    public class Rule3 : IRule
    {
        List<char> _abcSearchList = null;
        Rule3Config _rule3Config;
        FilePathConfig _filePathConfig;

        //public Rule3(string abcSearchStr)
        //{
        //    _abcSearchList = Helper.GetList(null, string.IsNullOrEmpty(abcSearchStr) ? "abc" : abcSearchStr);
            
        //}

        public Rule3(IOptionsMonitor<Rule3Config> rule3Config, IOptionsMonitor<FilePathConfig> filePathConfig)//change later
        {
            _rule3Config = rule3Config.CurrentValue;
            _abcSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule3Config.SearchStr1) ? "abc" : _rule3Config.SearchStr1);
            _filePathConfig = filePathConfig.CurrentValue;

        }


        public string Excecute(string str)
        {
            var wordList = new List<string>();
            var words = str.Split();

            wordList = words.Where(w => _abcSearchList.Any(s => w.StartsWith(s))).ToList();

            var longestWord = wordList.OrderByDescending(c => c.Length).FirstOrDefault();

            return longestWord;
        }


        public void WriteOutput(string str)
        {
            //System.IO.File.WriteAllText(@"C:\longest_words_starting_with_abc.txt", str);
            Helper.WriteToFile(_filePathConfig.FilePath, _rule3Config.FileName, str);

        }


        public bool IsRuleIncluded()
        {
            if (_rule3Config.IsRuleIncluded)
                return true;
            else
                return false;
        }

        public bool IsStopOnThisRule()
        {
            if (_rule3Config.IsStopOnThisRule)
                return true;
            else
                return false;

        }
    }
}
