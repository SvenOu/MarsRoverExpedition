using MarsRoverExpedition.modules.common.Config;
using MarsRoverExpedition.modules.expedition.daos;
using MarsRoverExpedition.modules.expedition.daos.impl;
using NUnit.Framework;

namespace MarsRoverExpedition.test.expedition
{
    public class DaoTest
    {
        private IExpeditionDao _expeditionDao;
        [SetUp]
        public void Setup()
        {
            ConfigFunction.InitByFilePath("appsettings.Development.json");
            _expeditionDao = new ExpeditionDaoImpl();
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