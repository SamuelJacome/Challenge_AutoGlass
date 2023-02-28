using System.Threading.Tasks;
using AutoGlass.Domain.Models;
using System.Collections.Generic;
using AutoGlass.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoGlass.Infrastructure.Data.Context;

namespace AutoGlass.Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AutoGlassContext _db;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(AutoGlassContext db)
        {
            _db = db;
            _dbSet = _db.Set<Product>();
        }
        public async Task<IEnumerable<Product>> GetAll() =>
            await _dbSet.ToListAsync();

        public async Task<Product> GetById(int id) =>
            await _dbSet.FirstAsync(_ => _.Id == id);

        public void Insert(Product product) =>
            _dbSet.Add(product);

        public void Update(Product product) =>
            _dbSet.Update(product);
        public async Task<bool> Commit() =>
            await _db.Commit();

        public void Dispose() =>
            _db.Dispose();
    }
}