using MarsRoverExpedition.modules.demo.models.Param;
using MarsRoverExpedition.modules.demo.services;
using MarsRoverExpedition.modules.demo.services.impl;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverExpedition.modules.demo.controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class TestController: ControllerBase
    {
        private readonly ITestService _testService;

        public TestController()
        {
            _testService = new TestServiceImpl();
        }


        /// <summary>
        /// just for test
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object AddTestData(TestParam param)
        {
            return _testService.getDataFromTestService(param);
        }
        
    }
}