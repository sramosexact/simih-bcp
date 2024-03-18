'use strict';

/* App Module */

angular.module('simihApp').controller('ReporteRetirados',
    function ($scope, $rootScope,$modal, uiGridConstants, $timeout, ExportarService, UtilsService, $filter, Requester, NotificacionService, TipoNotificacion) {

        /* Configuracion */

        $scope.configuracion = {

             nombreBotonMostrarOcultarDetalle: 'Mostrar Detalle'

        };


        /**
        * Eventos 
        */

        $scope.eventos = {

            buscarReporteRetirados: function (fechaInicial, fechaFinal) {

                $scope.presentar = [];

                if (fechaInicial == '' || fechaInicial == undefined || fechaFinal == '' || fechaFinal == undefined) {


                } else {

                    buscarReporteRetirados(fechaInicial, fechaFinal);

                }

            },

             mostrarOcultarDetalle:function(fechaInicial, fechaFinal){

                if ($scope.configuracion.nombreBotonMostrarOcultarDetalle == 'Mostrar Detalle') {

                    if ($scope.totalReclamos == 0) {

                        // No hay reclamos para mostrar

                    }else{

                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarRetiradosPorRangoDeFecha', { dFechaInicial: fechaInicial, dFechaFinal: fechaFinal }).then(function (data) {

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

                var nombreReporte = 'Detalle de Retirados'; 

                var cabecera = [
                    
                    'Autogenerado',
                    'Remitente',
                    'Área Remitente',
                    'Expedición Remitente',
                    'Destinatario',
                    'Área Destino',
                    'Expedición Destino',
                    'Fecha Creación',
                    'Usuario Retiro',
                    'Expedición Retiro',
                    'Fecha Retiro',
                    'Motivo Retiro'
                ];

                var cuerpo = [];

                angular.forEach(data, function (value, key) {

                    var obj = [

                        value.sAutogenerado,
                        value.de,
                        value.Origen,
                        value.ExpedicionOrigen,
                        value.para,
                        value.Destino,
                        value.ExpedicionDestino,
                        UtilsService.reemplazarNulo($filter('date')(value.FechaCreacion, 'dd/MM/yyyy'), ''),
                        value.sUsuarioRetiro,
                        value.sExpedicionRetiro,
                        UtilsService.reemplazarNulo($filter('date')(value.FechaRetiro, 'dd/MM/yyyy'), ''),
                        value.sMotivoCambioEstado   
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

        $scope.totalRetirados = 0;

        $scope.motivosRetirados = 0;

        $scope.myAppScopeProvider = {

            verTrack : function(row) {        
                  var myOtherModal = $modal({    
                          scope: $scope, 
                          template: 'modalTracking.html', 
                          show: false
                      });
                  myOtherModal.$promise.then(myOtherModal.show);  
     
                  $scope.id = row.entity.iId;

                  $scope.Autogenerado = row.entity.Autogenerado;

                  Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getSeguimiento', { "id": $scope.id }).then(function (Correspondencia) {
                            $scope.dataSeguimiento = Correspondencia;
                  }, function (status) {
                      alert("Ha fallado la petición. Estado HTTP:" + status);
                  });   
            }
        }

        $scope.datagrid = {
            paginationPageSizes: [100, 250, 500,1000],
            paginationPageSize: 100,
            enableFiltering: true,
            showGridFooter:true,
            columnDefs: [
                { name: 'Autogenerado', cellClass: 'link', cellTemplate:'<div class="link" ng-click="grid.appScope.verTrack(row)" style="text-align: left;">{{row.entity.sAutogenerado}}</div>', enableColumnResizing: false, filter: { condition : uiGridConstants.filter.CONTAINS}},
                { name: 'Remitente', field: 'de', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }},            
                { name: 'Área Remitente', displayName: 'Área remitente', field: 'Origen', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Expedición Remitente', displayName: 'Expedición remitente', field: 'ExpedicionOrigen', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Destinatario', field: 'para', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }},            
                { name: 'Área Destino', displayName: 'Área destino',field: 'Destino', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Expedición Destino', displayName: 'Expedición destino',field: 'ExpedicionDestino', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Fecha Creación', displayName: 'Fecha creación',field: 'FechaCreacion', type: 'date', cellFilter: 'date:\'dd-MM-yyyy HH:mm\'', enableColumnResizing: false, filter: { condition : uiGridConstants.filter.CONTAINS}, visible: false},      
                { name: 'Usuario Retiro', displayName: 'Fecha retiro',field: 'sUsuarioRetiro', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }},            
                { name: 'Expedición Retiro', displayName: 'Expedíción retiro',field: 'sExpedicionRetiro', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Fecha Retiro', displayName: 'Fecha retiro',field: 'FechaRetiro', type: 'date', cellFilter: 'date:\'dd-MM-yyyy HH:mm\'', enableColumnResizing: false, filter: { condition : uiGridConstants.filter.CONTAINS}, visible: false},      
                { name: 'Motivo Retiro', displayName: 'Motivo retiro',field: 'sMotivoCambioEstado', enableColumnResizing: true,  filter: { condition: uiGridConstants.filter.CONTAINS }}        
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

        var buscarReporteRetirados = function (fechaInicio, fechaFin) {

            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'listarCantidadPorMotivoCambioEstado', { fechaInicio: fechaInicio, fechaFin: fechaFin }).then(function (data) {
                
                if (data == undefined || data == null || data.length == 0) {

                } else {

                    $scope.presentar.push(1);

                    data = angular.fromJson(data);

                    $scope.motivosRetirados = data.length;
                    
                    var dataSet = {
                        labels: [],
                        datasets: [{
                            label: "Motivos de Retiros",
                            data: [],
                            backgroundColor: [],
                            borderColor: [],
                            borderWidth: 1,
                        }]
                    }

                    $scope.totalRetirados = 0;
                    angular.forEach(data, function (value, key) {

                        $scope.totalRetirados += value.iCantidad;
                        dataSet.labels.push(value.sDescripcion);
                        dataSet.datasets[0].data.push(value.iCantidad);
                        dataSet.datasets[0].backgroundColor.push('rgba(55, 82, 92, 0.2)');
                        dataSet.datasets[0].borderColor.push('rgba(55, 82, 92, 0.2)');

                    });

                    $timeout(function () {

                        var ctx = document.getElementById("retiradosChart").getContext("2d");

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
        }


    });


