using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Admin.ShopSettings;

namespace BioBalanceShop.Core.Contracts
{
    public interface IAdminShopSettingsService
    {
        Task<AdminShopSettingsFormModel> AllShopSettingsAsync();

        Task EditShopSettingsAsync(AdminShopSettingsFormModel model);

        Task<IEnumerable<ShopCurrencyServiceModel>> AllCurrenciesAsync();
    }
}
