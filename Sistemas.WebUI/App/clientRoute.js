
webApp.config(["$routeProvider", "$locationProvider", "$httpProvider", function ($routeProvider, $locationProvider, $httpProvider) {

    $httpProvider.interceptors.push('authInterceptorService');

    $routeProvider.when("/", {
        templateUrl: "/app/home/html/home.html",
        controller:  "homeController"
    });
        
    $routeProvider.when("/unidades", {
        templateUrl: "/app/unidad/html/unidadList.html",
        controller: "unidadController",
        controllerAs: "vm"
    });

    $routeProvider.when("/unidades/unidad", {
        templateUrl: "/app/unidad/html/unidadForm.html",
        controller: "crudUnidadController",
        controllerAs: "vm"
    });

    $routeProvider.when("/unidades/deleteunidad", {
        templateUrl: "/app/unidad/html/deleteUnidadForm.html",
        controller: "crudUnidadController",
        controllerAs: "vm"
    });

    $routeProvider.when("/about", {
        templateUrl: "/app/home/html/about.html"
    });

    $routeProvider.otherwise({
        redirecTo: '/'
    });

    $locationProvider.html5Mode(true).hashPrefix('!');

}]);