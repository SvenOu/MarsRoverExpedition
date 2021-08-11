using MarsRoverExpedition.modules.expedition.models.DTO;
using MarsRoverExpedition.modules.expedition.models.Param;

namespace MarsRoverExpedition.modules.expedition.daos
{
    public interface IExpeditionDao
    {
        TestDTO getDataFromTestDao(TestParam testParam);
    }
}