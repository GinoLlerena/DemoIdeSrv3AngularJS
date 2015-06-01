webApp.controller('unidadController', function ($location, sharedData, unidadService) {
    var vm = this;

    vm.unidades = [];
    vm.totalItems = 0;
    vm.usersPerPage = 10;

    getResultsPage();

    function pageChanged() {
        getResultsPage();
    };
    
    function edit(Id) {
        sharedData.value = Id;
        $location.path("/unidades/unidad");
    }

    function destroy(Id) {
        sharedData.value = Id;
        $location.path("/unidades/deleteunidad");
    }

    function getResultsPage() {

        var promise = unidadService.getUnidades();

            promise.then(function (results) {
                    vm.unidades = results.data;
                    vm.totalItems = results.data.length;
                },
            function (error) {
                alert(error.data.message);
            });
    };


    vm.edit = edit;
    vm.destroy = destroy;
    vm.pageChanged = pageChanged;

});