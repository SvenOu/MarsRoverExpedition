using MarsRoverExpedition.modules.expedition.models.DTO;
using MarsRoverExpedition.modules.expedition.models.Param;

namespace MarsRoverExpedition.modules.expedition.daos.impl
{
    public class ExpeditionDaoImpl:IExpeditionDao
    {
        public TestDto getDataFromTestDao(TestParam testParam)
        {
            var testDto = new TestDto();
            testDto.text = "data from ExpeditionDaoImpl";
            return testDto;
        }
    }
}