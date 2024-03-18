angular.module('simihApp').controller('ReporteDocumentosHaciaAgenciasController',
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

        $scope.gridReporteDocumentosHaciaAgencias = {
            expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
            expandableRowHeight: 400,
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            enableFiltering: true,
            autoResize: true,
            showGridFooter: true,
            columnDefs: [
                {
                    name: 'Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, autoResize: true, minWidth: 100, maxWidth: 500, filter: { condition: uiGridConstants.filter.CONTAINS },
                    cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)"><span class="glyphicon glyphicon-eye-open glyphicon-color-samay-cian"></span></div>'
                },
                { field: 'CodigoEntrega', name: 'Codigo Entrega', displayName: 'Codigo Entrega', autoResize: true, minWidth: 200, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'CodigoDocumento', name: 'Codigo Documento', displayName: 'Codigo Documento', autoResize: true, minWidth: 200, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'Tipo', name: 'Tipo', displayName: 'Tipo', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'BandejaDestino', name: 'Destino', displayName: 'Destino', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'CodigoAgenciaDestino', name: 'Codigo Agencia', displayName: 'Codigo Agencia', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'AgenciaDestino', name: 'Agencia', displayName: 'Agencia', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'Estado', name: 'Estado', displayName: 'Estado', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'FechaRutaAgencia', name: 'Fecha Ruta Agencia', displayName: 'Fecha Ruta Agencia', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'FechaRecibido', name: 'Fecha Recibido', displayName: 'Fecha Recibido', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'UsuarioRecibido', name: 'Recibido', displayName: 'Recibido', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'FechaConfirmado', name: 'Fecha Confirmado', displayName: 'Fecha Confirmado', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'UsuarioConfirmado', name: 'Confirmado', displayName: 'Confirmado', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                

            ],
            appScopeProvider: $scope.myAppScopeProvider
        };

        $scope.gridReporteDocumentosHaciaAgencias.onRegisterApi = function (gridApi) {

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
                            { field: 'Observacion', displayName: 'Observación', enableColumnResizing: true, width: '50%' }
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



        $scope.gridReporteDocumentosHaciaAgencias.data = [];

        $scope.generarReporteDocumentosHaciaAgencias = () => {
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReporteDocumentosHaciaAgencias', {
                "tipoAgenciaId": $scope.tipoAgenciaSeleccionado,                
                "fechaInicio": $scope.fromDate,
                "fechaFin": $scope.untilDate
            }).then(function (data) {
                $scope.gridReporteDocumentosHaciaAgencias.data = data;
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

                "Codigo Entrega",
                "Codigo Documento",
                "Tipo",
                "Destino",
                "Codigo Agencia Destino",
                "Agencia Destino",
                "Estado",
                "Fecha Ruta Agencia",
                "Fecha Recibido",
                "Usuario Recibido",
                "Fecha Confirmado",
                "Usuario Confirmado",
            ];


            ObjetoExportar.NameReporte = "ReporteDocumentosHaciaAgencias";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.gridReporteDocumentosHaciaAgencias.data, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'FechaCreacion');
            angular.forEach(datosExportar, function (value, index) {

                obj = [

                    value.CodigoEntrega,
                    value.CodigoDocumento,
                    value.Tipo,
                    value.BandejaDestino,                    
                    EvaluarString(value.CodigoAgenciaDestino),
                    EvaluarString(value.AgenciaDestino),
                    value.Estado,
                    EvaluarFecha(value.FechaRutaAgencia),  
                    EvaluarFecha(value.FechaRecibido),
                    EvaluarString(value.UsuarioRecibido),
                    EvaluarFecha(value.FechaConfirmado),
                    EvaluarString(value.UsuarioConfirmado),

                ];

              
                ObjetoExportar.detalle.push(obj);
            });
            ExportarService.ExcelObjeto(ObjetoExportar);
        };

        $scope.seleccionarTipoAgencia = function () {
            $scope.tipoAgenciaSeleccionado = $scope.tipo.tipoId;
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

        var listarTipoAgencias = () => {
            $scope.tiposAgencia = [
                { tipoId: 270, tipoNombre: 'LIMA' },
                { tipoId: 271, tipoNombre: 'PROVINCIA' }
            ];
        }
        
        listarTipoAgencias();
    }
);