'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/',{
                templateUrl: 'views/partials/main.html',
                controller: 'MainCtrl' })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/trips', {
                templateUrl: 'views/partials/trips.html',
                controller: 'tripsCtrl'
            })
            .when('/drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'driversCtrl'
            })
            .otherwise({
                redirectTo: '/' });
    }])
    .value('toastr', toastr)
  //  .constant('baseServiceUrl', 'http://localhost:1337');
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com');