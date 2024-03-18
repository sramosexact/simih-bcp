angular.module('simihApp').controller('contrActivo',
    function ($scope, localStorageService, $rootScope, Requester, $modal, uiGridConstants, $alert, ExportarService, $filter) {


        $scope.tabs = [
            {
                name: 'Bandeja de entrada',
                url: 'T1.html',
                active1: true,
                icon: 'glyphicon-tab glyphicon-log-in colorIngreso'
            }, {
                name: 'Bandeja de salida',
                url: 'T2.html',
                active1: false,
                icon: 'glyphicon-tab glyphicon-log-out colorSalida'
            }
        ];


        $scope.tab = 'T1.html'; /*default tab*/
        $scope.current = 'Bandeja de entrada'; /*default active tab*/

        $scope.toggleTab = function (s) {
            $scope.tab = s.url;  /*tab changed*/
            $scope.current = s.name; /* changing value of current*/

            if (s.name === "Bandeja de entrada") {
                $scope.grillaIngresos();
            }
            if (s.name === "Bandeja de salida") {
                $scope.grillaSalidas();
            }
        };


        var index = localStorageService.get('b');
        $scope.bandejaN = $rootScope.Bandejals[index].Id;

        /**********************tabla ingreso***********************/


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

                if (tipo === 2)
                    $scope.id = row.entity.ID;


                $scope.Autogenerado = row.entity.Autogenerado;

                //2022
                //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getSeguimiento',
                //    { "id": $scope.id }
                //).then(function (Correspondencia) {
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

        $scope.datasource = {
            expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
            expandableRowHeight: 400,
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: [
                { name: 'Id', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, visible: false },
                { name: 'Codigo', field: 'Autogenerado', displayName: 'Autogenerado', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Tipo documento', displayName: 'Tipo documento', field: 'sTipoElemento', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Creado el', displayName: 'Creado el', field: 'FechaTrack', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'CasillaDe', displayName: 'De', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'CasillaPara', displayName: 'Para', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Estado', field: 'Documento', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                {
                    name: 'Ver Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS },
                    cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,1)">Ver más</div>'
                }
            ],
            appScopeProvider: $scope.myAppScopeProvider
        };


        $scope.datasource.onRegisterApi = function (gridApi) {
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
                    //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'obtenerDocumentoContenido2',
                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle',
                        { "correspondenciaId": row.entity.Id }
                    ).then(function (Correspondencia) {
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
        //2022



        $scope.grillaIngresos = function () {
            $scope.llave = "true";
            $scope.llave2 = "false";
            $scope.mostrar1 = "true";
            $scope.mostrar2 = "false";
            //2022
            //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ActivosIngresos',
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaActivaBandejaEntrada',
                {}
            ).then(function (dataActivo) {
                $scope.datasource.data = dataActivo;
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

        $scope.grillaIngresos();

        /*****************************tabla salida*****************************/


        $scope.datasource2 = {
            expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
            expandableRowHeight: 400,
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: [
                { name: 'ID', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, visible: false },
                { name: 'Codigo', displayName: 'Autogenerado', field: 'Autogenerado', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Tipo documento', displayName: 'Tipo documento', field: 'sTipoElemento', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Creado el', displayName: 'Creado el', field: 'fechaTrack', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'CasillaPara', displayName: 'Para', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'CasillaDe', displayName: 'De', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                { name: 'Estado', field: 'Documento', width: '15%', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                {
                    name: 'Ver Tracking', displayName: 'Tracking', cellClass: 'link', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS },
                    cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)">Ver más</div>'
                }
            ],
            appScopeProvider: $scope.myAppScopeProvider
        };



        $scope.datasource2.onRegisterApi = function (gridApi) {
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

                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle',
                        { "correspondenciaId": row.entity.ID }
                    ).then(function (Correspondencia) {
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

        $scope.grillaSalidas = function () {
            //2022
            /*Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ActivosSalida',*/
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaActivaBandejaSalida',
                {}
            ).then(function (dataActivo2) {
                $scope.datasource2.data = dataActivo2;
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


        $scope.exportarReporteEntrada = () => {
            var ObjetoExportar = new ExportarService.Objeto();
            ObjetoExportar.Config.TitleBackgroundColor = "#808080";
            ObjetoExportar.Config.TitleFontColor = "#fff";
            ObjetoExportar.cabecera = [

                "Autogenerado",
                "Tipo documento",
                "Creado el",
                "De",
                "Para",
                "Estado",
                
            ];


            ObjetoExportar.NameReporte = "ActivosEntrada";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.datasource.data, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'FechaTrack');
            angular.forEach(datosExportar, function (value, index) {

                obj = [
                    
                    value.Autogenerado,
                    value.sTipoElemento,
                    EvaluarFecha(value.FechaTrack),
                    value.CasillaDe,
                    value.CasillaPara,
                    value.Documento,                   
                    
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
                "Creado el",
                "De",
                "Para",
                "Estado",

            ];


            ObjetoExportar.NameReporte = "ActivosSalida";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.datasource2.data, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'fechaTrack');
            angular.forEach(datosExportar, function (value, index) {

                obj = [

                    value.Autogenerado,
                    value.sTipoElemento,
                    EvaluarFecha(value.fechaTrack),
                    value.CasillaDe,
                    value.CasillaPara,
                    value.Documento,

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
    });

//angular.module('simihApp').controller('modalTracking', function ($scope, $modalInstance, items) {


//    $scope.id = items[0].id;
//    $scope.Autogenerado = items[0].Autogenerado;

//    //2022
//    //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getSeguimiento',
//    //    { "id": $scope.id }
//    //).then(function (Correspondencia) {
//    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaSeguimiento', { "CorrespondenciaId": $scope.id }).then(function (Correspondencia) {
//        $scope.dataSeguimiento = Correspondencia;

//    }, function (status) {

//        $alert(
//            {
//                title: 'ALERTA!',
//                content: "Ha fallado la petición. Estado HTTP:" + status,
//                placement: 'top-right2',
//                type: 'info',
//                container: "#contenedorAlert",
//                show: true,
//                duration: 3
//            });
//    });

//    $scope.ok = function () {
//        $modalInstance.close();
//    };

//    $scope.cancel = function () {
//        $modalInstance.dismiss('cancel');
//    };
//});
