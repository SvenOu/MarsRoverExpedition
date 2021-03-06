using System.Collections.Generic;
using MarsRoverExpedition.modules.common.Helper;
using MarsRoverExpedition.modules.expedition.models.design;

namespace MarsRoverExpedition.modules.expedition.models.dto
{


    /// <summary>
    /// 迷你直升机
    /// </summary>
    public class Ingenuity:IIngenuity
    {
        /// <summary>
        /// 探索
        /// </summary>
        public void Explore(AreaUnit location, Area area)
        {
            List<AreaUnit> aroundAreas= ExpeditionHelper.FindAround(location, area);
            for (int i = 0; i < aroundAreas.Count; i++)
            {
                var curUnit = aroundAreas[i];
                curUnit.IngenuityMark = true;
            }
        }
    }
}