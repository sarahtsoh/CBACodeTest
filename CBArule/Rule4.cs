using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    public class Rule4 : IRule
    {
        List<char> _cSearchList = null;
        List<char> _aSearchList = null;
        Rule4Config _rule4Config;
        FilePathConfig _filePathConfig;

        //public Rule4(string cSearchStr, string aSearchStr)
        //{
        //    _cSearchList = Helper.GetList(null, string.IsNullOrEmpty(cSearchStr) ? "cC" : cSearchStr);
        //    _aSearchList = Helper.GetList(null, string.IsNullOrEmpty(aSearchStr) ? "aA" : aSearchStr);
        //}


        public Rule4(IOptionsMonitor<Rule4Config> rule4Config, IOptionsMonitor<FilePathConfig> filePathConfig)//change later
        {
            
            _rule4Config = rule4Config.CurrentValue;
            _cSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule4Config.SearchStr1) ? "cC" : _rule4Config.SearchStr1);
            _aSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule4Config.SearchStr2) ? "aA" : _rule4Config.SearchStr2);
            _filePathConfig = filePathConfig.CurrentValue;
        }


        public string Excecute(string str)
        {

            var wordList = new List<string>();
            var words = str.Split();

            int sequence = 0;

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (_cSearchList.Any(c => words[i].StartsWith(c)) &&
                     _aSearchList.Any(a => words[i + 1].StartsWith(a)))
                    sequence++;
            }

            return sequence.ToString();
        }

        public void WriteOutput(string str)
        {
            //System.IO.File.WriteAllText(@"count_of_sequence_of_words_starting_withs_c_and_a.txt", str);
            Helper.WriteToFile(_filePathConfig.FilePath, _rule4Config.FileName, str);

        }

        public bool IsRuleIncluded()
        {
            if (_rule4Config.IsRuleIncluded)
                return true;
            else
                return false;
        }

        public bool IsStopOnThisRule()
        {
            if (_rule4Config.IsStopOnThisRule)
                return true;
            else
                return false;

        }
    }
}
