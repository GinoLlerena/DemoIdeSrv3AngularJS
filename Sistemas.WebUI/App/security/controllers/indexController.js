'use strict';
webApp.controller('indexController', ['$scope', '$location', 'authService', 'confServer', function ($scope, $location, authService, confServer) {

    var mgr = new OidcTokenManager(confServer.config);

    window.mgr = mgr;

    $scope.message = "";

    $scope.logOut = function () {
        mgr.redirectForLogout();
    }
        
    mgr.addOnTokenObtained(function () {
        console.log("token obtained");
    });
    
    $scope.login = function () {

        window.$windowScope = $scope;

        window.onDone = function () {
                console.log('modal window done');
                child.opener.$windowScope.authCompletedCB(mgr);
                child.close();
                delete window.onDone;
            };
       var child = window.open("modal.html", "_blank", "location=no,toolbar=no");
    };

    $scope.authCompletedCB = function () {
        $scope.$apply(function () {
            authService.registerExternal(mgr);
        });
    };

    $scope.authentication = authService.authentication;
    
}]);