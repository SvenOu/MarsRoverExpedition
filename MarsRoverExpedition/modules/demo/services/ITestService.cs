using MarsRoverExpedition.modules.common.Model;
using MarsRoverExpedition.modules.demo.models.DTO;
using MarsRoverExpedition.modules.demo.models.Param;

namespace MarsRoverExpedition.modules.demo.services
{
    public interface ITestService
    {
        CommonResponse<TestDTO> getDataFromTestService(TestParam param);
    }
}