﻿using Microsoft.Extensions.Options;
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
        IOptionsMonitor<Rule2Config> _rule2ConfigUpdate;
        IOptionsMonitor<FilePathConfig> _filePathConfigUpdate;

        public Rule2(IOptionsMonitor<Rule2Config> rule2Config, IOptionsMonitor<FilePathConfig> filePathConfig)//change later
        {
           
            _rule2Config = rule2Config.CurrentValue;
            _bSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule2Config.SearchStr1) ? "bB" : _rule2Config.SearchStr1);
            _eSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule2Config.SearchStr2) ? "eE" : _rule2Config.SearchStr2);
            _filePathConfig = filePathConfig.CurrentValue;
            _rule2ConfigUpdate = rule2Config;
            _filePathConfigUpdate = filePathConfig;
        }

        public void UpdateConfig()
        {
            _rule2ConfigUpdate.OnChange(x => _rule2Config = x);
            _filePathConfigUpdate.OnChange(x => _filePathConfig = x);
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
