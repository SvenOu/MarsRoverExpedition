using System.Collections.Generic;

namespace MarsRoverExpedition.modules.expedition.models.dto
{
    /// <summary>
    /// 场地内可探索区域
    /// </summary>
    public class AreaUnit
    {
        /// <summary>
        /// 根据坐标轴生成
        /// </summary>
        public string Id { set; get;}
        
        /// <summary>
        /// x 坐标
        /// </summary>
        public string X { set; get;}
        
        /// <summary>
        /// Y 坐标
        /// </summary>
        public string Y { set; get;}
        
        /// <summary>
        ///  是否有火星车探索过的痕迹
        /// </summary>
        public bool PercyMark { set; get;}
        
        /// <summary>
        ///  火星车探索过的痕迹的顺序
        ///  或重复，所以是list类型
        /// </summary>
        public List<int> PercyMarkOrder { set; get;}
        
        /// <summary>
        ///  是否有直升机探索过的痕迹
        /// </summary>
        public bool IngenuityMark { set; get;}
        
        /// <summary>
        ///  边界类型
        ///  0：不是边界, 1:上边界, 2: 右边界， 3：下边界， 4：左边界
        /// </summary>
        public List<int> BoundaryType { set; get;}
    }
}