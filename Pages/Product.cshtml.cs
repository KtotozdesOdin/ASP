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

        public void OnPost(string name, decimal? price, double discont)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }           
            var result = _onPostService.CalculateDiscount(price.Value, discont);
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont}% получится {result}";
            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            discont = 0.18;
            var result = _discountService.CalculateDiscount(price.Value, discont);
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont} получится {result}";
            Product.Price = price;
            Product.Name = name;
        }
        public void OnPostExtraDiscont(string name, decimal? price, double discont)
        {
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }
            else if (price > 1500)
            {
                //дополнительная скидка в 20%
                var extraDiscount = discont * 1.2;
                var result = _extraDiscountService.CalculateDiscount(price.Value, discont);
                MessageRezult = $"Для товара {name} с ценой {price} и дополнительной скидкой {extraDiscount}% получится {result}";

            }
            else
            {
                var result = price * (decimal?)(1 - discont / 100);
                MessageRezult = $"Ваша скидка {result}";
            }
            Product.Price = price;
            Product.Name = name;
        }
    }
}
