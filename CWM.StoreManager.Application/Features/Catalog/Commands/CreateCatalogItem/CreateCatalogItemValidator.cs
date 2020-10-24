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
                .MustAsync(IsUniqueName).WithMessage("{PropertyName} already exists.");
            RuleFor(p => p.Description)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.CatalogBrandId)
                .NotNull()
                .MustAsync(BrandExists).WithMessage("{PropertyName} does not exist.");
            RuleFor(p => p.CatalogTypeId)
               .NotNull()
               .MustAsync(TypeExists).WithMessage("{PropertyName} does not exist.");

        }

        private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _catalogContext.CatalogItems.AllAsync(a => a.Name != name);
        }
        private async Task<bool> BrandExists(int brandId, CancellationToken cancellationToken)
        {
            return await _catalogContext.CatalogBrands.AnyAsync(a => a.Id == brandId);
        }
        private async Task<bool> TypeExists(int typeId, CancellationToken cancellationToken)
        {
            return await _catalogContext.CatalogTypes.AnyAsync(a => a.Id == typeId);
        }
    }
}
