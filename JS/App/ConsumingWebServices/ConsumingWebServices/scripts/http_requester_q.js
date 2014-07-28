
    var http_requester_q = (function () {

        var requestTimeout = 5000; // milliseconds

        function getJSON(url) {

            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: "GET",
                timeout: requestTimeout,
                contentType: "application/json",
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error:function (errorData) {
                    deferred.reject(errorData);
                }
            });
        }

        function postJSON(url, data) {

            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: "POST",
                contentType: "application/json",
                timeout: requestTimeout,
                data: JSON.stringify(data),
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error: function (errorData) {
                    deferred.reject(errorData);
                }
            });
        }

        function deleteRequest(url, success, error) {
            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: "POST",
                timeout: requestTimeout,
                data: { _method: 'DELETE' },
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error:function (errorData) {
                    deferred.reject(errorData);
                }
            });
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            deleteRequest: deleteRequest
        };
    }());