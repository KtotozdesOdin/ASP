namespace lab1ex1.Services
{
    public interface IExtraDiscountService
    {
        decimal CalculateExtraDiscount(decimal price, double discount);
    }
}
