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
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
