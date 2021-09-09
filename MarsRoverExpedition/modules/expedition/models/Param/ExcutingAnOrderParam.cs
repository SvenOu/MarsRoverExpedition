using System.ComponentModel;

namespace MarsRoverExpedition.modules.expedition.models.Param
{
    public class ExcutingAnOrderParam
    {
        /// <summary>
        /// 命令
        /// </summary>
        [DefaultValue("FFFLFFRBBHFFFFF")]
        public string Order { get; set; }
        
        /// <summary>
        /// 着陆方向
        /// 上:0, 右:90, 下:180, 左:270
        /// </summary>
        [DefaultValue("0")]
        public int Direction { get; set; }
        
        /// <summary>
        /// 着陆位置
        /// </summary>
        [DefaultValue("H17")]
        public string LandId { get; set; }
    }
}