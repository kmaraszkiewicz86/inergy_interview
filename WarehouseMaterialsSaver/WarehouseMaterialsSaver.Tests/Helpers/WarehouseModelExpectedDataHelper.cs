using System.Collections.Generic;
using WarehouseMaterialsSaver.Models;

namespace WarehouseMaterialsSaver.Tests.Helpers
{
    public static class WarehouseModelExpectedDataHelper
    {
        public static List<Warehouse> ExpectedWarehouseModels
        {
            get
            {
                return new List<Warehouse>
                {
                    new Warehouse
                    {
                        Name = "WH-A",
                        Materials = new List<Material>
                        {
                            new Material
                            {
                                Id = "COM-100001",
                                Name = "Cherry Hardwood Arched Door - PS",
                                Count = 5
                            },
                            new Material
                            {
                                Id = "COM-124047",
                                Name = "Maple Dovetail Drawerbox",
                                Count = 15
                            },
                            new Material
                            {
                                Id = "COM-123906c",
                                Name = "Generic Wire Pull",
                                Count = 10
                            },
                            new Material
                            {
                                Id = "COM-123908",
                                Name = "Yankee Hardware 110 Deg.Hinge",
                                Count = 10
                            },
                            new Material
                            {
                                Id = "3MCherry-10mm",
                                Name = "Veneer - Charter Industries - 3M Adhesive Backed -Cherry 10mm - Paper Back",
                                Count = 10
                            }
                        }
                    },
                    new Warehouse
                    {
                        Name = "WH-B",
                        Materials = new List<Material>
                        {
                            new Material
                            {
                                Id = "COM-100001",
                                Name = "Cherry Hardwood Arched Door - PS",
                                Count = 10
                            },
                            new Material
                            {
                                Id = "COM-123906c",
                                Name = "Generic Wire Pull",
                                Count = 6
                            },
                            new Material
                            {
                                Id = "COM-123908",
                                Name = "Yankee Hardware 110 Deg.Hinge",
                                Count = 11
                            },
                            new Material
                            {
                                Id = "3MCherry-10mm",
                                Name = "Veneer - Charter Industries - 3M Adhesive Backed -Cherry 10mm - Paper Back",
                                Count = 1
                            }
                        }
                    },
                    new Warehouse
                    {
                        Name = "WH-C",
                        Materials = new List<Material>
                        {
                            new Material
                            {
                                Id = "COM-123906c",
                                Name = "Generic Wire Pull",
                                Count = 2
                            },
                            new Material
                            {
                                Id = "CB0115-CASSRC",
                                Name = "Hdw Accuride CB0115-CASSRC - Locking Handle Kit-Black",
                                Count = 13
                            },
                            new Material
                            {
                                Id = "COM-101734",
                                Name = "Veneer - Cherry Rotary 1 FSC;COM-123823;WH-C,10 MDF,CARB2,11/8",
                                Count = 8
                            }
                        }
                    },
                    new Warehouse
                    {
                        Name = "WHB",
                        Materials = new List<Material>
                        {
                            new Material
                            {
                                Id = "CB0115-CASSRC",
                                Name = "Hdw Accuride CB0115-CASSRC - Locking Handle Kit-Black",
                                Count = 5
                            }
                        }
                    },
                };
            }
        }

        public static List<string> ExpectedWarehouseModelsInFormattedStringLines
        {
            get
            {
                return new List<string>
                {
                    "WH-A (50)\r\nCOM-100001: (5)\r\nCOM-123906c: (10)\r\nCOM-124047: (15)\r\n3MCherry-10mm: (10)\r\nCOM-123908: (10)\r\n"
                };
            }
        }
    }
}
