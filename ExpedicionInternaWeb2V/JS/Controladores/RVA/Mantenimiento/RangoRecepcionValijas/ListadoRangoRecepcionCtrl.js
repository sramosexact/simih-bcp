app.controller('ListadoRangoRecepcionCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants) {


    /*********************
       Configuración
   **********************/
    $scope.setActive('vMantenimiento');
    $scope.setActiveNavBar(true);


    /***************************
       Variables Incializadas
   ****************************/
    $scope.rangoRecepcionList = [];
    var campoGridList = [];

    //var tmpEliminar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.eliminar(row)" ng-disabled="enRegistro"><span class="glyphicon glyphicon-remove" style="vertical-align : top; text-align : center; font-size : 18px; "></span></button>';

    var setCamposEstaticos = function () {
        campoGridList = [
            //{ displayName: 'Id', field: 'iId', width: '100', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            //{ displayName: 'Fecha', field: 'dFecha', width: '300', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy "', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Agencia', field: 'Agencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Proveedor', field: 'Proveedor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Arco Inferior', field: 'dArcoParcialInicial', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Arco Superior', field: 'dArcoParcialFinal', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Meta', field: 'iMeta', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' }
            //{ displayName: 'Tipo agencia', field: 'tipoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },

            //{ name: 'Eliminar', displayName: 'Eliminar', width: '100', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpEliminar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' }
        ];
    };

    setCamposEstaticos();      

    $scope.gridRangoRecepcion = {

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
    $scope.obtenerRangoRecepcionMantenimiento = function () {

        $scope.rangoRecepcionList = [];

        ServiciosApi.ListarRangoRecepcion().then(function (data) {

            $scope.rangoRecepcionList = data;
            $scope.gridRangoRecepcion.data = $scope.rangoRecepcionList;

        }, function (error) {
            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            console.error(error);
        });


    };

   
    $scope.obtenerRangoRecepcionMantenimiento();

    $scope.nuevoRango = function () {

        var scope = $scope.$new();

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/parcial/Mantenimiento/RangoRecepcionValijas/MantenimientoRangoRecepcion.html',
            controller: 'MantenimientoRangoRecepcionCtrl',
            scope: scope,
            size: 'md'
            //windowClass: 'app-modal-window'
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
