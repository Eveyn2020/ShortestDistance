namespace ShortestDistance.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MapData : DbContext
    {
        public MapData()
            : base("name=MapData")
        {
        }

        public virtual DbSet<Vertex> Vertices { get; set; }
        public virtual DbSet<Adjacent> Adjacents { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
