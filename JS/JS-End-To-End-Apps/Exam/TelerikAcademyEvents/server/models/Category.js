var mongoose = require('mongoose');

var categorySchema = mongoose.Schema({
    name: {type: String, required: true}
});

var Category = mongoose.model('Category', categorySchema);

module.exports.seedInitialCategories = function () {
    Category.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find categories: ' + err);
            return;
        }

        if (collection.length === 0) {
            Category.create({name:"Academy initiative"});
            Category.create({name:"Free time"});
            console.log('Categories added to database...');
        }
    });
};