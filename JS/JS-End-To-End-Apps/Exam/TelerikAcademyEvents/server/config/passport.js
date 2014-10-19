var passport = require('passport'),
    LocalPassport = require('passport-local'),
    data = require('../data/index');

module.exports = function () {
    passport.use(new LocalPassport(function (username, password, done) {
        data.users.findOne({ userName: username }, function (err, user) {
            if (err) {
                console.log('Error loading user: ' + err);
                return;
            }

            if (!user) {
                return done(null, false, {message: 'Wrong user name!'});
            }

            if (user && user.authenticate(password)) {
                return done(null, user);
            }

            return done(null, false, {message: 'Invalid password!'});
        })
    }));

    passport.serializeUser(function (user, done) {
        if (user) {
            return done(null, user._id);
        }
    });

    passport.deserializeUser(function (id, done) {
        data.users.findOne({_id: id}, function (err, user) {
            if (err) {
                console.log('Error loading user: ' + err);
                return;
            }

            if (user) {
                return done(null, user);
            }
            else {
                return done(null, false);
            }
        })
    });
};