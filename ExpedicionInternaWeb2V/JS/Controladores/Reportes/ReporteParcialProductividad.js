'use strict';

/* App Module */
angular.module('simihApp').controller('ReporteParcialProductividad',
    ['$scope', '$http', 'remoteResource', 'localStorageService', '$log', 'uiGridConstants', '$window', '$rootScope', '$modal', 'Requester', 'UtilsService', 'ExportarService', '$filter', 'ImportarService', 'NotificacionService', 'TipoNotificacion',
        function ($scope, $http, remoteResource, localStorageService, $log, uiGridConstants, $window, $rootScope, $modal, Requester, UtilsService, ExportarService, $filter, ImportarService, NotificacionService, TipoNotificacion) {

            /****************************************/

            var reporte_parcial = [];

            $scope.archivoJS = [];

            

            var cargarFecha = function () {
                $scope.fromDate = new Date();
                $scope.untilDate = new Date();
            };

            $scope.fileNameChanged = function (ev) {

                $scope.nombreArchivo = ev.files[0];

                ImportarService.importarData(ev.files[0], function (data) {
                    $scope.archivoJS = data;
                    console.log($scope.archivoJS);
                });

            };

            $scope.reporteProductividadParcial = function () {

                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReporteProductividadParcial', {
                    fechaInicio: $scope.fromDate,
                    fechaFinal: $scope.untilDate
                }).then(function (data) {

                    if (!UtilsService.isUndefinedOrNullOrEmpty(data)) {

                        reporte_parcial = angular.copy(data);

                        $scope.gridReporteParcial.data = data;

                    }
                    else {
                        $scope.gridDocumentosEspeciales.data = [];
                    }

                }, function (error) {

                    NotificacionService.mostrarNotificacionSimple('Ha ocurrido un problema en la petición HTTP. Comuníquese con el administrador del sistema', TipoNotificacion.ALERT);

                });
            };



            /****************Reporte documentos****************/
            $scope.gridReporteParcial = {

                paginationPageSizes: [10, 50, 75],
                paginationPageSize: 10,
                enableFiltering: true,
                columnDefs:
                    [
                        { name: 'Servicio', field: 'servicio', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Categorias', field: 'categoria', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Criterio', field: 'criterio', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Fecha', field: 'fecha', type: 'date', cellFilter: 'date:"MMM-yyyy"', enableColumnResizing: false, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Tipo Item', displayName: 'Tipo item',field: 'tipoItem', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                        { name: 'Cantidad Items', displayName: 'Cantidad item',field: 'cantidadItem', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } }

                    ]
            };

            $scope.exportar = function () {
                if (UtilsService.isUndefinedOrNullOrEmpty(reporte_parcial)) {                    
                    NotificacionService.mostrarNotificacionSimple('No existen datos a exportar', TipoNotificacion.WARNING);
                    return;
                }

                var nombreReporte = 'Reporte Productividad Parcial';

                var cabecera = [

                    'Servicio',
                    'Categorias',
                    'Criterio',
                    'Fecha',
                    'Tipo_Item',
                    'Cantidad_Items',
                    'Total_horas_empleadas',
                    'Cantidad_personal_requerido'
                ];

                var cuerpo = [];

                angular.forEach(reporte_parcial, function (value, key) {

                    var obj = [

                        value.servicio,
                        value.categoria,
                        value.criterio,
                        $filter('date')(value.fecha, 'MMM-yyyy'),
                        value.tipoItem,
                        value.cantidadItem

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


            // --------------------------------------------------------------------------------------------------

            $scope.manejarEventoImportarReporte = function (ev) {

                $scope.JsonValidado = [];

                $scope.UsuariosJSON = [];

                if ($scope.archivoJS.length > 0) {

                    var i = 1;

                    var mensaje = '';
                   
                    if (!angular.isDefined($scope.archivoJS[0].Servicio) ||
                        !angular.isDefined($scope.archivoJS[0].Categorias) ||
                        !angular.isDefined($scope.archivoJS[0].Criterio) ||
                        !angular.isDefined($scope.archivoJS[0].Fecha) ||
                        !angular.isDefined($scope.archivoJS[0].Tipo_Item) ||
                        !angular.isDefined($scope.archivoJS[0].Cantidad_Items) ||
                        !angular.isDefined($scope.archivoJS[0].Total_horas_empleadas) ||
                        !angular.isDefined($scope.archivoJS[0].Cantidad_personal_requerido)) {
                        NotificacionService.mostrarNotificacionSimple(`El archivo no tiene el formato de columnas correcto`, TipoNotificacion.ALERT);
                        return;
                    }



                    $scope.archivoJS.forEach(registro => {

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Servicio)) {
                            mensaje = `El campo 'servicio' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Servicio.trim().length === 0) {
                            mensaje = `El campo 'servicio' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Categorias)) {
                            mensaje = `El campo 'categorias' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Categorias.trim().length === 0) {
                            mensaje = `El campo 'categorias' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Criterio)) {
                            mensaje = `El campo 'criterio' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Criterio.trim().length === 0) {
                            mensaje = `El campo 'criterio' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Fecha)) {
                            mensaje = `El campo 'fecha' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Fecha.length === 0) {
                            mensaje = `El campo 'fecha' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Tipo_Item)) {
                            mensaje = `El campo 'tipo_item' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Tipo_Item.trim().length === 0) {
                            mensaje = `El campo 'tipo_item' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Cantidad_Items)) {
                            mensaje = `El campo 'cantidad_items' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Cantidad_Items.length === 0) {
                            mensaje = `El campo 'cantidad_items' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Total_horas_empleadas)) {
                            mensaje = `El campo 'total_horas_empleadas' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Total_horas_empleadas.length === 0) {
                            mensaje = `El campo 'total_horas_empleadas' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (UtilsService.isUndefinedOrNullOrEmpty(registro.Cantidad_personal_requerido)) {
                            mensaje = `El campo 'cantidad personal requerido' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }

                        if (registro.Cantidad_personal_requerido.length === 0) {
                            mensaje = `El campo 'cantidad personal requerido' en la fila ${i + 2} se encuentra vacío`;
                            $scope.archivoJS = [];
                            return;
                        }


                        var j = {
                            servicio: registro.Servicio.trim().toUpperCase(),
                            categoria: registro.Categorias.trim().toUpperCase(),
                            criterio: registro.Criterio.trim().toUpperCase(),
                            fecha: UtilsService.getJsDateFromExcel(registro.Fecha),
                            tipoItem: registro.Tipo_Item.trim().toUpperCase(),
                            cantidadItem: registro.Cantidad_Items,
                            totalHorasEmpleadas: registro.Total_horas_empleadas,
                            cantidadPersonalRequerido: registro.Cantidad_personal_requerido
                        };

                        $scope.JsonValidado.push(j);

                        i++;
                    });


                    if (mensaje.length > 0) {
                        NotificacionService.mostrarNotificacionSimple(mensaje, TipoNotificacion.ALERT);
                        return;
                    }

                    var reg = angular.toJson($scope.JsonValidado);

                    var nombre = $scope.nombreArchivo.name;

                    if ($scope.JsonValidado.length > 0) {

                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ImportarReporteProductividad', {
                            registros: reg,
                            nombreArchivo: nombre
                        }).then(function (data) {

                            if (!UtilsService.isUndefinedOrNullOrEmpty(data)) {

                                switch (data) {

                                    case 1:

                                        NotificacionService.mostrarNotificacionSimple('Se registró el reporte', TipoNotificacion.SUCCESS);
                                        break;                                   

                                    default:

                                        NotificacionService.mostrarNotificacionSimple('Ha ocurrido un error. Inténtelo nuevamente', TipoNotificacion.ALERT);
                                        
                                        $scope.archivoJS = [];
                                        break;
                                }
                                
                            } else {
                                NotificacionService.mostrarNotificacionSimple('Ha ocurrido un error', TipoNotificacion.ALERT);                                
                                $scope.archivoJS = [];
                                return;
                            }

                        }, function (error) {

                            NotificacionService.mostrarNotificacionSimple('Ha ocurrido un problema en la petición HTTP. Comuníquese con el administrador del sistema', TipoNotificacion.ALERT);

                        });






                    } else {
                        NotificacionService.mostrarNotificacionSimple('No hay registros válidos', TipoNotificacion.ALERT);
                        
                        $scope.archivoJS = [];
                        return;
                    }

                } else {
                    NotificacionService.mostrarNotificacionSimple('Ningún archivo seleccionado o no tiene registros.', TipoNotificacion.WARNING);
                    
                    $scope.archivoJS = [];
                    return;
                }

            };


            // ---------------------------------------------------------------------------------------------------


            cargarFecha();
        }]);

angular.module('simihApp').config(function ($datepickerProvider) {
    angular.extend($datepickerProvider.defaults, {
        dateFormat: 'dd/MM/yyyy',
        startWeek: 1,
        autoclose: true

    });
});

