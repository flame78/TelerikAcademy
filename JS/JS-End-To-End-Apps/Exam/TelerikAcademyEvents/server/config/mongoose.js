var mongoose = require('mongoose');
var models = require('../models');

module.exports = function (config) {
    mongoose.connect(config.databaseConnection);
    var db = mongoose.connection;

    db.once('open', function (err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database up and running...')
    });

    db.on('error', function (err) {
        console.log('Database error: ' + err);
    });

    models.Category.seedInitialCategories();
    models.Initiative.seedInitialInitiatives();
    models.Season.seedInitialSeasons();
    models.User.seedInitialUsers();
    models.Event.seedInitialEvent();
};