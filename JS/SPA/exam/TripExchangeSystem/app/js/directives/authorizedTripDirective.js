'use strict';

app.directive('authorizedTripDirective', function() {
    return {
        restrict: 'A',
        template: '<td><a href="#/drivers/{{trip.driverId}}">{{trip.driverName}}</a></td><td>{{trip.from}}</td><td>{{trip.to}}</td><td>{{trip.departureDate}}</td><td>{{trip.isMine}}</td>',
        scope: {
            trip: '=trip'
        }
    };
});
