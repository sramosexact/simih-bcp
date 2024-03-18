'use strict';

/* App Module */

angular.module('simihApp').controller('ReporteReclamos',
    function ($scope,$rootScope,uiGridConstants, $timeout, ExportarService, UtilsService, $filter, Requester, NotificacionService, TipoNotificacion) {

        /* Configuracion */

        $scope.configuracion = {

            nombreBotonMostrarOcultarDetalle: 'Mostrar Detalle'
        };

        /**
        * Eventos 
        */

        $scope.eventos = {

            buscarReporteReclamos: function (fechaInicial, fechaFinal) {

                $scope.presentar = [];

                if (fechaInicial == '' || fechaInicial == undefined || fechaFinal == '' || fechaFinal == undefined) {

                } else {

                    buscarReporteReclamos(fechaInicial, fechaFinal);

                }
            }, 

            mostrarOcultarDetalle:function(fechaInicial, fechaFinal){

                if ($scope.configuracion.nombreBotonMostrarOcultarDetalle == 'Mostrar Detalle') {

                    if ($scope.totalReclamos == 0) {

                        // No hay reclamos para mostrar

                    }else{

                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarReclamosPorRangoDeFecha', { dFechaInicial: fechaInicial, dFechaFinal: fechaFinal }).then(function (data) {

                            if (data == undefined || data == null) {

                                // Error

                            } else {
                                data = angular.fromJson(data);
                                $scope.datagrid.data = data;
                                $scope.configuracion.nombreBotonMostrarOcultarDetalle = 'OcultarDetalle';
                            }

                        }, function (error) {


                        });
                    }

                    
                }else{

                    $scope.configuracion.nombreBotonMostrarOcultarDetalle = 'Mostrar Detalle';

                }   
            }, 

            exportar: function(data){
                if (UtilsService.isUndefinedOrNullOrEmpty(data)) {

                    NotificacionService.mostrarNotificacionSimple('No existen datos a exportar', TipoNotificacion.WARNING)
                    return;
                }

                var nombreReporte = 'Detalle de reclamos'; 

                var cabecera = [
                    
                    'Código',
                    'Reclamo',
                    'Documento de referencia',
                    'Usuario',
                    'Área',
                    'Fecha Registro',
                    'Estado',
                    'Tipo Reclamo',
                    'Usuario de atención',
                    'Fecha Atención',
                    'Fundado',
                    'Entidad Responsable',
                    'Persona Responsable',
                    'Fecha Solución',
                    'Causa',
                    'Solución',
                ];

                var cuerpo = [];

                angular.forEach(data, function (value, key) {

                    var obj = [

                        value.iIdReclamo,
                        value.sDetalle,
                        UtilsService.reemplazarNulo(value.sDocReferencia,''),
                        value.sUsuarioCliente,
                        value.sArea,
                        UtilsService.reemplazarNulo($filter('date')(value.dFechaRegistro, 'dd/MM/yyyy'), ''),
                        value.sEstadoReclamo,
                        UtilsService.reemplazarNulo(value.sTipoReclamoUTD,''),
                        UtilsService.reemplazarNulo(value.sUsuarioAtencion,''),
                        UtilsService.reemplazarNulo($filter('date')(value.dFechaAtencion, 'dd/MM/yyyy'), ''),
                        UtilsService.reemplazarNulo(value.sFundado,''),
                        UtilsService.reemplazarNulo(value.sDescripcionTipoResponsable,''),
                        UtilsService.reemplazarNulo(value.sPersonaResponsable,''),
                        UtilsService.reemplazarNulo($filter('date')(value.dFechaSolucion, 'dd/MM/yyyy'), ''),
                        UtilsService.reemplazarNulo(value.sCausa,''),
                        UtilsService.reemplazarNulo(value.sSolucion,'')

                    ];

                    cuerpo.push(obj);

                });

                ExportarService.exportarData(nombreReporte, cabecera, cuerpo); 
            }
        }

        /**
         * Objetos del DOM
         */
        
        $scope.presentar = [];

        $scope.totalReclamos = 0;

        $scope.motivosReclamos = 0;

        $scope.datagrid = {
            paginationPageSizes: [100, 250, 500,1000],
            paginationPageSize: 100,
            enableFiltering: true,
            showGridFooter:true,
            columnDefs: [
                { name: 'Código', displayName: 'Código',field: 'iIdReclamo', enableColumnResizing: false, filter: { condition : uiGridConstants.filter.CONTAINS}},
                { name: 'Reclamo', field: 'sDetalle', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }},            
                { name: 'Documento de referencia', displayName: 'Documento de referencia', field: 'sDocReferencia', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Usuario', field: 'sUsuarioCliente', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Área', displayName: 'Área',field: 'sArea', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Fecha Registro', displayName: 'Fecha registro',field: 'dFechaRegistro', type: 'date', cellFilter: 'date:\'dd-MM-yyyy HH:mm\'', enableColumnResizing: false, filter: { condition : uiGridConstants.filter.CONTAINS}, visible: false},      
                { name: 'Estado', field: 'sEstadoReclamo', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }},          
                { name: 'Tipo Reclamo', displayName: 'Tipo reclamo', field: 'sTipoReclamoUTD', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Usuario de atención', displayName: 'Usuario de atención',field: 'sUsuarioAtencion', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS } },            
                { name: 'Fecha Atención', displayName: 'Fecha atención',field: 'dFechaAtencion', type: 'date', cellFilter: 'date:\'dd-MM-yyyy HH:mm\'', enableColumnResizing: false, filter: { condition : uiGridConstants.filter.CONTAINS}, visible: false},
                { name: 'Fundado', field: 'sFundado', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Entidad Responsable', displayName: 'Entidad responsable',field: 'sDescripcionTipoResponsable', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Persona Responsable', displayName: 'Persona responsable',field: 'sPersonaResponsable', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }},
                { name: 'Fecha Solución', displayName: 'Fecha solución',field: 'dFechaSolucion', type: 'date', cellFilter: 'date:\'dd-MM-yyyy HH:mm\'', enableColumnResizing: false, filter: { condition : uiGridConstants.filter.CONTAINS}, visible: false},
                { name: 'Causa', field: 'sCausa', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }},            
                { name: 'Solución', field: 'sSolucion', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }}
            ]
        };

        /**
         * Variables locales 
         */

        var coords = [];        

        /**
        * Funciones locales 
        */

        var buscarReporteReclamos = function (fechaInicio, fechaFin) {

            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarCantidadPorTiposReclamo', { fechaInicio: fechaInicio, fechaFin: fechaFin }).then(function (data) {

                if (data == undefined || data == null || data.length == 0) {

                } else {

                    $scope.presentar.push(1);

                    data = angular.fromJson(data);             

                    $scope.motivosReclamos = data.length;

                    var dataSet = {
                        labels: [],
                        datasets: [{
                            label: "Reclamos",
                            data: [],
                            backgroundColor: [], 
                            borderColor: [], 
                            borderWidth: 1,
                        }]
                    }
                    $scope.totalReclamos = 0;

                    angular.forEach(data, function (value, key) {

                        $scope.totalReclamos += value.iCantidad;
                        dataSet.labels.push(value.sDescripcion); 
                        dataSet.datasets[0].data.push(value.iCantidad);
                        dataSet.datasets[0].backgroundColor.push('rgba(55, 82, 92, 0.2)');
                        dataSet.datasets[0].borderColor.push('rgba(55, 82, 92, 0.2)');

                    });

                    $timeout(function () {

                        var ctx = document.getElementById("reclamosChart").getContext("2d");

                        var myBarChart = new Chart(ctx, {
                            type: 'horizontalBar',
                            data: dataSet,
                            fill: false,
                            options: {
                                scales: {
                                    xAxes: [{
                                        ticks: {
                                            beginAtZero: true
                                        }
                                    }]
                                }
                            }
                        });

                    }, 100);
                }

            }, function (error) {

            });
        };
        
    });


