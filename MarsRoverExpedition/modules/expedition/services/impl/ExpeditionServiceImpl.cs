using System;
using System.Linq;
using MarsRoverExpedition.modules.common.Helper;
using MarsRoverExpedition.modules.common.Model;
using MarsRoverExpedition.modules.expedition.models.dto;
using MarsRoverExpedition.modules.expedition.models.Param;
using Newtonsoft.Json;

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
            var landId = param.LandId?.ToUpper();
            var area = new Area().Init();
            var percy = new Percy()
            {
                Area = area,
            };
            
            AreaUnit landUnit = null;
            if (string.IsNullOrEmpty(landId))
            {
                landUnit = ExpeditionHelper.RandomLocation(area);
            }
            else
            {
                landUnit = ExpeditionHelper.FindUnitById(area, landId);
            }
            percy.Land(landUnit, param.Direction);
            
            percy.ExcutingAnOrder(order);
            
            AreaUnit lastStep = ExpeditionHelper.FindPercyLastStep(area);
            float explorePercentage  = ExpeditionHelper.FindExplorePercentage(area, 0);
            return CommonResponse<object>.Success(new
            {
                LastStep = lastStep.X+lastStep.Y,
                ExplorePercentage = explorePercentage * 100.0f + "%" 
            });
        }

        public CommonResponse<object> ExcutingAnOrderAndReturnUnits(ExcutingAnOrderParam param)
        {
            if (string.IsNullOrEmpty(param.Order))
            {
                CommonResponse<object>.Fail("order is empty!");
            }
            var order= param.Order?.ToUpper();
            var landId = param.LandId?.ToUpper();
            var area = new Area().Init();
            var percy = new Percy()
            {
                Area = area,
            };
            
            AreaUnit landUnit = null;
            if (string.IsNullOrEmpty(landId))
            {
                landUnit = ExpeditionHelper.RandomLocation(area);
            }
            else
            {
                landUnit = ExpeditionHelper.FindUnitById(area, landId);
            }
            percy.Land(landUnit, param.Direction);
            
            percy.ExcutingAnOrder(order);
            
            return CommonResponse<object>.Success(new
            {
                PercyAndIngenuity = ExpeditionHelper.FindExploreUnits(area, 0).Select(p => p.Id).ToList(),
                Percy = ExpeditionHelper.FindExploreUnits(area, 1).Select(p => p.Id).ToList(),
                Ingenuity = ExpeditionHelper.FindExploreUnits(area, 2).Select(p => p.Id).ToList()
            });
        }
    }
}