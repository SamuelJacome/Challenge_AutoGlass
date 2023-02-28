using System;
using FluentValidation;
using AutoGlass.Domain.Models;

namespace AutoGlass.Domain.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public void ValidateId()
        {
            RuleFor(_ => _.Id)
                .NotEqual(0).WithMessage("Código identificador do produto foi perdido");
        }
        public void ValidateDescription()
        {
            RuleFor(_ => _.Description)
                .NotEmpty().WithMessage("Entre com a descrição do produto")
                .MaximumLength(200).WithMessage("Descrição deve ter até 200 caracteres");
        }
        public void ValidateProductionDate()
        {
            RuleFor(_ => _.ProductionDate)
                .NotNull().WithMessage("Entre com a data de fabricação")
                .Must(BeAValidDate).WithMessage("Data de fabricação inválida");
        }
        public void ValidateExpirationDate()
        {
            RuleFor(_ => _.ExpirationDate)
                .NotNull().WithMessage("Entre com a data de validade")
                .Must(BeAValidDate).WithMessage("Data de validade inválida");
        }
        public void ValidateSupplierId()
        {
            RuleFor(_ => _.SupplierId)
                .NotEqual(0).WithMessage("Código do fornecedor foi perdido");
        }
        protected bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}