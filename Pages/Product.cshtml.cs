using lab1ex1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
//using WebAppCoreProduct.Pages;

namespace lab1ex1.Pages
{
    public class ProductModel : PageModel
    {
        public string? MessageRezult { get; private set; }
        public bool IsCorrect { get; set; } = true;
        public Product Product { get; set; }        

        public void OnGet()
        {
            MessageRezult = "Для товара можно определить скидку";
        }

        public void OnPost(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "Переданы некорректные данные. Повторите ввод";
                return;
            }

            var result = price * (decimal?)0.18;
            MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            var result = price * (decimal?)discont / 100;
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont} получится {result}";
            Product.Price = price;
            Product.Name = name;
        }        
        public void OnPostExtraDiscont(string name, decimal? price, double discont)
        {
            Product = new Product();
            if(price > 1500)
            {
                double extraDiscont = discont * 1.2;
                var result = price * (decimal?)(1 - extraDiscont / 100);
                MessageRezult = $"Для товара {name} с ценой {price} и дополнительной скидкой {extraDiscont}% получится {result}";

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
