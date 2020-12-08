using System;
using System.Linq;
using FigureStorage.Models;
using FigureStorage.Repo;
using Microsoft.EntityFrameworkCore;

namespace TestDrive.Db
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=figure.db";
            var factory = new RepositoryContextFactory(builder => builder.UseSqlite(connectionString));
            using var context = factory.CreateDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Rectangles.Add(new Rectangle(10));
            context.Rectangles.Add(new Rectangle(6.2));
            context.Rectangles.Add(new Rectangle(1));
            context.Triangles.Add(new Triangle(10, 5,7));
            context.Triangles.Add(new Triangle(10, 5,8));
            context.Triangles.Add(new Triangle(8, 5,6));
            context.Triangles.Add(new Triangle(5, 5,6));
    

            context.SaveChanges();

            var figures = context.Figures.ToList();
            foreach (var figure in figures)
            {
                Console.WriteLine(figure.Area);
            }

            Console.ReadLine();
        }
    }
}