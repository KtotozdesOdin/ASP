namespace lab1ex1.Services
{
    public class DiscountService : IDiscountService
    {
        public decimal CalculateDiscount(decimal price, double discount)
        {
            return price * (decimal)(1 - discount / 100);
        }
    }
}
