using System.Collections.Generic;
using MarsRoverExpedition.modules.expedition.models.DTO;

namespace MarsRoverExpedition.modules.common.Helper
{
    public class ExpeditionHelper
    {
        /// <summary>
        /// 根据坐标轴生成 Id
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string GenerateId(string x, string y)
        {
            return $"{x}-{y}";
        }
        
        /// <summary>
        /// 查找前面的格子
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static AreaUnit FindAheadUnit(AreaUnit location, int direction, Area area)
        {
            return null;
        }

        /// <summary>
        /// 查找后面的格子
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static AreaUnit FindBackUnit(AreaUnit location, int direction, Area area)
        {
            return null;
        }
        
        /// <summary>
        /// 查找周围的格子
        /// </summary>
        /// <param name="location"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static List<AreaUnit> FindAround(AreaUnit location, Area area)
        {
            return null;
        }

        public static AreaUnit FindLatStep(Area area)
        {
            return null;
        }

        public static float FindExplorePercentage(Area area)
        {
            return 0;
        }
    }
}