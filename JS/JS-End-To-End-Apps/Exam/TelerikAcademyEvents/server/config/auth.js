var passport = require('passport');

module.exports = {
    login: function(req, res, next) {
        var auth = passport.authenticate('local', function(err, user, info) {
            if (info){
                req.session.errorMessage = info.message;
            }
            if (err) return next(err);
            if (!user) {
                next();
            }

            req.logIn(user, function(err) {
                if (err) return next(err);
                next();
            })
        });

        auth(req, res, next);
    },
    logout: function(req, res, next) {
        req.logout();
        next();
    },
    isAuthenticated: function(req, res, next) {
        if (!req.isAuthenticated()) {
            res.redirect('/login');
        }
        else {
            next();
        }
    }
}