using System;
using System.Linq;
using AutoGlass.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoGlass.Infrastructure.Data.Context
{
    public class AutoGlassContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data source=(localdbAutoGlass)\\mssqllocaldb; Initial Catalog=C002;Integrated Security=true;pooling=true;";
            optionsBuilder
               .UseSqlServer(strConnection)
               .EnableSensitiveDataLogging()
               .LogTo(Console.WriteLine, LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                _ => _.GetProperties().Where(p => p.ClrType == typeof(string))
            ))
                property.SetColumnType("varchar(200)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(_ => _.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }
}