'use strict';

app.factory('gamesService', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', '$resource',
    function ($http, $q, identity, authorization, baseServiceUrl, $resource) {
        var gamesApiUrl = baseServiceUrl + '/api/games';

        return {
            create: function () {
                var headers = authorization.getAuthorizationHeader();
                return $http.post(gamesApiUrl + "/create", {}, { headers: headers });
            },
            join: function (id) {
                var headers = authorization.getAuthorizationHeader();
                return $http.post(gamesApiUrl + "/join?gameId=" + id, {}, { headers: headers });
            },
            list: function() {
             return $http.get(gamesApiUrl , {}, { headers: {"content-type":"application/json" }});
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