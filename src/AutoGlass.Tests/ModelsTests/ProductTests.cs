

using AutoGlass.Domain.Models;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoGlass.Tests.ModelsTests
{
    [TestClass]
    public class ProductTests
    {
        private readonly Product _product = new Product(7, "Monitor 144hz AoC", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(10), 2);


        [TestMethod]
        public void Dado_um_novo_produto_o_mesmo_nao_pode_ser_inativo()
        {
            Assert.AreEqual(_product.IsActive, true);
        }

        [TestMethod]
        public void Dado_um_novo_produto_o_mesmo_nao_pode_ser_como_removido()
        {
            Assert.AreEqual(_product.Removed, false);
        }

        [TestMethod]
        public void Dado_um_produto_com_data_de_fabricacao_maior_que_a_data_de_validade_deve_ser_invalido()
        {
            Product _dateExperitationLessThanDateProduction = new Product(7, "Monitor 144hz AoC 29 pol", DateTime.Now.AddDays(10), DateTime.Now.AddDays(-3), 2);

            Assert.AreEqual(_dateExperitationLessThanDateProduction.IsValid().IsValid, true);
        }

        [TestMethod]
        public void Dado_um_produto_com_a_descricao_nula_deve_ser_inválido()
        {
            Product _productWithOutDescription = new Product(8, "", true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(10), 0, false);
            Assert.AreEqual(_product.IsValid().IsValid, false);
        }

        [TestMethod]
        public void Dado_um_produto_sem_fornecedor_deve_ser_inválido()
        {
            Product _productWithOutSupplier = new Product(8, "Mouse gamer", true, DateTime.Now.AddDays(-2), DateTime.Now.AddDays(10), 0, false);
            Assert.AreEqual(_productWithOutSupplier.IsValid().IsValid, false);
        }

    }
}