using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Collections.Generic;
using AutoGlass.Application.ViewModels;

namespace AutoGlass.Application.Interfaces
{
    public interface ISupplierAppService : IDisposable
    {
        Task<IEnumerable<SupplierViewModel>> GetAll();
        Task<ValidationResult> Insert(SupplierViewModel model);
        Task<ValidationResult> Update(SupplierViewModel model);
        Task<bool> Remove(Guid id);
    }
}