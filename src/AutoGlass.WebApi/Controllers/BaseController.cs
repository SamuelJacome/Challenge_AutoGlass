using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();
        protected IActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> {
            { "messages", _errors.ToArray() }
        }));
        }
        protected IActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected bool IsOperationValid() =>
            !_errors.Any();

        protected void AddError(string error) =>
            _errors.Add(error);
    }
}