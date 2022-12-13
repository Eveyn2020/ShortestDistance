namespace ShortestDistance.Models
{
    using System;
    //using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    ////using System.Data.Entity.Spatial;

    [Table("Vertex")]
    public partial class Vertex
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        public double lat { get; set; }

        public double lng { get; set; }
       // public List<Vertex> Vertices { get; set; } = new List<Vertex>();
    }
}
