var mongoose = require('mongoose');

var commentSchema = mongoose.Schema({
    userName: {type: String, required: true},
    date: Date,
    text: String
});

var User = mongoose.model('Comment', commentSchema);
