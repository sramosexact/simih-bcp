'use strict';

/* App Module */
angular.module('simihApp').controller('ReporteProductividad',
    ['$scope', '$http', 'remoteResource', 'localStorageService', '$log', 'swangular','uiGridConstants', '$window', '$rootScope', '$modal', 'Requester', 'UtilsService', 'ExportarService', '$filter', 'NotificacionService','TipoNotificacion',
        function ($scope, $http, remoteResource, localStorageService, $log, swangular,uiGridConstants, $window, $rootScope, $modal, Requester, UtilsService, ExportarService, $filter, NotificacionService, TipoNotificacion) {

            /****************************************/

            var reporte_final = [];

            var cargarFecha = function () {
                $scope.fromDate = new Date();
                $scope.untilDate = new Date();
            };

            $scope._reportes = [];

            $scope.reporteProductividadGrupo = function () {

                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CargarReporteProductividad', {
                    fechaInicio: $scope.fromDate,
                    fechaFinal: $scope.untilDate
                }).then(function (data) {

                    if (!UtilsService.isUndefinedOrNullOrEmpty(data)) {

                        reporte_final = angular.copy(data);

                        $scope.gridReporteGrupo.data = data;

                    }
                    else {
                        $scope.gridDocumentosEspeciales.data = [];

                        reporte_final = [];
                    }

                }, function (error) {

                    NotificacionService.mostrarNotificacionSimple('Ha ocurrido un problema en la petición HTTP. Comuníquese con el administrador del sistema', TipoNotificacion.WARNING);

                });
            };

            $scope.DescargarFacturacion = function () {
                               
                if (UtilsService.isUndefinedOrNullOrEmpty(reporte_final)) {
                    NotificacionService.mostrarNotificacionSimple('No hay registros para descargar', TipoNotificacion.WARNING);
                    return;
                }

                $scope._reportes = [];

                reporte_final.forEach((r) => {

                    var j = {
                        iId: r.iId
                    };

                    $scope._reportes.push(j);
                });

                var reg = angular.toJson($scope._reportes);

                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReporteProductividadFinal', {
                    reportes: reg
                }).then(function (data) {

                    $scope.exportar(data);                    

                }, function (error) {

                    NotificacionService.mostrarNotificacionSimple('Ha ocurrido un problema en la petición HTTP. Comuníquese con el administrador del sistema', TipoNotificacion.WARNING);

                });
            };

            $scope.myAppScopeProvider = {
                eliminarReporte: function (ev, reporte) {

                    $scope.eliminarReporte(reporte.iId);

                }
            };

            
            $scope.eliminarReporte = function (id) {

                swangular.swal({
                    title:`Se eliminará el reporte # ${ id }`,
                    text: "¿Desea continuar?",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonText: 'Aceptar',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result) {

                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'EliminarReporteProductividad', {
                            id: id
                        }).then(function (data) {

                            if (data === 1) {
                                NotificacionService.mostrarNotificacionSimple('El reporte seleccionado ha sido eliminado', TipoNotificacion.SUCCESS);
                                $scope.reporteProductividadGrupo();
                                return;
                            }
                            else {
                                NotificacionService.mostrarNotificacionSimple('Ha ocurrido un problema', TipoNotificacion.WARNING);
                                return;
                            }

                        }, function (error) {

                            NotificacionService.mostrarNotificacionSimple('Ha ocurrido un problema en la petición HTTP. Comuníquese con el administrador del sistema', TipoNotificacion.WARNING);

                        });

                    } else {
                        alert("Cancelado");
                    }
                });



                
            };

            /****************Reporte documentos****************/
            $scope.gridReporteGrupo = {

                paginationPageSizes: [10, 50, 75],
                paginationPageSize: 10,
                enableFiltering: true,
                columnDefs:
                    [
                        { name: 'Id Reporte', field: 'iId', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Descripción', field: 'sDescripcion', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Fecha de carga', displayName: 'Fecha de carga', field: 'dFechaCarga', type: 'date', cellFilter: 'date:"MMM-yyyy"', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Eliminar', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: '<div style="height: 100%; text-align: center;" class="contenedorIconoGrid"><a href="" ng-click="grid.appScope.eliminarReporte($event, row.entity)"><span class="glyphicon glyphicon-remove-circle contenedorIconoGrid"><span></div>' }
                    ],
                appScopeProvider: $scope.myAppScopeProvider
            };

            $scope.exportar = function (data) {
                if (UtilsService.isUndefinedOrNullOrEmpty(data)) {

                    NotificacionService.mostrarNotificacionSimple('No existen datos a exportar', TipoNotificacion.WARNING);
                    return;
                }

                var nombreReporte = 'Reporte Productividad Parcial ';

                var cabecera = [

                    'Servicio',
                    'Categorias',
                    'Criterios',
                    'Fecha',
                    'Tipo Item',
                    'Cantidad Item',
                    'Total horas empleadas',
                    'Cantidad personal requerido'
                ];

                var cuerpo = [];

                angular.forEach(data, function (value, key) {

                    var obj = [

                        value.servicio,
                        value.categoria,
                        value.criterio,
                        $filter('date')(value.fecha, 'MMM-yyyy'),
                        value.tipoItem,
                        value.cantidadItem,
                        value.totalHorasEmpleadas,
                        value.cantidadPersonalRequerido

                    ];

                    cuerpo.push(obj);

                });

                ExportarService.exportarData(nombreReporte, cabecera, cuerpo);

            };


            /********************************/

            // Disashowtabsle weekend selection
            $scope.disabled = function (date, mode) {
                return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
            };


            $scope.dateOptions = {
                formatYear: 'yy',
                startingDay: 1
            };

            cargarFecha();
        }]);

angular.module('simihApp').config(function ($datepickerProvider) {
    angular.extend($datepickerProvider.defaults, {
        dateFormat: 'dd/MM/yyyy',
        startWeek: 1,
        autoclose: true

    });
});

