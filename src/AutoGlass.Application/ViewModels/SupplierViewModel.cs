using System;

namespace AutoGlass.Application.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Cnpj { get; set; }
        public bool Removed { get; set; }

    }
}