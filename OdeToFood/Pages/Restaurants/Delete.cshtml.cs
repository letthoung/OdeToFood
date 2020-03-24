using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");
            else
                return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var deletedRestaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();
            if (deletedRestaurant == null)
                return RedirectToPage("./NotFound");

            TempData["Message"] = $"{deletedRestaurant.Name} is deleted";
            return RedirectToPage("./List");
        }
    }
}