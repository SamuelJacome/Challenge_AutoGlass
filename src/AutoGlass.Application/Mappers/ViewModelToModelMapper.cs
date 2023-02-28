using AutoGlass.Application.ViewModels;
using AutoGlass.Domain.Models;
using AutoMapper;

namespace AutoGlass.Application.Mappers
{
    public class ViewModelToModelMapper : Profile
    {
        public ViewModelToModelMapper()
        {
            CreateMap<ProductViewModel, Product>()
                    .ConstructUsing(_ => new Product(
                        _.Id,
                        _.Description,
                        _.IsActive,
                        _.ProductionDate,
                        _.ExpirationDate,
                        _.SupplierId,
                        _.Removed
                    ));

            CreateMap<SupplierViewModel, Supplier>()
                  .ConstructUsing(_ => new Supplier(
                      _.Id,
                      _.Description,
                      _.Cnpj,
                      _.Removed
                  ));
        }
    }
}