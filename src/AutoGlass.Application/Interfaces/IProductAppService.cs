using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Collections.Generic;
using AutoGlass.Application.ViewModels;

namespace AutoGlass.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        Task<ValidationResult> Insert(ProductViewModel model);
        Task<ValidationResult> Update(ProductViewModel model);
        Task<bool> Remove(int id);
    }
}