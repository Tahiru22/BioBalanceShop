using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Home;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;
        private readonly IShopService _shopService;

        public ProductService(
            IRepository repository,
            IShopService shopService)
        {
            _repository = repository;
            _shopService = shopService;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.AllReadOnly<Product>()
                .AnyAsync(p => p.Id == id);
        }

        public async Task<ProductQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, ProductSorting sorting = ProductSorting.Newest, int currentPage = 1, int productsPerPage = 1)
        {
            var productsToShow = _repository.AllReadOnly<Product>()
                .Where(p => p.Quantity > 0);

            if (category != null)
            {
                productsToShow = productsToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                productsToShow = productsToShow
                    .Where(p => (p.Title.ToLower().Contains(normalizedSearchTerm) ||
                                p.Subtitle.ToLower().Contains(normalizedSearchTerm) ||
                                p.Description.ToLower().Contains(normalizedSearchTerm) ||
                                p.Ingredients.ToLower().Contains(normalizedSearchTerm)));
            }

            productsToShow = sorting switch
            {
                ProductSorting.Newest => productsToShow
                  .OrderByDescending(p => p.Id),
                ProductSorting.PriceAscending => productsToShow
                    .OrderBy(p => p.Price),
                ProductSorting.PriceDescending => productsToShow
                    .OrderByDescending(p => p.Price),
                _ => productsToShow
                    .OrderByDescending(p => p.Id)
            };

            var products = await productsToShow
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ProjectToProductServiceModel()
                .ToListAsync();

            int totalProducts = await productsToShow.CountAsync();

            var currency = await _shopService.GetShopCurrency();

            foreach (var prod in products)
            {
                prod.Currency = currency;
            }

            return new ProductQueryServiceModel()
            {
                Products = products,
                TotalProductsCount = totalProducts
            };
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<CategoryAllServiceModel>> AllCategoriesAsync()
        {
            return await _repository.AllReadOnly<Category>()
               .Select(c => new CategoryAllServiceModel()
               {
                   Id = c.Id,
                   Name = c.Name,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            return await _repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<ProductDetailsServiceModel?> GetProductByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Product>()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Subtitle = p.Subtitle,
                    Description = p.Description,
                    Ingredients = p.Ingredients,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    QuantityToOrder = 1,
                    QuantityInStock = p.Quantity,
                    CurrencySymbol = p.Shop.Currency.Symbol,
                    CurrencyIsSymbolPrefix = p.Shop.Currency.IsSymbolPrefix
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HomeIndexProductModel>> GetLastFiveProductsAsync()
        {
            return await _repository
                .AllReadOnly<Product>()
                .Where(p => p.Quantity > 0)
                .OrderByDescending(p => p.Id)
                .Take(5)
                .Select(p => new HomeIndexProductModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Subtitle = p.Subtitle,
                    ImageUrl = p.ImageUrl,
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateProductQuantityInStock(int productId, int orderedQuantity)
        {
            var productToUpdate = await _repository.GetByIdAsync<Product>(productId);

            if (orderedQuantity > productToUpdate.Quantity)
            {
                return false;
            }

            productToUpdate.Quantity -= orderedQuantity;
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
