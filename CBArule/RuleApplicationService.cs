using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    public class RulesApplicationService: IRulesApplicationService
    {
        IEnumerable<IRule> _ruleList = null;

        public RulesApplicationService(IEnumerable<IRule> ruleList)//IOption)
        {
            
           _ruleList = ruleList;

        }


        public void ExecuteRules(string str)
        {
            var rules = _ruleList.Where(c => c.IsRuleIncluded());
            foreach (var rule in rules)
            {
                var result = rule.Excecute(str);
                rule.WriteOutput(result);
                if (rule.IsStopOnThisRule())
                    break;
            }


        }

    }
}
