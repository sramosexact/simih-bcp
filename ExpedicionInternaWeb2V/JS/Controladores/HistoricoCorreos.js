angular.module('simihApp').controller('HistoricoCorreos',
    ['$scope', 'localStorageService', 'uiGridConstants', '$window', '$rootScope', '$modal', 'Requester','ExportarService','$filter',
        function ($scope, localStorageService, uiGridConstants, $window, $rootScope, $modal, Requester, ExportarService, $filter) {
            var index = localStorageService.get('b');
            $scope.bandejaN = $rootScope.Bandejals[index].Id;
            $scope.tabs = [
                {
                    name: 'Bandeja de entrada',
                    url: 'recibidosHistorico.html',
                    active1: true,
                    icon: 'glyphicon-tab glyphicon-log-out colorSalida'
                }, {
                    name: 'Bandeja de salida',
                    url: 'enviadosHistorico.html',
                    active1: false,
                    icon: 'glyphicon-tab glyphicon-log-in colorIngreso'
                }, {
                    name: 'Retirados',
                    url: 'retiradosHistorico.html',
                    active1: false,
                    icon: 'glyphicon-tab glyphicon-log-in colorIngreso'
                }
            ];

            $scope.tab = 'recibidosHistorico.html';/*default tab*/
            $scope.current = 'Bandeja de entrada'; /*default active tab*/

            var d = new Date(); // today!
            var hoy = new Date();
            d.setDate(d.getDate() - 0);
            $scope.fromDate = d;
            $scope.untilDate = hoy;
            $scope.fechaActual = new Date();


            $scope.toggleTab = function (s) {
                $scope.tab = s.url;  /*tab changed*/
                $scope.current = s.name; /* changing value of current*/

                if (s.name === "Enviados") {
                    $scope.josEnviados();
                }
                if (s.name === "Bandeja de entrada") {
                    $scope.josRecibidos();
                }
                if (s.name === "Retirados") {
                    $scope.josRetirados();
                }
            };

            $scope.myAppScopeProvider = {
                verTrack: function (row, tipo) {
                    var myOtherModal = $modal({
                        scope: $scope,
                        template: 'modalTracking.html',
                        show: false
                    });
                    myOtherModal.$promise.then(myOtherModal.show);
                    /**se considera solo al tipo 2**/
                    if (tipo === 1)
                        $scope.id = row.entity.ID;
                    else if (tipo === 2)
                        $scope.id = row.entity.ID;

                    $scope.Autogenerado = row.entity.Autogenerado;
                    //2022
                    //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getSeguimiento', {
                    //    "id": $scope.id
                    //}).then(function (Correspondencia) {
                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaSeguimiento', { "CorrespondenciaId": $scope.id }).then(function (Correspondencia) {
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
            /****************************************/
            //2022
            $scope.josEnviados = function () {
                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaHistoricaBandejaSalida', {
                    //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'HistoricoSalida', {                    
                    "fechaDesde": $scope.fromDate,
                    "fechaHasta": $scope.untilDate
                }).then(function (enviado2) {
                    $scope.gridEnviados.data = enviado2;
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

            var getFechaReal = function (fecha) {
                var year = fecha.getFullYear();
                var month = fecha.getMonth();
                var day = fecha.getDate();
                var hour = 0;
                var minute = 0;
                var second = 0;
                return new Date(Date.UTC(year, month, day, hour, minute, second))
            }

            //2022
            $scope.josRecibidos = function () {



                var fechaInicialConsulta = getFechaReal($scope.fromDate);
                var fechaFinalConsulta = getFechaReal($scope.untilDate);

                //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'HistoricoIngreso', {                    
                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaHistoricaBandejaEntrada', {
                    "fechaDesde": fechaInicialConsulta,
                    "fechaHasta": fechaFinalConsulta
                }).then(function (enviado) {
                    $scope.gridRecibidos.data = enviado;
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
            //2022
            $scope.josRetirados = function () {
                //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'HistoricoRetirado', {                    
                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaHistoricaRetiradosBandejaEntrada', {
                    "fechaDesde": $scope.fromDate,
                    "fechaHasta": $scope.untilDate
                }).then(function (enviado3) {
                    $scope.gridArchivados.data = enviado3;
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

            /****************Enviados****************/
            $scope.gridEnviados = {
                expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
                paginationPageSizes: [25, 50, 75],
                paginationPageSize: 25,
                enableFiltering: true,
                columnDefs: [
                    { field: 'Autogenerado', name: 'Codigo', displayName: 'Autogenerado', width: '20%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'sTipoElemento', name: 'Tipo documento', displayName: 'Tipo documento', width: '20%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'fechaTrack', name: 'Recibido', displayName: 'Recibido el', width: '15%', enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'CasillaDe', name: 'De', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'CasillaPara', name: 'Para', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    {
                        name: 'Ver Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS },
                        cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)">Ver más</div>'
                    }
                ],
                appScopeProvider: $scope.myAppScopeProvider
            };

            $scope.gridEnviados.onRegisterApi = function (gridApi) {
                //set gridApi on scope
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
                        //2022
                        //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'obtenerDocumentoContenido2', {
                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle', {
                            "correspondenciaId": row.entity.ID
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

            /********************************/
            $scope.gridRecibidos = {
                expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
                paginationPageSizes: [25, 50, 75],
                paginationPageSize: 25,
                enableFiltering: true,
                columnDefs: [
                    { field: 'Autogenerado', name: 'Codigo', displayName: 'Autogenerado', width: '20%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'sTipoElemento', name: 'Tipo Documento', displayName: 'Tipo documento', width: '20%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'fechaTrack', name: 'Recibido', displayName: 'Recibido el', width: '15%', enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'CasillaDe', name: 'De', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'CasillaPara', name: 'Para', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    {
                        name: 'Ver Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS },
                        cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)">Ver más</div>'
                    }
                ],
                appScopeProvider: $scope.myAppScopeProvider
            };

            $scope.gridRecibidos.onRegisterApi = function (gridApi) {
                //set gridApi on scope
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
                        //2022
                        //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'obtenerDocumentoContenido2', {
                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle', {
                            "correspondenciaId": row.entity.ID
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

            /********************************/
            $scope.gridArchivados = {
                expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
                paginationPageSizes: [25, 50, 75],
                paginationPageSize: 25,
                enableFiltering: true,
                columnDefs: [
                    { field: 'Autogenerado', name: 'Autogenerado', displayName: 'Autogenerado', width: '20%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'sTipoElemento', name: 'Tipo Documento', displayName: 'Tipo documento', width: '20%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'fechaTrack', name: 'Recibido', displayName: 'Retirado el', width: '15%', enableColumnResizing: true, cellFilter: 'date: "dd/MM/yyyy HH:mm"', filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'Motivo', name: 'Motivo', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'CasillaDe', name: 'De', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { field: 'CasillaPara', name: 'Para', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    {
                        name: 'Ver Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS },
                        cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)">Ver más</div>'
                    }
                ],
                appScopeProvider: $scope.myAppScopeProvider
            };

            $scope.gridArchivados.onRegisterApi = function (gridApi) {
                //set gridApi on scope
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
                        //2022
                        //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'obtenerDocumentoContenido2', {
                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle', {
                            "correspondenciaId": row.entity.ID
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

            $scope.actualizando = function () {
                $scope.josEnviados();

                $scope.josRecibidos();

                $scope.josRetirados();
            }

            /* $scope.gridArchivados.data = [
                     { Autogenerado: 'ABC131', Recibido: '20/02/2015', De: 'Jose Prado', Para: 'Frank Florez' },
                     { Autogenerado: 'ABC132', Recibido: '20/02/2015', De: 'Jose Prado', Para: 'Frank Florez' },
             ];*/
            /********************************/
            $scope.setVerDetalle = function () {
                $rootScope.retorno = '#/HistoricoCorreos';
                $window.location.href = '#/Tracking';
            }

            // Disashowtabsle weekend selection
            $scope.disabled = function (date, mode) {
                return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
            };

            /*  $scope.open = function ($event) {
                  $event.preventDefault();
                  $event.stopPropagation();
          
                  $scope.opened = true;
              };
          
              $scope.open2 = function ($event) {
                  $event.preventDefault();
                  $event.stopPropagation();
          
                  $scope.opened2 = true;
              };*/
            $scope.dateOptions = {
                formatYear: 'yy',
                startingDay: 1
            };

            /*  $scope.hidetabs = function () {
                  $scope.tabs = false;
              }*/


            $scope.exportarReporteEntrada = () => {
                var ObjetoExportar = new ExportarService.Objeto();
                ObjetoExportar.Config.TitleBackgroundColor = "#808080";
                ObjetoExportar.Config.TitleFontColor = "#fff";
                ObjetoExportar.cabecera = [

                    "Autogenerado",
                    "Tipo documento",
                    "Recibido el",
                    "De",
                    "Para"

                ];


                ObjetoExportar.NameReporte = "HistoricosEntrada";
                var obj = [];
                var datosExportar = [];
                angular.copy($scope.gridRecibidos.data, datosExportar);
                datosExportar = $filter('orderBy')(datosExportar, 'FechaTrack');
                angular.forEach(datosExportar, function (value, index) {

                    obj = [

                        value.Autogenerado,
                        value.sTipoElemento,
                        EvaluarFecha(value.fechaTrack),
                        value.CasillaDe,
                        value.CasillaPara

                    ];

                    ObjetoExportar.detalle.push(obj);
                });
                ExportarService.ExcelObjeto(ObjetoExportar);
            };


            $scope.exportarReporteSalida = () => {
                var ObjetoExportar = new ExportarService.Objeto();
                ObjetoExportar.Config.TitleBackgroundColor = "#808080";
                ObjetoExportar.Config.TitleFontColor = "#fff";
                ObjetoExportar.cabecera = [

                    "Autogenerado",
                    "Tipo documento",
                    "Recibido el",
                    "De",
                    "Para"

                ];


                ObjetoExportar.NameReporte = "HistoricosSalida";
                var obj = [];
                var datosExportar = [];
                angular.copy($scope.gridEnviados.data, datosExportar);
                datosExportar = $filter('orderBy')(datosExportar, 'fechaTrack');
                angular.forEach(datosExportar, function (value, index) {

                    obj = [

                        value.Autogenerado,
                        value.sTipoElemento,
                        EvaluarFecha(value.fechaTrack),
                        value.CasillaDe,
                        value.CasillaPara

                    ];

                    ObjetoExportar.detalle.push(obj);
                });
                ExportarService.ExcelObjeto(ObjetoExportar);
            };

            $scope.exportarReporteArchivados = () => {
                var ObjetoExportar = new ExportarService.Objeto();
                ObjetoExportar.Config.TitleBackgroundColor = "#808080";
                ObjetoExportar.Config.TitleFontColor = "#fff";
                ObjetoExportar.cabecera = [

                    "Autogenerado",
                    "Tipo documento",
                    "Retirado el",
                    "Motivo",
                    "De",
                    "Para"

                ];


                ObjetoExportar.NameReporte = "HistoricosArchivados";
                var obj = [];
                var datosExportar = [];
                angular.copy($scope.gridArchivados.data, datosExportar);
                datosExportar = $filter('orderBy')(datosExportar, 'fechaTrack');
                angular.forEach(datosExportar, function (value, index) {

                    obj = [

                        value.Autogenerado,
                        value.sTipoElemento,
                        EvaluarFecha(value.fechaTrack),
                        value.Motivo,
                        value.CasillaDe,
                        value.CasillaPara,

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
        }]);

angular.module('simihApp').config(function ($datepickerProvider) {
    angular.extend($datepickerProvider.defaults, {
        dateFormat: 'dd/MM/yyyy',
        startWeek: 1,
        autoclose: true,
        maxDate: new Date()
    });
})