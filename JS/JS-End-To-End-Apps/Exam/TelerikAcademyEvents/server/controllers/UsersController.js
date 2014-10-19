var encryption = require('../utilities/encryption'),
    fileUpload = require('../utilities/file-upload'),
    fs = require('fs'),
    data = require('../data');

var controllerName = 'users';
var FS_DELIMITER = '/';
var AVATARS_DIRECTORY = 'avatars';
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
    getProfileDetails: function (req, res, next) {
        data.events.find({creatorName:req.user.userName}, function (err, currentUserEvents) {
            res.render(controllerName + '/profile', {events:currentUserEvents});
        })
    },
    getAvatar: function (req, res, next) {
        var avatarsPath = 'uploads' + FS_DELIMITER + AVATARS_DIRECTORY + FS_DELIMITER;
        var file = avatarsPath + req.user.userName;
        fs.stat(file, function (err, stat) {
            if (err == null) {
                res.download(file);
            } else {
                res.download(avatarsPath + 'ninja');
            }
        });
    },
    getAll: function (req, res, next) {
        var queryObject = req.query;

        if (!queryObject.pager) {
            queryObject.pager = {
                currentPage: +queryObject.page || 1
            };
        }

        if (!queryObject.sort) {
            queryObject.sort = {
                columnName: "registerDate",
                order: "desc"
            }
        }

        data.users.getQuery(function (err) {
            res.redirect('/not-found');
        }, function (users) {
            // res.render(CONTROLLER_NAME + '/all', contestants);
            res.render(controllerName + '/all', users);

        }, queryObject, PAGE_SIZE);
    },
    getChangePassword: function (req, res, next) {
        res.render(controllerName + '/change-password');
    },
    postChangePassword: function (req, res, next) {
        var newUserData = req.body;
        var currentUser = req.user;

        // check current password
        if (currentUser.hashPass != encryption.generateHashedPassword(currentUser.salt, newUserData.currentPassword).toString()) {
            req.session.errorMessage = 'Invalid current password!';
            res.redirect('/change-password');
            return;
        }

        if (!isPasswordValid(req, newUserData)) {
            res.redirect('/change-password');
            return;
        }

        var updatedUserData = {};
        updatedUserData.salt = encryption.generateSalt();
        updatedUserData.hashPass = encryption.generateHashedPassword(updatedUserData.salt, newUserData.password);

        data.users.update({_id: currentUser._id}, updatedUserData, function () {
            res.redirect('/');
        })
    },
    getProfile: function (req, res, next) {
        res.render(controllerName + '/editprofile');
    },
    postProfile: function (req, res, next) {
        var currentUser = req.user;

        var newUserData = {};
        req.pipe(req.busboy);

        req.busboy.on('file', function (fieldname, file, filename) {
            if (filename.length > 0) {
                var filePath = AVATARS_DIRECTORY + FS_DELIMITER;
                fileUpload.saveFile(file, currentUser.userName, filePath);
            }
            else {
                data.users.update({_id: currentUser._id}, newUserData, function () {
                    res.redirect('/');
                })
            }
        });

        req.busboy.on('field', function (fieldname, val) {
            newUserData[fieldname] = val;
        });

        req.busboy.on('finish', function () {
            data.users.update({_id: currentUser._id}, newUserData, function () {
                res.redirect('/');
            })
        })
    },
    getRegister: function (req, res, next) {
        res.render(controllerName + '/register');
    },
    postRegister: function (req, res, next) {
        var username;
        var newUserData = {};
        req.pipe(req.busboy);

        req.busboy.on('file', function (fieldname, file, filename) {

            var filePath = AVATARS_DIRECTORY + FS_DELIMITER;
            fileUpload.saveFile(file, newUserData.userName, filePath);
        });

        req.busboy.on('field', function (fieldname, val) {
            newUserData[fieldname] = val;
        });

        req.busboy.on('finish', function () {

            if (!isUserNameValid(newUserData.userName)) {
                req.session.errorMessage = "The username should be between 6 and 20 characters long and can contain Latin letters, digits and the symbols '_' (underscore), ' ' (space) and '.' (dot)'";
                res.redirect('/register');
                return;
            }
            if (!isPasswordValid(req, newUserData)) {
                res.redirect('/register');
                return;
            }

            else {
                newUserData.salt = encryption.generateSalt();
                newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
                data.users.create(newUserData, function (err, user) {
                    if (err) {
                        req.session.errorMessage = err.errorMessage;
                        res.redirect('/register');
                        return;
                    }
                    req.logIn(user, function (err) {
                        if (err) {
                            res.status(400);
                            return res.send({reason: err.toString()}); // create error page
                        }

                        res.redirect('/');
                        return;
                    });
                });
            }
            //  }
        })
    },
    getLogin: function (req, res, next) {
        res.render(controllerName + '/login-user');
    },
    postLogin: function (req, res, next) {
        if (req.user) {
            res.redirect('/');
        }
        else {
            res.redirect('/login');
        }
    },
    logout: function (req, res, next) {
        res.redirect('/');
    }
};