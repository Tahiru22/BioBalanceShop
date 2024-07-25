using BioBalanceShop.Core.Contracts;
using BioBalanceShop.Core.Models.Cart;
using BioBalanceShop.Core.Models.Payment;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using static BioBalanceShop.Core.Constants.CookieConstants;

namespace BioBalanceShop.Core.Services
{
    public class CookieService : ICookieService
    {
        public void SetCartCookie(IResponseCookies httpResponse, CartCookieModel cart)
        {
            string cartJson = JsonConvert.SerializeObject(cart);
            httpResponse.Append(ShoppingCartCookie, cartJson, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true
            });

        }

        public CartCookieModel GetOrCreateCartCookie(string? cartCookie)
        {
            CartCookieModel cart;

            if (string.IsNullOrEmpty(cartCookie))
            {
                cart = new CartCookieModel();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<CartCookieModel>(cartCookie);
            }

            return cart;
        }


        public void RemoveCookie(IResponseCookies httpResponse, string cookie)
        {
            httpResponse.Append(cookie, "", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            });
        }

        public void SaveOrderInfoInCookie(IResponseCookies httpResponse, CheckoutFormModel model)
        {
            string orderInfo = JsonConvert.SerializeObject(model);
            httpResponse.Append(OrderInfoCookie, orderInfo, new CookieOptions
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = true,
                Secure = true
            });
        }

        public CheckoutFormModel GetOrderInfoFromCookie(string? orderCookie)
        {
            CheckoutFormModel orderInfo;

            if (string.IsNullOrEmpty(orderCookie))
            {
                orderInfo = null;
            }
            else
            {
                orderInfo = JsonConvert.DeserializeObject<CheckoutFormModel>(orderCookie);
            }

            return orderInfo;
        }

        public void SetConsentCookie(IResponseCookies httpResponse, string consentStatus)
        {
            httpResponse.Append(ConsentCookie, consentStatus, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(365),
                HttpOnly = true,
                Secure = true
            });
        }

        public bool CookieConsentGiven(string? cookieConsent)
        {
            if (cookieConsent != null && cookieConsent.ToLower() == "accepted")
            {
                return true;
            }

            return false;
        }
    }
}
