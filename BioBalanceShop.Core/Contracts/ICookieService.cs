using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Payment;
using Microsoft.AspNetCore.Http;

namespace BioBalanceShop.Core.Contracts
{
    public interface ICookieService
    {
        void SetCartCookie(IResponseCookies httpResponse, CartCookieModel cart);

        CartCookieModel GetOrCreateCartCookie(string? cartCookie);

        void RemoveCookie(IResponseCookies httpResponse, string cookie);

        void SaveOrderInfoInCookie(IResponseCookies httpResponse, CheckoutFormModel model);

        CheckoutFormModel GetOrderInfoFromCookie(string? orderCookie);

        void SetConsentCookie(IResponseCookies httpResponse, string consentStatus);

        bool CookieConsentGiven(string? cookieConsent);
    }
}
