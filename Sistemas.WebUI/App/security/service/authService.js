'use strict';
webApp.factory('authService', ['$http', '$q', 'confServer', function ($http, $q,  confServer) {

    var mgr = new OidcTokenManager(confServer.config);
    window.mgr = mgr;


    var serviceBase = confServer.authUrl;
    var authServiceFactory = {};

    var _authentication = {
        isAuth: !mgr.expired,
        userName: ""
    };

  
    var _registerExternal = function (response) {
            _authentication.isAuth = !mgr.expired;
            _authentication.userName = response.profile.name;
    };

    authServiceFactory.authentication = _authentication;
    authServiceFactory.registerExternal = _registerExternal;

    return authServiceFactory;
}]);