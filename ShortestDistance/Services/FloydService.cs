using ShortestDistance.Models;
using ShortestDistance.VewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace ShortestDistance.Services
{
    public class FloydService
    {
        private readonly MapData _context = new MapData();

        #region adjacent
        List<AdjacentsOnMemory> adjacents = new List<AdjacentsOnMemory>
        {

           new AdjacentsOnMemory {no=1,vertex1=1,vertex2=2,distance=0.14},
           new AdjacentsOnMemory {no=2,vertex1=1,vertex2=3,distance=0.6 },
           new AdjacentsOnMemory {no=3,vertex1=1,vertex2=5,distance= 0.65},
           new AdjacentsOnMemory {no=4,vertex1=1,vertex2=6,distance= 0.9},
           new AdjacentsOnMemory {no=5,vertex1=1,vertex2=11,distance=0.7 },
           new AdjacentsOnMemory {no=6,vertex1=1,vertex2=12,distance=0.65 },
           new AdjacentsOnMemory {no=7,vertex1=1,vertex2=13,distance= 0.7},
           new AdjacentsOnMemory {no=8,vertex1=1,vertex2=14,distance=0.85 },
           new AdjacentsOnMemory {no=9,vertex1=1,vertex2=15,distance= 1.5},
           new AdjacentsOnMemory {no=10,vertex1=1,vertex2=20,distance=1.1 },
           new AdjacentsOnMemory {no=11,vertex1=1,vertex2=21,distance=0.7 },
           new AdjacentsOnMemory {no=12,vertex1=1,vertex2=22,distance=1.2 },

           new AdjacentsOnMemory {no=13,vertex1=2,vertex2=3,distance=0.55 },
           new AdjacentsOnMemory {no=14,vertex1=2,vertex2=5,distance=0.55 },
           new AdjacentsOnMemory {no=15,vertex1=2,vertex2=6,distance=0.85 },
           new AdjacentsOnMemory {no=16,vertex1=2,vertex2=11,distance=0.55 },
           new AdjacentsOnMemory {no=17,vertex1=2,vertex2=12,distance=0.85 },
           new AdjacentsOnMemory {no=18,vertex1=2,vertex2=13,distance=0.65 },
           new AdjacentsOnMemory {no=19,vertex1=2,vertex2=14,distance=0.75 },
           new AdjacentsOnMemory {no=20,vertex1=2,vertex2=15,distance=1.1 },
           new AdjacentsOnMemory {no=21,vertex1=2,vertex2=21,distance=0.85 },
           new AdjacentsOnMemory {no=22,vertex1=2,vertex2=22,distance=1.1 },
           new AdjacentsOnMemory {no=23,vertex1=2,vertex2=1,distance=0.14 },

           new AdjacentsOnMemory {no=24,vertex1=3,vertex2=4,distance=0.4 },
           new AdjacentsOnMemory {no=25,vertex1=3,vertex2=5,distance= 0.55},
           new AdjacentsOnMemory {no=26,vertex1=3,vertex2=6,distance=0.29 },
           new AdjacentsOnMemory {no=27,vertex1=3,vertex2=7,distance=0.6 },
           new AdjacentsOnMemory {no=28,vertex1=3,vertex2=1,distance=0.6 },
           new AdjacentsOnMemory {no=29,vertex1=3,vertex2=2,distance=0.55 },


           new AdjacentsOnMemory {no=30,vertex1=4,vertex2=3,distance=0.4 },
           new AdjacentsOnMemory {no=31,vertex1=4,vertex2=6,distance=0.65 },
           new AdjacentsOnMemory {no=32,vertex1=4,vertex2=7,distance= 0.35},
           new AdjacentsOnMemory {no=33,vertex1=4,vertex2=8,distance= 0.45},
           new AdjacentsOnMemory {no=34,vertex1=4,vertex2=9,distance=0.75 },
           new AdjacentsOnMemory {no=35,vertex1=4,vertex2=10,distance= 1},



           new AdjacentsOnMemory {no=36,vertex1=5,vertex2=2,distance=0.55 },
            new AdjacentsOnMemory {no=37,vertex1=5,vertex2=3,distance= 0.55},
            new AdjacentsOnMemory {no=38,vertex1=5,vertex2=1,distance= 0.65},
            new AdjacentsOnMemory {no=39,vertex1=5,vertex2=6,distance= 0.3},
           new AdjacentsOnMemory {no=40,vertex1=5,vertex2=11,distance= 0.9},
           new AdjacentsOnMemory {no=41,vertex1=5,vertex2=13,distance= 0.65},
           new AdjacentsOnMemory {no=42,vertex1=5,vertex2=14,distance=0.3 },
           new AdjacentsOnMemory {no=43,vertex1=5,vertex2=15,distance= 0.5},
           new AdjacentsOnMemory {no=44,vertex1=5,vertex2=20,distance=0.5 },

          new AdjacentsOnMemory {no=45,vertex1=6,vertex2=1,distance= 0.9},
          new AdjacentsOnMemory {no=46,vertex1=6,vertex2=2,distance=0.85 },
          new AdjacentsOnMemory {no=47,vertex1=6,vertex2=3,distance=0.29 },
          new AdjacentsOnMemory {no=48,vertex1=6,vertex2=4,distance=0.65 },
            new AdjacentsOnMemory {no=49,vertex1=6,vertex2=5,distance= 0.3},
           new AdjacentsOnMemory {no=50,vertex1=6,vertex2=7,distance=0.29 },
           new AdjacentsOnMemory {no=51,vertex1=6,vertex2=14,distance=0.6},
           new AdjacentsOnMemory {no=52,vertex1=6,vertex2=15,distance=0.3 },
           new AdjacentsOnMemory {no=53,vertex1=6,vertex2=16,distance=0.85 },


           new AdjacentsOnMemory {no=54,vertex1=7,vertex2=3,distance=0.6 },
           new AdjacentsOnMemory {no=55,vertex1=7,vertex2=4,distance= 0.35},
            new AdjacentsOnMemory {no=56,vertex1=7,vertex2=6,distance=0.29 },
           new AdjacentsOnMemory {no=57,vertex1=7,vertex2=8,distance=0.26 },
           new AdjacentsOnMemory {no=58,vertex1=7,vertex2=15,distance=0.6 },
           new AdjacentsOnMemory {no=59,vertex1=7,vertex2=16,distance=0.55 },


           new AdjacentsOnMemory {no=60,vertex1=8,vertex2=4,distance= 0.45},
           new AdjacentsOnMemory {no=61,vertex1=8,vertex2=7,distance=0.26 },
           new AdjacentsOnMemory {no=62,vertex1=8,vertex2=9,distance=0.45 },
           new AdjacentsOnMemory {no=63,vertex1=8,vertex2=15,distance= 0.85},
           new AdjacentsOnMemory {no=64,vertex1=8,vertex2=16,distance=0.55},
           new AdjacentsOnMemory {no=65,vertex1=8,vertex2=17,distance=0.55},

           new AdjacentsOnMemory {no=66,vertex1=9,vertex2=4,distance=0.75 },
          new AdjacentsOnMemory {no=67,vertex1=9,vertex2=8,distance=0.45 },
           new AdjacentsOnMemory {no=68,vertex1=9,vertex2=10,distance=0.3 },

           new AdjacentsOnMemory {no=69,vertex1=9,vertex2=17,distance=0.45 },
           new AdjacentsOnMemory {no=70,vertex1=9,vertex2=18,distance=0.45},


             new AdjacentsOnMemory {no=71,vertex1=10,vertex2=9,distance=0.3 },
           new AdjacentsOnMemory {no=72,vertex1=10,vertex2=4,distance=1 },
           new AdjacentsOnMemory {no=73,vertex1=10,vertex2=18,distance=0.4 },
           new AdjacentsOnMemory {no=74,vertex1=10,vertex2=19,distance=0.55 },

          new AdjacentsOnMemory {no=75,vertex1=11,vertex2=1,distance=0.7 },
          new AdjacentsOnMemory {no=76,vertex1=11,vertex2=2,distance=0.55 },
           new AdjacentsOnMemory {no=77,vertex1=11,vertex2=5,distance= 0.9},
           new AdjacentsOnMemory {no=78,vertex1=11,vertex2=12,distance=0.12 },
           new AdjacentsOnMemory {no=79,vertex1=11,vertex2=13,distance=0.35 },
           new AdjacentsOnMemory {no=80,vertex1=11,vertex2=14,distance=0.85 },

           new AdjacentsOnMemory {no=81,vertex1=12,vertex2=1,distance=0.65 },

          new AdjacentsOnMemory {no=82,vertex1=12,vertex2=2,distance=0.85 },
           new AdjacentsOnMemory {no=83,vertex1=12,vertex2=11,distance=0.12 },

           new AdjacentsOnMemory {no=84,vertex1=12,vertex2=14,distance=1 },

          new AdjacentsOnMemory {no=85,vertex1=13,vertex2=1,distance= 0.7},
            new AdjacentsOnMemory {no=86,vertex1=13,vertex2=5,distance= 0.65},
           new AdjacentsOnMemory {no=87,vertex1=13,vertex2=14,distance=0.5 },
          new AdjacentsOnMemory {no=88,vertex1=13,vertex2=2,distance=0.65 },
           new AdjacentsOnMemory {no=89,vertex1=13,vertex2=21,distance=0.2 },



           new AdjacentsOnMemory {no=90,vertex1=14,vertex2=11,distance=0.85 },
           new AdjacentsOnMemory {no=91,vertex1=14,vertex2=15,distance=0.3 },
           new AdjacentsOnMemory {no=92,vertex1=14,vertex2=20,distance=0.26 },
           new AdjacentsOnMemory {no=93,vertex1=14,vertex2=21,distance=0.5 },
           new AdjacentsOnMemory {no=94,vertex1=14,vertex2=22,distance=0.4 },
          new AdjacentsOnMemory {no=95,vertex1=14,vertex2=5,distance=0.3 },
           new AdjacentsOnMemory {no=96,vertex1=14,vertex2=13,distance=0.5 },
           new AdjacentsOnMemory {no=97,vertex1=14,vertex2=6,distance=0.6},

             new AdjacentsOnMemory {no=98,vertex1=15,vertex2=5,distance= 0.5},
           new AdjacentsOnMemory {no=99,vertex1=15,vertex2=16,distance=0.6 },
           new AdjacentsOnMemory {no=100,vertex1=15,vertex2=14,distance=0.3 },
           new AdjacentsOnMemory {no=101,vertex1=15,vertex2=20,distance=0.21 },
            new AdjacentsOnMemory {no=102,vertex1=15,vertex2=6,distance=0.3 },
            new AdjacentsOnMemory {no=103,vertex1=15,vertex2=7,distance=0.6 },
            new AdjacentsOnMemory {no=104,vertex1=15,vertex2=8,distance= 0.85},



           new AdjacentsOnMemory {no=105,vertex1=16,vertex2=9,distance=0.7 },
           new AdjacentsOnMemory {no=106,vertex1=16,vertex2=17,distance=0.26 },
           new AdjacentsOnMemory {no=107,vertex1=16,vertex2=6,distance=0.85 },
           new AdjacentsOnMemory {no=108,vertex1=16,vertex2=7,distance=0.55 },
           new AdjacentsOnMemory {no=109,vertex1=16,vertex2=8,distance=0.55},
           new AdjacentsOnMemory {no=110,vertex1=16,vertex2=23,distance=0.6 },
           new AdjacentsOnMemory {no=111,vertex1=16,vertex2=25,distance=0.24 },
            new AdjacentsOnMemory {no=112,vertex1=16,vertex2=15,distance=0.6 },

            new AdjacentsOnMemory {no=113,vertex1=17,vertex2=8,distance=0.55},
            new AdjacentsOnMemory {no=114,vertex1=17,vertex2=9,distance=0.45 },
           new AdjacentsOnMemory {no=115,vertex1=17,vertex2=10,distance=0.75},
             new AdjacentsOnMemory {no=116,vertex1=17,vertex2=16,distance=0.26 },
           new AdjacentsOnMemory {no=117,vertex1=17,vertex2=18,distance=0.35 },


           new AdjacentsOnMemory {no=118,vertex1=18,vertex2=9,distance=0.45},
           new AdjacentsOnMemory {no=119,vertex1=18,vertex2=10,distance=0.4 },
            new AdjacentsOnMemory {no=120,vertex1=17,vertex2=18,distance=0.35 },
           new AdjacentsOnMemory {no=121,vertex1=18,vertex2=26,distance=0.35 },
          new AdjacentsOnMemory {no=122,vertex1=18,vertex2=19,distance= 0.6},


           new AdjacentsOnMemory {no=123,vertex1=19,vertex2=10,distance=0.55 },
           new AdjacentsOnMemory {no=124,vertex1=19,vertex2=18,distance=0.6 },
           new AdjacentsOnMemory {no=125,vertex1=19,vertex2=26,distance=0.6 },

          new AdjacentsOnMemory {no=126,vertex1=20,vertex2=5,distance=0.5 },
          new AdjacentsOnMemory {no=127,vertex1=20,vertex2=14,distance=0.26 },
          new AdjacentsOnMemory {no=128,vertex1=20,vertex2=15,distance=0.21 },
           new AdjacentsOnMemory {no=129,vertex1=20,vertex2=22,distance=0.3 },
           new AdjacentsOnMemory {no=130,vertex1=20,vertex2=23,distance=0.95 },


             new AdjacentsOnMemory {no=131,vertex1=21,vertex2=13,distance=0.2 },
             new AdjacentsOnMemory {no=132,vertex1=21,vertex2=14,distance=0.5 },
           new AdjacentsOnMemory {no=133,vertex1=21,vertex2=22,distance= 0.65},

              new AdjacentsOnMemory {no=134,vertex1=22,vertex2=21,distance= 0.65},
              new AdjacentsOnMemory {no=135,vertex1=22,vertex2=23,distance=0.9 },
              new AdjacentsOnMemory {no=136,vertex1=22,vertex2=20,distance=0.3 },
               new AdjacentsOnMemory {no=137,vertex1=22,vertex2=14,distance=0.4 },


              new AdjacentsOnMemory {no=138,vertex1=23,vertex2=22,distance=0.9},

            new AdjacentsOnMemory {no=139,vertex1=23,vertex2=16,distance=0.6 },
           new AdjacentsOnMemory {no=140,vertex1=23,vertex2=24,distance=0.2 },
           new AdjacentsOnMemory {no=141,vertex1=23,vertex2=26,distance=0.65 },

           new AdjacentsOnMemory {no=142,vertex1=24,vertex2=23,distance=0.2 },
           new AdjacentsOnMemory {no=143,vertex1=24,vertex2=25,distance=0.11 },
           new AdjacentsOnMemory {no=144,vertex1=24,vertex2=26,distance=0.65 },

           new AdjacentsOnMemory {no=145,vertex1=25,vertex2=24,distance=0.11},
           new AdjacentsOnMemory {no=146,vertex1=25,vertex2=17,distance=0.17 },
           new AdjacentsOnMemory {no=147,vertex1=25,vertex2=16,distance=0.6 },


           new AdjacentsOnMemory {no=148,vertex1=26,vertex2=19,distance=0.6 },
           new AdjacentsOnMemory {no=149,vertex1=26,vertex2=24,distance=0.65 },
           new AdjacentsOnMemory {no=150,vertex1=26,vertex2=23,distance=0.65 },
             new AdjacentsOnMemory {no=151,vertex1=26,vertex2=18,distance=0.35 }



        };

        #endregion

        public List<Vertex> GetVertices()
        {
            var vertices = _context.Vertices.ToList();
            return vertices;
        }
        //public List<Adjacent> GetAdjacents()
        //{
        //    return _context.Adjacents.ToList();
        //}
        public double GetDistance(int i, int j)
        {
            var aviableAdjacents = adjacents
                .Where(a => a.vertex1 == i + 1 || a.vertex2 == i + 1).ToList();
            var adjacent = aviableAdjacents
                .Where(a => a.vertex1 == j + 1 || a.vertex2 == j + 1)
                .Select(a => a)
                .FirstOrDefault();

            return adjacent != null ? adjacent.distance : 999;

        }
        public ResultInfoForJson FloydWarshall(int sourceId,int destinationId)
        {
            List<Vertex> path = new List<Vertex>();
            var verticesCount = _context.Vertices.ToList().Count;
            double[,] distance = new double[verticesCount, verticesCount];
            int[,] vor = new int[verticesCount, verticesCount];

            Stopwatch w = new Stopwatch();
            w.Start();
            #region initialized
            for (int i = 0; i < verticesCount; ++i)
                for (int j = 0; j < verticesCount; ++j)
                {
                    distance[i, j] = i == j ? 0 : GetDistance(i, j);
                    if (distance[i, j] != 999) vor[i, j] = j;
                    else vor[i, j] = 0;
                }
            #endregion
            
            #region Floyd
            for (int k = 0; k < verticesCount; ++k)
            {
                for (int i = 0; i < verticesCount; ++i)
                {
                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                            vor[i, j] = vor[i, k];
                        }
                           
                    }
                }
            }
            #endregion

            w.Stop();
            long time = w.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
         
            #region path

            var startVertex = _context.Vertices.Where(v => v.id == sourceId).FirstOrDefault();
            path.Add(startVertex);

            var source = sourceId - 1;
            var destination = destinationId - 1;
            
            while (source != destination)
            {
                source = vor[source, destination];
                var vertex = _context.Vertices.Where(v => v.id == source + 1).FirstOrDefault();
                path.Add(vertex);
            }
            #endregion
           
            #region totalDistance
            double totalDistance =0;
            double total = 0;
            List<int> pathId = new List<int>();
            pathId = path.Select(p => p.id).ToList();
           
            for (int i = 0; i < path.Count-1; i++)
            {
                var u = pathId[i];
                var v = pathId[i+1];
                totalDistance += distance[u-1,v-1];
                total = Math.Round(totalDistance, 3);
            }
            #endregion
            var model = new ResultInfoForJson()
            {
                Path = path,
                TimeComplexcity = time,
                TotalDistance = total,
                Str = ""
            };
            return model;
        }
        //void Print(double[,] distance,int N)
        //{
        //    int i, j;
        //    string[] name = _context.Vertices.Select(v=>v.name).ToArray();
        //    string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
        //    using (FileStream fs = new FileStream(path+"/mindist1.txt", FileMode.Create))
        //    {
        //        using (BinaryWriter writer = new BinaryWriter(fs))
        //        {
        //            writer.Write("\n\n Minimum Distance Matrix \n");
        //            writer.Write("\t\t");
        //            for (i = 1; i <= N; i++)
        //                writer.Write(i.ToString().PadRight(8) + "\t");
        //            writer.Write("\n\n");
        //            writer.Write("\t\t");
        //            for (i = 0; i < N; i++)
        //                writer.Write(name[i].PadRight(8) + "\t");
                    
                        
        //            writer.Write("\n\n");
        //            for (i = 1; i < N; i++)
        //            {
        //                writer.Write(i.ToString().PadRight(4) + "\t" + name[i] + "\t");
        //                for (j = 1; j < N; j++)
        //                    writer.Write(distance[i, j].ToString().PadRight(8) + distance[i, j] + "\t");
        //                writer.Write("\n");
        //                writer.Write("\n\n");
        //            }

        //        }
        //    }

        //}

    }
}