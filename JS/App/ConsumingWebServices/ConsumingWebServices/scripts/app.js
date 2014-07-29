require.config({
    paths: {
        'jquery': '../libs/jquery-2.1.1',
        'sammy': '../libs/sammy',
        'bootstrap': '../libs/bootstrap',
        'handlebars': '../libs/handlebars-v1.3.0',
        'underscore': '../libs/underscore',
        'q': '../libs/q',
        'crypto-js': '../libs/sha1',
        'http-requester': 'http-requester-q',
        'message-box': 'message-box',
        'data-provider': 'data-provider',
        'controller': 'controller',
        'app-data': 'data-provider'
    }
});

require(['jquery', 'sammy', 'controller', 'data-provider'],
    function ($, Sammy, controller, dataProvider) {

        debugger;
        var ROOT_URL = 'http://localhost:40643/api';
        var APPLICATION_NAME = 'exam';
        var partialViewSelector = '#wrapper';

        var appDataProvider = dataProvider.getDataProvider(ROOT_URL, APPLICATION_NAME);
        var appController = controller.getController(appDataProvider, partialViewSelector);
        appController.attachEventHandlers();

        var app = Sammy(partialViewSelector, function () {


            /*
                var bullsAndCowsApp = Sammy(partialViewSelector, function () {
                    this.get("#/login", function () {
                        if (appDataProvider.isUserLoggedIn()) {
                            window.location = '#/home';
                            return;
                        }
            
                        appController.loadLoginForm();
                    });
            
                    this.get("#/home", function () {
                  
                });
                */



            this.put('#/log', function () {
                debugger;
                appController.tryToLogin();
                return false;
            });

            this.put('#/reg', function () {
                toggleShowHide('#register');
                show('#logout');
            });

            this.put('#/reg', function () {
                toggleShowHide('#register');
                show('#logout');
            });

            this.get('#/login', function () {
                if (appDataProvider.isUserLoggedIn()) {
                    this.redirect('#/main');
                    return;
                }

                appController.loadLoginForm();
            });

            this.get('#/register', function () {
                if (appDataProvider.isUserLoggedIn()) {
                    this.redirect('#/main');
                    return;
                }
                appController.loadRegisterForm();
            });

            this.get('#/', function () {
                if (!appDataProvider.isUserLoggedIn()) {
                    this.redirect('#/login');
                    return;
                }

                appController.loadHomeForm();
            });
        });

        app.run('#/');
    });

/*   require(["jquery", "sammy"], function ($, sammy) {
       var app = sammy("#wrapper",function () {
           this.get("#/", function () {
               alert("In home");
               $("body").append(
               )
           });

           this.get("#/about", function () {

           });

           this.get("#/item/:id", function (id) {
               alert("In item with id: " + this.params["id"]);
           });
       });
       app.run("#/");

   });*/
