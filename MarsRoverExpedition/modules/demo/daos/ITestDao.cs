using MarsRoverExpedition.modules.demo.models.DTO;
using MarsRoverExpedition.modules.demo.models.Param;

namespace MarsRoverExpedition.modules.demo.daos
{
    public interface ITestDao
    {
        TestDTO getDataFromTestDao(TestParam testParam);
    }
}