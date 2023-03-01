using System;
using FluentValidation;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.Validations.Utils;

namespace AutoGlass.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {

        protected void ValidateId()
        {
            RuleFor(_ => _.Id)
                .NotEqual(0).WithMessage("Código identificador do produto foi perdido");
        }
        protected void ValidateIdRegisterProduct()
        {
            RuleFor(_ => _.Id)
                .Equal(0).WithMessage("Código identificador deve ser 0");
        }
        protected void ValidateDescription()
        {
            RuleFor(_ => _.Description)
                .NotNull().WithMessage("Entre com a descrição do produto")
                .NotEmpty().WithMessage("Entre com a descrição do produto")
                .MaximumLength(200).WithMessage("Descrição deve ter até 200 caracteres");
        }
        protected void ValidateProductionDate()
        {
            RuleFor(_ => _.ProductionDate)
                .NotNull().WithMessage("Entre com a data de fabricação")
                .Must(BeAValidDate).WithMessage("Data de fabricação inválida")
                .LessThanOrEqualTo(_ => _.ExpirationDate).WithMessage("Data de fabricação não pode ser maior ou igual à data de validade.");
        }
        protected void ValidateExpirationDate()
        {
            RuleFor(_ => _.ExpirationDate)
                .NotNull().WithMessage("Entre com a data de validade")
                .Must(BeAValidDate).WithMessage("Data de validade inválida");
        }
        protected void ValidateSupplierId()
        {
            RuleFor(_ => _.SupplierId)
                            .NotEqual(0).WithMessage("Código do fornecedor foi perdido");
        }
        protected void ValidateSupplierValidation()
        {
            RuleFor(_ => _.Supplier.Description)
                .NotNull().WithMessage("Entre com a descrição do fornecedor")
                .NotEmpty().WithMessage("Entre com a descrição do fornecedor")
                .MaximumLength(200).WithMessage("Descrição deve ter até 200 caracteres");

            RuleFor(_ => _.Supplier.Cnpj.Length).Equal(ValidateCnpj.LengthCnpj)
                    .WithMessage("O campo Cnpj do fornecedor precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(_ => ValidateCnpj.Validate(_.Supplier.Cnpj)).Equal(true)
                    .WithMessage("O Cnpj fornecido é inválido.");
        }
        protected bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}