using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    public class Rule1 : IRule
    {
        List<char> _aSearchList = null;
        Rule1Config _rule1Config;
        FilePathConfig _filePathConfig;
        IOptionsMonitor<Rule1Config> _rule1ConfigUpdate;
        IOptionsMonitor<FilePathConfig> _filePathConfigUpdate;

        public Rule1(IOptionsMonitor<Rule1Config> rule1Config, IOptionsMonitor<FilePathConfig> filePathConfig)//change later
        {
            _rule1Config = rule1Config.CurrentValue;
            _aSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule1Config.SearchStr1) ? "aA" : _rule1Config.SearchStr1);
            _filePathConfig = filePathConfig.CurrentValue;
            _rule1ConfigUpdate = rule1Config;
            _filePathConfigUpdate = filePathConfig;
        }

        public void UpdateConfig()
        {
            _rule1ConfigUpdate.OnChange(x => _rule1Config = x);
            _filePathConfigUpdate.OnChange(x => _filePathConfig = x);
        }

        public string Excecute(string str)
        {
            var wordList = new List<string>();
            var words = str.Split();

           var averageLength = words.Where(w => _aSearchList.Any(s => w.StartsWith(s))).Average(s=>s.Length);

            return averageLength.ToString();
        }

       

        public void WriteOutput(string str)
        {
            Helper.WriteToFile(_filePathConfig.FilePath, _rule1Config.FileName, str);

        }

        public bool IsRuleIncluded()
        {
            if (_rule1Config.IsRuleIncluded)
                return true;
            else
                return false;
        }

        public bool IsStopOnThisRule()
        {
            if (_rule1Config.IsStopOnThisRule)
                return true;
            else
                return false;

        }

    }
}
