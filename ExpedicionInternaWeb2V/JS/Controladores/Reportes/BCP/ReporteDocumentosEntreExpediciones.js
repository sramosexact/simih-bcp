angular.module('simihApp').controller('ReporteDocumentosEntreExpedicionesController',
    function ($scope, localStorageService, $filter, $rootScope, Requester, $modal, uiGridConstants, $alert, ExportarService) {

        var d = new Date(); // today!
        var hoy = new Date();
        d.setDate(d.getDate() - 0);
        $scope.fromDate = d;
        $scope.untilDate = hoy;
        $scope.fechaActual = new Date();

        $scope.myAppScopeProvider = {
            verTrack: function (row, tipo) {
                var myOtherModal = $modal({
                    scope: $scope,
                    template: 'modalTracking.html',
                    show: false
                });
                myOtherModal.$promise.then(myOtherModal.show);

                if (tipo === 1)
                    $scope.id = row.entity.Id;
                else if (tipo === 2)
                    $scope.id = row.entity.Id;

                $scope.Autogenerado = row.entity.CodigoDocumento;

                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReporteCorrespondenciaSeguimiento', { "CorrespondenciaId": $scope.id }).then(function (Correspondencia) {
                    $scope.dataSeguimiento = Correspondencia;
                }, function (status) {
                    $alert(
                        {
                            title: 'ALERTA!',
                            content: "Ha fallado la petición. Estado HTTP:" + status,
                            placement: 'top-right2',
                            type: 'info',
                            container: "#contenedorAlert",
                            show: true,
                            duration: 3
                        });
                });
            }
        }

        $scope.gridReporteDocumentosEntreExpediciones = {
            expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
            expandableRowHeight: 400,
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            enableFiltering: true,            
            showGridFooter: true,
            columnDefs: [
                {
                    name: 'Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, autoResize: true, minWidth: 100, maxWidth: 500, filter: { condition: uiGridConstants.filter.CONTAINS },
                    cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)"><span class="glyphicon glyphicon-eye-open glyphicon-color-samay-cian"></span></div>'
                },
                { field: 'CodigoValija', name: 'Codigo Valija', displayName: 'Codigo Valija', autoResize: true, minWidth: 200, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'EstadoValija', name: 'Estado Valija', displayName: 'Estado Valija', autoResize: true, minWidth: 200, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },

                { field: 'CodigoDocumento', name: 'Codigo Documento', displayName: 'Codigo Documento', autoResize: true, minWidth: 200, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'Tipo', name: 'Tipo', displayName: 'Tipo', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'Estado', name: 'Estado', displayName: 'Estado', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'FechaCreacion', name: 'Fecha Creacion', displayName: 'Fecha Creacion', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },

                { field: 'BandejaRemitente', name: 'Remitente', displayName: 'Remitente', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'UbicacionOrigen', name: 'Ubicacion Origen', displayName: 'Ubicacion Origen', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'ExpedicionOrigen', name: 'Expedicion Origen', displayName: 'Expedicion Origen', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },

                { field: 'BandejaDestino', name: 'Destino', displayName: 'Destino', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'UbicacionDestino', name: 'Ubicacion Destino', displayName: 'Ubicacion Destino', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'ExpedicionDestino', name: 'Expedicion Destino', displayName: 'Expedicion Destino', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                                
            ],
            appScopeProvider: $scope.myAppScopeProvider
        };

        $scope.gridReporteDocumentosEntreExpediciones.onRegisterApi = function (gridApi) {

            $scope.gridApi = gridApi;

            gridApi.expandable.on.rowExpandedStateChanged($scope, function (row) {
                if (row.isExpanded) {
                    row.entity.subGridOptions = {
                        enableColumnResizing: true,
                        fastWatch: true,
                        columnDefs: [
                            { field: 'EmpaqueBD', displayName: 'Empaque', width: '*' },
                            { field: 'TIPODOCUMENTO', displayName: 'Tipo documento', width: '*' },
                            { field: 'MONEDA', displayName: 'Moneda', width: '*' },
                            { field: 'cantidadBd', displayName: 'Cantidad', width: '*' },
                            { field: 'Observacion', name: 'Observacion', displayName: 'Observacion', enableColumnResizing: true, width: '50%' }
                        ]
                    };
                    
                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReporteCorrespondenciaDetalle', {
                        "correspondenciaId": row.entity.Id
                    }).then(function (Correspondencia) {
                        row.entity.subGridOptions.data = Correspondencia;
                    }, function (status) {
                        $alert(
                            {
                                title: 'ALERTA!',
                                content: "Ha fallado la petición. Estado HTTP:" + status,
                                placement: 'top-right2',
                                type: 'info',
                                container: "#contenedorAlert",
                                show: true,
                                duration: 3
                            });
                    });

                }
            });
        };

        

        $scope.gridReporteDocumentosEntreExpediciones.data = [];

        $scope.generarReporteDocumentosEntreExpediciones = () => {
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReporteDocumentosEntreExpediciones', {
                "expedicionOrigenId": $scope.expedicionOrigenSeleccionado,
                "expedicionDestinoId": $scope.expedicionDestinoSeleccionado,
                "areaOrigenId": $scope.areaOrigenSeleccionado,
                "areaDestinoId": $scope.areaDestinoSeleccionado,
                "fechaInicio": $scope.fromDate,
                "fechaFin": $scope.untilDate
            }).then(function (data) {
                $scope.gridReporteDocumentosEntreExpediciones.data = data;
            }, function (status) {
                $alert(
                    {
                        title: 'ALERTA!',
                        content: "Ha fallado la petición. Estado HTTP:" + status,
                        placement: 'top-right2',
                        type: 'info',
                        container: "#contenedorAlert",
                        show: true,
                        duration: 3
                    });
            });
        }

        $scope.exportarReporte = () => {
            var ObjetoExportar = new ExportarService.Objeto();
            ObjetoExportar.Config.TitleBackgroundColor = "#808080";
            ObjetoExportar.Config.TitleFontColor = "#fff";
            ObjetoExportar.cabecera = [
                "Codigo Valija",
                "Estado Valija",
                "Codigo Documento",
                "Tipo",
                "Estado",
                "Fecha Creacion",
                "Remitente",
                "Ubicacion Origen",
                "Expedicion Origen",
                "Destino",
                "Ubicacion Destino",
                "Expedicion Destino"
            ];


            ObjetoExportar.NameReporte = "ReporteDocumentosEntreExpediciones";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.gridReporteDocumentosEntreExpediciones.data, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'FechaCreacion');
            angular.forEach(datosExportar, function (value, index) {

                obj = [
                    value.CodigoValija,
                    value.EstadoValija,
                    value.CodigoDocumento,
                    value.Tipo,
                    value.Estado,
                    EvaluarFecha(value.FechaCreacion),
                    value.BandejaRemitente,
                    value.UbicacionOrigen,
                    value.ExpedicionOrigen,
                    value.BandejaDestino,
                    value.UbicacionDestino,
                    value.ExpedicionDestino,
                    
                ];

                ObjetoExportar.detalle.push(obj);
            });
            ExportarService.ExcelObjeto(ObjetoExportar);
        };

        $scope.seleccionarExpedicionOrigen = function () {            
            listarAreasOrigen($scope.expedicionOrigenSeleccionado);
        }

        $scope.seleccionarExpedicionDestino = function () {            
            console.log($scope.expedicionDestinoSeleccionado);
            listarAreasDestino($scope.expedicionDestinoSeleccionado);
        }

        $scope.seleccionarAreaOrigen = function () {
            $scope.areaOrigenSeleccionado = $scope.areaOrigenSeleccionado;
        }

        $scope.seleccionarAreaDestino = function () {
            $scope.areaDestinoSeleccionado = $scope.areaDestinoSeleccionado;
        }

        var EvaluarFecha = function (fecha) {
            if (fecha === null || fecha === "") {
                return "";
            }
            else {
                date = new Date(fecha);
                return $filter('date')(fecha, 'yyyy-MM-dd HH:mm:ss', 'UTC / GMT');
            }

        };

        var EvaluarString = function (valor) {
            if (valor === null || valor === undefined) {
                return "";
            }
            return valor;
        };

        var fechaReal = function (fecha) {
            var year = fecha.getFullYear();
            var month = fecha.getMonth();
            var day = fecha.getDate();
            var hour = 0;
            var minute = 0;
            var second = 0;
            return new Date(Date.UTC(year, month, day, hour, minute, second))
        }

 
        var listarExpediciones = () => {
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarExpediciones', {
                
            }).then(function (data) {
                $scope.expedicionesOrigen = [...data];
                $scope.expedicionesDestino = [...data];
                $scope.expedicionOrigenSeleccionado = 0;
                $scope.expedicionDestinoSeleccionado = 0;
                
            }, function (status) {
                
            });
        }

        var cargarAreasOrigen = () => {
            $scope.areasOrigen = [];
            $scope.areasOrigen = [
                { areaId: 0, areaNombre: 'TODOS' }
            ];

            $scope.areaOrigen = $scope.areasOrigen[0];
            $scope.areaOrigen.areaId = 0;
            $scope.areaOrigenSeleccionado = 0;
        }

        var listarAreasOrigen = (expedicionId) => {
            
            cargarAreasOrigen();

            if (expedicionId === 0) {
                return;
            }

            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarAreasPorExpedicion', {
                "expedicionId": expedicionId
            }).then(function (data) {
                $scope.areasOrigen.push(...data);
            }, function (status) {

            });
        }

        var cargarAreasDestino = () => {
            $scope.areasDestino = [];
            $scope.areasDestino = [
                { areaId: 0, areaNombre: 'TODOS' }
            ];

            $scope.areaDestino = $scope.areasDestino[0];
            $scope.areaDestino.areaId = 0;
            $scope.areaDestinoSeleccionado = 0;
        }

        var listarAreasDestino = (expedicionId) => {

            cargarAreasDestino();

            if (expedicionId === 0) {                  
                return;
            }

            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarAreasPorExpedicion', {
                "expedicionId": expedicionId
            }).then(function (data) {
                $scope.areasDestino.push(...data);
            }, function (status) {

            });
        }

        listarExpediciones();
        cargarAreasOrigen();
        cargarAreasDestino();
    }
);