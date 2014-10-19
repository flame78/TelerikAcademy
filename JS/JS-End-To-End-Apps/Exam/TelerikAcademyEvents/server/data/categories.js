var Category = require('mongoose').model('Category'),
    paging = require('../utilities/paging');


module.exports = {
    create: function (category, callback) {
        //    console.log(category);
        Category.create(category, function (err, category) {
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
                callback(err, category);
            }
        );
    },
    find: function (obj, callback) {
        Category.find(obj,callback);
    }
   /* update: function (obj, userData, callback) {
        Category.update(obj, userData, callback);
    },
    getQuery: function (err, success, queryObject, pageSize) {
        paging.populateResponse(err, success, queryObject, Category, '', pageSize)
    }*/
}