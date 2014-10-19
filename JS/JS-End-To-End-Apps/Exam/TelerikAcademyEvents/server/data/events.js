var Event = require('mongoose').model('Event'),
    paging = require('../utilities/paging');


module.exports = {
    create: function (event, callback) {
        Event.create(event, function (err, event) {
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
                callback(err, event);
            }
        );
    },
    find: function (obj, callback) {
        Event.find(obj, callback);
    }
}
