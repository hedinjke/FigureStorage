﻿// <auto-generated />
using FigureStorage.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FigureStorage.API.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FigureStorage.Models.Figure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Figures");
                });

            modelBuilder.Entity("FigureStorage.Models.Rectangle", b =>
                {
                    b.HasBaseType("FigureStorage.Models.Figure");

                    b.Property<double>("Radius")
                        .HasColumnType("REAL");

                    b.ToTable("Rectangles");
                });

            modelBuilder.Entity("FigureStorage.Models.Triangle", b =>
                {
                    b.HasBaseType("FigureStorage.Models.Figure");

                    b.Property<double>("SideA")
                        .HasColumnType("REAL");

                    b.Property<double>("SideB")
                        .HasColumnType("REAL");

                    b.Property<double>("SideC")
                        .HasColumnType("REAL");

                    b.ToTable("Triangles");
                });

            modelBuilder.Entity("FigureStorage.Models.Rectangle", b =>
                {
                    b.HasOne("FigureStorage.Models.Figure", null)
                        .WithOne()
                        .HasForeignKey("FigureStorage.Models.Rectangle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FigureStorage.Models.Triangle", b =>
                {
                    b.HasOne("FigureStorage.Models.Figure", null)
                        .WithOne()
                        .HasForeignKey("FigureStorage.Models.Triangle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
