var app = angular.module('restaurant', []);

function RestaurantsController($scope, $http) {
    // Create a function assigned to btnSearch's click event (ng-click).
    $scope.get = function () {

        var restaurant = new Object();

        //var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug81959/WebAPI/api/Restaurants/";
        var strURL = "http://localhost:56475/api/Restaurants/";

        //.restaurantName has to match the parameter in my web service method
        restaurant = JSON.stringify(restaurant);

        // Configure the request by creating a JavaScript object with the necessary properties
        // and values for the request.
        var request = {
            method: "Get",
            url: strURL,
            headers: {  // object containing header type as properties.
                'Content-Type': "application/json; charset=utf-8",
            },
            data: restaurant // input parameter sent as JSON object.
        };

        // Setup and send an AJAX request that sends a search term 
        // used by the Web API to find a team.
        $http(request).
            then(function (response) {  // success callback function
                console.log(response);

                $scope.restaurants = response.data;
                console.log($scope.restaurants);
                $("#searchResults").html("");

                angular.forEach($scope.restaurants, function (restaurants, index) {
                    console.log('key:', index);
                    console.log('value:', restaurants);
                    console.log(restaurants.RestaurantID);
                    $("#searchResults").append("<table><tr><td>" +
                        "<img src = " + restaurants.ImageURL + " /></td>".concat("<td>Restaurant ID: ", restaurants.RestaurantID,
                            "<br>Restaurant Name: ", restaurants.RestName, "<br>Location: ", restaurants.RestAddr,
                            "<br>Star Rating: ", restaurants.StarRating, "<br>Price Rating: ", restaurants.PriceRating,
                            "<br>Cuisine: ", restaurants.Cuisine, "<br>Average Rating: ", restaurants.AvgRating, "</td></tr></table><hr>"));
                });
            },
                function (response) {   // error callback function
                    alert("ERROR: " + response.data);
                });
    };

    // Create a function assigned to btnSearch's click event (ng-click).
    $scope.search = function () {

        var rName = $scope.searchName;
        var restName = $("#txtRestaurant").val();
        var restaurant = new Object();

        //var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug81959/WebAPI/api/Restaurants/";
        var strURL = "http://localhost:56475/api/Restaurants/GetByName/" + restName;

        //scope this
        var valid = true;
        var field = $scope.searchName;
        if (field == undefined) {
            alert("Please enter a valid name.");
            valid = false;
        } else {

            //.restaurantName has to match the parameter in my web service method
            restaurant.name = rName;
            restaurant = JSON.stringify(restaurant);

            // Configure the request by creating a JavaScript object with the necessary properties
            // and values for the request.
            var request = {
                method: "Get",
                url: strURL,
                headers: {  // object containing header type as properties.
                    'Content-Type': "application/json; charset=utf-8",
                },
                data: restaurant // input parameter sent as JSON object.
            };

            // Setup and send an AJAX request that sends a search term 
            // used by the Web API to find a team.
            $http(request).
                then(function (response) {  // success callback function
                    console.log(response);

                    $scope.restaurants = response.data;
                    console.log($scope.restaurants);
                    $("#searchResults").html("");

                    angular.forEach($scope.restaurants, function (restaurants, index) {
                        console.log('key:', index);
                        console.log('value:', restaurants);
                        console.log(restaurants.RestaurantID);
                        $("#searchResults").append("<table><tr><td>" +
                            "<img src = " + restaurants.ImageURL + " /></td>".concat("<td>Restaurant ID: ", restaurants.RestaurantID,
                            "<br>Restaurant Name: ", restaurants.RestName, "<br>Location: ", restaurants.RestAddr,
                            "<br>Star Rating: ", restaurants.StarRating, "<br>Price Rating: ", restaurants.PriceRating,
                            "<br>Cuisine: ", restaurants.Cuisine, "<br>Average Rating: ", restaurants.AvgRating, "</td></tr></table><hr>"));
                    });
                },
                    function (response) {   // error callback function
                        alert("ERROR: " + response.data);
                    });
        }
    };

    // Create a function assigned to btnSearch's click event (ng-click).
    $scope.search1 = function () {

        var loc = $("#txtLocation").val();
        var cuisine = $("#txtCuisine").val();
        var restaurant = new Object();

        //var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug81959/WebAPI/api/Restaurants/";
        var strURL = "http://localhost:56475/api/Restaurants/GetByCuisine/" + loc + "/" + cuisine;

        //scope this
        var valid = true;
        var field = $scope.searchLocation;
        var field2 = $scope.searchCuisine;
        if (field == undefined) {
            alert("Please enter a valid location.");
            valid = false;
        } else if (field2 == undefined) {
            alert("Please enter a valid cuisine.");
            valid = false;
        } else {
            //.restaurantName has to match the parameter in my web service method
            restaurant.addr = loc;
            restaurant.cuisine = cuisine;
            restaurant = JSON.stringify(restaurant);

            // Configure the request by creating a JavaScript object with the necessary properties
            // and values for the request.
            var request = {
                method: "Get",
                url: strURL,
                headers: {  // object containing header type as properties.
                    'Content-Type': "application/json; charset=utf-8",
                },
                data: restaurant // input parameter sent as JSON object.
            };

            // Setup and send an AJAX request that sends a search term 
            // used by the Web API to find a team.
            $http(request).
                then(function (response) {  // success callback function
                    console.log(response);

                    $scope.restaurants = response.data;
                    console.log($scope.restaurants);
                    $("#searchResults").html("");

                    angular.forEach($scope.restaurants, function (restaurants, index) {
                        console.log('key:', index);
                        console.log('value:', restaurants);
                        console.log(restaurants.RestaurantID);
                        $("#searchResults").append("<table><tr><td>" +
                            "<img src = " + restaurants.ImageURL + " /></td>".concat("<td>Restaurant ID: ", restaurants.RestaurantID,
                                "<br>Restaurant Name: ", restaurants.RestName, "<br>Location: ", restaurants.RestAddr,
                                "<br>Star Rating: ", restaurants.StarRating, "<br>Price Rating: ", restaurants.PriceRating,
                                "<br>Cuisine: ", restaurants.Cuisine, "<br>Average Rating: ", restaurants.AvgRating, "</td></tr></table><hr>"));
                    });
                },
                    function (response) {   // error callback function
                        alert("ERROR: " + response.data);
                    });
        }
    };

    // Create a function assigned to btnSearch's click event (ng-click).
    $scope.search2 = function () {

        var loc = $("#txtLocation2").val();
        var rating = $("#txtRating").val();
        var restaurant = new Object();

        //var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug81959/WebAPI/api/Restaurants/";
        var strURL = "http://localhost:56475/api/Restaurants/GetByRatings/" + loc + "/" + rating;

        //scope this
        var valid = true;
        var field = $scope.searchLocation2;
        var field2 = $scope.searchRating;
        if (field == undefined) {
            alert("Please enter a valid location.");
            valid = false;
        } else if (field2 == undefined) {
            alert("Please enter a valid rating.");
            valid = false;
        } else {
            //.restaurantName has to match the parameter in my web service method
            restaurant.addr = loc;
            restaurant.rating = rating;
            restaurant = JSON.stringify(restaurant);

            // Configure the request by creating a JavaScript object with the necessary properties
            // and values for the request.
            var request = {
                method: "Get",
                url: strURL,
                headers: {  // object containing header type as properties.
                    'Content-Type': "application/json; charset=utf-8",
                },
                data: restaurant // input parameter sent as JSON object.
            };

            // Setup and send an AJAX request that sends a search term 
            // used by the Web API to find a team.
            $http(request).
                then(function (response) {  // success callback function
                    console.log(response);

                    $scope.restaurants = response.data;
                    console.log($scope.restaurants);
                    $("#searchResults").html("");

                    angular.forEach($scope.restaurants, function (restaurants, index) {
                        console.log('key:', index);
                        console.log('value:', restaurants);
                        console.log(restaurants.RestaurantID);
                        $("#searchResults").append("<table><tr><td>" +
                            "<img src = " + restaurants.ImageURL + " /></td>".concat("<td>Restaurant ID: ", restaurants.RestaurantID,
                                "<br>Restaurant Name: ", restaurants.RestName, "<br>Location: ", restaurants.RestAddr,
                                "<br>Star Rating: ", restaurants.StarRating, "<br>Price Rating: ", restaurants.PriceRating,
                                "<br>Cuisine: ", restaurants.Cuisine, "<br>Average Rating: ", restaurants.AvgRating, "</td></tr></table><hr>"));
                    });
                },
                    function (response) {   // error callback function
                        alert("ERROR: " + response.data);
                    });
        }
    };

}

app.controller('RestaurantsController', RestaurantsController);