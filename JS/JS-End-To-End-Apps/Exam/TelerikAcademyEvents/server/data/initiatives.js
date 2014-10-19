var Initiative = require('mongoose').model('Initiative'),
    paging = require('../utilities/paging');


module.exports = {
    create: function (initiative, callback) {
        //    console.log(category);
        Initiative.create(initiative, function (err, initiative) {
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
                callback(err, initiative);
            }
        );
    },
    find: function (obj, callback) {
        Initiative.find(obj,callback);
    }
/*    update: function (obj, userData, callback) {
        Initiative.update(obj, userData, callback);
    },
    getQuery: function (err, success, queryObject, pageSize) {
        paging.populateResponse(err, success, queryObject, Initiative, '', pageSize)
    }*/
}