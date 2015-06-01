"use strict";

var webApp = angular.module('webApp', ['ngRoute', 'ui.bootstrap', 'angular-loading-bar']);


webApp.constant("confServer", {
    "apiUrl": "http://localhost:61500/",
    "config": {
        "authority": "https://localhost:44333/core",
        "client_id": "implicitclient",
        "redirect_uri": window.location.protocol + "//" + window.location.host + "/modal.html",
        "post_logout_redirect_uri": window.location.protocol + "//" + window.location.host + "/index.html",
        "response_type": "id_token token",
        "scope": "openid profile email webapi",
    }
});

webApp.factory("sharedData", function () { return { value: 0 } });

