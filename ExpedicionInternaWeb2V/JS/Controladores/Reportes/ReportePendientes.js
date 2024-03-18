'use strict';

/* App Module */

angular.module('simihApp').controller('ReportePendientes',
    function ($scope, $rootScope, $modal, uiGridConstants, $timeout, ExportarService, UtilsService, $filter, Requester) {

        /* Configuracion */

        $scope.configuracion = {

            nombreBotonMostrarOcultarDetalle: 'Mostrar Detalle'
        };

        /**
        * Eventos 
        */

        $scope.eventos = {

            buscarReportePendientes: function (fechaInicial, fechaFinal) {

                $scope.presentar = [];

                if (fechaInicial == '' || fechaInicial == undefined || fechaFinal == '' || fechaFinal == undefined) {

                } else {

                    buscarReportePendientes(fechaInicial, fechaFinal);

                }
            },

            mostrarOcultarDetalle: function (fechaInicial, fechaFinal) {

                if ($scope.configuracion.nombreBotonMostrarOcultarDetalle == 'Mostrar Detalle') {

                    if ($scope.totalReclamos == 0) {

                        // No hay reclamos para mostrar

                    } else {

                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarEstadosIndicador', { dFechaInicial: fechaInicial, dFechaFinal: fechaFinal }).then(function (data) {

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

                var nombreReporte = 'Detalle de pendientes';

                var cabecera = [

                    'Autogenerado',
                    'Estado',
                    'Encargado',
                    'Área encargada',
                    'Expedición encargada',
                    'Fecha',
                    'Tipo Indicador'
                ];

                var cuerpo = [];

                angular.forEach(data, function (value, key) {

                    var obj = [

                        value.Autogenerado,
                        value.Estado,
                        UtilsService.reemplazarNulo(value.CasillaDe, ''),
                        UtilsService.reemplazarNulo(value.Origen, ''),
                        UtilsService.reemplazarNulo(value.Procedencia, ''),
                        UtilsService.reemplazarNulo($filter('date')(value.dFecha, 'dd/MM/yyyy'), ''),
                        UtilsService.reemplazarNulo(value.tipoIndicador, '')

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
                { name: 'Autogenerado', cellClass: 'link', cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row)" style="text-align: left;">{{row.entity.Autogenerado}}</div>', enableColumnResizing: false, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Estado', field: 'Estado', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Encargado', field: 'CasillaDe', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Área encargada', displayName: 'Área encargada',field: 'Origen', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Expedición encargada', displayName: 'Expedición encargada',field: 'Procedencia', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Fecha', field: 'dFecha', type: 'date', cellFilter: 'date:\'dd-MM-yyyy HH:mm\'', enableColumnResizing: false, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Tipo Indicador', displayName: 'Tipo indicador',field: 'tipoIndicador', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Indicador', enableFiltering: false, cellTemplate: '<div><span  ng-class="{\'text-warning\': row.entity.indicadorFlag == 2, \'text-danger\': row.entity.indicadorFlag == 3}" class="glyphicon-pag glyphicon-flag" aria-hidden="true"></span></div>' }
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

        var buscarReportePendientes = function (fechaInicio, fechaFin) {

            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarCantidadEstadosIndicador', { dFechaInicial: fechaInicio, dFechaFinal: fechaFin }).then(function (data) {

                    if (data == undefined || data == null || data.length == 0) {

                    } else {

                        $scope.presentar.push(1);

                        data = angular.fromJson(data)[0];

                        $scope.data = data;

                        data.PorcentajeIndicadorCreadoVerde = Math.round(data.IndicadorCreadoVerde / (data.IndicadorCreadoVerde + data.IndicadorCreadoAmarillo + data.IndicadorCreadoRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCustodiaRutaVerde = Math.round(data.IndicadorCustodiaRutaVerde / (data.IndicadorCustodiaRutaVerde + data.IndicadorCustodiaRutaAmarillo + data.IndicadorCustodiaRutaRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaSucursalesVerde = Math.round(data.IndicadorRutaSucursalesVerde / (data.IndicadorRutaSucursalesVerde + data.IndicadorRutaSucursalesAmarillo + data.IndicadorRutaSucursalesRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaAgenciaVerde = Math.round(data.IndicadorRutaAgenciaVerde / (data.IndicadorRutaAgenciaVerde + data.IndicadorRutaAgenciaAmarillo + data.IndicadorRutaAgenciaRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCustodiaPisoVerde = Math.round(data.IndicadorCustodiaPisoVerde / (data.IndicadorCustodiaPisoVerde + data.IndicadorCustodiaPisoAmarillo + data.IndicadorCustodiaPisoRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaPisosVerde = Math.round(data.IndicadorRutaPisosVerde / (data.IndicadorRutaPisosVerde + data.IndicadorRutaPisosAmarillo + data.IndicadorRutaPisosRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCreadoAmarillo = Math.round(data.IndicadorCreadoAmarillo / (data.IndicadorCreadoVerde + data.IndicadorCreadoAmarillo + data.IndicadorCreadoRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCustodiaRutaAmarillo = Math.round(data.IndicadorCustodiaRutaAmarillo / (data.IndicadorCustodiaRutaVerde + data.IndicadorCustodiaRutaAmarillo + data.IndicadorCustodiaRutaRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaSucursalesAmarillo = Math.round(data.IndicadorRutaSucursalesAmarillo / (data.IndicadorRutaSucursalesVerde + data.IndicadorRutaSucursalesAmarillo + data.IndicadorRutaSucursalesRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaAgenciaAmarillo = Math.round(data.IndicadorRutaAgenciaAmarillo / (data.IndicadorRutaAgenciaVerde + data.IndicadorRutaAgenciaAmarillo + data.IndicadorRutaAgenciaRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCustodiaPisoAmarillo = Math.round(data.IndicadorCustodiaPisoAmarillo / (data.IndicadorCustodiaPisoVerde + data.IndicadorCustodiaPisoAmarillo + data.IndicadorCustodiaPisoRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaPisosAmarillo = Math.round(data.IndicadorRutaPisosAmarillo / (data.IndicadorRutaPisosVerde + data.IndicadorRutaPisosAmarillo + data.IndicadorRutaPisosRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCreadoRojo = Math.round(data.IndicadorCreadoRojo / (data.IndicadorCreadoVerde + data.IndicadorCreadoAmarillo + data.IndicadorCreadoRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCustodiaRutaRojo = Math.round(data.IndicadorCustodiaRutaRojo / (data.IndicadorCustodiaRutaVerde + data.IndicadorCustodiaRutaAmarillo + data.IndicadorCustodiaRutaRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaSucursalesRojo = Math.round(data.IndicadorRutaSucursalesRojo / (data.IndicadorRutaSucursalesVerde + data.IndicadorRutaSucursalesAmarillo + data.IndicadorRutaSucursalesRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaAgenciaRojo = Math.round(data.IndicadorRutaAgenciaRojo / (data.IndicadorRutaAgenciaVerde + data.IndicadorRutaAgenciaAmarillo + data.IndicadorRutaAgenciaRojo) * 10000) / 100;
                        data.PorcentajeIndicadorCustodiaPisoRojo = Math.round(data.IndicadorCustodiaPisoRojo / (data.IndicadorCustodiaPisoVerde + data.IndicadorCustodiaPisoAmarillo + data.IndicadorCustodiaPisoRojo) * 10000) / 100;
                        data.PorcentajeIndicadorRutaPisosRojo = Math.round(data.IndicadorRutaPisosRojo / (data.IndicadorRutaPisosVerde + data.IndicadorRutaPisosAmarillo + data.IndicadorRutaPisosRojo) * 10000) / 100;



                        var dataSet = {
                            labels: ["Creados", "Custodiados en Sede Origen", "Ruta Sucursal", "Ruta Agencia", "Custodiados en Sede Destino", "Ruta Pisos"],
                            datasets: [

                                {
                                    label: "A Tiempo",
                                    data: [
                                        data.PorcentajeIndicadorCreadoVerde,
                                        data.PorcentajeIndicadorCustodiaRutaVerde,
                                        data.PorcentajeIndicadorRutaSucursalesVerde,
                                        data.PorcentajeIndicadorRutaAgenciaVerde,
                                        data.PorcentajeIndicadorCustodiaPisoVerde,
                                        data.PorcentajeIndicadorRutaPisosVerde
                                    ],
                                    backgroundColor: 'rgba(139,206,151,0.47)',
                                    borderColor: [],
                                    borderWidth: 1,
                                },
                                {
                                    label: "Con ligera demora",
                                    data: [
                                        data.PorcentajeIndicadorCreadoAmarillo,
                                        data.PorcentajeIndicadorCustodiaRutaAmarillo,
                                        data.PorcentajeIndicadorRutaSucursalesAmarillo,
                                        data.PorcentajeIndicadorRutaAgenciaAmarillo,
                                        data.PorcentajeIndicadorCustodiaPisoAmarillo,
                                        data.PorcentajeIndicadorRutaPisosAmarillo
                                    ],
                                    backgroundColor: 'rgba(218,220,75,0.47)',
                                    borderColor: [],
                                    borderWidth: 1,
                                }, {
                                    label: "Con mucha demora",
                                    data: [
                                        data.PorcentajeIndicadorCreadoRojo,
                                        data.PorcentajeIndicadorCustodiaRutaRojo,
                                        data.PorcentajeIndicadorRutaSucursalesRojo,
                                        data.PorcentajeIndicadorRutaAgenciaRojo,
                                        data.PorcentajeIndicadorCustodiaPisoRojo,
                                        data.PorcentajeIndicadorRutaPisosRojo
                                    ],
                                    backgroundColor: 'rgba(214,65,65,0.47)',
                                    borderColor: [],
                                    borderWidth: 1,
                                }
                            ]
                        }

                        $timeout(function () {

                            var ctx = document.getElementById("pendientesChart").getContext("2d");

                            var myBarChart = new Chart(ctx, {
                                type: 'bar',
                                data: dataSet,
                                fill: false,
                                options: {
                                    tooltips: {
                                        callbacks: {

                                            label: function (tooltipItem, data) {

                                                var dataset = data.datasets[tooltipItem.datasetIndex];

                                                var currentValue = dataset.data[tooltipItem.index];

                                                return currentValue + '%';

                                            }

                                        },
                                        mode: 'index',
                                        intersect: false
                                    },
                                    responsive: true,
                                    scales: {
                                        xAxes: [{
                                            stacked: true,
                                        }],
                                        yAxes: [{
                                            stacked: true
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
