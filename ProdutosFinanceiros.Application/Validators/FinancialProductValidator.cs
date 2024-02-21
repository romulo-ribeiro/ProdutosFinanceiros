﻿using FluentValidation;
using ProdutosFinanceiros.Domain;

namespace ProdutosFinanceiros.Application.Validators;

public class FinancialProductValidator : AbstractValidator<FinancialProduct>, IValidator<FinancialProduct>
{
    public FinancialProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Type is required");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Invalid Type");

        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage("Value is required");

        RuleFor(x => x.Value)
            .GreaterThan(0m)
            .WithMessage("Value is invalid");
    }
}
