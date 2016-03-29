
var app = angular.module('myApp', []);
app.controller('homeController', ['$scope', 'peopleService', function ($scope, peopleService) {
       
    
        $scope.IncrementAge = function () {

         
            peopleService.IncrementAge($scope);
           
            location.href = "/home/GetListOfPeople/0";
        }

        $scope.people = peopleService.peopleStat($scope);

            
        
    }])

app.service('peopleService', ['$http', function ($http) {
    this.IncrementAge = function ($scope) {
           return $http({
                method: "GET",
                url: "/Home/IncrementAge",
                headers: { 'Content-Type': 'application/json' }
            }).success(function (data) {
               // $scope.people = data;
                console.log(data);
            }).error(function (data) {
                console.log("error")
                console.log(data);
            });;
    };

    this.peopleStat = function ($scope) {
         return $http({
            method: "GET",
            url: "/Home/GetStatistics/",
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.people = data;
                        console.log(data);
        }).error(function (data) {
            console.log("error")
            console.log(data);
        });;
    };

    }]);
