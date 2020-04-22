using OdeToFood_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood_Data.Services
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

        public void Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(i => i.Id) + 1;
            restaurants.Add(restaurant);
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(i => i.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
