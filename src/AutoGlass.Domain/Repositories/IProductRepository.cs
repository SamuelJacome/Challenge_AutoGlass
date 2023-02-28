using System.Collections.Generic;
using System.Threading.Tasks;
using AutoGlass.Domain.Models;

namespace AutoGlass.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        void Insert(Product product);
        void Update(Product product);
        Task<bool> Commit();
    }
}