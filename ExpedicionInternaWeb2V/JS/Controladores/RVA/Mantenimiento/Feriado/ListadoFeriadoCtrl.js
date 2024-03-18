app.controller('ListadoFeriadoCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants) {


    /*********************
       Configuración
   **********************/
    $scope.setActive('vMantenimiento');
    $scope.setActiveNavBar(true);


    /***************************
       Variables Incializadas
   ****************************/
    $scope.feriadoList = [];
    var campoGridList = [];

    var tmpEliminar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.eliminar(row)" ng-disabled="enRegistro"><i class="fa fa-times" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';

    var setCamposEstaticos = function () {
        campoGridList = [
            //{ displayName: 'Id', field: 'iId', width: '100', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Fecha', field: 'dFecha', width: '300', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy "', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Descripción', field: 'sDescripcion', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Tipo agencia', field: 'tipoAgencia', width: '250', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },

            { name: 'Eliminar', displayName: 'Eliminar', width: '100', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpEliminar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' }
        ];
    };

    setCamposEstaticos();

    $scope.myAppScopeProvider = {
        eliminar: function (row) {

            swal({
                title: "\u00a1Un Momento!",
                text: "Se eliminar\u00e1n el registro seleccionado. \u00bfDesea continuar?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Aceptar",
                cancelButtonText: "Cancelar",
                closeOnConfirm: false,
                closeOnCancel: true
            },
                function (isConfirm) {
                    if (isConfirm) {
                        ServiciosApi.EliminarFeriado(row.entity.iId).then(function (data) {
                            if (data === 1) {
                                $scope.obtenerFeriadoMantenimiento();
                                swal("\u00a1Registro eliminado!", "Se han eliminado el registro seleccionado.", "success");
                            }
                            else {
                                swal("Error", "Hubo un error, vuelva a intentarlo m\u00e1s tarde.", "error");
                            }
                        }, function (error) {
                            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet.", "error");
                        });
                    }
                });
        }
    };

    $scope.gridFeriados = {

        paginationPageSizes: [10, 50, 75],
        paginationPageSize: 10,
        enableFiltering: true,
        showGridFooter: true,
        columnDefs: campoGridList,
        //enableVerticalScrollbar: false,
        appScopeProvider: $scope.myAppScopeProvider,
        onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

    };

    /*Función para llamar a todas las agencias*/
    $scope.obtenerFeriadoMantenimiento = function () {

        $scope.feriadoList = [];

        ServiciosApi.ListarFeriadosActivos().then(function (data) {

            $scope.feriadoList = data;
            $scope.gridFeriados.data = $scope.feriadoList;

        }, function (error) {
            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            console.error(error);
        });
    };

    $scope.obtenerFeriadoMantenimiento();

    $scope.nuevoFeriado = function () {

        var scope = $scope.$new();
        scope.registroFeriado = null;

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/parcial/Mantenimiento/Feriado/MantenimientoFeriado.html',
            controller: 'MantenimientoFeriadoCtrl',
            scope: scope
        }).result.then(function (data) {
            //do logic
        }, function () {
            // action on popup dismissal.
        });
        return;
    };

    /*Evitar que el backspace retroceda a la ventana anterior*/
    $(document).unbind('keydown').bind('keydown', function (event) {
        var doPrevent = false;
        if (event.keyCode === 8) {
            var d = event.srcElement || event.target;
            if ((d.tagName.toUpperCase() === 'INPUT' &&
                (
                    d.type.toUpperCase() === 'TEXT' ||
                    d.type.toUpperCase() === 'PASSWORD' ||
                    d.type.toUpperCase() === 'FILE' ||
                    d.type.toUpperCase() === 'SEARCH' ||
                    d.type.toUpperCase() === 'EMAIL' ||
                    d.type.toUpperCase() === 'NUMBER' ||
                    d.type.toUpperCase() === 'DATE')
            ) ||
                d.tagName.toUpperCase() === 'TEXTAREA') {
                doPrevent = d.readOnly || d.disabled;
            }
            else {
                doPrevent = true;
            }
        }

        if (doPrevent) {
            event.preventDefault();
        }
    });

}]);
