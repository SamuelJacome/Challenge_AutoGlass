using System.Collections.Generic;
using System.Threading.Tasks;
using AutoGlass.Domain.Models;

namespace AutoGlass.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        void Insert(Supplier supplier);
        void Update(Supplier supplier);
        Task<bool> Commit();
    }
}