'use strict';

app.directive('cityDirective', function() {
    return {
        restrict: 'A',
        template: '<option value="{{city}}">{{city}}</option>',
        scope: {
            city: '=city'
        }
    };
});
