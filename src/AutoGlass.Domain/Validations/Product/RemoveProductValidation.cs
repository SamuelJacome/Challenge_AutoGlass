using System;
using FluentValidation;
using AutoGlass.Domain.Models;

namespace AutoGlass.Domain.Validations
{
    public class RemoveProductValidation : ProductValidation
    {
        public RemoveProductValidation()
        {
            ValidateId();
        }
    }
}