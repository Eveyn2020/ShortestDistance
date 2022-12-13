using ShortestDistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestDistance.VewModels
{
    public class CompareInfoViewModel
    {
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();           
        public List<Coordinate> CoordinatePoints { get; set; } = new List<Coordinate>();
    }
}