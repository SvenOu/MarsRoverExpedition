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
        /// 执行火星车命令
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object ExcutingAnOrder(ExcutingAnOrderParam param)
        {
            return _expeditionService.ExcutingAnOrder(param);
        }
        
        
        /// <summary>
        /// 执行火星车命令并返回轨迹
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public object ExcutingAnOrderAndReturnUnits(ExcutingAnOrderParam param)
        {
            return _expeditionService.ExcutingAnOrderAndReturnUnits(param);
        }
    }
}