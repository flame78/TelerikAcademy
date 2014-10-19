var data = require('../data');

var controllerName = 'events';
var PAGE_SIZE = 3;

function isUserNameValid(userName) {
    var re = /^[A-Za-z0-9_ .-]{6,20}$/;
    return re.test(userName);
}
function isPasswordValid(req, userData) {
    if (userData.password != userData.confirmPassword) {
        req.session.errorMessage = 'Passwords do not match!';
        return false;
    }
    else if (userData.password.length < 2) {
        req.session.errorMessage = 'Passwords must be at least 2 symbols';
        return false;
    }
    return true;

}

module.exports = {
    getCreate: function (req, res, next) {
        debugger;
        if (!req.user.phoneNumber) {
            req.session.errorMessage = 'Please provide a phone number,to can create an event!';
            res.redirect('/users/editprofile');
            return;
        }
        data.categories.find({}, function (err, categories) {
            data.initiatives.find({}, function (err, initiatives) {
                data.seasons.find({}, function (err, seasons) {
                    res.render(controllerName + '/create', {categories: categories, initiatives: initiatives, seasons: seasons});
                })
            });
        });
    },
    postCreate: function (req, res, next) {
        var newEvent = req.body;
        newEvent.creatorName = req.user.userName;
        newEvent.creatorPhoneNumber = req.user.phoneNumber;
        newEvent.type += " "+ newEvent.season;

        console.dir(newEvent);
        data.events.create(newEvent, function (err, user) {
            if (err) {
                req.session.errorMessage = err.errorMessage;
                res.redirect('/');
                return;
            }

            res.redirect('/profile');
            return;
        });
    },
}
;