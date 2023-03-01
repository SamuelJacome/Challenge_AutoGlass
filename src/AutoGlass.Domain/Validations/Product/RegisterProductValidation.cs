
namespace AutoGlass.Domain.Validations
{
    public class RegisterProductValidation : ProductValidation
    {
        public RegisterProductValidation()
        {
            ValidateIdRegisterProduct();
            ValidateDescription();
            ValidateProductionDate();
            ValidateExpirationDate();
            // ValidateSupplierValidation();
        }
    }
}