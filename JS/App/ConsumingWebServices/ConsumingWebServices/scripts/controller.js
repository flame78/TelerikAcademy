define(['jquery', 'message-box'], function ($, messageBox) {

    var SUCCESSFUL_LOG_IN_MESSAGE = "You've logged in successfully!";
    var SUCCESSFUL_LOGOUT_MESSAGE = "You've logged out successfully!";
    var MESSAGE_SELECTOR = '#message-box';

    $('#logout').on('click', function () {
        show('#login');
        hide('#logout');
    });

    function toggleShowHide(id) {
        $(id).removeClass('hiden');
        $(id).toggleClass('hide');
        $(id).toggleClass('show');
    }

    function show(id) {
        $(id).removeClass('hiden');
        $(id).removeClass('hide');
        $(id).addClass('show');
    }

    function hide(id) {
        $(id).removeClass('show');
        $(id).addClass('hide');
    }

    tryToLogin = function () {
        var userData = {
            username: $('#username').val(),
            password: $('#password').val()
        };

        var that = this;
        this.dataProvider.user.login(userData, function () {
            that.loadHomeForm.call(that);
            messageBox.success(SUCCESSFUL_LOG_IN_MESSAGE, MESSAGE_SELECTOR);
        }, function (err) {
            messageBox.error(err.responseJSON.Message, MESSAGE_SELECTOR);
        });

    };

    tryToLogout = function () {
        var that = this;

        this.dataProvider.user.logout(function () {
            that.loadLoginForm.call(that);
            messageBox.success(SUCCESSFUL_LOGOUT_MESSAGE, MESSAGE_SELECTOR);
        }, function (err) {
            messageBox.error(err.responseJSON.Message, MESSAGE_SELECTOR);
        });
    };

    function Controller(dataProvider, partialViewSelector) {
        this.dataProvider = dataProvider;
        this.partialViewSelector = partialViewSelector;
    }

    Controller.prototype.loadLoginForm = function () {
            $(this.partialViewSelector).load('views/login.html');    
    };

    Controller.prototype.tryToLogin = function () {
        tryToLogin();
    };

    Controller.prototype.loadRegisterForm = function () {
   //     hide(this.partialViewSelector);
   //     setTimeout(function () {
            $(this.partialViewSelector).load('views/register.html');
   //         show(this.partialViewSelector);
    //    }, 500);
    };

    Controller.prototype.loadHomeForm = function () {
            $(this.partialViewSelector).load('views/home.html');
    };

    Controller.prototype.attachEventHandlers = function () {
        var that = this;

        $(that.partialViewSelector).on('click', '#btn-login', function () {
            tryToLogin.call(that);
            return false;
        });

        $(that.partialViewSelector).on('click', '#btn-logout', function () {
            tryToLogout.call(that);
            return false
        });
    };

    return {
        getController: function (dataProvider, partialViewSelector) {
            return new Controller(dataProvider, partialViewSelector)
        }
    };
});
