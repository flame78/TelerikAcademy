var mongoose = require('mongoose');

var initiativeSchema = mongoose.Schema({
    name: {type: String, required: true}
});

var Initiative = mongoose.model('Initiative', initiativeSchema);

module.exports.seedInitialInitiatives = function () {
    Initiative.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find initiatives: ' + err);
            return;
        }

        if (collection.length === 0) {
            Initiative.create({name:"Software Academy"});
            Initiative.create({name:"Algo Academy"});
            Initiative.create({name:"School Academy"});
            Initiative.create({name:"Kids Academy"});
            console.log('Initiatives added to database...');
        }
    });
};