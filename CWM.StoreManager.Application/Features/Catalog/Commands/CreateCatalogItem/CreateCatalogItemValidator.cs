using CWM.StoreManager.Application.Abstractions.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CWM.StoreManager.Application.Features.Catalog.Commands.CreateCatalogItem
{
    public class CreateCatalogItemValidator : AbstractValidator<CreateCatalogItemCommand>
    {
        private readonly ICatalogContext _catalogContext;

        public CreateCatalogItemValidator(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");

        }

        private async Task<bool> IsUniqueBarcode(string barcode, CancellationToken cancellationToken)
        {
            return await _catalogContext.CatalogItems.AllAsync(a => a.Name != barcode);
        }
    }
}
