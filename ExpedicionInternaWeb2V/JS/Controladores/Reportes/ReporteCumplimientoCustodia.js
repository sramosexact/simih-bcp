'use strict';

/* App Module */

angular.module('simihApp').controller('ReporteCumplimientoCustodia',
    function ($scope, $rootScope, $modal, uiGridConstants, $timeout, ExportarService, UtilsService, $filter, Requester) {

        /* Configuracion */

        $scope.configuracion = {

            nombreBotonMostrarOcultarDetalle: 'Mostrar Detalle'
        };

        /**
        * Eventos 
        */


        $scope.eventos = {

            buscarReporteEstados: function (fechaInicial, fechaFinal) {

                $scope.presentar = [];

                if (fechaInicial == '' || fechaInicial == undefined || fechaFinal == '' || fechaFinal == undefined) {

                } else {

                    buscarReporteEstados(fechaInicial, fechaFinal);

                }
            },

            mostrarOcultarDetalle: function (fechaInicial, fechaFinal) {

                if ($scope.configuracion.nombreBotonMostrarOcultarDetalle == 'Mostrar Detalle') {

                    if ($scope.totalReclamos == 0) {

                        // No hay reclamos para mostrar

                    } else {

                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarDetalleEstadoAutogeneradoActualCustodia', { dFechaInicial: fechaInicial, dFechaFinal: fechaFinal }).then(function (data) {

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


                } else {

                    $scope.configuracion.nombreBotonMostrarOcultarDetalle = 'Mostrar Detalle';

                }
            },

            exportar: function (data) {
                if (UtilsService.isUndefinedOrNullOrEmpty(data)) {

                    NotificacionService.mostrarNotificacionSimple('No existen datos a exportar', TipoNotificacion.WARNING)
                    return;
                }

                var nombreReporte = 'Detalle de Estados';

                var cabecera = [

                    'Autogenerado',
                    'Remitente',
                    'Área Origen',
                    'Expedición Origen',
                    'Destinatario',
                    'Área Destino',
                    'Expedición Destino',
                    'Fecha',
                    'Estado'
                ];

                var cuerpo = [];

                angular.forEach(data, function (value, key) {

                    var obj = [

                        value.Autogenerado,
                        value.de,
                        UtilsService.reemplazarNulo(value.Origen, ''),
                        UtilsService.reemplazarNulo(value.ExpedicionOrigen, ''),
                        value.para,
                        UtilsService.reemplazarNulo(value.Destino, ''),
                        UtilsService.reemplazarNulo(value.ExpedicionDestino, ''),
                        UtilsService.reemplazarNulo($filter('date')(value.dFecha, 'dd/MM/yyyy'), ''),
                        UtilsService.reemplazarNulo(value.sDescripcionEstado, '')

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

        $scope.myAppScopeProvider = {

            verTrack: function (row) {
                var myOtherModal = $modal({
                    scope: $scope,
                    template: 'modalTracking.html',
                    show: false
                });
                myOtherModal.$promise.then(myOtherModal.show);

                $scope.id = row.entity.ID;

                $scope.Autogenerado = row.entity.Autogenerado;

                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getSeguimiento', { "id": $scope.id }).then(function (Correspondencia) {
                    $scope.dataSeguimiento = Correspondencia;
                }, function (status) {
                    alert("Ha fallado la petición. Estado HTTP:" + status);
                });
            }
        }

        $scope.datagrid = {
            paginationPageSizes: [100, 250, 500, 1000],
            paginationPageSize: 100,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: [
                { name: 'Autogenerado', displayName: 'Autogenerado', cellClass: 'link', cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row)" style="text-align: left;">{{row.entity.Autogenerado}}</div>', enableColumnResizing: false, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Remitente', field: 'de', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Área Origen', displayName: 'Área origen', field: 'Origen', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Expedición Origen', displayName: 'Expedición origen', field: 'ExpedicionOrigen', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Destinatario', field: 'para', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Área Destino', displayName: 'Área destino',field: 'Destino', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Expedición Destino', displayName: 'Expedición destino',field: 'ExpedicionDestino', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Fecha', field: 'dFecha', type: 'date', cellFilter: 'date:\'dd-MM-yyyy HH:mm\'', enableColumnResizing: false, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Estado', field: 'sDescripcionEstado', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
            ],

            appScopeProvider: $scope.myAppScopeProvider
        };

        /**
         * Variables locales 
         */

        var coords = [];

        /**
        * Funciones locales 
        */

        var buscarReporteEstados = function (fechaInicio, fechaFin) {

            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarCantidadEstadoAutogeneradoActualCustodia', { dFechaInicial: fechaInicio, dFechaFinal: fechaFin }).then(function (data) {

                if (data == undefined || data == null || data.length == 0) {

                } else {

                    $scope.presentar.push(1);

                    data = angular.fromJson(data)[0];

                    $scope.data = data;

                    var dataSet = {
                        labels: ["Total Autogenerados", "Autogenerados cumplidos"],
                        datasets: [
                            {
                                data: [

                                    data.IndicadorCustodiaRutaVerde + data.IndicadorCustodiaRutaAmarillo +
                                    data.IndicadorCustodiaRutaRojo + data.IndicadorRutaSucursalesVerde + data.IndicadorRutaSucursalesAmarillo + data.IndicadorRutaSucursalesRojo +
                                    data.IndicadorCustodiaPisoVerde + data.IndicadorCustodiaPisoAmarillo + data.IndicadorCustodiaPisoRojo + data.IndicadorRutaPisosVerde + data.IndicadorRutaPisosAmarillo + data.IndicadorRutaPisosRojo,
                                    data.cantidadRecibido + data.cantidadConfirmado + data.IndicadorRutaAgenciaVerde + data.IndicadorRutaAgenciaAmarillo + data.IndicadorRutaAgenciaRojo + data.cantidadRetirado
                                ],
                                backgroundColor: [
                                    'rgba(218, 220, 75, 0.47)',
                                    'rgba(139,206,151,0.47)'
                                ],
                                hoverBackgroundColor: [
                                    'rgba(218, 220, 75, 0.85)',
                                    'rgba(139,206,151,0.85)'
                                ]
                            }
                        ]
                    }

                    $timeout(function () {

                        var ctx = document.getElementById("estadosChart").getContext("2d");

                        var myBarChart = new Chart(ctx, {
                            type: 'doughnut',
                            data: dataSet,
                            options: {                                
                                responsive: true,
                                legend: {
                                    display: false,
                                    position: 'right'
                                }
                                
                            }
                        });

                    }, 100);
                }

            }, function (error) {

            });
        };

    });
