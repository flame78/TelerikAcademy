var rest = (function () {

    var getHttpRequest, getJSON, makeRequest, postJSON;

    getHttpRequest = (function () {
        var xmlHttpFactories;
        xmlHttpFactories = [

          function () {
              return new XMLHttpRequest();
          },
          function () {
              return new ActiveXObject("Msxml3.XMLHTTP");
          },
          function () {
              return new ActiveXObject("Msxml2.XMLHTTP.6.0");
          },
          function () {
              return new ActiveXObject("Msxml2.XMLHTTP.3.0");
          },
          function () {
              return new ActiveXObject("Msxml2.XMLHTTP");
          },
          function () {
              return new ActiveXObject("Microsoft.XMLHTTP");
          }
        ];
        return function () {
            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (_error) {

                }
            }
            return null;
        };
    })();

    makeRequest = function (options) {

        var httpRequest, requestUrl, type, success, error, contentType, accept, data;

        httpRequest = getHttpRequest();
        options = options || {};
        //extract the values from the options and provide default values for the missing arguments
        requestUrl = options.url;
        type = options.type || 'GET';
        success = options.success || function () { };
        error = options.error || function () { };
        contentType = options.contentType || '';
        accept = options.accept || '';
        data = options.data || null;

        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState === 4) {
                switch (Math.floor(httpRequest.status / 100)) {
                    case 2:
                        success(httpRequest.responseText);
                        break;
                    default:
                        error(httpRequest.responseText);
                        break;
                }
            }
        };
        httpRequest.open(type, requestUrl, true);
        httpRequest.setRequestHeader('Content-Type', contentType);
        httpRequest.setRequestHeader('Accept', accept);
        return httpRequest.send(data);
    };

    getJSON = function (url, success, error) {

        var options = {
            url: url,
            type: 'GET',
            contentType: 'application/json',
            accept: 'application/json',
            success: function (data) {

                if (!success) {
                    return;
                }

                if (data) {
                    return success(JSON.parse(data));
                } else {
                    return success();
                }
            },

            error: function (err) {

                if (!error) {
                    return;
                }

                if (err) {
                    return error(JSON.parse(err));
                } else {
                    return error();
                }
            }
        };

        return makeRequest(options);
    };

    postJSON = function (url, data, success, error) {

        var options = {
            url: url,
            type: 'POST',
            contentType: 'application/json',
            accept: 'application/json',
            data: JSON.stringify(data),

            success: function (data) {

                if (!success) {
                    return;
                }

                if (data) {
                    return success(JSON.parse(data));
                } else {
                    return success();
                }
            },

            error: function (err) {

                if (!error) {
                    return;
                }
                if (err) {
                    return error(JSON.parse(err));
                } else {
                    return error();
                }
            }
        };

        return makeRequest(options);
    };

    deleteJSON = function (url, data, success, error) {

        var options = {
            url: url,
            type: 'DELETE',
            contentType: 'application/json',
            accept: 'application/json',
            data: JSON.stringify(data),

            success: function (data) {

                if (!success) {
                    return;
                }

                if (data) {
                    return success(JSON.parse(data));
                } else {
                    return success();
                }
            },

            error: function (err) {

                if (!error) {
                    return;
                }
                if (err) {
                    return error(JSON.parse(err));
                } else {
                    return error();
                }
            }
        };

        return makeRequest(options);
    };

    var promiseAjaxRequest = function (url, type, data) {
        var defferedAjax = Q.defer();

        if (data) {
            data = JSON.stringify(data);
        }

        $.ajax({
            url: url,
            type: type,
            data: data,
            contentType: "application/json",
            success: function (responseData) {
                defferedAjax.resolve(responseData);
            },
            error: function (errorData) {
                defferedAjax.reject(errorData);
            }
        });

        return defferedAjax.promise;
    };

    var promiseAjaxRequestGet = function (url) {
        return promiseAjaxRequest(url, "get");
    };

    var promiseAjaxRequestPost = function (url, data) {
        return promiseAjaxRequest(url, "post", data);
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        deleteJSON: deleteJSON,
        promiseAjaxGetJSON: promiseAjaxRequestGet,
        promiseAjaxPostJSON: promiseAjaxRequestPost
    };
})();


