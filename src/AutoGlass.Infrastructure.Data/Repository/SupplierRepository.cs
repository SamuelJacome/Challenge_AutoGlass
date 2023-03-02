using System.Collections.Generic;
using System.Threading.Tasks;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.Repositories;
using AutoGlass.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.Infrastructure.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AutoGlassContext _db;
        private readonly DbSet<Supplier> _dbSet;

        public SupplierRepository(AutoGlassContext db)
        {
            _db = db;
            _dbSet = _db.Set<Supplier>();
        }

        public async Task<IEnumerable<Supplier>> GetAll() =>
            await _dbSet.ToListAsync();

        public async Task<Supplier> GetById(int id) =>
            await _dbSet.FirstAsync(_ => _.Id == id);

        public void Insert(Supplier supplier) =>
            _dbSet.Add(supplier);

        public void Update(Supplier supplier) =>
            _dbSet.Update(supplier);

        public async Task<bool> Commit() =>
             await _db.Commit();

        public void Dispose() =>
                  _db.Dispose();
    }
}