'use strict';

app.factory('tripsResource', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl',
    function ($http, $q, identity, authorization, baseServiceUrl) {
        var tripApiUrl = baseServiceUrl + '/api/trips';

        return {
           /* create: function () {
                var headers = authorization.getAuthorizationHeader();
                return $http.post( tripApiUrl  + "/create", {}, { headers: headers });
            },
            join: function (id) {
                var headers = authorization.getAuthorizationHeader();
                return $http.post( tripApiUrl  + "/join?gameId=" + id, {}, { headers: headers });
            },*/
            getPublic: function() {
                return $http.get( tripApiUrl  , {}, { headers: {"content-type":"application/json" }});
            },
        /*    api/trips?page={P}*/
            getByPage: function(page) {
                var headers = authorization.getAuthorizationHeader();
                return $http.get( tripApiUrl  +'?page=' + page, { headers: headers });
            },
        /*    api/trips?page={P}&orderBy ={S}&orderType={O}*/
            getByPageOrdered: function(page, order, type) {
                var headers = authorization.getAuthorizationHeader();
                return $http.get(tripApiUrl +'?page=' + page +"&orderBy="+order+"&orderType="+type,{ headers: headers });
            },
           /* api/trips?page={P}&from={F}&to={T}*/
            getFromTo: function(page, from, to) {
                var headers = authorization.getAuthorizationHeader();
                console.log(tripApiUrl +'?page=' + page +"&from="+from+"&to="+to);
                return $http.get(tripApiUrl +'?page=' + page +"&from="+from+"&to="+to,{ headers: headers });
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

