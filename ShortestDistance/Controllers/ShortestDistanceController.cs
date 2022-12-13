using ShortestDistance.Models;
using ShortestDistance.Services;
using ShortestDistance.VewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace ShortestDistance.Controllers
{ 
    public class ShortestDistanceController : Controller
    {
        private readonly FloydService _service = new FloydService();
        private readonly DijkstraService _dijkstraService = new DijkstraService();
        private readonly BellmanFordService _bellmanService = new BellmanFordService();
        // GET: ShortestDistance
        long floydTime;
        long dijkTime;
        long bellmanTime;
       
        public ActionResult Index()
        {
            var vertices = _service.GetVertices();
            var viewModel = new CompareInfoViewModel { Vertices = vertices };
            return View(viewModel);
        }
        public JsonResult GetPath(int SourceId,int DestinationId)
        {
            var Path=_service.FloydWarshall(SourceId, DestinationId);
            floydTime = Path.TimeComplexcity;
            return Json(Path, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPathDijkstra(int SourceId,int DestinationId)
        {
            var Path = _dijkstraService.Dijkstra(SourceId, DestinationId);
            dijkTime = Path.TimeComplexcity;
            return Json(Path, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPathBellman(int SourceId, int DestinationId)
        {
            var Path = _bellmanService.BellManFord(SourceId, DestinationId);
            bellmanTime = Path.TimeComplexcity;
            return Json(Path, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNodeInfo()
        {
            List<Vertex> makers =_service.GetVertices();
            return Json(makers, JsonRequestBehavior.AllowGet);

        }

        //public List<Graph> GetTimeComplex()
        //{
        //    //List<long> getTimes = new List<long>();
        //    //getTimes.Add(floydTime);
        //    //getTimes.Add(dijkTime);
        //    //getTimes.Add(bellmanTime);
        //    //return getTimes;
        //    List<Graph> graph = new List<Graph>
        //    {
        //        new Graph { Time = floydTime,Name="Floyd" },
        //        new Graph { Time = dijkTime,Name="Dijkstra" },
        //        new Graph { Time = bellmanTime,Name="Bellman" },

        //    };
        //    return graph;
         
        //}
        //public ActionResult GetChart()
        //{
        //    long Floyd = floydTime;
        //    long Dijkstra = dijkTime;
        //    long Bellman = bellmanTime;

        //    new Chart(width: 300, height: 400)
        //        .AddSeries(
        //        chartType: "column",
        //        xValue: new[] { "Floyd", "Dijkstra", "Bellman" },
        //        yValues: new[] { Floyd, Dijkstra, Bellman }
        //        ).Write("png");
        //    return null;
        //}
        //public ActionResult Chart()
        //{
        //    return Json(GetTimeComplex(), JsonRequestBehavior.AllowGet);
        //}

    }
}
