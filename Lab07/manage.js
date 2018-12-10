// Create the module for the entire application.
var appModule = angular.module('MyModule', []);

// Create a controller that uses the $http service.
function DeleteController($scope, $http) {

    // Create a function assigned to deleteBtn's click event (ng-click).
    $scope.search = function (deleteValue) {

        var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug81959/WebAPI2/api/Restaurants/DeleteRestaurant";

        // Setup and send an AJAX request to the Web API 
        $http.delete(strURL).
            then(function (response) {  // success callback function
                $scope.result = "Successfully deleted restaurant from database";
            },
                function (response) {   // error callback function
                    $scope.result = "Error - restaurant was not deleted from database";
                });
    };
}