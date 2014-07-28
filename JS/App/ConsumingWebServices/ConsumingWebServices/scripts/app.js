/// <reference path="http_requester.js" />
/// <reference path="../libs/require.js" />
/// <reference path="persister.js" />

/*  require.config({
      paths: {
          'jquery': "../libs/jquery-2.1.1",
          'sammy': "../libs/sammy",
          'q': '../libs/q',
          'persister': 'persister',
          'http_requester': 'http_requester',
      }
  });


  require(['http_requester'], function (hr) {*/


var app = $.sammy('#container_demo',function () {

    var apiURL = 'http://localhost:3000/students';
    var appName = 'template';

    var persister = persister.getDataProvider(apiURL, appName);
    
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

    this.put('#/log', function () {
        toggleShowHide('#login');
        show('#logout');
        return false;
    });

    this.put('#/reg', function () {
        toggleShowHide('#register');
        show('#logout');
    });

    this.get('#/login', function () {
        if ($('#register').hasClass('show')) hide('#register');
        show('#login');
    });

    this.get('#/register', function () {
        hide('#login');
        show('#register');
    });

    this.get('#/', function () {
        this.redirect('#/login');
    });
});

app.run('#/');



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
