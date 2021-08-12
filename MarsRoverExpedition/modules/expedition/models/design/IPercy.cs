using System;
using MarsRoverExpedition.modules.expedition.models.DTO;

namespace MarsRoverExpedition.modules.expedition.models.design
{
    public interface IPercy
    {
        /// <summary>
        /// 左转
        /// </summary>
        void RotateLeft();

        /// <summary>
        /// 右转
        /// </summary>
        void RotateRight();

        /// <summary>
        /// 前进
        /// </summary>
        void GoAhead();

        /// <summary>
        /// 后退
        /// </summary>
        void GoBack();

        /// <summary>
        /// 放出迷你直升机
        /// </summary>
        void ReleaseIngenuity();

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="order"></param>
        /// <param name="landUnit"></param>
        void ExcutingAnOrder(string order);

        /// <summary>
        ///  登陆
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <exception cref="NotImplementedException"></exception>
        void Land(AreaUnit location, int direction = Constants.DirectionUp);
    }
}