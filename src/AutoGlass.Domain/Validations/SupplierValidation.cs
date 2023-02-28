using FluentValidation;
using AutoGlass.Domain.Models;

namespace AutoGlass.Domain.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public void ValidateId()
        {
            RuleFor(_ => _.Id)
                .NotEqual(0).WithMessage("Código identificador do fornecedor foi perdido");
        }
        public void ValidateDescription()
        {
            RuleFor(_ => _.Description)
                .NotEmpty().WithMessage("Entre com a descrição do fornecedor")
                .MaximumLength(200).WithMessage("Descrição deve ter até 200 caracteres");
        }
        public void ValidateCnpj()
        {
            RuleFor(_ => _.Cnpj)
                .NotEmpty().WithMessage("Entre com o Cnpj")
                .Length(14).WithMessage("Cnpj incompleto");
        }
    }
}