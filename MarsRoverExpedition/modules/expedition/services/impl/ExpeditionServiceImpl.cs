using MarsRoverExpedition.modules.common.Model;
using MarsRoverExpedition.modules.expedition.daos;
using MarsRoverExpedition.modules.expedition.daos.impl;
using MarsRoverExpedition.modules.expedition.models.DTO;
using MarsRoverExpedition.modules.expedition.models.Param;

namespace MarsRoverExpedition.modules.expedition.services.impl
{
   
    public class ExpeditionServiceImpl: IExpeditionService
    {
        private readonly IExpeditionDao _expeditionDao;
 

        public ExpeditionServiceImpl()
        {
            _expeditionDao = new ExpeditionDaoImpl();
        }
        
        public  CommonResponse<TestDTO>  getDataFromTestService(TestParam testParam)
        {
            return CommonResponse<TestDTO>.Success(_expeditionDao.getDataFromTestDao(testParam));
        }
    }
}