var mongoose = require('mongoose'),
    encryption = require('../utilities/encryption'),
    Initiative = mongoose.model('Initiative');

var userSchema = mongoose.Schema({
    userName: { type: String, require: '{PATH} is required', unique: 'User name {VALUE} already used'},
    salt: String,
    hashPass: String,
    firstName: { type: String, required: '{PATH} is required', trim: true},
    emailAddress: { type: String, unique: "Email {VALUE} already used", require: '{PATH} is required', trim: true },
    lastName: { type: String, required: '{PATH} is required', trim: true },
    phoneNumber: { type: String, default: '', trim: true},
    facebookLink: { type: String, default: '', trim: true},
    twitterLink: { type: String, default: '', trim: true},
    linkedInLink: { type: String, default: '', trim: true},
    googlePlusLink: { type: String, default: '', trim: true},
    eventPoints: { type: Number, min: 0},
    initiatives: [Initiative]
});

userSchema.path('userName').validate(function (username) {
    return username.length >= 6 && username.length <= 20;
}, 'Username must be between 6 and 20 characters');

userSchema.method({
    authenticate: function (password) {
        if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
            return true;
        }
        else {
            return false;
        }
    }
});

var User = mongoose.model('User', userSchema);
//};

module.exports.seedInitialUsers = function () {
    User.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Cannot find users: ' + err);
            return;
        }

        if (collection.length === 0) {
            var salt;
            var hashedPwd;

            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, '123456');
            User.create({userName: '123456', firstName: '123', lastName: '456', emailAddress: '123@456.com', phoneNumber:'+359-888-888-888',
                salt: salt, hashPass: hashedPwd});
            console.log('User with userName:123456 and password:123456 generated. ')
            console.log('Users added to database...');
        }
    });
};