using Xunit;
using CBArule;
using Moq;
using Microsoft.Extensions.Options;
using System;

namespace CBARuleUnitTest
{

    public class Rule2Test : IDisposable
    {
        public IRule rule2;
        //Constructor is a bit like testfixture
        public Rule2Test()
        {
            Rule2Config config = new Rule2Config();
            config.SearchStr1 = "bB";
            config.SearchStr2 = "eE";
            var rule2Config = new Mock<IOptionsMonitor<Rule2Config>>();
            rule2Config.Setup(r => r.CurrentValue).Returns(config);
            var filePathConfig = new Mock<IOptionsMonitor<FilePathConfig>>();
            rule2 = new Rule2(rule2Config.Object, filePathConfig.Object);

        }


        [Fact]
        public void Rule2TestTotalOfEStartingWithB()
        {
            string testData = "beeee aba cbee abcde bcdefe";
            var output = rule2.Excecute(testData);
            Assert.Equal("6", output);
        }

        public void Dispose()
        {
            //require IRule to implement IDispose
        }

    }
}
