using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    public class Rule1Config
    {
        //public string RuleName { get; set; }
        public string SearchStr1 { get; set; }
        public string SearchStr2 { get; set; }
        public bool IsRuleIncluded { get; set; }
        public bool IsStopOnThisRule { get; set; }
        public string FileName { get; set; }
    }

    public class Rule2Config
    {
        //public string RuleName { get; set; }
        public string SearchStr1 { get; set; }
        public string SearchStr2 { get; set; }
        public bool IsRuleIncluded { get; set; }
        public bool IsStopOnThisRule { get; set; }
        public string FileName { get; set; }
    }

    public class Rule3Config
    {
        //public string RuleName { get; set; }
        public string SearchStr1 { get; set; }
        public string SearchStr2 { get; set; }
        public bool IsRuleIncluded { get; set; }
        public bool IsStopOnThisRule { get; set; }
        public string FileName { get; set; }
    }

    public class Rule4Config
    {
        //public string RuleName { get; set; }
        public string SearchStr1 { get; set; }
        public string SearchStr2 { get; set; }
        public bool IsRuleIncluded { get; set; }
        public bool IsStopOnThisRule { get; set; }
        public string FileName { get; set; }
    }


    public class RulesConfig
    {
        public Rule1 rule1 { get; set; }
        public Rule2 rule2 { get; set; }
        public Rule3 rule3 { get; set; }
        public Rule4 rule4 { get; set; }
    }


    public class FilePathConfig
    {
        public string FilePath { get; set; }
    }
}



