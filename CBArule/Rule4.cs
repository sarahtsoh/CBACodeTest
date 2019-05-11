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
        IOptionsMonitor<Rule4Config> _rule4ConfigUpdate;
        IOptionsMonitor<FilePathConfig> _filePathConfigUpdate;

        public Rule4(IOptionsMonitor<Rule4Config> rule4Config, IOptionsMonitor<FilePathConfig> filePathConfig)//change later
        {
            _rule4Config = rule4Config.CurrentValue;
            _cSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule4Config.SearchStr1) ? "cC" : _rule4Config.SearchStr1);
            _aSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule4Config.SearchStr2) ? "aA" : _rule4Config.SearchStr2);
            _filePathConfig = filePathConfig.CurrentValue;
            _rule4ConfigUpdate = rule4Config;
            _filePathConfigUpdate = filePathConfig;
        }

        public void UpdateConfig()
        {
            _rule4ConfigUpdate.OnChange(x => _rule4Config = x);
            _filePathConfigUpdate.OnChange(x => _filePathConfig = x);
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
