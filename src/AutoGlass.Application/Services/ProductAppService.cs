using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoGlass.Application.Interfaces;
using AutoGlass.Application.ViewModels;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.Repositories;
using AutoMapper;
using FluentValidation.Results;

namespace AutoGlass.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductAppService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductViewModel>> GetAll(int skip, int take) =>
            _mapper.Map<IEnumerable<ProductViewModel>>(
                await _productRepository.GetAll(skip, take)
            );

        public async Task<ProductViewModel> GetById(int id) =>
         _mapper.Map<ProductViewModel>(
                await _productRepository.GetById(id)
            );

        public async Task<ValidationResult> Insert(ProductViewModel model)
        {

            var product = _mapper.Map<Product>(model);

            var validationResult = product.RegisterModelIsValid();

            if (validationResult.IsValid)
            {
                _productRepository.Insert(product);

                if (!await _productRepository.Commit())
                    throw new Exception("Não foi possível gravar as alterações");
            }

            return validationResult;
        }

        public async Task<ValidationResult> Update(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model);

            var validationResult = product.UpdateModelIsValid();

            if (validationResult.IsValid)
            {
                _productRepository.Update(product);

                if (!await _productRepository.Commit())
                    throw new Exception("Não foi possível gravar as alterações");
            }

            return validationResult;
        }
        public async Task<bool> Remove(int id)
        {
            var product = await _productRepository.GetById(id);
            product.SetRemoved(true);

            _productRepository.Update(product);

            if (!await _productRepository.Commit())
                return false;

            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}