using System.Collections.Generic;
using MarsRoverExpedition.modules.common.Helper;

namespace MarsRoverExpedition.modules.expedition.models.DTO
{
    /// <summary>
    /// 场地
    /// </summary>
    public class Area
    {
        /// <summary>
        /// x 轴
        /// </summary>
        public List<string> XAxis { set; get; } = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
            "V", "W", "X", "Y"
        };

        /// <summary>
        /// Y 轴
        /// </summary>
        public List<string> YAxis { set; get; } = new List<string>()
        {
            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
            "20", "21", "22", "23", "24", "25"
        };

        /// <summary>
        /// 所有可探索区域
        /// </summary>
        public List<AreaUnit> AreaUnits { set; get; }

        /// <summary>
        /// 重置单元格
        /// </summary>
        public Area Init()
        {
            AreaUnits = new List<AreaUnit>();
            for (int i = 0; i < XAxis.Count; i++)
            {
                string xe = XAxis[i];
                for (int j = 0; j < YAxis.Count; j++)
                {
                    string ye = YAxis[j];
                    List<int> boundaryTypes = new List<int>();
                    if (j == 0)
                    {
                        boundaryTypes.Add(Constants.BoundaryTypeUp);
                    }

                    if (i == XAxis.Count - 1)
                    {
                        boundaryTypes.Add(Constants.BoundaryTypeRight);
                    }

                    if (j == YAxis.Count - 1)
                    {
                        boundaryTypes.Add(Constants.BoundaryTypeDown);
                    }

                    if (i == 0)
                    {
                        boundaryTypes.Add(Constants.BoundaryTypeLeft);
                    }

                    if (boundaryTypes.Count <= 0)
                    {
                        boundaryTypes.Add(Constants.BoundaryTypeNone);
                    }

                    var areaUnit = new AreaUnit()
                    {
                        Id = ExpeditionHelper.GenerateId(xe, ye),
                        X = xe,
                        Y = ye,
                        PercyMark = false,
                        PercyMarkOrder = new List<int>(),
                        IngenuityMark = false,
                        BoundaryType = boundaryTypes
                    };
                    AreaUnits.Add(areaUnit);
                }
            }

            return this;
        }
    }
}