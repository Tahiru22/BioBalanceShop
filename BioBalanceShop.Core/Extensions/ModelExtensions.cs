using BioBalanceShop.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BioBalanceShop.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetProductInfo(this IProductModel product)
        {
            string productInfo = product.Title.Replace(" ", "-");
            productInfo = Regex.Replace(productInfo, @"[^a-zA-Z0-9\-]", string.Empty);

            return productInfo;
        }
    }
}
