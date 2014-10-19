'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/games', {
                templateUrl: 'views/partials/gameslist.html',
                controller: 'GamesController'
            })
            .when('/partial2', {
                // templateUrl: 'views/partials/modal.html',
                controller: 'MyCtrl2'
            })
            .when('/games/:id', {
                templateUrl: 'views/partials/game.html',
                controller: 'playCtrl'
            })
            .otherwise({ redirectTo: '/games' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:33257');