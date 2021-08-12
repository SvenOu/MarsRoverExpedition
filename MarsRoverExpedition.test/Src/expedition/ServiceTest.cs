using System;
using MarsRoverExpedition.modules.common.Config;
using MarsRoverExpedition.modules.expedition.models.Param;
using MarsRoverExpedition.modules.expedition.services;
using MarsRoverExpedition.modules.expedition.services.impl;
using Newtonsoft.Json;
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
        public void Test_ExcutingAnOrder()
        {
            ExcutingAnOrderParam param = new ExcutingAnOrderParam()
            {
                Order = "FFFLFFRBBHFFFFF",
                LandId = "H17",
                Direction = 0
            };
            var result = _expeditionService.ExcutingAnOrder(param);
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Assert.Pass();
        }
    }
}