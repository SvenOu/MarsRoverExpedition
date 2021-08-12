using System;
using MarsRoverExpedition.modules.common.Helper;
using MarsRoverExpedition.modules.expedition.models.design;
using Newtonsoft.Json;

namespace MarsRoverExpedition.modules.expedition.models.dto
{
    /// <summary>
    /// 火星车
    /// </summary>
    public class Percy:IPercy
    {
        /// <summary>
        ///  方向. 默认向上
        /// </summary>
        public int Direction { get; set; } = Constants.DirectionUp;
        
        /// <summary>
        ///  一共走了多少步,即当前最后一步（包含遇到边界不动的情况）
        /// </summary>
        public int StepCount { get; set; } = 0;
        
        /// <summary>
        ///  位置
        /// </summary>
        public AreaUnit Location { get; set; }
        
        /// <summary>
        ///  场地
        /// </summary>
        public Area Area { get; set; }
        
        /// <summary>
        /// 迷你直升机
        /// </summary>
        public IIngenuity Ingenuity { get; set; }

        public Percy()
        {
            Ingenuity = new Ingenuity();
        }

        /// <summary>
        /// 左转
        /// </summary>
        public void RotateLeft()
        {
            if (Direction == Constants.DirectionUp)
            {
                Direction = 360 - Constants.RotateRange;
            }
            else
            {
                Direction = Direction - Constants.RotateRange;
            }
        }
        /// <summary>
        /// 右转
        /// </summary>
        public void RotateRight()
        {
            Direction = Direction + Constants.RotateRange;
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
            StepCount++;
            var nextStep = ExpeditionHelper.FindAheadUnit(Location, Direction, Area);
            if (nextStep == null)
            {
                Console.WriteLine($"{JsonConvert.SerializeObject(Location)} ahead step is Boundary");
                return;
            }
            nextStep.PercyMark = true;
            nextStep.PercyMarkOrder.Add(StepCount);
            Location = nextStep;
        }
        /// <summary>
        /// 后退
        /// </summary>
        public void GoBack ()
        {
            StepCount++;
            var nextStep = ExpeditionHelper.FindBackUnit(Location, Direction, Area);
            if (nextStep == null)
            {
                Console.WriteLine($"{JsonConvert.SerializeObject(Location)} back step is Boundary");
                return;
            }
            nextStep.PercyMark = true;
            nextStep.PercyMarkOrder.Add(StepCount);
            Location = nextStep;
        }

        /// <summary>
        /// 放出迷你直升机
        /// </summary>
        public void ReleaseIngenuity()
        {
            Ingenuity.Explore(Location, Area);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="order"></param>
        public void ExcutingAnOrder(string order)
        {
            for (int i = 0; i < order.Length; i++)
            {
                char c = order[i];
                switch (c)
                {
                    case 'F':  GoAhead();
                        break;
                    case 'B':  GoBack();
                        break;
                    case 'L':  RotateLeft();
                        break;
                    case 'R':  RotateRight();
                        break;
                    case 'H':  ReleaseIngenuity();
                        break;
                }
            }
            Console.Write("");
        }

        /// <summary>
        ///  登陆
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Land(AreaUnit location, int direction =Constants.DirectionUp)
        {
            StepCount++;
            if (location == null)
            {
                Console.WriteLine($"{JsonConvert.SerializeObject(Location)} back step is Boundary");
                return;
            }
            Direction = direction;
            location.PercyMark = true;
            location.PercyMarkOrder.Add(StepCount);
            Location = location;
        }
    }
}