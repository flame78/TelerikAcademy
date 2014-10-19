'use strict';

app.controller('driversCtrl', ['$scope', 'driversResource', 'errorHandler', 'identity',
    function ($scope, driversResource, errorHandler, identity) {

        $scope.permission = {};
        $scope.page = {};
        $scope.filter = {};
        $scope.page.currentPage = 1;
        $scope.permission.isAuthenticated = identity.isAuthenticated();

        $scope.changePage = function changePage(direction) {

            if (direction === '-' && $scope.page.currentPage > 1) {
                $scope.page.currentPage--;
            }

            if (direction === '+' && $scope.page.currentPage) {

                $scope.page.currentPage++;
            }

            if ($scope.filter.filterString!=undefined)
            {
                $scope.applyFilter();
                return;
            }

            driversResource.getByPage($scope.page.currentPage)
                .success(function (result) {
                    $scope.drivers = result;
                })
                .error(function (error) {
                    errorHandler(error);
                });

        }

        $scope.applyFilter = function(){
            driversResource.getByPageAndUserName($scope.page.currentPage,$scope.filter.filterString)
                .success(function (result) {
                    $scope.drivers = result;
                })
                .error(function (error) {
                    errorHandler(error);
                });
        }

        driversResource.getPublic()
            .success(function (result) {
                $scope.drivers = result;
            })
            .error(function (error) {
                errorHandler(error);
            });
    }]);