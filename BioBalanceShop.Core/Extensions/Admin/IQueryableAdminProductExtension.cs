using BioBalanceShop.Core.Models.Admin.Product;
using BioBalanceShop.Core.Models.Product;
using BioBalanceShop.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQueryableAdminProductExtension
    {
        public static IQueryable<AdminProductServiceModel> ProjectToAdminProductServiceModel(this IQueryable<Product> products)
        {
            return products
                .Select(p => new AdminProductServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    ProductCode = p.ProductCode,
                    ImageUrl = p.ImageUrl,
                    Quantity = p.Quantity,
                    Price = p.Price
                });
        }
    }
}
