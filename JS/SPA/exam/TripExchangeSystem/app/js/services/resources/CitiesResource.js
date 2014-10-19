'use strict';

app.factory('citiesResource', ['$http', 'baseServiceUrl',
    function ($http, baseServiceUrl) {
        var citiesApiUrl = baseServiceUrl + '/api/cities';

        return {
            get: function() {
                return $http.get(citiesApiUrl , {}, { headers: {"content-type":"application/json" }});
            }
        }
    }])
