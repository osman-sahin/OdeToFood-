using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;  //private olduðunda sadece kendi ulaþabilir readonly okuyor onu 
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }              //deðerleri aþðaýga çaðýrmak içimnproperty yazýyoruz burda
        public IEnumerable<Restaurant> Restaurants { get; set; }     //deðerleri aþðaýga çaðýrmak içimnproperty yazýyoruz burda

        [BindProperty(SupportsGet =  true)]               //Baðlayýcý Model  html arayacak varsa onu kullanacak
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                            IRestaurantData restaurantData)
        {
            this.config = config;  //set ediyoruz
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
