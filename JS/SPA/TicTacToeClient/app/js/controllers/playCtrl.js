'use strict';

app.controller('playCtrl', ['$scope', 'errorHandler', function($scope, errorHandler) {
    notifier.success('Partial 1!');
    notifier.error('Partial 1');
}]);