using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1ex1.Pages
{
    public class IndexModel : PageModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public bool IsCorrect { get; set; } = true;

        public void OnGet(string name, decimal? price)
        {
            if(price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }
            Price = price;
            Name = name;
        }
    }
}
