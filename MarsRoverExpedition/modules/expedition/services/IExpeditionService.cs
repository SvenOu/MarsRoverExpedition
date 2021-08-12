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

        /// <summary>
        /// 执行火星车命令并返回轨迹
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        CommonResponse<object> ExcutingAnOrderAndReturnUnits(ExcutingAnOrderParam param);
    }
}