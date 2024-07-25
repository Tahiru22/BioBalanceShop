using BioBalanceShop.Core.Enumerations;
using BioBalanceShop.Core.Models.Admin.Product;

namespace BioBalanceShop.Core.Contracts
{
    public interface IAdminProductService
    {
        Task<AdminProductQueryServiceModel> AllAsync(
           string? category = null,
           string? searchTerm = null,
           AdminProductSorting sorting = AdminProductSorting.Newest,
           int currentPage = 1,
           int productsPerPage = 1);

        Task DeleteProductByIdAsync(int productId);

        Task EditProductAsync(AdminProductEditFormModel model);

        Task<AdminProductEditFormModel?> GetProductByIdAsync(int id);

        Task CreateProductAsync(AdminProductCreateFormModel model, string userId);

        Task<bool> ProductCodeExistsAsync(string productCode);

        Task<bool> ProductCodeExistsAsync(string productCode, int productId);
    }
}
