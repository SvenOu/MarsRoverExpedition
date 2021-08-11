using MarsRoverExpedition.modules.common.Model;
using MarsRoverExpedition.modules.expedition.models.DTO;
using MarsRoverExpedition.modules.expedition.models.Param;

namespace MarsRoverExpedition.modules.expedition.services
{
    public interface IExpeditionService
    {
        CommonResponse<TestDTO> getDataFromTestService(TestParam param);
    }
}