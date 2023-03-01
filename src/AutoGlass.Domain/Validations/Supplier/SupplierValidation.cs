using FluentValidation;
using AutoGlass.Domain.Models;
using AutoGlass.Domain.Validations.Utils;

namespace AutoGlass.Domain.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {

            RuleFor(_ => _.Description)
                .NotNull().WithMessage("Entre com a descrição do fornecedor")
                .NotEmpty().WithMessage("Entre com a descrição do fornecedor")
                .MaximumLength(200).WithMessage("Descrição deve ter até 200 caracteres");

            RuleFor(_ => _.Cnpj.Length).Equal(ValidateCnpj.LengthCnpj)
                    .WithMessage("O campo Cnpj do fornecedor precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(_ => ValidateCnpj.Validate(_.Cnpj)).Equal(true)
                    .WithMessage("O Cnpj fornecido é inválido.");
        }

    }
}