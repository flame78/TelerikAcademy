'use strict';

app.controller('citiesCtrl', ['$scope', 'citiesResource', 'errorHandler',
    function ($scope, citiesResource, errorHandler) {

        citiesResource.get()
            .success(function (result) {
                $scope.cities = result;
                console.log(result);
            })
            .error(function (error) {
                errorHandler(error);
            });
    }]);

