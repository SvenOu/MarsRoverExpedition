using MarsRoverExpedition.modules.common.Config;
using MarsRoverExpedition.modules.expedition.services;
using MarsRoverExpedition.modules.expedition.services.impl;
using NUnit.Framework;

namespace MarsRoverExpedition.test.expedition
{
    public class ServiceTest
    {
        private IExpeditionService _expeditionService;

        [SetUp]
        public void Setup()
        {
            ConfigFunction.InitByFilePath("appsettings.Development.json");
            _expeditionService = new ExpeditionServiceImpl();
        }
        
        [TearDown]
        public void Close() {}

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}