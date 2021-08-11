using MarsRoverExpedition.modules.common.Model;
using MarsRoverExpedition.modules.demo.daos;
using MarsRoverExpedition.modules.demo.daos.impl;
using MarsRoverExpedition.modules.demo.models.DTO;
using MarsRoverExpedition.modules.demo.models.Param;

namespace MarsRoverExpedition.modules.demo.services.impl
{
   
    public class TestServiceImpl: ITestService
    {
        private readonly ITestDao _testDao;
 

        public TestServiceImpl()
        {
            _testDao = new TestDaoImpl();
        }
        
        public  CommonResponse<TestDTO>  getDataFromTestService(TestParam testParam)
        {
            return CommonResponse<TestDTO>.Success(_testDao.getDataFromTestDao(testParam));
        }
    }
}