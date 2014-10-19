'use strict';

app.controller('tripsCtrl', ['$scope', 'tripsResource', 'errorHandler', 'identity', 'citiesResource',
    function ($scope, tripsResource, errorHandler, identity, citiesResource) {

        $scope.page = {};
        $scope.filter = {};
        $scope.sort = {};
        $scope.order = {};
        $scope.destinations = {};
        $scope.page.currentPage = 1;

        if (!$scope.sort.sort) {
            $scope.sort.sort = 'date';
        }

        if (!$scope.order.order) {
            $scope.order.order = 'asc';
        }

        $scope.permission = {};
        $scope.permission.isAuthenticated = identity.isAuthenticated();

        citiesResource.get()
            .success(function (result) {
                $scope.cities = result;
            })
            .error(function (error) {
                errorHandler(error);
            });

        if (!$scope.permission.isAuthenticated) {
            tripsResource.getPublic()
                .success(function (result) {
                    $scope.trips = result;
                })
                .error(function (error) {
                    errorHandler(error);
                });
        }
        else {
            tripsResource.getByPageOrdered($scope.page.currentPage,$scope.sort,$scope.order)
                .success(function (result) {
                    $scope.trips = result;
                })
                .error(function (error) {
                    errorHandler(error);
                });
        }

        $scope.changeSort = function () {
            tripsResource.getByPageOrdered($scope.page.currentPage,$scope.sort.sort,$scope.order.order)
                .success(function (result) {
                    $scope.trips = result;
                })
                .error(function (error) {
                    errorHandler(error);
                });
        }

        $scope.changeFromTo = function(){
            tripsResource.getFromTo($scope.page.currentPage,$scope.destinations.from,$scope.destinations.to)
                .success(function (result) {
                    $scope.trips = result;
                })
                .error(function (error) {
                    errorHandler(error);
                });
        }

        $scope.changePage = function changePage(direction) {

            if (direction === '-' && $scope.page.currentPage > 1) {
                $scope.page.currentPage--;
            }

            if (direction === '+' && $scope.page.currentPage) {

                $scope.page.currentPage++;
            }

            $scope.changeSort();

        }
    }]);