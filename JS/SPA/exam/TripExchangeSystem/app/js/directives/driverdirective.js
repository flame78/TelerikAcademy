'use strict';

app.directive('driverDirective', function() {
    return {
        restrict: 'A',
        template: '<td><a href="#/drivers/{{driver.id}}">{{driver.name}}</a></td><td>{{driver.numberOfUpcomingTrips}}</td><td>{{driver.numberOfTotalTrips}}</td>',
        scope: {
            driver: '=driver'
        }
    };
});
