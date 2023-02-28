using System;

namespace AutoGlass.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierId { get; set; }
        public bool Removed { get; set; }
        public virtual SupplierViewModel Supplier { get; set; }
    }
}