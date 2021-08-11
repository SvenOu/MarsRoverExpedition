namespace MarsRoverExpedition.modules.expedition.models.DTO
{
    /// <summary>
    /// 火星车
    /// </summary>
    public class Percy
    {
        /// <summary>
        ///  方向. 默认向上
        /// </summary>
        public int Direction { get; set; } = Constants.DirectionUp;
        
        /// <summary>
        ///  位置
        /// </summary>
        public ZeroUnit Location { get; set; }
        
        /// <summary>
        ///  场地
        /// </summary>
        public Zero Zero { get; set; }

        /// <summary>
        /// 左转
        /// </summary>
        public void RotateLeft()
        {
            if (Direction == Constants.DirectionUp)
            {
                Direction = 360 - Constants.RatateRange;
            }
            else
            {
                Direction = Direction - Constants.RatateRange;
            }
        }
        /// <summary>
        /// 右转
        /// </summary>
        public void RotateRight()
        {
            Direction = Direction + Constants.RatateRange;
            if (Direction >= 360)
            {
                Direction = 0;
            }
        }
        /// <summary>
        /// 前进
        /// </summary>
        public void GoAhead ()
        {
            switch (Direction)
            {
                case Constants.DirectionUp:
                    break;
                case Constants.DirectionRight:
                    break;
                case Constants.DirectionDown:
                    break;
                case Constants.DirectionLeft:
                    break;
            }
        }
        /// <summary>
        /// 后退
        /// </summary>
        public void GoBack ()
        {
            switch (Direction)
            {
                case Constants.DirectionUp: 
                    break;
                case Constants.DirectionRight: 
                    break;
                case Constants.DirectionDown: 
                    break;
                case Constants.DirectionLeft: 
                    break;
            }
        }
    }
}