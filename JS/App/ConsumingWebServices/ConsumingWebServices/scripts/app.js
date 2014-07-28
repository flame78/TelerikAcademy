/// <reference path="http_requester.js" />
/// <reference path="../libs/require.js" />
'use strict';
(function () {

    require.config({
        paths: {
            'jquery': "../libs/jquery-2.1.1",
            'sammy': "../libs/sammy",
            'q': '../libs/q',
            'persister': 'persister',
            'http_requester': 'http_requester',
        }
    });


    require(['http_requester'], function (hr) {
        var apiURL = 'http://localhost:3000/students';

        debugger;
        hr.postJSON(apiURL, { name: 'Pesho', grade: 5 }, function (data) { console.log(data); }, function (err) { console.log(err); });

        hr.getJSON(apiURL, function (data) { console.log(data); }, function (err) { console.log(err); });

        hr.deleteRequest(apiUrl+'/1',function (data) { console.log(data); }, function (err) { console.log(err); });
    });

    /*  require(["jquery", "sammy"], function ($, sammy){
  
          var app = $.sammy(function () {
  
                  var persister = 
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
                      toggleShowHide('#logout');
                      return false;
                  });
  
                  this.put('#/reg', function () {
                      toggleShowHide('#register');
                      toggleShowHide('#logout');
                  });
  
                  this.get('#/login', function () {
                      console.log($('#register').hasClass('show'));
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
      */


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
}());