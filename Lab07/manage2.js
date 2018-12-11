// Create the module for the entire application.
var appModule = angular.module('MyModule', []);

// Create a controller that uses the $http service.
function DeleteController($scope, $http) {

    // Create a function assigned to deleteBtn's click event (ng-click).
    $scope.delete = function () {
        console.log("In delete function");

        var restName = $("#nameTxt").val();
        var rName = $scope.deleteValue;
        var restaurant = new Object();

        //var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug82619/WebAPI/api/Restaurants/DeleteRestaurant/";
        var strURL = "http://localhost:56475/api/Restaurants/DeleteRestaurant/" + restName;

        restaurant.name = rName;
        restaurant = JSON.stringify(restaurant);

        var request = {
            method: "DELETE",
            url: strURL,
            headers: {  // object containing header type as properties.
                'Content-Type': "application/json; charset=utf-8",
            },
            data: restaurant // input parameter sent as JSON object.
        };

        $http(request).
            then(function (response) {
                alert("Success");
                console.log(response);
                $scope.result = "Successfully deleted restaurant from database";
                console.log($scope.result);
            },
                function (response) {
                    alert("ERROR: " + response.data);
                    $scope.result = "Error - restaurant was not deleted from database";
                });
    };
};

function AddController($scope, $http) {
    $scope.add = function () {

        //var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug82619/WebAPI2/api/Restaurants/AddRestaurant/";
        var strURL = "http://localhost:56475/api/Restaurants/AddRestaurant/";
        console.log("in add function");

        var restaurant = JSON.stringify({
            RestName: $scope.RestName,
            RestAddr: $scope.RestAddr,
            StarRating: $scope.StarRating,
            PriceRating: $scope.PriceRating,
            ImageURL: $scope.ImageURL,
            Cuisine: $scope.Cuisine,
            AvgRating: $scope.AvgRating
        });

        var request = {
            method: "Post",
            url: strURL,
            headers: {  // object containing header type as properties.
                'Content-Type': "application/json; charset=utf-8",
            },
            data: restaurant // input parameter sent as JSON object.
        }

        $http.post(strURL, restaurant).
            then(function () {  // success callback function
                $scope.result = "Successfully added restaurant from database";
            },
                function () {   // error callback function
                    $scope.result = "Error - restaurant was not added from database";
                });

    };
};

appModule.controller('DeleteController', DeleteController);
appModule.controller('AddController', AddController);