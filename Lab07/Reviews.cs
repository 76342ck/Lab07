using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Lab07
{
    public class Reviews
    {
        public string RestaurantID { get; set; }
        public int StarRating { get; set; }
        public string PriceRating { get; set; }
        public string Comments { get; set; }

        public Reviews()
        {

        }

        public Reviews(string id, int starRating, string priceRating, string comm)
        {
            this.RestaurantID = id;
            this.StarRating = starRating;
            this.PriceRating = priceRating;
            this.Comments = comm;
        }
    }
}
