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

        //public Rule1(string aSearchStr)
        //{
            
        //    _aSearchList = Helper.GetList(null, string.IsNullOrEmpty(aSearchStr) ? "aA" : aSearchStr);
        //}

        public Rule1(IOptions<Rule1Config> rule1Config, IOptions<FilePathConfig> filePathConfig)//change later
        {
            _rule1Config = rule1Config.Value;
            _aSearchList = Helper.GetList(null, string.IsNullOrEmpty(_rule1Config.SearchStr1) ? "aA" : _rule1Config.SearchStr1);
            _filePathConfig = filePathConfig.Value;

        }

        public string Excecute(string str)
        {
            
            var wordList = new List<string>();
            var words = str.Split();

            wordList = words.Where(w => _aSearchList.Any(s => w.StartsWith(s))).ToList();

            var totalNumWords = wordList.Count;
            var indiviaulWordLength = 0;
            foreach (var word in wordList)
            {
                indiviaulWordLength += word.Length;
            }

            var averageLength = indiviaulWordLength / totalNumWords;

            return averageLength.ToString();
        }

       

        public void WriteOutput(string str)
        {
            //System.IO.File.WriteAllText(@"C:\average_length_of_words_starting_with_a.txt", str);
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
