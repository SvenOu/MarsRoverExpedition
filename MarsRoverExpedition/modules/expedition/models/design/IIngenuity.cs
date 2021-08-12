using MarsRoverExpedition.modules.expedition.models.DTO;

namespace MarsRoverExpedition.modules.expedition.models.design
{
    public interface IIngenuity
    {
        /// <summary>
        /// 探索
        /// </summary>
        void Explore(AreaUnit location, Area area);
    }
}