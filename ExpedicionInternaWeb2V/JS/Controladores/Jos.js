angular.module('simihApp').controller('TabsDemoCtrl',
    function ($scope, $rootScope, localStorageService, $modal, $alert, $filter, Requester) {

        var idAgencia = 0;
        var session = localStorageService.get('session');
        $scope.hola = session;
        var idEntregaSeleccionada = 0;
        var idEntregaCerradaSeleccionada = 0;
        $scope.cadena = [];
        $scope.cadenaNoRecibidos = [];
        $scope.visibilidad = false;
        $scope.ingreso = [];
        $scope.Noingreso = [];
        $scope.tamanio;
        $scope.fech = [];
        $scope.pestania = true;
        /**Asignando fechas a historicoJos**/
        var d = new Date(); // today!
        var hoy = new Date();
        d.setDate(d.getDate() - 30);
        $scope.fech.fromDate = d;
        $scope.fech.untilDate = hoy;


        var j = 0;

        var usuario = $rootScope.Usuariols;

        var idCliq = 0;
        if (typeof $rootScope.Usuariols !== "undefined") {
            if ($rootScope.Usuariols.length > 0) {
                idCliq = $rootScope.Usuariols.idCliente;
            }
        }
        if (idCliq === 1) {
            $scope.tabs = [
                {
                    name: 'Ingresos',
                    url: 'ingresos.html',
                    active1: true,
                    icon: 'glyphicon-tab glyphicon-log-in colorIngreso'
                },

                {
                    name: 'Historicos de Ingresos',
                    url: 'historico.html',
                    active1: false,
                    icon: 'glyphicon-tab glyphicon-log-in colorIngreso'
                }

            ];
        } else {
            $scope.tabs = [
                {
                    name: 'Ingresos',
                    url: 'ingresos.html',
                    active1: true,
                    icon: 'glyphicon-tab glyphicon-log-in colorIngreso'
                },



                {
                    name: 'Historicos de Ingresos',
                    url: 'historico.html',
                    active1: false,
                    icon: 'glyphicon-tab glyphicon-log-in colorIngreso'
                }
            ];
        }

        $scope.subtabs = [
            {
                name: 'Ingreso historico',
                url: 'ingresohis.html',
                active1: true
            }

        ];

        $scope.tab = 'ingresos.html';/*default tab*/
        $scope.current = 'Ingresos'; /*default active tab*/

        $scope.tab1 = 'ingresohis.html';/*default tab1*/
        $scope.current2 = 'Ingreso historico';

        $scope.toggleTab2 = function (s) {
            $scope.tab1 = s.url;  /*tab changed*/
            $scope.current2 = s.name; /* changing value of current*/


        }

        $scope.toggleTab = function (s) {
            $scope.tab = s.url;  /*tab changed*/
            $scope.current = s.name; /* changing value of current*/

            if (s.name === "Ingresos") {
                ListarEntregasPorRecibirPorJOS($scope.selectedItem.iId);
            }
            if (s.name === "Ingresos no recibidos") {
                $scope.josIngresosnoRecibidos();
            }
            if (s.name === "Salidas") {
                $scope.josSalidas();
            }
            if (s.name === "Historicos de Ingresos y Salidas") {
                //$scope.josHistorico();
                //$scope.actualizando();
            }
            if (idCliq !== 1) {
                if (s.name === "Creación de Valija de hoy") {
                    $scope.josCreacionValija();
                }
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
                    $scope.id = row.entity.iId;
                else if (tipo === 2)
                    $scope.id = row.entity.iId;

                $scope.Autogenerado = row.entity.Autogenerado;
                
                /*Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getSeguimiento', { "id": $scope.id }).then(function (Correspondencia) {*/
                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaSeguimiento', { "CorrespondenciaId": $scope.id }).then(function (Correspondencia) {
                    $scope.dataSeguimiento = Correspondencia;
                }, function (status) {
                    alert("Ha fallado la petición. Estado HTTP:" + status);
                });
            }
        }

        var ListarEntregaDetalleJOS = function (entity) {
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarEntregaDetalleJOS', { "iIdEntrega": entity.iId }).then(function (data) {
                $scope.subGridOptions.data = JSON.parse(data);
                $scope.Entrega = entity.iId;
                $scope.fecha = $filter('date')(entity.dInicio, 'dd/mm/yyyy');
            }, function (estatus) {
                alert("Ha fallado la petición. Estado HTTP:" + status);
            });
        };

        var ListarEntregaDetalleCerradasJOS = function (entity) {
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarEntregaDetalleCerradasJOS', { "iIdEntrega": entity.iId }).then(function (data) {
                $scope.subGridOptions.data = JSON.parse(data);
                $scope.Entrega = entity.iId;
                $scope.fecha = $filter('date')(entity.dInicio, 'dd/mm/yyyy');
            }, function (estatus) {
                alert("Ha fallado la petición. Estado HTTP:" + status);
            });
        };

        var dataa = [];
        var myOtherModalC;
        $scope.myModalProvider = {
            verContenido: function (row, tipo) {
                idEntregaSeleccionada = row;
                myOtherModalC = $modal({
                    scope: $scope,
                    template: 'modalContenido.html',
                    show: false,
                });
                myOtherModalC.$promise.then(myOtherModalC.show);


                $scope.subGridOptions = {
                    expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla2.html',
                    enableRowSelection: true,
                    enableSelectAll: true,
                    columnDefs: [
                        { name: 'Id', field: 'iId', width: '15%', enableColumnResizing: true, visible: false },
                        { name: 'Codigo', field: 'Autogenerado', enableColumnResizing: false },
                        { name: 'Tipo documento', field: 'sTipoElemento', enableColumnResizing: false },
                        { field: 'De', name: 'De', enableColumnResizing: true },
                        { field: 'Para', name: 'Para', enableColumnResizing: true },
                        { field: 'Area', name: 'Area', enableColumnResizing: true },
                        {
                            name: 'Ver Tracking', cellClass: 'link', enableFiltering: false,
                            cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,1)">Ver más</div>'
                            //cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)"><span class="glyphicon-grilla glyphicon-plus-sign" aria-hidden="true"></span></div>'
                        }
                    ],
                    appScopeProvider: $scope.myAppScopeProvider
                };

                $scope.subGridOptions.onRegisterApi = function (gridApi) {
                    $scope.gridApi = gridApi;
                    if (row.isSelected) {
                        $scope.val = "True";
                        $scope.gridApi.selection.selectAllRows();
                    }
                    else {
                        $scope.val = "False";
                    }
                }

                ListarEntregaDetalleJOS(row.entity);



            }
        }


        var myOtherModalC2;
        $scope.myModalProviderEDC = {
            verContenidoCerrado: function (roww, tipo) {
                idEntregaCerradaSeleccionada = roww; 
                myOtherModalC2 = $modal({
                    scope: $scope,
                    template: 'modalContenido2.html',
                    show: false,
                });
                myOtherModalC2.$promise.then(myOtherModalC2.show);


                $scope.subGridOptions = {
                    expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla2.html',
                    enableRowSelection: true,
                    enableSelectAll: true,
                    columnDefs: [
                        { name: 'Id', field: 'iId', width: '15%', enableColumnResizing: true, visible: false },
                        { name: 'Codigo', field: 'Autogenerado', enableColumnResizing: false },
                        { name: 'Tipo documento', field: 'sTipoElemento', enableColumnResizing: false },
                        { field: 'De', name: 'De', enableColumnResizing: true },
                        { field: 'Para', name: 'Para', enableColumnResizing: true },
                        { field: 'Area', name: 'Area', enableColumnResizing: true },
                        {
                            name: 'Ver Tracking', cellClass: 'link', enableFiltering: false,
                            cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)"><span class="glyphicon-grilla glyphicon-plus-sign" aria-hidden="true"></span></div>'
                        }
                    ],
                    appScopeProvider: $scope.myAppScopeProvider
                };



                ListarEntregaDetalleCerradasJOS(roww.entity);



            }
        }



        /*******************combo desplegabe**********************/

        if (typeof $rootScope.Bandejals !== "undefined") {
            if ($rootScope.Bandejals.length > 0) {
                var index = localStorageService.get('b');
                $scope.bandejaN = $rootScope.Bandejals[index].Id;


                /*1 : IDCLIENTE */
                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarAgenciasVinculadasAlUsuario', { "iIdUsuario": $rootScope.Usuariols.ID }).then(function (data) {
                    if (data.length > 0) {
                        data = JSON.parse(data);
                    }
                    if (data.length <= 1) {
                        $scope.inspector = data;
                        $scope.puntoEntrega = data[0].sDescripcion;
                        idAgencia = data[0].iId;
                        $scope.selectedItem = {}
                        $scope.selectedItem.iId = idAgencia;
                    }
                    else {
                        $scope.inspector = data;
                        $rootScope.hijosdoc = data;
                        $scope.selectedItem = $rootScope.hijosdoc[0];

                        idAgencia = $scope.selectedItem.iId;

                    }

                    /***datos ingreso***/

                    $scope.seleccionaPunto(idAgencia)


                });

                $scope.seleccionaPunto = function () {
                    $scope.ingreso = [];
                    $scope.Noingreso = [];

                    ListarEntregasPorRecibirPorJOS($scope.selectedItem.iId);


                };

                $scope.actualizando = function () {
                    if ($scope.fech.fromDate !== undefined && $scope.fech.untilDate !== undefined) {
                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarEntregasCerradasJOS', { "iIdAgencia": $scope.selectedItem.iId, "fecha_ini": $scope.fech.fromDate, "fecha_fin": $scope.fech.untilDate }).then(function (salida1) {
                            $scope.ingresohis.data = JSON.parse(salida1);
                        }, function (status) {
                            alert("actualizando Ha fallado la petición. Estado HTTP:" + status);
                        });

                    } else {
                        alert("Ingresar las fechas desde y hasta");
                    }

                };
                /***********************************************************************/
                $scope.josIngresos = function () {
                    $scope.pestania = true;
                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ingresoJOS', { "idGeo": idGeo, "opc": 1, "idEntrega": 0 }).then(function (ingreso1) {
                        for (i = 0; i < (ingreso1.length); i++) {
                            if (ingreso1[i].TipoDocS === "0") {
                                $scope.ingreso[j] = ingreso1[i];
                                j++;
                            }
                        }
                        $scope.tamanio = j;
                        $scope.dataIngreso.data = ingreso1;
                        j = 0;
                    }, function (status) {
                        alert(" josIngresos Ha fallado la petición. Estado HTTP:" + status);
                    });
                    $scope.ingreso = [];
                }

                

                $scope.josHistorico = function () {
                    /*  falta implementar*/
                    $scope.pestania = true;
                };

                $scope.josCreacionValija = function () {
                    /*  falta implementar*/
                };
                $scope.josIngresohis = function () {

                };

                $scope.josSalidahis = function () {

                };

                /*****************************tabla ingreso*****************************/

                $scope.dataIngreso = {
                    paginationPageSizes: [25, 50, 75],
                    paginationPageSize: 25,
                    enableFiltering: true,
                    showGridFooter: true,
                    enableGridMenu: true,
                    enableSelectAll: false,
                    enableRowHeaderSelection: false,
                    columnDefs: [
                        { field: 'iId', name: 'Id Entrega', enableColumnResizing: false },
                        { field: 'sDescripcion', name: 'Estado', enableColumnResizing: true },
                        { field: 'dInicio', name: 'Fecha', enableColumnResizing: true, type: 'date', cellFilter: 'date:\'dd-MM-yyyy\'' },
                        { field: 'iCantidadBultos', name: 'Nro Valijas', enableColumnResizing: true },
                        { field: 'iCantidadElementos', name: 'Nro Elementos', enableColumnResizing: true },
                        { field: 'iCantidadElementosRuta', name: 'Por Recibir', enableColumnResizing: true },
                        {
                            name: 'Contenido', cellClass: 'link', enableFiltering: false,
                            cellTemplate: '<div class="link" ng-click="grid.appScope.verContenido(row,2)"><span style="color: #557e8e;" class="glyphicon glyphicon-eye-open"></span></div>'
                        }
                    ],
                    appScopeProvider: $scope.myModalProvider
                };


                $scope.dataIngreso.onRegisterApi = function (gridApiI) {
                    //set gridApi on scope
                    $scope.gridApiI = gridApiI;
                    gridApiI.selection.on.rowSelectionChanged($scope, function (row) {
                        if (row.isSelected) {
                            var icon = "<span class='glyphicon-jos glyphicon-info-sign'></span>";
                            var mensaje = "SE CONFIRMARA  " + row.entity.cantDoc + " DOCUMENTO.";
                            if (row.entity.cantDoc > 1)
                                mensaje = "SE CONFIRMARAN  " + row.entity.cantDoc + " DOCUMENTOS.";
                            $rootScope.notiAviso = [
                                {
                                    Aviso: icon + mensaje,
                                    Autogenerado: '',
                                    Cs: "alertaNotificacionJos",
                                    tiempo: 3
                                }
                            ];

                        }
                    });
                };

                /**********************table ingresos no recibidos***********************/
                $scope.dataNoingreso = {
                    expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
                    paginationPageSizes: [25, 50, 75],
                    paginationPageSize: 25,
                    enableFiltering: true,
                    showGridFooter: true,
                    enableGridMenu: true,
                    columnDefs: [
                        { field: 'Autogenerado', enableColumnResizing: false },
                        { field: 'CasillaDe', name: 'De', enableColumnResizing: true },
                        { field: 'CasillaPara', name: 'Para', enableColumnResizing: true },
                        {
                            name: 'Ver', cellClass: 'link', enableFiltering: false,
                            cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)">Ver mas</div>'
                        }
                    ],
                    appScopeProvider: $scope.myAppScopeProvider
                };

                $scope.dataNoingreso.onRegisterApi = function (gridApi) {
                    $scope.gridApi = gridApi;

                    gridApi.expandable.on.rowExpandedStateChanged($scope, function (row) {
                        if (row.isExpanded) {
                            row.entity.subGridOptions = {
                                columnDefs: [
                                    { field: 'EmpaqueBD', displayName: 'Empaque', width: '*' },
                                    { field: 'TIPODOCUMENTO', displayName: 'Tipo documento', width: '*' },
                                    { field: 'MONEDA', displayName: 'Moneda', width: '*' },
                                    { field: 'cantidadBd', displayName: 'Cantidad', width: '*' },
                                    { field: 'Observacion', displayName: 'Observación', enableColumnResizing: true, width: '50%' }
                                ]
                            };

                            //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'obtenerDocumentoContenido2', {
                            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle', {
                                "correspondenciaId": row.entity.ID
                            }).then(function (Correspondencia) {
                                row.entity.subGridOptions.data = Correspondencia;
                            }, function (status) {
                                alert("Ha fallado la petición. Estado HTTP:" + status);
                            });
                        }
                    });
                };
                /*****************************tabla salida*****************************/

                $scope.salida = {
                    expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
                    paginationPageSizes: [25, 50, 75],
                    paginationPageSize: 25,
                    enableFiltering: true,
                    showGridFooter: true,
                    enableGridMenu: true,
                    columnDefs: [
                        { field: 'Autogenerado', enableColumnResizing: false },
                        { field: 'CasillaDe', enableColumnResizing: true }, // showing backwards compatibility with 2.x.  you can use field in place of name
                        { field: 'CasillaPara', enableColumnResizing: true },
                        { field: 'FechaTicket', enableColumnResizing: true },
                        {
                            name: 'Ver', cellClass: 'link', enableFiltering: false,
                            cellTemplate: '<div class="link" ng-click="grid.appScope.verTrack(row,2)">Ver más</div>'
                        }
                    ],
                    appScopeProvider: $scope.myAppScopeProvider
                };



                $scope.Recibircadena = function () {
                    var idusu;
                    $scope.cadena = [];
                    if ($scope.val === "True") {
                        $scope.gridApi.selection.selectAllRows();
                    }
                    angular.forEach($scope.gridApi.selection.getSelectedRows(), function (value) {
                        $scope.cadena.push({
                            ID: value.iId
                        });
                    });

                    if ($scope.current === "Ingresos") {
                        if ($scope.cadena.length > 0) {
                            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'Desencriptado', { "a": localStorageService.get('viu') }).then(function (res) {
                                idusu = JSON.parse(res.Descripcion);
                                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'objectoRecibirFacJSON', {
                                    "cadena": angular.toJson($scope.cadena),
                                    "de": $rootScope.Usuariols.idCasilla,
                                    "idUsuario": idusu,
                                    "idEntrega": idEntregaSeleccionada.entity.iId
                                }).then(function (res1) {
                                    var icon = "<span class='glyphicon-jos glyphicon-info-sign'></span>";
                                    var mensaje = "";
                                    if (res1 > 0) {

                                        mensaje = "SE HAN RECIBIDO  " + res1 + " DOCUMENTOS.";
                                        $rootScope.notiAviso = [
                                            {
                                                Aviso: icon + mensaje,
                                                Autogenerado: '',
                                                Cs: "alertaNotificacionJos",
                                                tiempo: 3
                                            }
                                        ];

                                        ListarEntregaDetalleJOS(idEntregaSeleccionada.entity);
                                        $scope.seleccionaPunto();

                                    }
                                    else if (res1 === 0) {

                                        mensaje = "SE HA CERRADO LA ENTREGA CORRECTAMENTE.";
                                        myOtherModalC.hide();
                                        $scope.seleccionaPunto();
                                        $rootScope.notiAviso = [
                                            {
                                                Aviso: icon + mensaje,
                                                Autogenerado: '',
                                                Cs: "alertaNotificacionJos",
                                                tiempo: 3
                                            }
                                        ];


                                    }
                                    else {
                                        mensaje = "Se HA PRODUCIDO UN ERROR, INTÉNTELO NUEVAMENTE MÁS TARDE.";
                                        $rootScope.notiAviso = [
                                            {
                                                Aviso: icon + mensaje,
                                                Autogenerado: '',
                                                Cs: "alertaNotificacionJos",
                                                tiempo: 3
                                            }
                                        ];
                                    }
                                }, function (status) {
                                    alert("Ha fallado la petición2. Estado HTTP:" + status);
                                });
                            }, function (status) {
                                alert("Ha fallado la petición1. Estado HTTP:" + status);
                            });
                        }
                        else {
                            $alert({
                                title: '',
                                content: 'Debe de seleccionar alguna correspondencia.',
                                placement: 'top-right2',
                                type: 'alert alert-m',
                                container: "#mensajeA",
                                show: true,
                                duration: 500
                            });
                        }
                    }
                    if ($scope.current === "Ingresos no recibidos") {

                        //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'obtenerDocumentoContenido2', {
                        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle', {
                            "correspondenciaId": localStorageService.get('viu')
                        }).then(function (res) {
                            idusu = JSON.parse(res.Descripcion);
                            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'objectoRecibirFacJSON', {
                                "cadena": angular.toJson($scope.cadena),
                                "de": $rootScope.Usuariols.idCasilla,
                                "idUsuario": idusu,
                                "idEntrega": idEntregaSeleccionada.entity.iId
                            }).then(function (res1) {
                                $scope.josIngresosnoRecibidos();
                                $scope.cadena = [];
                            }, function (status) {
                                alert("Ha fallado la petición2. Estado HTTP:" + status);
                            });
                        }, function (status) {
                            alert("Ha fallado la petición1. Estado HTTP:" + status);
                        });
                    }
   
                }

                $scope.salida.onRegisterApi = function (gridApi) {

                    $scope.gridApi = gridApi;

                    gridApi.expandable.on.rowExpandedStateChanged($scope, function (row) {
                        if (row.isExpanded) {
                            row.entity.subGridOptions = {
                                columnDefs: [
                                    { field: 'EmpaqueBD', displayName: 'Empaque', width: '*' },
                                    { field: 'TIPODOCUMENTO', displayName: 'Tipo documento', width: '*' },
                                    { field: 'MONEDA', displayName: 'Moneda', width: '*' },
                                    { field: 'cantidadBd', displayName: 'Cantidad', width: '*' },
                                    { field: 'Observacion', displayName: 'Observación', enableColumnResizing: true, width: '50%' }
                                ]
                            };
                            //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'obtenerDocumentoContenido2', {
                            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'CorrespondenciaDetalle', {
                                "correspondenciaId": row.entity.ID
                            }).then(function (Correspondencia) {
                                row.entity.subGridOptions.data = Correspondencia;
                            }, function (status) {
                                alert("Ha fallado la petición. Estado HTTP:" + status);
                            });
                        }
                    });
                };

                /*********************************historico ingresos/salida*********************************/
                $scope.ingresohis = {
                    expandableRowTemplate: '../PAGINAS/ACCIONES/plantilla.html',
                    paginationPageSizes: [25, 50, 75],
                    paginationPageSize: 25,
                    enableFiltering: true,
                    showGridFooter: true,
                    enableGridMenu: true,
                    enableSelectAll: false,
                    enableRowHeaderSelection: false,
                    columnDefs: [


                        { field: 'iId', name: 'Id Entrega', enableColumnResizing: false },
                        { field: 'sDescripcion', name: 'Estado', enableColumnResizing: true },
                        { field: 'dInicio', name: 'Fecha', enableColumnResizing: true, type: 'date', cellFilter: 'date:\'dd-MM-yyyy\'' },
                        { field: 'iCantidadElementos', name: 'Nro Elementos', enableColumnResizing: true },
                        {
                            name: 'Contenido', cellClass: 'link', enableFiltering: false,
                            cellTemplate: '<div class="link" ng-click="grid.appScope.verContenidoCerrado(row,2)"><span style="color: #557e8e;" class="glyphicon glyphicon-eye-open"></span></div>'
                        }

                    ],
                    appScopeProvider: $scope.myModalProviderEDC
                };


                $scope.ingresohis.onRegisterApi = function (gridApi) {
                    $scope.gridApi = gridApi;
                };



                /***********************************************************/

                $scope.click = function () {
                    $scope.hola = $scope.holaN;
                    $scope.$watch('session', function () {
                        localStorageService.add('session', $scope.hola);
                    }, true);

                }

                $scope.clickDelete = function () {
                    localStorageService.remove('session');
                }

                $scope.bandejaA = {
                    descripcion: 'Usted escogio al usuario :  '
                };



                var ListarEntregasPorRecibirPorJOS = function (iIdAgencia) {

                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarEntregasPorRecibirPorJOS', { "iIdAgencia": iIdAgencia }).then(function (data) {
                        if (data.length > 0) {
                            data = JSON.parse(data);
                            if (data.length > 0) {
                                $scope.dataIngreso.data = data;
                            } else {
                                $scope.dataIngreso.data = [];
                            }
                        }
                    }, function (status) {
                        alert("Ha fallado la petición. Estado HTTP:" + status);
                    });
                }

                $scope.asignar = function () {
                    if ($scope.bandejaA.j === null) {
                        alert("Seleccione una valija.");
                    }
                    else {
                        vm.nombre = $scope.bandejaA.j;
                        vm.funciones.guardarNombre();

                        $rootScope.encargadoValija = vm.nombre;

                        $rootScope.notiAviso = [
                            { nombre: vm.nombre }
                        ];

                        if ("FLORES-MOLINA" === vm.nombre) {
                            $rootScope.notiAvisoJosBandeja = [
                                { nombre: vm.nombre }
                            ];
                        }
                    }
                }
            }
        }
    });


angular.module('simihApp')
    .controller('MyCtrl', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
        $scope.lang = 'es';

    }]);


angular.module('simihApp').controller('TabsDemoCtrl2', function ($scope, $window) {

});

angular.module('simihApp').controller('CollapseDemoCtrl', function ($scope) {
    $scope.isCollapsed = false;
});







