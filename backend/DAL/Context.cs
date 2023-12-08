using CodeRoute.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeRoute.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
            Database.EnsureDeleted();
            Database.Migrate();
            
            if (Routes.Count() == 0)
            {
                this.AddAllPresets();
                this.SaveChanges();
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoute>().HasKey(ur => new { ur.UserId, ur.RouteId });
            modelBuilder.Entity<RelatedRoutes>().HasKey(ur => new { ur.CurrentRouteId, ur.RelatedRouteId });
            modelBuilder.Entity<UserVertex>().HasKey(ur => new { ur.UserId, ur.VertexId });
            modelBuilder.Entity<VertexConnection>().HasKey(ur => new { ur.CurrentVertexId, ur.PreviousVertexId });
            modelBuilder.Entity<DirectionRoute>().HasKey(dr => new { dr.DirectionId, dr.RouteId });


            modelBuilder.Entity<Models.Route>().HasAlternateKey(r => r.Title);
            //modelBuilder.Entity<VertexStatus>().Property(p => p.StatusDescription).IsRequired(false);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.Route> Routes { get; set; }
        public DbSet<UserRoute> UserRoutes { get; set; }
        public DbSet<RouteStatus> RouteStatuses { get; set; }
        public DbSet<RelatedRoutes> RelatedRoutes { get; set; }
        public DbSet<UserVertex> UserVertexes { get; set; }
        public DbSet<Vertex> Vertexes { get; set; }
        public DbSet<VertexStatus> VertexStatuses { get; set; }
        public DbSet<VertexConnection> VertexConnections { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<DirectionRoute> DirectionRoutes { get; set; }
    }
}
