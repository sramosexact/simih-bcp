angular.module('simihApp').controller('controllerConfirmado',
    ['$scope', 'uiGridConstants', '$rootScope', 'localStorageService', '$modal', '$alert', 'Requester',
        function ($scope, uiGridConstants, $rootScope, localStorageService, $modal, $alert, Requester) {

            $scope.plazo = $rootScope.plazoConfirmacion;

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
                    //2023                    
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
            };


            $scope.AutogeneradoGrid = [];
            $scope.isCollapsed = true;
            $scope.datagrid = {
                
                expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
                expandableRowHeight: 200,
                paginationPageSizes: [100, 250, 500, 1000],
                paginationPageSize: 100,
                enableFiltering: true,
                showGridFooter: true,
                columnDefs: [
                    { name: 'ID', width: '10%',  enableColumnResizing: false, filter: { condition: uiGridConstants.filter.CONTAINS }, visible: false },
                    { name: 'Codigo', field: 'Autogenerado', displayName: 'Autogenerado', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { name: 'Tipo documento', displayName: 'Tipo documento', field: 'sTipoElemento', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { name: 'CasillaDe', displayName: 'De', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { name: 'CasillaPara', displayName: 'Para', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { name: 'Origen', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { name: 'fechaCreacion', displayName: 'Fecha creación', enableColumnResizing: true, field: 'fechaTrack', filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { name: 'FechaRuta', displayName: 'Fecha ruta', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },
                    { name: 'FechaRecepcion', displayName: 'Fecha recepción', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } },

                    {
                        name: 'ShowScope', displayName: 'Tracking', cellClass: 'link', enableFiltering: false,
                        cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row)">Ver más</div>'
                    }
                ],
                appScopeProvider: $scope.myAppScopeProvider
            };



            if (typeof $rootScope.Bandejals !== "undefined") {
                if ($rootScope.Bandejals.length > 0) {
                    var index = localStorageService.get('b');
                    var idCasilla = $rootScope.Bandejals[index].Id;

                    //2023                    
                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaPorConfirmar', {}).then(function (Correspondencia) {
                        $scope.datagrid.data = Correspondencia;
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

            $scope.datagrid.onRegisterApi = function (gridApi) {                
                $scope.gridApi = gridApi;
                gridApi.selection.on.rowSelectionChanged($scope, function (row) {
                    var msg = 'row selected ' + row.col;
                    console.log(row.entity.Autogenerado);
                    var rowCol = gridApi.cellNav.getFocusedCell();
                    if (rowCol !== null) {
                        console.log('Row Autogenerado:' + rowCol.row.entity.Autogenerado + ' col:' + rowCol.col.colDef.name);
                    }
                    console.log(row.isSelected)
                });

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
                        //2023                        
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
                    };
                });

            };


            $scope.setConfirmar = function () {
                if ($scope.gridApi.selection.getSelectedRows().length > 0) {

                    var index = localStorageService.get('b');
                    var idCasillax = $rootScope.Bandejals[index].Id;

                    var porConfirmar = [];
                    angular.forEach($scope.gridApi.selection.getSelectedRows(), function (value) {
                        porConfirmar.push({                            
                            ID: value.ID
                        });
                    });

                    //2023                    
                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaConfirmar', {
                        "valores": angular.toJson(porConfirmar)
                    }).then(function (res) {
                        if (res.length === 0) {
                            alert("Ha ocurrido un error, inténtelo nuevamente.");
                        } else {
                            $rootScope.Configuracionls = $rootScope.Configuracionls + " ";
                            if (typeof $rootScope.Bandejals !== "undefined") {
                                if ($rootScope.Bandejals.length > 0) {
                                    var index = localStorageService.get('b');
                                    var idCasilla = $rootScope.Bandejals[index].Id;
                                    //2023                                    
                                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaPorConfirmar', {}).then(function (Correspondencia) {
                                        $scope.datagrid.data = Correspondencia;

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
                        }
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
                else {
                    $alert(
                        {
                            title: 'Para confirmar los documentos, se debe primero seleccionar alguno,',
                            content: ' muchas gracias.',
                            placement: 'top-right2',
                            type: 'danger',
                            container: "#conta",
                            show: true,
                            duration: 5
                        });
                }
            };

            $scope.setRegresar = function () {
                $scope.panel = "Mostrar";
            };

            $scope.panel = "Mostrar";


        }]);

