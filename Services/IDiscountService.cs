namespace lab1ex1.Services
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(decimal price, double discount);
    }
}
