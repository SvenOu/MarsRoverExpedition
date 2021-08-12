using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverExpedition.modules.common.Config;
using MarsRoverExpedition.modules.common.Helper;
using MarsRoverExpedition.modules.expedition.models;
using MarsRoverExpedition.modules.expedition.models.DTO;
using MarsRoverExpedition.modules.expedition.models.Param;
using MarsRoverExpedition.modules.expedition.services;
using MarsRoverExpedition.modules.expedition.services.impl;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MarsRoverExpedition.test.expedition
{
    public class ExpeditionTest
    {
        private Area _area;
        private Percy _percy;

        private AreaUnit A1;
        private AreaUnit A2;
        private AreaUnit A3;
        private AreaUnit A4;

        private AreaUnit B1;
        private AreaUnit B2;
        private AreaUnit B3;
        private AreaUnit B4;

        private AreaUnit C1;
        private AreaUnit C2;
        private AreaUnit C3;
        private AreaUnit C4;

        private AreaUnit D1;
        private AreaUnit D2;
        private AreaUnit D3;
        private AreaUnit D4;

        [SetUp]
        public void Setup()
        {
            ConfigFunction.InitByFilePath("appsettings.Development.json");
            // 动态规划思想，用小场地测试
            _area = new Area()
            {
                XAxis = new List<string>()
                {
                    "A", "B", "C", "D"
                },
                YAxis = new List<string>()
                {
                    "1", "2", "3", "4"
                }
            }.Init();
            _percy = new Percy()
            {
                Area = _area,
            };
            var zeroUnits = _area.AreaUnits;
            Console.Write(JsonConvert.SerializeObject(zeroUnits));
            
            A1 = zeroUnits.Find(c => c.Id.Equals("A1"));
            A2 = zeroUnits.Find(c => c.Id.Equals("A2"));
            A3 = zeroUnits.Find(c => c.Id.Equals("A3"));
            A4 = zeroUnits.Find(c => c.Id.Equals("A4"));

            B1 = zeroUnits.Find(c => c.Id.Equals("B1"));
            B2 = zeroUnits.Find(c => c.Id.Equals("B2"));
            B3 = zeroUnits.Find(c => c.Id.Equals("B3"));
            B4 = zeroUnits.Find(c => c.Id.Equals("B4"));

            C1 = zeroUnits.Find(c => c.Id.Equals("C1"));
            C2 = zeroUnits.Find(c => c.Id.Equals("C2"));
            C3 = zeroUnits.Find(c => c.Id.Equals("C3"));
            C4 = zeroUnits.Find(c => c.Id.Equals("C4"));

            D1 = zeroUnits.Find(c => c.Id.Equals("D1"));
            D2 = zeroUnits.Find(c => c.Id.Equals("D2"));
            D3 = zeroUnits.Find(c => c.Id.Equals("D3"));
            D4 = zeroUnits.Find(c => c.Id.Equals("D4"));
        }

        [TearDown]
        public void Close()
        {
        }
        [Test]
        public void Test_ExcutingAnOrder()
        {
            ExcutingAnOrderParam param = new ExcutingAnOrderParam()
            {
                Order = "FFHLFRBBFFFFF",
                LandId = "C4",
                Direction = 0
            };
            
            AreaUnit landUnit = null;
            if (string.IsNullOrEmpty(param.LandId))
            {
                landUnit = ExpeditionHelper.RandomLocation(_area);
            }
            else
            {
                landUnit = ExpeditionHelper.FindUnitById(_area, param.LandId);
            }
            
            _percy.Land(landUnit, param.Direction);
            
            _percy.ExcutingAnOrder(param.Order);
            
            Console.WriteLine("-----Percy and Ingenuity------");
            Console.WriteLine(JsonConvert.SerializeObject(ExpeditionHelper.FindExploreUnits(_area, 0).Select(p => p.Id).ToList()));
            
            Console.WriteLine("-----Percy------");
            Console.WriteLine(JsonConvert.SerializeObject(ExpeditionHelper.FindExploreUnits(_area, 1).Select(p => p.Id).ToList()));
            
            Console.WriteLine("-----Ingenuity------");
            Console.WriteLine(JsonConvert.SerializeObject(ExpeditionHelper.FindExploreUnits(_area, 2).Select(p => p.Id).ToList()));
            
            AreaUnit lastStep = ExpeditionHelper.FindPercyLastStep(_area);
            float explorePercentage  = ExpeditionHelper.FindExplorePercentage(_area, 0);
            var result = new
            {
                LastStep = lastStep.X + lastStep.Y,
                ExplorePercentage = explorePercentage * 100.0f + "%"
            };
            
            Console.WriteLine("------_area.AreaUnits--------");
            Console.WriteLine(JsonConvert.SerializeObject(_area.AreaUnits));
            
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Assert.Pass();
        }

        [Test]
        public void Test_RandomLocation()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(JsonConvert.SerializeObject(ExpeditionHelper.RandomLocation(_area)));
            }
        }

        [Test]
        public void Test_FindAheadUnit()
        {
            _percy.Land(C3);
            _percy.RotateLeft();
            _percy.RotateLeft();
            _percy.RotateLeft();
            _percy.RotateLeft();
            _percy.RotateLeft();
            _percy.GoAhead();
            Assert.IsTrue(_percy.Location == B3);
            _percy.RotateRight();
            _percy.RotateRight();
            _percy.RotateRight();
            _percy.RotateRight();
            _percy.RotateRight();
            _percy.GoAhead();
            Assert.IsTrue(_percy.Location == B2);
            _percy.GoAhead();
            Assert.IsTrue(_percy.Location == B1);
            _percy.GoBack();
            _percy.GoBack();
            _percy.GoBack();
            _percy.GoBack();
            Assert.IsTrue(_percy.Location == B4);
            _percy.RotateLeft();
            _percy.GoAhead();
            Assert.IsTrue(_percy.Location == A4);
            _percy.GoAhead();
            Assert.IsTrue(_percy.Location == A4);
            _percy.ReleaseIngenuity();

            Console.WriteLine("-----Percy and Ingenuity------");
            Console.WriteLine(JsonConvert.SerializeObject(ExpeditionHelper.FindExploreUnits(_area, 0).Select(p => p.Id).ToList()));
            
            Console.WriteLine("-----Percy------");
            Console.WriteLine(JsonConvert.SerializeObject(ExpeditionHelper.FindExploreUnits(_area, 1).Select(p => p.Id).ToList()));
            
            Console.WriteLine("-----Ingenuity------");
            Console.WriteLine(JsonConvert.SerializeObject(ExpeditionHelper.FindExploreUnits(_area, 2).Select(p => p.Id).ToList()));
        }

        [Test]
        public void TestArea()
        {
            Assert.IsTrue(A1.BoundaryType.Contains(Constants.BoundaryTypeLeft) &&
                          A1.BoundaryType.Contains(Constants.BoundaryTypeUp));
            Assert.IsTrue(A2.BoundaryType.Contains(Constants.BoundaryTypeLeft));
            Assert.IsTrue(A3.BoundaryType.Contains(Constants.BoundaryTypeLeft));
            Assert.IsTrue(A4.BoundaryType.Contains(Constants.BoundaryTypeLeft) &&
                          A4.BoundaryType.Contains(Constants.BoundaryTypeDown));

            Assert.IsTrue(B1.BoundaryType.Contains(Constants.BoundaryTypeUp));
            Assert.IsTrue(B2.BoundaryType.Contains(Constants.BoundaryTypeNone));
            Assert.IsTrue(B3.BoundaryType.Contains(Constants.BoundaryTypeNone));
            Assert.IsTrue(B4.BoundaryType.Contains(Constants.BoundaryTypeDown));

            Assert.IsTrue(C1.BoundaryType.Contains(Constants.BoundaryTypeUp));
            Assert.IsTrue(C2.BoundaryType.Contains(Constants.BoundaryTypeNone));
            Assert.IsTrue(C3.BoundaryType.Contains(Constants.BoundaryTypeNone));
            Assert.IsTrue(C4.BoundaryType.Contains(Constants.BoundaryTypeDown));

            Assert.IsTrue(D1.BoundaryType.Contains(Constants.BoundaryTypeRight) &&
                          D1.BoundaryType.Contains(Constants.BoundaryTypeUp));
            Assert.IsTrue(D2.BoundaryType.Contains(Constants.BoundaryTypeRight));
            Assert.IsTrue(D3.BoundaryType.Contains(Constants.BoundaryTypeRight));
            Assert.IsTrue(D4.BoundaryType.Contains(Constants.BoundaryTypeRight) &&
                          D4.BoundaryType.Contains(Constants.BoundaryTypeDown));
        }
    }
}