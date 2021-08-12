using MarsRoverExpedition.modules.common.Helper;
using MarsRoverExpedition.modules.common.Model;
using MarsRoverExpedition.modules.expedition.models.DTO;
using MarsRoverExpedition.modules.expedition.models.Param;

namespace MarsRoverExpedition.modules.expedition.services.impl
{
    public class ExpeditionServiceImpl : IExpeditionService
    {
        public ExpeditionServiceImpl() {}

        public CommonResponse<object> ExcutingAnOrder(ExcutingAnOrderParam param)
        {
            if (string.IsNullOrEmpty(param.Order))
            {
                CommonResponse<object>.Fail("order is empty!");
            }
            var order= param.Order?.ToUpper();
            var area = new Area();
            var percy = new Percy()
            {
                Area = area
            };
            percy.ExcutingAnOrder(order);
            AreaUnit lastStep = ExpeditionHelper.FindLatStep(area);
            float explorePercentage  = ExpeditionHelper.FindExplorePercentage(area);
            return CommonResponse<object>.Success(new
            {
                LastStep = lastStep.X+lastStep.Y,
                ExplorePercentage = explorePercentage * 100.0f + "%" 
            });
        }
    }
}