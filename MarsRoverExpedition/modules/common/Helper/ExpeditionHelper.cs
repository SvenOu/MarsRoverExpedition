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
    }
}