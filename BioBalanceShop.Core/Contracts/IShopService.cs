using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Shared;

namespace BioBalanceShop.Core.Contracts
{
    public interface IShopService
    {
        Task<ShopCurrencyServiceModel?> GetShopCurrency();

        Task<decimal?> GetShippingFeeRate();

        Task<IList<ShopCountryServiceModel>> AllCountriesAsync();
    }
}
