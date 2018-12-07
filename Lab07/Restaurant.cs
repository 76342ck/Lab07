using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab07
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string RestName { get; set; }
        public string RestAddr { get; set; }
        public int StarRating { get; set; }
        public string PriceRating { get; set; }
        public string ImageURL { get; set; }
        public string Cuisine { get; set; }
        public int AvgRating { get; set; }

        public Restaurant()
        {

        }

        public Restaurant(int id, string name, string addr,
            int starRating, string priceRating, string imgURL,
            string cuisine, int avg)
        {
            this.RestaurantID = id;
            this.RestName = name;
            this.RestAddr = addr;
            this.StarRating = starRating;
            this.PriceRating = priceRating;
            this.ImageURL = imgURL;
            this.Cuisine = cuisine;
            this.AvgRating = avg;
        }
    }
}
