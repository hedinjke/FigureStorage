using FigureStorage.Models;
using Microsoft.EntityFrameworkCore;

namespace FigureStorage.Repo
{
    public class RepositoryContext : DbContext
    {
        protected RepositoryContext()
        {
        }

        internal RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Figure> Figures { get; set; }
        public DbSet<Rectangle> Rectangles { get; set; }
        public DbSet<Triangle> Triangles { get; set; }
    }
}