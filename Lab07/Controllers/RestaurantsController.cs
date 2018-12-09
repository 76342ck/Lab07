using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace Lab07.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurants")]
    public class RestaurantsController : Controller
    {
        // GET: api/Restaurants
        [HttpGet]
        public List<Restaurant> Get()
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM Restaurant_T ORDER BY RestaurantID");
            List<Restaurant> restaurants = new List<Restaurant>();
            Restaurant restaurant;

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                restaurant = new Restaurant();
                restaurant.RestaurantID = int.Parse(record["RestaurantID"].ToString());
                restaurant.RestName = record["RestName"].ToString();
                restaurant.RestAddr = record["RestAddr"].ToString();
                restaurant.StarRating = int.Parse(record["StarRating"].ToString());
                restaurant.PriceRating = record["PriceRating"].ToString();
                restaurant.ImageURL = record["ImageURL"].ToString();
                restaurant.Cuisine = record["Cuisine"].ToString();
                restaurant.AvgRating = int.Parse(record["AvgRating"].ToString());
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        [HttpGet("GetByName/{name}")]
        public List<Restaurant> GetByName(string name)
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM Restaurant_T WHERE RestName LIKE '%" + name + "%'");
            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.RestaurantID = int.Parse(record["RestaurantID"].ToString());
                restaurant.RestName = record["RestName"].ToString();
                restaurant.RestAddr = record["RestAddr"].ToString();
                restaurant.StarRating = int.Parse(record["StarRating"].ToString());
                restaurant.PriceRating = record["PriceRating"].ToString();
                restaurant.ImageURL = record["ImageURL"].ToString();
                restaurant.Cuisine = record["Cuisine"].ToString();
                restaurant.AvgRating = int.Parse(record["AvgRating"].ToString());
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        [HttpGet("GetByCuisine/{addr}/{cuisine}")]
        public List<Restaurant> GetByLocationCuisine(string addr, string cuisine)
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM Restaurant_T WHERE RestAddr LIKE '%" + addr + "%' AND " +
                "Cuisine LIKE '%" + cuisine + "%'");
            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.RestaurantID = int.Parse(record["RestaurantID"].ToString());
                restaurant.RestName = record["RestName"].ToString();
                restaurant.RestAddr = record["RestAddr"].ToString();
                restaurant.StarRating = int.Parse(record["StarRating"].ToString());
                restaurant.PriceRating = record["PriceRating"].ToString();
                restaurant.ImageURL = record["ImageURL"].ToString();
                restaurant.Cuisine = record["Cuisine"].ToString();
                restaurant.AvgRating = int.Parse(record["AvgRating"].ToString());
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        [HttpGet("GetByRatings/{addr}/{rating}")]
        public List<Restaurant> GetByLocationRatings(string addr, string rating)
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM Restaurant_T WHERE RestAddr LIKE '%" + addr + "%' AND Cuisine = '" + rating + "'");
            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (DataRow record in ds.Tables[0].Rows)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.RestaurantID = int.Parse(record["RestaurantID"].ToString());
                restaurant.RestName = record["RestName"].ToString();
                restaurant.RestAddr = record["RestAddr"].ToString();
                restaurant.StarRating = int.Parse(record["StarRating"].ToString());
                restaurant.PriceRating = record["PriceRating"].ToString();
                restaurant.ImageURL = record["ImageURL"].ToString();
                restaurant.Cuisine = record["Cuisine"].ToString();
                restaurant.AvgRating = int.Parse(record["AvgRating"].ToString());
                restaurants.Add(restaurant);
            }

            return restaurants;
        }

        // POST: api/Restaurants
        [HttpPost("AddRestaurant/{newRestaurant}")]
        public Boolean AddRestaurant(Restaurant newRestaurant)
        {
            DBConnect objDB = new DBConnect();
            string sql = "INSERT INTO Restaurant_T (RestName, RestAddr, StarRating, PriceRating, ImageURL, Cuisine, AvgRating" +
                "VALUES ('" + newRestaurant.RestName + "', '" +
                newRestaurant.RestAddr + "', " +
                newRestaurant.StarRating + ", '" +
                newRestaurant.PriceRating + "', '" +
                newRestaurant.ImageURL + "', '" +
                newRestaurant.Cuisine + "', " +
                newRestaurant.AvgRating + ");";

            int result = objDB.DoUpdate(sql);
            if (result == -1)
            {
                return true;
            } else {
                return false;
            }
        }

        [HttpPost("AddReview/{review}")]
        public Boolean AddReview(Reviews review)
        {
            DBConnect objDB = new DBConnect();

            string sql = "INSERT INTO Reviews_T " +
                "VALUES (" +
                review.RestaurantID + ", " +
                review.StarRating + ", '" +
                review.PriceRating + "', '" +
                review.Comments + "');";

            int result = objDB.DoUpdate(sql);

            if (result == -1)
            {
                return false; 
            } else
            {
                return true;
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("DeleteRestaurant/{name}")]
        public Boolean DeleteRestaurant(string name)
        {
            DBConnect objDB = new DBConnect();

            string sql = "DELETE FROM Restaurant_T" +
                "WHERE RestName = '" + name + "';";

            int result = objDB.DoUpdate(sql);

            if (result == -1)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
