var Season = require('mongoose').model('Season'),
    paging = require('../utilities/paging');


module.exports = {
    create: function (season, callback) {
        Season.create(season, function (err, category) {
                if (err) {
                    if (err.code = 11000) {
                        var messageAsStr = err.message.toString();
                        var msg = messageAsStr.substr(messageAsStr.indexOf('dup key: { : "') + 14).split('"')[0] + ' already exist';
                        err.errorMessage = msg;
                    }
                    else {
                        err.errorMessage = JSON.stringify(err);
                    }
                }
                callback(err, season);
            }
        );
    },
    find: function (obj, callback) {
        Season.find(obj, callback);
    }
   /* update: function (obj, data, callback) {
        Season.update(obj, data, callback);
    },
    getQuery: function (err, success, queryObject, pageSize) {
        paging.populateResponse(err, success, queryObject, Season, '', pageSize)
    }*/
}
