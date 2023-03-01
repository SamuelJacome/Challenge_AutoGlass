using AutoGlass.Application.Services;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.Repositories;
using AutoGlass.Domain.Validations;
using AutoMapper;
using Moq;
using Xunit;

namespace AutoGlass.Tests.ModelsTests
{
    public class ProductControllerTests
    {
        private RegisterProductValidation RegisterValidator { get; }
        private UpdateProductValidation UpdateValidator { get; }
        public ProductControllerTests()
        {
            RegisterValidator = new RegisterProductValidation();
            UpdateValidator = new UpdateProductValidation();
            _productAppService = new ProductAppService(new Mock<IProductRepository>().Object, new Mock<IMapper>().Object);
        }
        private ProductAppService _productAppService;
        private readonly Product _product = new Product(5, "Monitor 144hz AoC", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(10), 2);


        [Fact]
        public void tentativa_de_registro_de_produto_passando_um_id_diferente_de_zero_deve_ser_inválido()
        {
            Assert.False(RegisterValidator.Validate(_product).IsValid);
        }
        [Fact]
        public void Dado_um_novo_produto_o_mesmo_nao_pode_ser_inativo()
        {
            Assert.True(_product.IsActive);
        }

        [Fact]
        public void Dado_um_novo_produto_o_mesmo_nao_pode_ser_como_removido()
        {
            Assert.False(_product.Removed);
        }

        [Fact]
        public void Dado_um_produto_com_data_de_fabricacao_maior_que_a_data_de_validade_deve_ser_invalido()
        {
            Product _dateExperitationLessThanDateProduction = new Product(0, "Monitor 144hz AoC 29 pol", DateTime.Now.AddDays(10), DateTime.Now.AddDays(-3), 2);
            Assert.False(RegisterValidator.Validate(_dateExperitationLessThanDateProduction).IsValid);
        }

        [Fact]
        public void Dado_um_produto_com_a_descricao_vazia_deve_ser_invalido()
        {
            Product _productWithOutDescription = new Product(0, "", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(10), 2);
            Assert.False(RegisterValidator.Validate(_productWithOutDescription).IsValid);
        }

        [Fact]
        public void Dado_um_produto_sem_fornecedor_deve_ser_invalido()
        {
            Product _productWithOutSupplier = new Product(0, "Mouse gamer", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(10), 0);
            Assert.False(UpdateValidator.Validate(_productWithOutSupplier).IsValid);
        }
    }
}