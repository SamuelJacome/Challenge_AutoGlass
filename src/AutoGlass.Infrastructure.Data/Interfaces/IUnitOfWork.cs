using System.Threading.Tasks;

namespace AutoGlass.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}