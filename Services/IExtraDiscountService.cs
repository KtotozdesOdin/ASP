namespace lab1ex1.Services
{
    public interface IExtraDiscountService
    {
        decimal CalculateDiscount(decimal price, double discount);
    }
}
