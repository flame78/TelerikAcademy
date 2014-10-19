var express = require('express'),
    bodyParser = require('body-parser'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    passport = require('passport'),
    busboy = require('connect-busboy');

var secretPassPhrase = 'lkjlk@jer&tlj8r34ljrgdjg$#%sdf23@##';

module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', config.rootPath + '/views');
    app.use(cookieParser(secretPassPhrase));
    app.use(express.static(config.rootPath + '/../public'));
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: true }));
    app.use(busboy({ immediate: false }));
    app.use(session({resave: true, saveUninitialized: true, secret: secretPassPhrase}));
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(function (req, res, next) {
        app.locals.currentUser = req.user;
        next();
    })
};