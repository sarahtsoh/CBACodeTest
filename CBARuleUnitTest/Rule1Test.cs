using Xunit;
using CBArule;
using Moq;
using Microsoft.Extensions.Options;
using System;

namespace CBARuleUnitTest
{

    public class Rule1Test : IDisposable
    {
        public IRule rule1;
        //Constructor is a bit like testfixture
        public Rule1Test()
        {
            Rule1Config config = new Rule1Config();
            config.SearchStr1 = "aA";
            var rule1Config = new Mock<IOptionsMonitor<Rule1Config>>();
            rule1Config.Setup(r => r.CurrentValue).Returns(config);
            var filePathConfig = new Mock<IOptionsMonitor<FilePathConfig>>();
            rule1 = new Rule1(rule1Config.Object, filePathConfig.Object);

        }

              
        [Fact]
        public void Rule1TestAverage()
        {
            string testData = "aaa aba cbaaa abcde abcdefg";
            var output = rule1.Excecute(testData);
            Assert.Equal("4", output);
        }

        public void Dispose()                          
        {
           //require IRule to implement IDispose
        }

    }
}
