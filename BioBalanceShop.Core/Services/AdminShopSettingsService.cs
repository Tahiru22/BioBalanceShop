using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models._Base;
using BioBalanceShop.Core.Models.Admin.ShopSettings;
using BioBalanceShop.Infrastructure.Data.Common;
using BioBalanceShop.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BioBalanceShop.Core.Services
{
    public class AdminShopSettingsService : IAdminShopSettingsService
    {
        private readonly IRepository _repository;
 

        public AdminShopSettingsService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ShopCurrencyServiceModel>> AllCurrenciesAsync()
        {
            return await _repository.AllReadOnly<Currency>()
                .Select(c => new ShopCurrencyServiceModel()
                {
                    Id = c.Id,
                    CurrencyCode = c.Code,
                    CurrencyIsSymbolPrefix = c.IsSymbolPrefix,
                    CurrencySymbol = c.Symbol
                })
                .ToListAsync();
        }

        public async Task<AdminShopSettingsFormModel> AllShopSettingsAsync()
        {
            return await _repository.AllReadOnly<Shop>()
                .Select(s => new AdminShopSettingsFormModel()
                {
                    CurrencyId = s.CurrencyId,
                    ShippingFeeRate = s.ShippingFeeRate
                })
                .FirstAsync();
        }

        public async Task EditShopSettingsAsync(AdminShopSettingsFormModel model)
        {
            var shopSettings = await _repository
                .All<Shop>()
                .FirstAsync();

            shopSettings.CurrencyId = model.CurrencyId;
            shopSettings.ShippingFeeRate = model.ShippingFeeRate;

            await _repository.SaveChangesAsync();
        }
    }
}
