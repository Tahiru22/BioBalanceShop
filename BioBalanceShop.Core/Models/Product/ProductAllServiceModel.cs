using BioBalanceShop.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace BioBalanceShop.Core.Models.Product
{
    public class ProductAllServiceModel
    {
        public int ProductsPerPage { get; } = 6;

        public string Category { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public ProductSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ProductServiceModel> Products { get; set; } = new List<ProductServiceModel>();
    }
}
