using MarsRoverExpedition.modules.common.Model;
using MarsRoverExpedition.modules.expedition.models.Param;

namespace MarsRoverExpedition.modules.expedition.services
{
    public interface IExpeditionService
    {
        /// <summary>
        /// 执行火星车命令
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CommonResponse<object> ExcutingAnOrder(ExcutingAnOrderParam param);

        CommonResponse<object> ExcutingAnOrderAndReturnUnits(ExcutingAnOrderParam param);
    }
}