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

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(i => i.Name);
        }
    }
}
