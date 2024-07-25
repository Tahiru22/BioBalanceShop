namespace BioBalanceShop.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const string DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";

        public static class ProductData
        {
            public const int ProductCodeMaxLength = 20;
            public const int ProductCodeMinLength = 3;

            public const int TitleMaxLength = 250;
            public const int TitleMinLength = 2;

            public const int SubtitleMaxLength = 500;
            public const int SubtitleMinLength = 2;

            public const int DescriptionMaxLength = 3000;
            public const int DescriptionMinLength = 10;

            public const int IngredeientsMaxLength = 3000;
            public const int IngredeientsMinLength = 10;

            public const int ImageUrlMaxLength = 500;
            public const int ImageUrlMinLength = 5;

            public const string QuantityMaxRange = "99999";
            public const string QuantityMinRange = "0";

            public const string PriceMaxRange = "9999999";
            public const string PriceMinRange = "0";
        }

        public static class CategoryData
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
        }

        public static class CountryData
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

            public const int CountryCodeMaxLength = 3;
            public const int CountryCodeMinLength = 3;
            public const string CountryCodeRegexPattern = @"[A-Z]{3}";
        }

        public static class OrderData
        {
            public const int OrderNumberMaxLength = 20;
            public const int OrderNumberMinLength = 5;

            public const string AmountMinValue = "0";
            public const string AmountMaxValue = "999999";

            public const string ShipppingFeeMinValue = "0";
            public const string ShipppingFeeMaxValue = "100";
        }

        public static class AddressData
        {
            public const int StreetMaxLength = 50;
            public const int StreetMinLength = 5;

            public const int PostCodeMaxLength = 10;
            public const int PostCodeMinLength = 2;

            public const int CityMaxLength = 20;
            public const int CityMinLength = 1;
        }

        public static class ApplicationUserData
        {
            public const int NameMaxLength = 25;
            public const int NameMinLength = 2;

            public const int PasswordMaxLength = 50;
            public const int PasswordMinLength = 6;
            public const string PasswordRegexPattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{8,}$";

            public const int PhoneMaxLength = 15;
            public const int PhoneMinLength = 5;
            public const string PhoneRegexPattern = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";

            public const int EmailMaxLength = 30;
            public const int EmailMinLength = 6;
            public const string EmailRegexPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        }

        public static class CurrencyData
        {
            public const int CurrencyCodeMaxLength = 3;
            public const int CurrencyCodeMinLength = 3;
            public const string CurrencyCodeRegexPattern = @"[A-Z]{3}";

            public const int CurrencySymbolMaxLength = 3;
            public const int CurrencySymbolMinLength = 1;
        }

        public static class PaymentData
        {
            public const string PaymentAmountMinValue = "0";
            public const string PaymentAmountMaxValue = "999999";
        }
    }
}
