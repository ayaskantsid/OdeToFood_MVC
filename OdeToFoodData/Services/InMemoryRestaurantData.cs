using OdeToFoodData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodData.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Indian Accent", Cuisine=CuisineType.Indian},
                new Restaurant{Id=2, Name="Shang Palace", Cuisine=CuisineType.French},
                new Restaurant{Id=3, Name="Wasabi", Cuisine=CuisineType.Italian}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(i => i.Name);
        }
    }
}
