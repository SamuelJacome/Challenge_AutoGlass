using System;
using FluentValidation.Results;
using AutoGlass.Domain.Validations;

namespace AutoGlass.Domain.Models
{
    public class Product : Entity
    {
        public string Description { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public int SupplierId { get; private set; }
        public virtual Supplier Supplier { get; set; }

        protected Product() { }
        public Product(int id,
                        string description,
                        bool isActive,
                        DateTime productionDate,
                        DateTime expirationDate,
                        int supplierId,
                        bool removed)
        {
            Id = id;
            Description = description;
            IsActive = isActive;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            SupplierId = supplierId;
            Removed = removed;
        }

        public Product(int id,
                       string description,
                       DateTime productionDate,
                       DateTime expirationDate,
                       int supplierId
                       )
        {
            Id = id;
            Description = description;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            SupplierId = supplierId;
            IsActive = true;
        }

        public void SetRemoved(bool removed) =>
            Removed = removed;

        public ValidationResult IsValid() =>
            new ProductValidation().Validate(this);
    }
}