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
            MessageRezult = "��� ������ ����� ���������� ������";
        }

        public void OnPost(string name, decimal? price, double discount)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }
            var result = _onPostService.CalculateDiscount(price.Value, discount);
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discount}% ��������� {result:F2}";
            Product.Price = price;
            Product.Name = name;
        }

        public void OnPostDiscount(string name, decimal? price, double discount)
        {
            Product = new Product();

            // �������� ������������ ������� ������
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }
                        
            // ������ �������� ���� � ������� �������
            var result = _discountService.CalculateDiscount(price.Value, discount);

            MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discount}% ��������� {result}";

            // ���������� ������ � ������ Product
            Product.Price = price;
            Product.Name = name;
        }
        public void OnPostExtraDiscount(string name, decimal? price, double discount)
        {

            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                MessageRezult = "�������� ������������ ������. ��������� ����";
                return;
            }

            if (price > 1500)
            {
                decimal result = _extraDiscountService.CalculateExtraDiscount(price.Value, discount);
                MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discount}% ��������� {result}"; 
            }           

            Product.Price = price;
            Product.Name = name;
        }
    }
}
