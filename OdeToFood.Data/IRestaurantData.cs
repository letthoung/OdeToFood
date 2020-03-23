using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>(){
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "MaryLand", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Budhha Barn", Location = "NewPort", Cuisine = CuisineType.Indian},
                new Restaurant {Id = 3, Name = "Taco Bell", Location = "Cincy", Cuisine = CuisineType.Mexican}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return from r in restaurants orderby r.Name select r;
            else
                return from r in restaurants where r.Name.StartsWith(name) select r;
        }
    }
}
