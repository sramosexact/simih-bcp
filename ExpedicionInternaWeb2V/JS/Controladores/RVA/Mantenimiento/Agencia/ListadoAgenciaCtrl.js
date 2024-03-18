/*Controlador de la página ListadoAgencia.html*/
app.controller('ListadoAgenciaCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants) {

    /*********************
        Configuración
    **********************/
    $scope.setActive('vMantenimiento');
    $scope.setActiveNavBar(true);


    /***************************
       Variables Incializadas
   ****************************/
    $scope.agenciasList = [];
    var campoGridList = [];

    var tmpModificar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.modificar(row)" ng-disabled="enRegistro"><i class="fa fa-pencil" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';


    var setCamposEstaticos = function () {
        campoGridList = [
            { displayName: 'Codigo', field: 'codigoAgencia', width: '100', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Agencia', field: 'agencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Proveedor', field: 'proveedor', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Tipo agencia', field: 'tipoAgencia', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Días plazo recepción', field: 'diasPlazoRecepcion', width: '140', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Arco inferior recojo', field: 'arcoInferior', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Arco superior recojo', field: 'arcoSuperior', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Estado', field: 'estado', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { name: 'Modificar', displayName: 'Modificar', width: '100', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpModificar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' }
        ];
    };

    setCamposEstaticos();

    $scope.myAppScopeProvider = {
        modificar: function (row) {
            var scope = $scope.$new();
            scope.registroAgencia = row.entity;           

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/parcial/Mantenimiento/Agencia/MantenimientoAgencia.html',
                controller: 'MantenimientoAgenciaCtrl',
                scope: scope,
                windowClass: 'app-modal-window',
                size: 'lg',
            }).result.then(function (data) {
                //do logic
            }, function () {
                // action on popup dismissal.
            });
            return;
            




        }
    };

    $scope.gridAgencias = {

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
    $rootScope.obtenerAgenciasMantenimiento = function () {

        $scope.agenciasList = [];

        ServiciosApi.ListarAgenciasRegistradas().then(function (data) {
            $scope.agenciasList = data;
            $scope.gridAgencias.data = $scope.agenciasList;
        }, function (error) {
            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            console.error(error);
        });


    };

    $rootScope.obtenerAgenciasMantenimiento();

    $scope.nuevaAgencia = function () {
        
        var scope = $scope.$new();
        scope.registroAgencia = null;

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/parcial/Mantenimiento/Agencia/MantenimientoAgencia.html',
            controller: 'MantenimientoAgenciaCtrl',
            scope: scope,
            size: 'lg',
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


