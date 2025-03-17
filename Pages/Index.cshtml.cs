using lab1ex1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1ex1.Pages
{
    public class IndexModel : PageModel
    {
        public bool IsCorrect { get; set; } = true;
        public Product Product { get; set; }

        public void OnGet(string name, decimal? price)
        {
            Product = new Product();
            if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }
            Product.Price = price;
            Product.Name = name;
        }
    }
}
