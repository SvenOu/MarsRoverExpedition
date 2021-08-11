namespace MarsRoverExpedition.modules.expedition.models
{
    public class Constants
    {
        /// <summary>
        /// 正常格子
        /// </summary>
        public const int BoundaryTypeNone = 0;
        /// <summary>
        /// 上边界格子
        /// </summary>
        public const int BoundaryTypeUp = 1;
        /// <summary>
        /// 右边界格子
        /// </summary>
        public const int BoundaryTypeRight = 2;
        /// <summary>
        /// 下边界格子
        /// </summary>
        public const int BoundaryTypeDown = 3;
        /// <summary>
        /// 左边界格子
        /// </summary>
        public const int BoundaryTypeLeft = 4;
        
        /// <summary>
        /// 旋转角度
        /// </summary>
        public const int RatateRange = 90;
        
        /// <summary>
        /// 方向向上
        /// </summary>
        public const int DirectionUp = 0;
        
        /// <summary>
        /// 方向向右
        /// </summary>
        public const int DirectionRight = 90;
        
        /// <summary>
        /// 方向向下
        /// </summary>
        public const int DirectionDown = 180;
        
        /// <summary>
        /// 方向向左
        /// </summary>
        public const int DirectionLeft = 270;
    }
}