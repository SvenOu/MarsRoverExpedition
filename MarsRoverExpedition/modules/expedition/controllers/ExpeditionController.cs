using MarsRoverExpedition.modules.expedition.models.Param;
using MarsRoverExpedition.modules.expedition.services;
using MarsRoverExpedition.modules.expedition.services.impl;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverExpedition.modules.expedition.controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ExpeditionController: ControllerBase
    {
        private readonly IExpeditionService _expeditionService;

        public ExpeditionController()
        {
            _expeditionService = new ExpeditionServiceImpl();
        }


        /// <summary>
        /// just for test
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object AddTestData(TestParam param)
        {
            return _expeditionService.getDataFromTestService(param);
        }
        
    }
}