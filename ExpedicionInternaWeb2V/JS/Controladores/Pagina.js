angular.module('simihApp').controller('pagController',
    function ($scope, $http, $rootScope, $location, $modal, $route, Requester, localStorageService, $alert, ServiciosApi) {

        $rootScope.plazoConfirmacion = '0';
        $scope.checked = true;//////
        $rootScope.Empresa = 'neutro';
        $scope.mostrar = true;
        //$scope.verListaReclamos = false;
        $rootScope.reclamo = {};
        $rootScope.colores = {};

        $scope.tituloApp = 'SIMIH';

        $rootScope.mostrarError = (titulo, mensaje) => {
            swal(titulo, mensaje, "error");
        };

        $rootScope.mostrarSuccess = (titulo, mensaje) => {
            swal(titulo, mensaje, "success");
        };

        $scope.msalMensaje = '';
        $scope.cuentaAzureAD = {};

        $rootScope.Usuario = {
            Nick: "",
            Password: ""
        };

        const config = {
            auth: {
                clientId: AuthConfig.clientId,
                authority: AuthConfig.authority,
                redirectUri: AuthConfig.redirectUri

            },
            cache: {
                cacheLocation: 'localStorage',
                storeAuthStateInCookie: true,
            }
        };


        const accessTokenRequest = {
            scopes: AuthConfig.webApiScopes
        };


        $scope.client = new Msal.UserAgentApplication(config);

        $scope.request = {
            scopes: AuthConfig.webApiScopes
        };

        var authCallback = function (error, response) {

            $scope.client.acquireTokenSilent(accessTokenRequest).then(function (accessTokenResponse) {
                // Acquire token silent success            
                let accessToken = accessTokenResponse.accessToken;
                localStorageService.set('msalTokenId', accessToken);
                $scope.validarCuentaAzureADRegistrada(accessToken);
            }).catch(function (error) {
                //Acquire token silent failure, and send an interactive request            
                if (error.errorMessage.indexOf("interaction_required") !== -1) {
                    $scope.client.acquireTokenRedirect(accessTokenRequest);
                }
            });

        };

        $scope.client.handleRedirectCallback(authCallback);

        $scope.isUndefinedOrNullOrEmpty = function (obj) {
            return !angular.isDefined(obj) || obj === null || obj.length === 0;
        };

        $rootScope.AD = false;
        $rootScope.spinnerLogin = false;

        $scope.validarCuentaAzureADRegistrada = function (accessToken) {

            $rootScope.verMensajeAzure = true;            
            $rootScope.spinnerLogin = true;
            $rootScope.AD = true;
            $scope.openSidebar = "";
            $scope.closeSessionVisible = "hidden";

            var params = {}
                        
            $http({
                method: 'POST',
                url: $rootScope.rutaHost + 'SeguridadAzureWS.asmx/LoginWeb',
                data: JSON.stringify(params),
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + accessToken
                },
            }).then(function (response) {

                var _data = JSON.parse(response.data.d);
                var Usuarios = _data.usuario;
                $rootScope.token = _data.token;
                $rootScope.refreshToken = _data.refreshToken;
                
                $rootScope.spinnerLogin = false;
                $scope.openSidebar = "open-sidebar";
                $scope.openHome = "open-home";
                $scope.closeSessionVisible = "visible";

                if (Usuarios.idCasilla !== 0) {
                    $scope.Bandejas = [];
                    $rootScope.Bandejals = [];
                    $scope.comprobar = 0;
                    $scope.contar = 0;
                    $rootScope.Usuario.Password = '';
                    $rootScope.Usuario.Nick = '';
                    if (typeof Usuarios.Nombre !== "undefined") {
                        $rootScope.mensajeAzure = "Redirigiendo...";
                        //$scope.getColoresIndicador();
                        $rootScope.Usuario.Nombre = Usuarios.Nombre;
                        $rootScope.Usuario.Id = Usuarios.Descripcion;
                        $rootScope.Usuario.Datos = Usuarios.Datos;
                        $rootScope.Usuario.IdTipoAcceso = Usuarios.IdTipoAcceso;
                        if (Usuarios.IdTipoAcceso == 46 || Usuarios.IdTipoAcceso == 47) { $scope.tituloApp = 'RVA' };
                        $rootScope.Usuario.Empresa = Usuarios.Empresa;
                        $rootScope.Usuario.idCliente = Usuarios.idCliente;
                        $rootScope.Usuario.idCasilla = Usuarios.idCasilla;
                        $rootScope.Usuario.usuFac = Usuarios.usuFac;
                        $rootScope.Usuario.Cas = Usuarios.Cas;
                        $rootScope.Usuario.sCodigoAgencia = Usuarios.sCodigoAgencia;
                        $rootScope.Usuario.sAgencia = Usuarios.sAgencia;
                        $rootScope.Usuario.iIdProveedor = Usuarios.iIdProveedor;
                        var resultadobandeja = JSON.parse(Usuarios.descripcionCasilla);
                        
                        angular.forEach(resultadobandeja, function (value) {
                            $scope.Bandejas.push({
                                Bandeja: value.Descripcion, Id: value.IdCasilla, IdGeo: value.IdGeo,
                            });
                        });
                        $rootScope.Usuariols = $rootScope.Usuario;
                        if ($rootScope.Usuariols.usuFac > 0) {
                            $scope.JOS = true;
                        }
                        else {
                            $scope.JOS = false;
                        }
                        $rootScope.Empresa = $rootScope.Usuario.Empresa;
                        $rootScope.Bandejals = $scope.Bandejas;
                        localStorageService.add('viu', $rootScope.Usuario.Id);
                        localStorageService.add('b', 0);
                        var rec = localStorageService.get('recordar');
                        if ($scope.recuerdame === 'true') $rootScope.recordar = [{ nombre: "ACTIVO" }];
                        $rootScope.barraNotificacion = true;
                        $scope.menuEnabledv = true;
                        $rootScope.mensajeAzure = "";

                        $scope.getColoresIndicador();

                        $location.path('/Inicio');
                    }
                    else {
                        console.log('NO REGISTRADO');
                        $rootScope.mensajeAzure = "";
                        $alert(
                            {
                                title: 'La cuenta ingresada no est\u00E1 registrada en la aplicaci\u00F3n',
                                content: 'Comun\u00EDquese con el administrador del sistema',
                                placement: 'top-right',
                                type: 'danger',
                                container: "#loginMessage",
                                show: true,
                                duration: 5
                            });
                    }
                }
                else {
                    $rootScope.spinnerLogin = false;
                    $rootScope.mensajeAzure = "";
                    $alert(
                        {
                            title: 'La cuenta ingresada no est\u00E1 registrada en la aplicaci\u00F3n',
                            content: 'Comun\u00EDquese con el administrador del sistema',
                            placement: 'top-right',
                            type: 'danger',
                            container: "#loginMessage",
                            show: true,
                            duration: 5
                        });
                }
            }, function (response) {
                $rootScope.spinnerLogin = false;
                $rootScope.mensajeAzure = "";

                //$scope.limpiarCierreSesion();

                if (response.status === 401) {

                    //$scope.client.logout();

                    $alert(
                        {
                            title: 'Su cuenta no est\u00E1 registrada en el sistema.',
                            content: 'Comun\u00EDquese con el administrador del sistema',
                            placement: 'top-right',
                            type: 'warning',
                            container: "#loginMessage",
                            show: true,
                            duration: 5
                        });
                }
                else {

                    $alert(
                        {
                            title: 'Hubo un error en la comunicaci\u00F3n HTTP',
                            content: 'Comun\u00EDquese con el administrador del sistema',
                            placement: 'top-right',
                            type: 'danger',
                            container: "#loginMessage",
                            show: true,
                            duration: 5
                        });
                }
            });


        };

        2022
        $rootScope.$watch('actualizar', function () {

            if (typeof $rootScope.Bandejals !== "undefined") {
                if ($rootScope.Bandejals.length > 0) {
                    var index = localStorageService.get('b');
                    $scope.bandejaN = $rootScope.Bandejals[index].Id;
                    //2022
                    obtenerListaDatos();
                }
            }
        });

        $rootScope.$watch('Empresa', function () {
            $scope.menucolor = "navbar-inverse-banbif";
            $scope.colorTexto = "colorTexto-banbif";

        });

        $rootScope.$watch('MenuGuardado', function () {
                $scope.MenuPrincipal = $rootScope.MenuGuardado;
            $scope.mostrarJOSv = $scope.mostrarJOS;

        });

        $rootScope.$watch('Bandejals', function () {
            $scope.Tbandejas = $rootScope.Bandejals;
            if (typeof $scope.Tbandejas !== 'undefined') {
                if ($scope.Tbandejas.length > 0) {
                    var index = localStorageService.get('b');
                    if ($scope.Tbandejas[index].Id === $rootScope.Usuario.idCasilla) {
                        $rootScope.bandejaActual = $scope.Tbandejas[index].Bandeja;
                        $rootScope.Usuariols.idCasilla = $scope.Tbandejas[index].Id;
                        $rootScope.Ubicacion = $scope.Tbandejas[index].Ubicacion;
                        $scope.bandeja = $scope.Tbandejas[index].Bandeja;
                        $rootScope.actualizar = "a";
                    }
                }
            }
        });

        var myOtherModal = $modal({
            scope: $scope,
            template: 'myModalContent.html',
            show: false,
            keyboard: false,
            backdrop: 'static',
            animation: 'none'
        });



        $scope.recargarPaginaInicio = function () {
            $rootScope.recargarPagina();
        }

        $scope.open = function (size) {
            myOtherModal.$promise.then(myOtherModal.show);
        };

        

        $scope.cancel = function () {
            if ($rootScope.Administradores === 44) {
                myOtherModalAdmin.$promise.then(myOtherModalAdmin.hide);
            } else {
                myOtherModal.$promise.then(myOtherModal.hide);
            }
        };


        $scope.limpiarCierreSesion = function () {
            
            myOtherModal.$promise.then(myOtherModal.hide);
            limpiarVariables();

            //login
            $rootScope.mostroNoti = false;
            $rootScope.iNotificaciones = [];
            $scope.recuerdame = false;
            $scope.menuEnabledv = false;
            $rootScope.verMensajeAzure = false;
            $rootScope.mensajeAzure = "";
            $rootScope.userWinAuth = "";

            //pagina
            $rootScope.plazoConfirmacion = '0';
            $scope.checked = true;
            $rootScope.Empresa = 'neutro';
            $rootScope.token = "";
            $rootScope.refreshToken = "";
            $scope.mostrar = true;
            //$scope.verListaReclamos = false;
            $rootScope.reclamo = {};

            $scope.msalMensaje = '';
            $scope.cuentaAzureAD = {};
            $rootScope.actualizar = undefined;

            //$location.path('/');
        }

        $scope.cerrarSession = function () {
            $scope.limpiarCierreSesion();
            $scope.client.logout();
           


        };

        $scope.RevisaBandeja = function () {
            $scope.mostrar = false;
        }

        $scope.init = function () {
            var valores = [];
            var indx = 0;
            angular.forEach($scope.Tbandejas, function (value) {
                valores.push({
                    Bandeja: value.Bandeja,
                    Id: value.Id,
                    IdGeo: value.IdGeo,
                    Ubicacion: value.Ubicacion,
                    index: indx,
                    AutogeneradosAsociados: value.AutogeneradosAsociados
                });
                indx++;
            });

            $scope.items = valores;
            $rootScope.bandejasVirtuales = [];
            $rootScope.bandejasVirtuales = [...valores];
            $scope.selected = $scope.items[0];
            var ck = false;
            if (localStorageService.get('recordar') === 'true') { ck = true; }

            $scope.checkboxModel = {
                value1: ck
            };
        }



        var limpiarVariables = function () {
            localStorageService.remove('viu');
            localStorageService.remove('recordar');
            $rootScope.recordar = [];
            $rootScope.MenuGuardado = [];
            $rootScope.Bandejals = [];
            $rootScope.Usuariols = [];
            $rootScope.Configuracionls = [];
            $rootScope.barraNotificacion = false;
        };

        var obtenerListaDatos = function () {
            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ObtenerListas', {}).then(function (list) {
                var listados = list;
                if (listados.length === 0) {

                    limpiarVariables();
                    $location.path('/');
                }
                else {
                    var listtotal = listados;
                    listados = '';
                    angular.forEach(listtotal, function (value) {
                        if (value.Lista === 'CONFIGURACION') {
                            $rootScope.Configuracionls = JSON.parse(value.Descripcion);
                            $rootScope.accesoAcciones = $rootScope.Configuracionls.find(x => x.Valor3 === 'CONF_BANDEJA_NOTIFICACIONES');
                            $rootScope.accesoConsulta = $rootScope.Configuracionls.find(x => x.Valor3 === 'CONSULTAS');
                            $rootScope.accesoReporte = $rootScope.Configuracionls.find(x => x.Valor3 === 'REPORTES');
                            $rootScope.accesoRVAUsuarioLima = $rootScope.Configuracionls.find(x => x.Valor3 === 'RVA_USUARIO_LIMA');
                            $rootScope.accesoRVAUTDLima = $rootScope.Configuracionls.find(x => x.Valor3 === 'RVA_UTD_LIMA');
                            $rootScope.accesoRVAUTDReporteLima = $rootScope.Configuracionls.find(x => x.Valor3 === 'RVA_UTD_REPORTE_LIMA');
                            $rootScope.accesoRVAProveedorRecojo = $rootScope.Configuracionls.find(x => x.Valor3 === 'RVA_PROV-RECOJO');
                            $rootScope.accesoRVAProveedorEntrega = $rootScope.Configuracionls.find(x => x.Valor3 === 'RVA_PROV-ENTREGA');

                            $rootScope.accesoRVAProveedorGestor = $rootScope.Configuracionls.find(x => x.Valor3 === 'RVA_PROVEEDOR_GESTOR');
                            $rootScope.accesoRVAProveedorGestorReporte = $rootScope.Configuracionls.find(x => x.Valor3 === 'RVA_PROVEEDOR_REPORTE_GESTOR');
                            $rootScope.accesoRVAGDIAReporte = $rootScope.Configuracionls.find(x => x.Valor3 === 'GDIA_RVA_REPORTE');

                            /*console.log($rootScope.accesoRVAProveedor);*/
                            $scope.indicadoresData = $rootScope.Configuracionls;
                        }
                        else if (value.Lista === 'BANDEJAS') {
                            $rootScope.Bandejals = JSON.parse(value.Descripcion);
                            $scope.init();
                        }
                        else if (value.Lista === 'MENU') {                            
                            if (value.Descripcion) { 
                                $rootScope.MenuGuardado = JSON.parse(value.Descripcion);
                                $rootScope.tieneMenu = true;
                            }
                            else {
                                $rootScope.tieneMenu = false;
                            }
                        }
                        else if (value.Lista === 'USUARIO') {
                            $rootScope.Usuariols = JSON.parse(value.Descripcion);
                            //$rootScope.Administradores = $rootScope.Usuariols.IdTipoAcceso;

                            if (JSON.parse(value.Descripcion).usuFac > 0)
                                $scope.mostrarJOS = "";
                            else
                                $scope.mostrarJOS = "5";
                        }

                    });
                    listtotal = [];
                    $location.path('/Inicio');
                }
            }, function (status) {

                
                if (status === 498) {
                    $alert(
                        {
                            title: 'La cuenta ingresada no est\u00E1 registrada en la aplicaci\u00F3n',
                            content: 'Comun\u00EDquese con el administrador del sistema',
                            placement: 'top-right',
                            type: 'danger',
                            container: "#loginMessage",
                            show: true,
                            duration: 5
                        }
                    );
                }

                if (status === 401) {
                    $alert(
                        {
                            title: 'Perfil no autorizado',
                            content: 'Comun\u00EDquese con el administrador del sistema',
                            placement: 'top-right',
                            type: 'danger',
                            container: "#loginMessage",
                            show: true,
                            duration: 5
                        }
                    );
                }

            });
        };


        //2022
        if (typeof localStorageService.get('recordar') !== "undefined") {
            var rec = localStorageService.get('recordar');
            if (localStorageService.get('recordar') === 'true') {

                //2022
                obtenerListaDatos();
            }
            else {

                limpiarVariables();
                $location.path('/');
            }
        }

        $scope.setActive = function (Opcion) {
            $scope.vRecepcion = "";
            $scope.vRecojo = "";
            $scope.vEnvio = "";
            $scope.vReporte = "";
            $scope.vMantenimiento = "";
            $scope.vEntrega = "";
            $scope[Opcion] = "active";
        };

        $scope.setActiveNavBar = function (bool) {
            $scope.MostrarNav = bool;
        };


        $scope.getColoresIndicador = function () {
            $rootScope.cargando = true;
            ServiciosApi.getColoresIndicador().then(
                function (data) {
                    $rootScope.cargando = false;
                    $rootScope.colores = data;
                },
                function (error) {
                    $rootScope.cargando = false;
                    console.log(error);
                }
            );
        };

    });


angular.module('simihApp').factory("BandejalsFactory", function () {
    return {
        data: {}
    };
});


angular.module('simihApp').animation('.slideUp', function () {
    var NG_HIDE_CLASS = 'ng-hide';
    return {
        beforeAddClass: function (element, className, done) {
            if (className === NG_HIDE_CLASS) {
                element.slideUp(done);
            }
        },
        removeClass: function (element, className, done) {
            if (className === NG_HIDE_CLASS) {
                element.hide().slideDown(done);
            }
        }
    }
});