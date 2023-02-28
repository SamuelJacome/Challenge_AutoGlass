using AutoGlass.Domain.Validations;
using FluentValidation.Results;
using System.Collections.Generic;

namespace AutoGlass.Domain.Models
{
    public class Supplier : Entity
    {
        public string Description { get; private set; }
        public string Cnpj { get; private set; }
        public virtual IEnumerable<Product> Products { get; set; }
        protected Supplier() { }
        public Supplier(int id,
                        string description,
                        string cnpj,
                        bool removed)
        {
            Id = id;
            Description = description;
            Cnpj = cnpj;
            Removed = removed;
        }
        public ValidationResult IsValid() =>
           new SupplierValidation().Validate(this);
    }
}