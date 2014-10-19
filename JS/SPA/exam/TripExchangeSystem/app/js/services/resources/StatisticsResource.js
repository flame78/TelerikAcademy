'use strict';

app.factory('statisticsResource', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl',
    function ($http, $q, identity, authorization, baseServiceUrl) {
        var driversApiUrl = baseServiceUrl + '/api/stats';

        return {
            get: function() {
                return $http.get(driversApiUrl , {}, { headers: {"content-type":"application/json" }});
            }
        }
    }])

