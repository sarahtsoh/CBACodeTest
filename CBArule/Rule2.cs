using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    public class Rule2 : IRule
    {
        List<char> _bSearchList = null;
        List<char> _eSearchList = null;
        Rule2Config _rule2Config;
        FilePathConfig _filePathConfig;

        //public Rule2( string bSearchStr, string eSearchStr)
        //{
        //    _bSearchList = Helper.GetList(null, string.IsNullOrEmpty(bSearchStr) ? "bB" : bSearchStr);
        //    _eSearchList = Helper.GetList(null, string.IsNullOrEmpty(bSearchStr) ? "eE" : eSearchStr);
        //}

        public Rule2(IOptions<Rule2Config> rule2Config,IOptions<FilePathConfig> filePathConfig)//change later
        {
           
            _rule2Config = rule2Config.Value;
            _bSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule2Config.SearchStr1) ? "bB" : _rule2Config.SearchStr1);
            _eSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule2Config.SearchStr2) ? "eE" : _rule2Config.SearchStr2);
            _filePathConfig = filePathConfig.Value;
        }


        public string Excecute(string str)
        {
            var wordList = new List<string>();
            var words = str.Split();

            wordList = words.Where(w => _bSearchList.Any(s => w.StartsWith(s))).ToList();

            var totalNumberOfChar = 0;
            foreach (var word in wordList)
            {
                totalNumberOfChar += word.Where(c => _eSearchList.Contains(c)).Count();
            }

            return totalNumberOfChar.ToString();

        }

        public void WriteOutput(string str)
        {
            //System.IO.File.WriteAllText(@"C:\count_of_e_in_words_starting_with_b.txt", str);
            Helper.WriteToFile(_filePathConfig.FilePath, _rule2Config.FileName, str);

        }

        public bool IsRuleIncluded()
        {
            if (_rule2Config.IsRuleIncluded)
                return true;
            else
                return false;
        }

        public bool IsStopOnThisRule()
        {
            if (_rule2Config.IsStopOnThisRule)
                return true;
            else
                return false;

        }
    }
}
