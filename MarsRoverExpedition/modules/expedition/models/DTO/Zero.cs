using System.Collections.Generic;
using MarsRoverExpedition.modules.common.Helper;

namespace MarsRoverExpedition.modules.expedition.models.DTO
{
    /// <summary>
    /// 场地
    /// </summary>
    public class Zero
    {
        /// <summary>
        /// x 轴
        /// </summary>
        public readonly List<string> XAxis = new List<string>()
        {
            "A", "B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y"
        };
        /// <summary>
        /// Y 轴
        /// </summary>
        public readonly List<string> YAxis = new List<string>()
        {
            "1", "2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25"
        };
        /// <summary>
        /// 所有可探索区域
        /// </summary>
        public List<ZeroUnit> ZeroUnits { set; get; }

        public Zero()
        {
            Init();
        }

        /// <summary>
        /// 重置单元格
        /// </summary>
        public void Init()
        {
            ZeroUnits = new List<ZeroUnit>();
            for (int i = 0; i < XAxis.Count; i++)
            {
                string xe = XAxis[i];
                for (int j = 0; j < YAxis.Count; j++)
                {
                    string ye = YAxis[i];

                    int boundaryType = Constants.BoundaryTypeNone;
                    if (j == 0)
                    {
                        boundaryType = Constants.BoundaryTypeUp;
                    }else if (i == XAxis.Count - 1)
                    {
                        boundaryType = Constants.BoundaryTypeRight;
                    }
                    else if (j == YAxis.Count - 1)
                    {
                        boundaryType = Constants.BoundaryTypeDown;
                    }
                    else if (i == 0)
                    {
                        boundaryType = Constants.BoundaryTypeLeft;
                    }

                    var zeroUnit = new ZeroUnit()
                    {
                        Id = ExpeditionHelper.GenerateId(xe, ye),
                        PercyMark = false,
                        PercyMarkOrder = new List<int>(),
                        IngenuityMark = false,
                        BoundaryType = boundaryType
                    };
                    ZeroUnits.Add(zeroUnit);
                }
            }
        }
    }
}