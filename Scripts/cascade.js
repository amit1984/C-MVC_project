var app = angular.module('myModule', []);
app.controller('myController', function ($scope, $http) {
    
    GetCountries();
    function GetCountries() {
        $http({
            method: 'Get',
            url: '/city/GetCountry'
        }).success(function (data, status, headers, config) {
            $scope.country = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }
    $scope.sendForm = function () {
        $http({
            method: 'POST',
            url: '/city/create',
            data : $scope.model
        }).success(function (data, status, headers, config) {

        }).error(function (data, status, headers, config) {

        });
    };

});