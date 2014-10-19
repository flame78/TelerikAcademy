'use strict';

app.factory('driversResource', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl',
    function ($http, $q, identity, authorization, baseServiceUrl) {
        var driversApiUrl = baseServiceUrl + '/api/drivers';

        return {
            create: function () {
                var headers = authorization.getAuthorizationHeader();
                return $http.post(driversApiUrl + "/create", {}, { headers: headers });
            },
            join: function (id) {
                var headers = authorization.getAuthorizationHeader();
                return $http.post(driversApiUrl + "/join?gameId=" + id, {}, { headers: headers });
            },
            getPublic: function() {
                return $http.get(driversApiUrl , {}, { headers: {"content-type":"application/json" }});
            },
            getByPage: function(page) {
                var headers = authorization.getAuthorizationHeader();
                return $http.get(driversApiUrl +'?page=' + page, { headers: headers });
            },
            getByPageAndUserName: function(page, userName) {
                var headers = authorization.getAuthorizationHeader();
                return $http.get(driversApiUrl +'?page=' + page +"&username="+userName, { headers: headers });
            },
            isAuthenticated: function () {
                if (identity.isAuthenticated()) {
                    return true;
                }
                else {
                    return $q.reject('not authorized');
                }
            }
        }
    }])
