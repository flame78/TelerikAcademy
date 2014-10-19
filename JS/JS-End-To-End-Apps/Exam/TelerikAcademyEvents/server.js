var express = require('express');

var environment = process.env.NODE_ENV || 'development';
var config = require('./server/config/config')[environment];

var app = express();


require('./server/config/express')(app, config);
require('./server/config/mongoose')(config);
require('./server/config/passport')();
require('./server/config/errorHandler')(app);
require('./server/config/routes')(app);

app.listen(config.port);
console.log('Express server listening on port ' + config.port);