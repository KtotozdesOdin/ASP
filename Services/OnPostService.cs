namespace lab1ex1.Services
{
    public class OnPostService : IOnPostService
    {
        public decimal CalculateDiscount(decimal price, double discount)
        {
            discount = 18;
            return price * (decimal)(1 - discount / 100);
        }
    }
}
