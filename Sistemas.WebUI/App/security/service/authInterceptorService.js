'use strict';
webApp.factory('authInterceptorService', ['$q', '$location', 'confServer', function ($q, $location, confServer) {

    var mgr = new OidcTokenManager(confServer.config);
    window.mgr = mgr;


    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        if (!mgr.expired) {
            config.headers.Authorization = 'Bearer ' + mgr.access_token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            $location.path('/');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);