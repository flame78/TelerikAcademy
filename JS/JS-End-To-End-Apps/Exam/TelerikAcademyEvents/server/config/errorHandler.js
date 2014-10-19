module.exports = function (app) {
  //  app.use(errorHandler);
    app.use(function errorHandler(req, res, next) {
        if (req.session.errorMessage) {
            app.locals.errorMessage = req.session.errorMessage;
            delete req.session.errorMessage;
        }
        else {
            delete app.locals.errorMessage;
        }

        /*  //   console.dir(err);
         if (err) {
         var code = err.code ? err.code : '?!?!?!';
         var message = err.message ? err.message : '?!?!?!';
         res.writeHead(code, message, {'content-type': 'text/plain'});
         res.end(message);
         }*/
        next();
    });
};


