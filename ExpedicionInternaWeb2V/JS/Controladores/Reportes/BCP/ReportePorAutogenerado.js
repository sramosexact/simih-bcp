angular.module('simihApp').controller('ReportePorAutogeneradoController',
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

        $scope.gridReportePorAutogenerado = {
            expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
            expandableRowHeight: 400,
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            enableFiltering: true,
            /*autoResize: true,*/
            showGridFooter: true,
            columnDefs: [
                {
                    name: 'Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, autoResize: true, minWidth: 100, maxWidth: 500, filter: { condition: uiGridConstants.filter.CONTAINS },
                    cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)"><span class="glyphicon glyphicon-eye-open glyphicon-color-samay-cian"></span></div>'
                },
                { field: 'CodigoDocumento', name: 'Codigo Documento', displayName: 'Codigo Documento', autoResize: true, minWidth: 200, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'Tipo', name: 'Tipo', displayName: 'Tipo', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'Estado', name: 'Estado', displayName: 'Estado', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'BandejaRemitente', name: 'Remitente', displayName: 'Remitente', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'UbicacionOrigen', name: 'Ubicacion Origen', displayName: 'Ubicacion Origen', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'BandejaDestino', name: 'Destino', displayName: 'Destino', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'UbicacionDestino', name: 'Ubicacion Destino', displayName: 'Ubicacion Destino', autoResize: true, minWidth: 300, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'Cargos', name: 'Cargos', displayName: 'Cargos', autoResize: true, minWidth: 50, maxWidth: 100, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { field: 'FechaCreacion', name: 'Fecha Creacion', displayName: 'Fecha Creacion', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaCustodiaOrigen', name: 'Fecha Custodia Origen', displayName: 'Fecha Custodia Origen', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaCustodiaDestino', name: 'FechaCustodiaDestino', displayName: 'Fecha Custodia Destino', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaRutaExpedicion', name: 'Fecha Ruta Expedicion', displayName: 'Fecha Ruta Expedicion', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaRutaPisos', name: 'Fecha Ruta Pisos', displayName: 'Fecha Ruta Pisos', autoResize: true, minWidth: 100, maxWidth: 150, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaRutaAgencia', name: 'Fecha Ruta Agencia', displayName: 'Fecha Ruta Agencia', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaRecibido', name: 'Fecha Recibido', displayName: 'Fecha Recibido', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaConfirmado', name: 'Fecha Confirmado', displayName: 'Fecha Confirmado', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'FechaRetiro', name: 'Fecha Retiro', displayName: 'Fecha Retiro', autoResize: true, minWidth: 150, maxWidth: 500, enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'CodigoAgenciaOrigen', name: 'Codigo Agencia Origen', displayName: 'Codigo Agencia Origen', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'AgenciaOrigen', name: 'Agencia Origen', displayName: 'Agencia Origen', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'CodigoAgenciaDestino', name: 'Codigo Agencia Destino', displayName: 'Codigo Agencia Destino', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'AgenciaDestino', name: 'Agencia Destino', displayName: 'Agencia Destino', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'ExpedicionCustodiaOrigen', name: 'Expedicion Custodia Origen', displayName: 'Expedicion Custodia Origen', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                //{ field: 'ExpedicionCustodiaDestino', name: 'Expedicion Custodia Destino', displayName: 'Expedicion Custodia Destino', autoResize: true, minWidth: 100, maxWidth: 500, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },

            ],
            appScopeProvider: $scope.myAppScopeProvider
        };


        $scope.gridReportePorAutogenerado.onRegisterApi = function (gridApi) {

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
                            { field: 'Observacion', name: 'Observación', displayName: 'Observación', enableColumnResizing: true, width: '50%' }
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

        

        $scope.gridReportePorAutogenerado.data = [];

        $scope.generarReportePorAutogenerado = () => {
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReportePorAutogenerado', {
                "autogenerado": $scope.autogenerado
            }).then(function (data) {
                $scope.gridReportePorAutogenerado.data = data;
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

                "Codigo Documento",
                "Tipo",
                "Estado",
                "Remitente",
                "Ubicacion Origen",
                "Destino",
                "Ubicacion Destino",
                "Cargos",
                "Fecha Creacion",
                //"Fecha Custodia Origen",
                //"Fecha Custoda Destino",
                //"Fecha Ruta Expedicion",
                //"Fecha Ruta Pisos",
                //"Fecha Ruta Agencia",
                //"Fecha Recibido",
                //"Fecha Confirmado",
                //"Fecha Retiro",
                //"Codigo Agencia Origen",
                //"Agencia Origen",
                //"Codigo Agencia Destino",
                //"Agencia Destino",
                //"Expedicion Custodia Origen",
                //"Expedicion Custodia Destino"
            ];


            ObjetoExportar.NameReporte = "ReportePorAutogenerado";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.gridReportePorAutogenerado.data, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'FechaCreacion');
            angular.forEach(datosExportar, function (value, index) {

                obj = [

                    value.CodigoDocumento,
                    value.Tipo,
                    value.Estado,
                    value.BandejaRemitente,
                    value.UbicacionOrigen,
                    value.BandejaDestino,
                    value.UbicacionDestino,
                    value.Cargos,
                    EvaluarFecha(value.FechaCreacion),
                    //EvaluarFecha(value.FechaCustodiaOrigen),
                    //EvaluarFecha(value.FechaCustodiaDestino),
                    //EvaluarFecha(value.FechaRutaExpedicion),
                    //EvaluarFecha(value.FechaRutaPisos),
                    //EvaluarFecha(value.FechaRutaAgencia),
                    //EvaluarFecha(value.FechaRecibido),
                    //EvaluarFecha(value.FechaConfirmado),
                    //EvaluarFecha(value.FechaRetiro),
                    //EvaluarString(value.CodigoAgenciaOrigen),
                    //EvaluarString(value.AgenciaOrigen),
                    //EvaluarString(value.CodigoAgenciaDestino),
                    //EvaluarString(value.AgenciaDestino),
                    //EvaluarString(value.ExpedicionCustodiaOrigen),
                    //EvaluarString(value.ExpedicionCustodiaDestino)
                ];

                ObjetoExportar.detalle.push(obj);
            });
            ExportarService.ExcelObjeto(ObjetoExportar);
        };


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
    }
);