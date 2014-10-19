'use strict';

app.controller('MainCtrl', ['$scope', 'driversResource', 'tripsResource', 'statisticsResource', 'errorHandler',
    function ($scope, driversResource, tripsResource, statisticsResource, errorHandler) {

        statisticsResource.get()
            .success(function (result) {
                $scope.stats = result;
            })
            .error(function (error) {
                errorHandler(error);
            });

        driversResource.getPublic()
            .success(function (result) {
                $scope.drivers = result;
            })
            .error(function (error) {
                errorHandler(error);
            });

        tripsResource.getPublic()
            .success(function (result) {
                $scope.trips = result;
            })
            .error(function (error) {
                errorHandler(error);
            });

    }]);
