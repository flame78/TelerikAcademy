var serverPort = 1234;

var formidable = require('./formidable'),
    http = require('http'),
    fs = require('fs'),
    url = require('url');

http.createServer(function (req, res) {
    var request = url.parse(req.url);
    if (request.pathname == '/upload' && req.method.toLowerCase() == 'post') {
        // parse a file upload
        var form = new formidable.IncomingForm();

        form.uploadDir = "./uploads";

        form.parse(req, function (err, fields, files, asd) {
            res.writeHead(200, {'content-type': 'text/html'});
            res.write('<a href="'+req.headers.origin+'/uploads?'+files.upload.path.substr(8)+'">Link </a>'+'to your file');
            res.end();
        });

        return;
    }

    if (request.pathname == '/uploads') {
            fs.readFile('./uploads/' + request.query, function (err, data) {
                if (err) {
                    res.writeHead(400, {'Content-Type': 'text/html'});
                    res.write('<h1>Invalid Link</h1>');
                    res.end();
                }
                else {
                    res.writeHead(200, {'Content-Type': 'text/html'});
                    res.write(data);
                    res.end();
                }
            });
        return;
    }

    // show a file upload form
    res.writeHead(200, {'content-type': 'text/html'});
    res.end(
            '<form action="/upload" enctype="multipart/form-data" method="post">' +
            '<input type="file" name="upload" multiple="multiple"><br>' +
            '<input type="submit" value="Upload">' +
            '</form>'
    );
}).listen(serverPort);

console.log('Server running at http://127.0.0.1:' + serverPort + '/');




