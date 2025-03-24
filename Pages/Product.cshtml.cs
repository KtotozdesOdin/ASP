using lab1ex1.Models;
using lab1ex1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
//using WebAppCoreProduct.Pages;

namespace lab1ex1.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IDiscountService _discountService;
        private readonly IExtraDiscountService _extraDiscountService;
        private readonly IOnPostService _onPostService;

        public ProductModel(IDiscountService discountService, IExtraDiscountService extraDiscountService, IOnPostService onPostService)
        {
            _discountService = discountService;
            _extraDiscountService = extraDiscountService;
            _onPostService = onPostService;
        }
        public string? MessageRezult { get; private set; }
        public bool IsCorrect { get; set; } = true;
        public Product Product { get; set; }

        public void OnGet()
        {
            MessageRezult = "Для товара можно определить скидку";
        }

        public void OnPost(string name, decimal? price, double discount)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            var result = _onPostService.CalculateDiscount(price.Value, discount);
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discount}% получится {result:F2}";
            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostDiscount(string name, decimal? price, double discount)
        {
            Product = new Product();

            // Проверка корректности входных данных
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
                        
            // Расчет итоговой цены с помощью сервиса
            var result = _discountService.CalculateDiscount(price.Value, discount);

            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discount}% получится {result}";

            // Сохранение данных в объект Product
            Product.Price = price;
            Product.Name = name;
        }
        public void OnPostExtraDiscount(string name, decimal? price, double discount)
        {

            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }

            if (price > 1500)
            {
                decimal result = _extraDiscountService.CalculateExtraDiscount(price.Value, discount);
                MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discount}% получится {result}"; 
            }           

            Product.Price = price;
            Product.Name = name;
        }
    }
}
