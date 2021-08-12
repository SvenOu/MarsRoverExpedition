using System.Collections.Generic;
using MarsRoverExpedition.modules.common.Helper;

namespace MarsRoverExpedition.modules.expedition.models.DTO
{
    /// <summary>
    /// 迷你直升机
    /// </summary>
    public class Ingenuity
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