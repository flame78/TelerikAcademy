var auth = require('./auth');
controllers = require('../controllers/index');

module.exports = function (app) {


    app.get('/', function (req, res) {
        res.render('index');
    });

    app.get('/profile',auth.isAuthenticated, controllers.users.getProfileDetails);

    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login, controllers.users.postLogin);

    app.get('/logout', auth.logout, controllers.users.logout);

    app.get('/change-password', auth.isAuthenticated, controllers.users.getChangePassword);
    app.post('/change-password', auth.isAuthenticated, controllers.users.postChangePassword);

    app.get('/editprofile', auth.isAuthenticated, controllers.users.getProfile);
    app.post('/editprofile', auth.isAuthenticated, controllers.users.postProfile);

    app.get('/avatar', auth.isAuthenticated, controllers.users.getAvatar);

    app.get('/createevent', auth.isAuthenticated, controllers.events.getCreate);
    app.post('/createevent', auth.isAuthenticated, controllers.events.postCreate);


  /*  app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
    app.get('/upload/links', auth.isAuthenticated, controllers.files.getLinks);
    app.get('/files/download/:id', controllers.files.download);*/
    app.get('*', function (req, res) {
        res.redirect('/');
    });
};