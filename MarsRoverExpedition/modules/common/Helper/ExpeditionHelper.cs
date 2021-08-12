using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverExpedition.modules.expedition.models;
using MarsRoverExpedition.modules.expedition.models.dto;

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
            return $"{x}{y}";
        }
        /// <summary>
        /// 获取随机位置
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static AreaUnit RandomLocation(Area area)
        {
           var rIndex = new Random().Next(0, area.AreaUnits.Count);
           return area.AreaUnits[rIndex];
        }
        /// <summary>
        /// 查找前面的格子
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static AreaUnit FindAheadUnit(AreaUnit location, int direction, Area area)
        {
            var x = location.X;
            var y = location.Y;
            switch (direction)
            {
                case Constants.DirectionUp:
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeUp))
                    {
                        return null;
                    }
                    y = GetTargetAxis(area.YAxis, location.Y, -1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
                case Constants.DirectionRight: 
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeRight))
                    {
                        return null;
                    }

                    x = GetTargetAxis(area.XAxis, location.X, 1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
                case Constants.DirectionDown:
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeDown))
                    {
                        return null;
                    }
                    y = GetTargetAxis(area.YAxis, location.Y, 1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
                
                case Constants.DirectionLeft: 
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeLeft))
                    {
                        return null;
                    }
                    x = GetTargetAxis(area.XAxis, location.X, -1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
            }
            return null;
        }

        private static string GetTargetAxis(List<string> axis, string locationValue, int increment)
        {
            var originIndex = axis.FindIndex(c2 => c2.Equals(locationValue));
            var targetIndex = originIndex + increment;
            if (targetIndex<0 || targetIndex>=axis.Count)
            {
                return locationValue;
            }
            return axis[targetIndex];
        }

        /// <summary>
        /// 查找后面的格子
        /// </summary>
        /// <param name="location"></param>
        /// <param name="direction"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static AreaUnit FindBackUnit(AreaUnit location, int direction, Area area)
        {
            var x = location.X;
            var y = location.Y;
            switch (direction)
            {
                case Constants.DirectionUp:
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeDown))
                    {
                        return null;
                    }
                    y = GetTargetAxis(area.YAxis, location.Y, 1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
                case Constants.DirectionRight: 
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeLeft))
                    {
                        return null;
                    }
                    x = GetTargetAxis(area.XAxis, location.X, -1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
                case Constants.DirectionDown:
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeUp))
                    {
                        return null;
                    }
                    y = GetTargetAxis(area.YAxis, location.Y, -1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
                
                case Constants.DirectionLeft: 
                    if (location.BoundaryType.Contains(Constants.BoundaryTypeRight))
                    {
                        return null;
                    }
                    x = GetTargetAxis(area.YAxis, location.X, 1);
                    return area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
            }
            return null;
        }
        
        /// <summary>
        /// 查找周围的格子
        /// </summary>
        /// <param name="location"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static List<AreaUnit> FindAround(AreaUnit location, Area area)
        {
            List<AreaUnit> aroundUnits = new List<AreaUnit>();
            string x,y;
            var unit0 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(location.X, location.Y)));
            aroundUnits.Add(unit0);
            x = GetTargetAxis(area.XAxis, location.X, -1);
            var unit1 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, location.Y)));
            if (unit1 != null)
            {
                aroundUnits.Add(unit1);
            }
            x = GetTargetAxis(area.XAxis, location.X, -1);
            y = GetTargetAxis(area.YAxis, location.Y, -1);
            var unit2 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
            if (unit2 !=new AreaUnit())
            {
                aroundUnits.Add(unit2);
            }
            x = GetTargetAxis(area.XAxis, location.X, 1);
            y = GetTargetAxis(area.YAxis, location.Y, -1);
            var unit3 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(location.X, y)));
            if (unit3 !=new AreaUnit())
            {
                aroundUnits.Add(unit3);
            }
            x = GetTargetAxis(area.XAxis, location.X, 1);
            y = GetTargetAxis(area.YAxis, location.Y, -1);
            var unit4 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
            if (unit4 !=new AreaUnit())
            {
                aroundUnits.Add(unit4);
            }
            x = GetTargetAxis(area.XAxis, location.X, 1);
            var unit5 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, location.Y)));
            if (unit5 !=new AreaUnit())
            {
                aroundUnits.Add(unit5);
            }
            x = GetTargetAxis(area.XAxis, location.X, 1);
            y = GetTargetAxis(area.YAxis, location.Y, 1);
            var unit6 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
            if (unit6 !=new AreaUnit())
            {
                aroundUnits.Add(unit6);
            }
            y = GetTargetAxis(area.YAxis, location.Y, 1);
            var unit7 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(location.X, y)));
            if (unit7 !=new AreaUnit())
            {
                aroundUnits.Add(unit7);
            }
            x = GetTargetAxis(area.XAxis, location.X, -1);
            y = GetTargetAxis(area.YAxis, location.Y, 1);
            var unit8 = area.AreaUnits.Find(c => c.Id.Equals(GenerateId(x, y)));
            if (unit8 !=new AreaUnit())
            {
                aroundUnits.Add(unit8);
            }
            return aroundUnits;
        }
        
        /// <summary>
        /// 查找火星车最后一步
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static AreaUnit FindPercyLastStep(Area area)
        {
            AreaUnit lastUnit = null;
            foreach (var unit in area.AreaUnits)
            {
                if (lastUnit == null)
                {
                    lastUnit = unit;
                }else if (unit.PercyMarkOrder.Count >0)
                {
                    if (lastUnit.PercyMarkOrder.Count <=0 || unit.PercyMarkOrder.Max() > lastUnit.PercyMarkOrder.Max())
                    {
                        lastUnit = unit;
                    }
                }
            }
            return lastUnit;
        }
        
        /// <summary>
        /// 查找百分比
        /// type: 0 火星车 and 迷你直升机
        /// type: 1 火星车
        /// type: 2 迷你直升机
        /// </summary>
        /// <param name="area"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static float FindExplorePercentage(Area area, int type)
        {
            int total = area.AreaUnits.Count;
            List<AreaUnit> targets = FindExploreUnits(area, type);
            return targets.Count/1.0f/total;
        }
        
        /// <summary>
        /// 查找单元格
        /// type: 0 火星车 and 迷你直升机
        /// type: 1 火星车
        /// type: 2 迷你直升机
        /// </summary>
        /// <param name="area"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<AreaUnit> FindExploreUnits(Area area, int type)
        {
            List<AreaUnit> targets = new List<AreaUnit>();
            foreach (var unit in area.AreaUnits)
            {
                if (type == 0)
                {
                    if (unit.IngenuityMark || unit.PercyMark)
                    {
                        targets.Add(unit);
                    }
                }else if (type == 1)
                {
                    if (unit.PercyMark)
                    {
                        targets.Add(unit);
                    }
                }else if (type == 2)
                {
                    if (unit.IngenuityMark)
                    {
                        targets.Add(unit);
                    }
                }
            }
            return targets;
        }

        /// <summary>
        /// 根据Id查找单元格
        /// </summary>
        /// <param name="area"></param>
        /// <param name="landId"></param>
        /// <returns></returns>
        public static AreaUnit FindUnitById(Area area, string landId)
        {
            return area.AreaUnits.Find(c => c.Id.Equals(landId));
        }
    }
}