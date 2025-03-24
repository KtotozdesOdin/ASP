namespace lab1ex1.Services
{
    public class ExtraDiscountService : IExtraDiscountService
    {
        public decimal CalculateExtraDiscount(decimal price, double discount)
        {
            if (price > 1500)
            {
                // Увеличиваем скидку на 20 % 
                double extraDiscount = discount * 1.2;
                return price * (decimal)(1 - extraDiscount / 100);
            }
            else
            {
                return CalculateExtraDiscount(price, discount);

            }

        }
    }
}
