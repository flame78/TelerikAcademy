'use strict';

app.controller('TripsCtrl', ['$scope', 'notifier', function($scope, notifier) {
    notifier.success('Partial 1!');
    notifier.error('Partial 1');
}]);