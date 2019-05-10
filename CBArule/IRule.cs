using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//http://www.michael-whelan.net/rules-design-pattern/
//https://edi.wang/post/2019/1/5/auto-refresh-settings-changes-in-aspnet-core-runtime
namespace CBArule
{
    public interface IRule
    {

        bool IsRuleIncluded();
        string Excecute(string str);
        void WriteOutput(string str);
        bool IsStopOnThisRule();
       
    }
}
