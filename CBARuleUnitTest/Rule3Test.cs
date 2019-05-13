using Xunit;
using CBArule;
using Moq;
using Microsoft.Extensions.Options;
using System;

namespace CBARuleUnitTest
{

    public class Rule3Test : IDisposable
    {
        public IRule rule3;
        //Constructor is a bit like testfixture
        public Rule3Test()
        {
            Rule3Config config = new Rule3Config();
            config.SearchStr1 = "abc";
            var rule3Config = new Mock<IOptionsMonitor<Rule3Config>>();
            rule3Config.Setup(r => r.CurrentValue).Returns(config);
            var filePathConfig = new Mock<IOptionsMonitor<FilePathConfig>>();
            rule3 = new Rule3(rule3Config.Object, filePathConfig.Object);

        }


        [Fact]
        public void Rule3TestLongestStringStartingWithABC()
        {
            string testData = "abcerere aererervegegeg cbee abcde bcdefe";
            var output = rule3.Excecute(testData);
            Assert.Equal("aererervegegeg", output);
        }

        public void Dispose()
        {
            //require IRule to implement IDispose
        }

    }
}
