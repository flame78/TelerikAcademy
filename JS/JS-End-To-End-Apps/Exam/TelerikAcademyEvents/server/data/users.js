var User = require('mongoose').model('User'),
    paging = require('../utilities/paging');


module.exports = {
    create: function (user, callback) {
        console.log(user);
        User.create(user, function (err, user) {
                if (err) {
                    if (err.code = 11000) {
                        var messageAsStr = err.message.toString();
                        var msg = messageAsStr.substr(messageAsStr.indexOf('dup key: { : "')+14).split('"')[0] + ' already used';
                        err.errorMessage= msg;
                    }
                    else {
                        err.errorMessage= JSON.stringify(err);
                    }
                }
                callback(err,user);
            }
        );
    },
    findOne: function (obj, callback) {
        User.findOne(obj).exec(callback);
    },
    update: function (obj, userData, callback) {
        User.update(obj, userData, callback);
    },
    getQuery: function (err, success, queryObject, pageSize) {
        paging.populateResponse(err, success, queryObject, User, 'fullName', pageSize)
    }
}