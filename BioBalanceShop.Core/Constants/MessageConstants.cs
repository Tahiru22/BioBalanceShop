namespace BioBalanceShop.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} value is required";

        public const string LengthMessage = "The value {0} must be between {2} and {1} characters long";

        public const string RangeErrorMessage = "{0} must not be a negaitve number and must be less than {2}";

        public const string UserMessageSuccess = "UserMessageSuccess";

        public const string UserMessageError = "UserMessageError";

        public const string FormatErrorMessage = "Invalid {0} format";

        public const string EmailFormatErrorMessage = "Invalid {0} format. Please enter a valid email address";

        public const string PasswordFormatErrorMessage = "Invalid {0} format. {} must contain at least 1 digit, 1 uppercase letter, 1 lowercase letter and 1 non-alphanumeric character";

        public const string PasswordConfirmErrorMessage = "The password and confirmation password do not match";

        public const string ProductCodeExistsErrorMessage = "The product code already exists. Please enter a unique product code";

    }
}
