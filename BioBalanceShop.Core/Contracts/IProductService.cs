using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Home;
using BioBalanceShop.Core.Models.Product;

namespace BioBalanceShop.Core.Contracts
{
    public interface IProductService
    {
        Task<bool> ExistsAsync(int id);

        Task<ProductQueryServiceModel> AllAsync(
           string? category = null,
           string? searchTerm = null,
           ProductSorting sorting = ProductSorting.Newest,
           int currentPage = 1,
           int productsPerPage = 1);

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<IEnumerable<CategoryAllServiceModel>> AllCategoriesAsync();
        
        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<ProductDetailsServiceModel?> GetProductByIdAsync(int id);

        Task<IEnumerable<HomeIndexProductModel>> GetLastFiveProductsAsync();

        Task<bool> UpdateProductQuantityInStock(int productId, int orderedQuantity);
    }
}
