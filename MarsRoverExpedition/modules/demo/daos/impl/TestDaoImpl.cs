using MarsRoverExpedition.modules.demo.models.DTO;
using MarsRoverExpedition.modules.demo.models.Param;

namespace MarsRoverExpedition.modules.demo.daos.impl
{
    public class TestDaoImpl:ITestDao
    {
        public TestDTO getDataFromTestDao(TestParam testParam)
        {
            var testDto = new TestDTO();
            testDto.text = "data from TestDaoImpl";
            return testDto;
        }
    }
}