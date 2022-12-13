using ShortestDistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShortestDistance.VewModels
{
    public class ResultInfoForJson
    {
        public List<Vertex> Path { get; set; } = new List<Vertex>();
        public long TimeComplexcity { get; set; }
        public double TotalDistance { get; set; }
        public string Str { get; set; }
    }
}