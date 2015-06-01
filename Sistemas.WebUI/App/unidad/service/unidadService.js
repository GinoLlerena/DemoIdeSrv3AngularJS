
webApp.service("unidadService", function ($http, confServer) {

    this.data = [];

    this.getTest = function () {
        return $http.get(confServer.apiUrl + "api/Unidad/test");
    };
    
    this.getUnidades = function () {
        return $http.get(confServer.apiUrl + "api/Unidad");
    };

    

    this.getPaginado = function (page) {
        return $http.get(confServer.apiUrl + "api/Unidad/paging/" + page)
            .success(function (data) {
                this.data = data;
            });
    };
    
    this.getUnidad = function (id) {
        return $http.get(confServer.apiUrl + "api/Unidad/" + id);
    };

    
    this.post = function (Unidad) {
        var request = $http({
            method: "post",
            url: confServer.apiUrl + "api/Unidad/",
            data: Unidad
        });
        return request;
    };

    
    this.put = function (id, Unidad) {
        var request = $http({
            method: "put",
            url: confServer.apiUrl +  "api/Unidad/" + id,
            data: Unidad
        });
        return request;
    };

    
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: confServer.apiUrl +  "api/Unidad/" + id
        });
        return request;
    };
});
