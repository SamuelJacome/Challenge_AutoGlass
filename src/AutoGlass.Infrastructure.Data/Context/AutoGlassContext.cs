using System;
using System.Linq;
using System.Threading.Tasks;
using AutoGlass.Domain.Models;
using AutoGlass.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoGlass.Infrastructure.Data.Context
{
    public class AutoGlassContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public AutoGlassContext(DbContextOptions<AutoGlassContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
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

            modelBuilder.Entity<Product>().HasQueryFilter(_ => !_.Removed);
        }
        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }
}