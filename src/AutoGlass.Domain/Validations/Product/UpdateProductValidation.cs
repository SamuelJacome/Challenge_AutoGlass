
namespace AutoGlass.Domain.Validations
{
    public class UpdateProductValidation : ProductValidation
    {
        public UpdateProductValidation()
        {
            ValidateId();
            ValidateDescription();
            ValidateProductionDate();
            ValidateExpirationDate();
            // ValidateSupplierValidation();
            ValidateSupplierId();
        }
    }
}