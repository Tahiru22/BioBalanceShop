using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.Product;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class AdminProductService : IAdminProductService
    {
        private readonly IRepository _repository;
        private readonly IShopService _shopService;
        private readonly IProductService _productService;

        public AdminProductService(
            IRepository repository,
            IShopService shopService,
            IProductService productService)
        {
            _repository = repository;
            _shopService = shopService;
            _productService = productService;
        }


        public async Task<AdminProductQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, AdminProductSorting sorting = AdminProductSorting.Newest, int currentPage = 1, int productsPerPage = 1)
        {
            var productsToShow = _repository.AllReadOnly<Product>();

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
                                p.Ingredients.ToLower().Contains(normalizedSearchTerm) ||
                                p.ProductCode.ToLower().Contains(normalizedSearchTerm)));
            }

            productsToShow = sorting switch
            {
                AdminProductSorting.Newest => productsToShow
                    .OrderByDescending(p => p.Id),
                AdminProductSorting.Oldest => productsToShow
                .OrderBy(p => p.Id),
                AdminProductSorting.PriceAscending => productsToShow
                    .OrderBy(p => p.Price),
                AdminProductSorting.PriceDescending => productsToShow
                    .OrderByDescending(p => p.Price),
                AdminProductSorting.QuantityAscending => productsToShow
                    .OrderBy(p => p.Quantity),
                AdminProductSorting.QuantityDescending => productsToShow
                    .OrderByDescending(p => p.Quantity),
                AdminProductSorting.ProductNameAscending => productsToShow
                    .OrderBy(p => p.Title),
                AdminProductSorting.ProductNameDescending => productsToShow
                    .OrderByDescending(p => p.Title),
                AdminProductSorting.ProductCodeAscending => productsToShow
                    .OrderBy(p => p.ProductCode),
                AdminProductSorting.ProductCodeDescending => productsToShow
                    .OrderByDescending(p => p.ProductCode),
                _ => productsToShow
                    .OrderByDescending(p => p.Id)
            };

            var products = await productsToShow
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .ProjectToAdminProductServiceModel()
                .ToListAsync();

            int totalProducts = await productsToShow.CountAsync();

            var currency = await _shopService.GetShopCurrency();

            foreach (var prod in products)
            {
                prod.Currency = currency;
            }

            return new AdminProductQueryServiceModel()
            {
                Products = products,
                TotalProductsCount = totalProducts
            };
        }

        public async Task CreateProductAsync(AdminProductCreateFormModel model, string userId)
        {
            var productToAdd = new Product()
            {
                Title = model.Title,
                Subtitle = model.Subtitle,
                Description = model.Description,
                Ingredients = model.Ingredients,
                ProductCode = model.ProductCode,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId,
                CreatedDate = DateTime.Now,
                CreatedById = userId,
                ShopId = 1
            };

            await _repository.AddAsync(productToAdd);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteProductByIdAsync(int productId)
        {
            var product = await _repository.GetByIdAsync<Product>(productId);

            if (product != null)
            {
                product.IsActive = false;
                await _repository.SaveChangesAsync();
            }
        }

        public async Task EditProductAsync(AdminProductEditFormModel model)
        {
            var productToEdit = await _repository.GetByIdAsync<Product>(model.Id);

            if (productToEdit != null)
            {
                productToEdit.ProductCode = model.ProductCode;
                productToEdit.Title = model.Title;
                productToEdit.Subtitle = model.Subtitle;
                productToEdit.Description = model.Description;
                productToEdit.Ingredients = model.Ingredients;
                productToEdit.ImageUrl = model.ImageUrl;
                productToEdit.Quantity = model.Quantity;
                productToEdit.Price = model.Price;
                productToEdit.CategoryId = model.CategoryId;

                await _repository.SaveChangesAsync();
            }
        }

        public async Task<AdminProductEditFormModel?> GetProductByIdAsync(int id)
        {
            return await _repository
                .AllReadOnly<Product>()
                .Where(p => p.Id == id)
                .Select(p => new AdminProductEditFormModel()
                {
                    Id = p.Id,
                    ProductCode = p.ProductCode,
                    Title = p.Title,
                    Subtitle = p.Subtitle,
                    Description = p.Description,
                    Ingredients = p.Ingredients,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryId = p.Category.Id
        })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ProductCodeExistsAsync(string productCode)
        {
            return await _repository.AllReadOnly<Product>()
                .AnyAsync(p => p.ProductCode == productCode);
        }

        public async Task<bool> ProductCodeExistsAsync(string productCode, int productId)
        {
            return await _repository.AllReadOnly<Product>()
                .AnyAsync(p => p.ProductCode == productCode && p.Id != productId);
        }
    }
}
