// Create the module for the entire application.
var appModule = angular.module('MyModule', []);

// Create a controller that uses the $http service.
function DeleteController($scope, $http) {

    // Create a function assigned to deleteBtn's click event (ng-click).
    $scope.search = function (searchTerm) {
        $scope.reverse = false;

        var strURL = "http://cis-iis2.temple.edu/Fall2018/cis3344_tug81959/WebAPI2/api/Restaurants/";

        // Setup and send an AJAX request to the Web API 
        // that gets information about the countries in Europe.
        $http.get(strURL).
            then(function (response) {  // success callback function
                $scope.countries = response.data;
            },
                function (response) {   // error callback function
                    alert("ERROR: " + response.data);
                });

        // Define the sorting function used to sort the items.
        // This function is attached to the table headers using ng-click.
        $scope.sortList = function (key) {
            // Set the filter's parameter value for the ng-repeat.
            $scope.filterSortKey = key;

            // Flip the ordering Ascending to Descending and vice versa.
            if ($scope.reverse)
                $scope.reverse = false;
            else
                $scope.reverse = true;
        };
    };
}