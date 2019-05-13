using Xunit;
using CBArule;
using Moq;
using Microsoft.Extensions.Options;
using System;

namespace CBARuleUnitTest
{

    public class Rule4Test : IDisposable
    {
        public IRule rule4;
        //Constructor is a bit like testfixture
        public Rule4Test()
        {
            Rule4Config config = new Rule4Config();
            config.SearchStr1 = "cC";
            config.SearchStr2 = "aA";
            var rule4Config = new Mock<IOptionsMonitor<Rule4Config>>();
            rule4Config.Setup(r => r.CurrentValue).Returns(config);
            var filePathConfig = new Mock<IOptionsMonitor<FilePathConfig>>();
            rule4 = new Rule4(rule4Config.Object, filePathConfig.Object);

        }


        [Fact]
        public void Rule4TestNumberOfCASequence()
        {
            string testData = "cccc aaaa bbbb ccc abaa dddd cccc ";
            var output = rule4.Excecute(testData);
            Assert.Equal("2", output);
        }

        public void Dispose()
        {
            //require IRule to implement IDispose
        }

    }
}
