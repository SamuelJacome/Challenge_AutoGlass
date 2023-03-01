using AutoGlass.Application.ViewModels;
using AutoGlass.Domain.Models;
using AutoMapper;

namespace AutoGlass.Application.Mappers
{
    public class ModelToViewModelMapper : Profile
    {
        public ModelToViewModelMapper()
        {

            CreateMap<Product, ProductViewModel>()
            .ConstructUsing(_ => new ProductViewModel
            {
                Id = _.Id,
                Description = _.Description,
                IsActive = _.IsActive,
                ProductionDate = _.ProductionDate,
                ExpirationDate = _.ExpirationDate,
                SupplierId = _.SupplierId,
                Removed = _.Removed
            });

            CreateMap<Supplier, SupplierViewModel>()
           .ConstructUsing(_ => new SupplierViewModel
           {
               Id = _.Id,
               Description = _.Description,
               Cnpj = _.Cnpj,
               Removed = _.Removed
           });

        }
    }
}