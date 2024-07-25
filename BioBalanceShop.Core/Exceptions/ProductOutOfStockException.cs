namespace BioBalanceShop.Core.Exceptions
{
    public class ProductOutOfStockException : Exception
    {
        public ProductOutOfStockException() { }

        public ProductOutOfStockException(string message) : base(message) { }
    }
}
