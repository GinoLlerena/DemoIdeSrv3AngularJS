webApp.controller("crudUnidadController", function ($location, sharedData, unidadService) {

    var vm = this;
    
    if (sharedData.value > 0) {
        unidadService.getUnidad(sharedData.value).then(function (results) {
            vm.unidad = results.data;
        },
        function (error) {
            alert(error.data.message);
        });
    } else vm.unidad = {};

    function save() {
        var Unidad = {
            Id: vm.unidad.id,
            Nemonico: vm.unidad.nemonico,
            Descripcion: vm.unidad.descripcion
        };

        var promise

        if (sharedData.value > 0) 
            promise = unidadService.put(sharedData.value, Unidad);
        else
            promise = unidadService.post(Unidad);

        promise.then(function (pl) {
            alert("Unidad grabada exitosamente.");
            $location.path("/unidades");
        },
              function (errorPl) {
                  alert(errorPl.statusText);
              });
    };

    function destroy() {
        var promise = unidadService.delete(sharedData.value);

        promise.then(function (pl) {
            $location.path("/unidades");
        },
        function (errorPl) {
            alert(errorPl.statusText);
        });
    };

    function cancel() {
        $location.path("/unidades");
    };

    vm.cancel = cancel;
    vm.save = save;
    vm.destroy = destroy;

});