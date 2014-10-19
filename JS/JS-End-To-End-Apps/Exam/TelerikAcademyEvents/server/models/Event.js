var  mongoose = require('mongoose');

 var Comment = mongoose.model('Comment'),
     Category = mongoose.model('Category');

var eventSchema = mongoose.Schema({
    title: {type:String,required:true},
    description: {type:String,required:true},
    locationLatitude:Number,
    locationLongitude: Number,
    creatorName: {type: String, required: true},
    creatorPhoneNumber: {type: String},
    category: {type:String,required:true},
    type: {type:String,required:true},
    comments: [Comment],
    joinedUsers: [String]
});

var Event = mongoose.model('Event', eventSchema);

module.exports.seedInitialEvent = function () {
    Category.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find categories: ' + err);
            return;
        }

        if (collection.length === 0) {
            Event.create({
                title: 'Test',
                description: 'none',
                category: 'Free time',
                type: 'Software Academy Started 2013',
                season: 'Started 2013',
                locationLatitude: '42.650847',
                locationLongitude: '23.379431',
                creatorName: '123456',
                creatorPhoneNumber: '+359-888-888-888' });
            Category.create({name:"Free time"});
            Event.create({
                title: 'Test2',
                description: 'none',
                category: 'Free time',
                type: 'Software Academy Started 2013',
                season: 'Started 2013',
                locationLatitude: '42.650847',
                locationLongitude: '23.379431',
                creatorName: '123456',
                creatorPhoneNumber: '+359-888-888-888' });
            Category.create({name:"Free time"});
            Event.create({
                title: 'Test3',
                description: 'none',
                category: 'Free time',
                type: 'Software Academy Started 2013',
                season: 'Started 2013',
                locationLatitude: '42.650847',
                locationLongitude: '23.379431',
                creatorName: '123456',
                creatorPhoneNumber: '+359-888-888-888' });
            Category.create({name:"Free time"});
            console.log('Events added to database...');
        }
    });
};

