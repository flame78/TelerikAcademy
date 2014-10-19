var path = require('path');
var rootPath = path.normalize(__dirname + '/../');

module.exports = {
    development: {
        rootPath: rootPath,
        databaseConnection: 'mongodb://localhost:27017/TelerikAcademyEventsSystem-ver-00-00-01',
        port: process.env.PORT || 3000
    }
}