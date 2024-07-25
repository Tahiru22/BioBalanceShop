using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQueryableProductExtension
    {
        public static IQueryable<ProductServiceModel> ProjectToProductServiceModel(this IQueryable<Product> products)
        {
            return products
                .Select(p => new ProductServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                });
        }
    }
}
