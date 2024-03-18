'use strict';
angular.module('simihApp').controller('contr1', ['$scope', '$modal', 'localStorageService', '$location', '$rootScope', '$interval', '$alert', 'Requester'
    , function ($scope, $modal, localStorageService, $location, $rootScope, $interval, $alert, Requester) {


        $scope.pagina = 1;
        $scope.paginas = [];
        $scope.bloque = 1;
        $scope.bloquePaginas = [];
        $scope.bloques = 1;
        $scope.adelante = false;
        $scope.atras = false;
        $scope.spinner = false;        

        $scope.existePaginas = false;
        $scope.pasoCont = 1;
        $scope.asunto = {
            opcion: ""
        }
        var myOtherModal = $modal({
            scope: $scope,
            template: 'MyModal.html',
            show: false,
            keyboard: false,
            backdrop: 'static'
        });                

        var cargarListaBandejas = () => {
            $scope.listaBandejasVirtuales = [...$rootScope.bandejasVirtuales];
            console.log($scope.listaBandejasVirtuales);
            $scope.bandejaVirtualSeleccionado = {};
            $scope.bandejaVirtualSeleccionado.Id = 0;
        }
        cargarListaBandejas();

        $scope.atrasBloque = () => {

            let bloques = 1;

            if (Math.trunc($scope.paginas.length / 10) === 0) {
                bloques = 1;
            }
            else {
                if (Math.trunc($scope.paginas.length % 10) > 0) {
                    bloques = Math.trunc($scope.paginas.length / 10) + 1;
                }
                else {
                    bloques = Math.trunc($scope.paginas.length / 10);
                }
            }


            if ($scope.paginas.length > 10 && $scope.bloque > 1) {
                $scope.atras = true;
                $scope.adelante = true;
                $scope.bloque -= 1;
                $scope.bloquePaginas = [...$scope.paginas].filter(paginas => paginas >= (1 + (($scope.bloque - 1) * 10)) && paginas <= ($scope.bloque * 10));
                if ($scope.bloque == 1) {
                    $scope.atras = false;
                }
            }
            else {
                $scope.atras = false;
            }


        }

        $scope.adelanteBloque = () => {

            let bloques = 1;

            if (Math.trunc($scope.paginas.length / 10) === 0) {
                bloques = 1;
            }
            else {
                if (Math.trunc($scope.paginas.length % 10) > 0) {
                    bloques = Math.trunc($scope.paginas.length / 10) + 1;
                }
                else {
                    bloques = Math.trunc($scope.paginas.length / 10);
                }
            }


            if ($scope.paginas.length > 10 && $scope.bloque < bloques) {
                $scope.adelante = true;
                $scope.atras = true;
                $scope.bloque += 1;
                $scope.bloquePaginas = [...$scope.paginas].filter(paginas => paginas >= (1 + (($scope.bloque - 1) * 10)) && paginas <= ($scope.bloque * 10));
                if ($scope.bloque == bloques) {
                    $scope.adelante = false;
                }
            }
            else {
                $scope.adelante = false;
            }


        }

        $scope.verMas = (p) => {
            $scope.pagina = p;

            if ($scope.searchText.length > 0) {


                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'Bandejas', { "pagina": $scope.pagina, "b": $scope.searchText }).then(function (bandejas) {
                    $scope.datasource = bandejas;
                    $scope.busqueda = true;
                    $scope.n.cantidad = "";
                    if (bandejas.length > 0) {

                        $scope.paginas = [...Array(bandejas[0].PageWidth).keys()].map(i => i + 1);
                        $scope.bloquePaginas = [...$scope.paginas].filter(paginas => paginas >= (1 + (($scope.bloque - 1) * 10)) && paginas <= ($scope.bloque * 10));
                        $scope.existePaginas = true;

                        let bloques = 1;

                        if (Math.trunc($scope.paginas.length / 10) === 0) {
                            bloques = 1;
                        }
                        else {
                            if (Math.trunc($scope.paginas.length % 10) > 0) {
                                bloques = Math.trunc($scope.paginas.length / 10) + 1;
                            }
                            else {
                                bloques = Math.trunc($scope.paginas.length / 10);
                            }
                        }



                        if ($scope.paginas.length > 10 && $scope.bloque < bloques) {
                            $scope.adelante = true;
                        }
                        else {
                            $scope.adelante = false;
                        }

                    }
                    else {
                        $scope.paginas = [];
                        $scope.bloque = 1;
                        $scope.bloquePaginas = [];
                        $scope.existePaginas = false;
                        $scope.adelante = false;
                        $scope.atras = false;
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
                $scope.busqueda = false;
                $scope.pagina = 1;
                $scope.paginas = [];
                $scope.bloque = 1;
                $scope.bloquePaginas = [];
                $scope.existePaginas = false;
                $scope.adelante = false;
                $scope.atras = false;
            }
        }

        $scope.open = function (size, per, id, Person) {
            if (per != $rootScope.Bandejals[localStorageService.get('b')].Bandeja) {

                $rootScope.Persona = { "Id": id, "Nombre": per };
                $rootScope.personaLista = Person;
                myOtherModal.$promise.then(myOtherModal.show);
            } else {

                $alert(
                    {
                        title: 'ALERTA!',
                        content: 'No puede elegirse a sí mismo',
                        placement: 'top-right',
                        type: 'warning',
                        container: "#alertaBusqueda",
                        show: true,
                        duration: 3
                    });
            }
        }

        $scope.Imprimir = function () {

            window.print();
        }

        $scope.TextChange = function () {
            if ($scope.searchText.length > 0) {

                $scope.bloque = 1;
                $scope.pagina = 1;
                $scope.paginas = [];
                $scope.bloquePaginas = [];
                $scope.existePaginas = false;
                $scope.adelante = false;
                $scope.atras = false;

                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'Bandejas', { "pagina": $scope.pagina, "b": $scope.searchText }).then(function (bandejas) {
                    $scope.datasource = bandejas;
                    $scope.busqueda = true;
                    $scope.n.cantidad = "";
                    $scope.pagina = 1;
                    if (bandejas.length > 0) {

                        $scope.paginas = [...Array(bandejas[0].PageWidth).keys()].map(i => i + 1);
                        $scope.bloquePaginas = [...$scope.paginas].filter(paginas => paginas >= (1 + (($scope.bloque - 1) * 10)) && paginas <= ($scope.bloque * 10));
                        $scope.existePaginas = true;

                        let bloques = 1;

                        if (Math.trunc($scope.paginas.length / 10) === 0) {
                            bloques = 1;
                        }
                        else {
                            if (Math.trunc($scope.paginas.length % 10) > 0) {
                                bloques = Math.trunc($scope.paginas.length / 10) + 1;
                            }
                            else {
                                bloques = Math.trunc($scope.paginas.length / 10);
                            }
                        }



                        if ($scope.paginas.length > 10 && $scope.bloque < bloques) {
                            $scope.adelante = true;
                        }
                        else {
                            $scope.adelante = false;
                        }

                    }
                    else {
                        $scope.paginas = [];
                        $scope.bloque = 1;
                        $scope.bloquePaginas = [];
                        $scope.existePaginas = false;
                        $scope.adelante = false;
                        $scope.atras = false;
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
                $scope.busqueda = false;
                $scope.pagina = 1;
                $scope.paginas = [];
                $scope.bloque = 1;
                $scope.bloquePaginas = [];
                $scope.existePaginas = false;
                $scope.adelante = false;
                $scope.atras = false;
            }
        }


        $scope.seleccionarBandejaVirtualIndexChange = function () {
            console.log($scope.bandejaVirtualSeleccionado);
        }

        $scope.n = [];
        $scope.hijos = [];
        $scope.check = {
            aviso: 0
        };

        $scope.visibilidad = true;
        $scope.visibilidad2 = false;
        $scope.visibilidad3 = true;
        $scope.Sel = 0;
        $scope.TextoPedido = '';
        $scope.botones = true;
        $scope.indicePedido = -1;

        $scope.busqueda = false;
        $scope.ShowMoneda = false;

        var enviarAutogenerado = true;

        function timerCallback() {
            $scope.spinner = false;
            // Puedes realizar acciones aquí una vez que se haya completado el temporizador.
        }

        $scope.Save = function () {

            if ($scope.hijos.HijosDoc1.ID === 0) {
                $alert(
                    {
                        title: 'ALERTA!',
                        content: 'Seleccione un Tipo de documento',
                        placement: 'top-right2',
                        type: 'info',
                        container: "#contenedorAlert",
                        show: true,
                        duration: 3
                    });
                return;
            }

            if ($scope.ShowMoneda && $scope.NuevoPedidos.Moneda.ID === '0') {
                $alert(
                    {
                        title: 'ALERTA!',
                        content: 'Seleccione un tipo de moneda',
                        placement: 'top-right2',
                        type: 'info',
                        container: "#contenedorAlert",
                        show: true,
                        duration: 3
                    });
                return;
            }


            if ($scope.n.cantidad.length === 0) {
                var tipoCantidad = 'cantidad';

                if ($scope.ShowMoneda == true) {

                    tipoCantidad = 'monto';
                }

                $alert(
                    {
                        title: 'ALERTA!',
                        content: 'Ingrese ' + tipoCantidad + ', por favor',
                        placement: 'top-right2',
                        type: 'info',
                        container: "#contenedorAlert",
                        show: true,
                        duration: 3
                    });

                return;
            }


            if ($scope.NuevoPedidos.Observacion === undefined || $scope.NuevoPedidos.Observacion === null || $scope.NuevoPedidos.Observacion.length === 0) {
                $alert(
                    {
                        title: 'ALERTA!',
                        content: 'Ingrese una observación',
                        placement: 'top-right2',
                        type: 'info',
                        container: "#contenedorAlert",
                        show: true,
                        duration: 3
                    });
                return;
            }


            $scope.shouldBeOpen = "true";

            $scope.NuevoPedidos.Cantidad = $scope.n.cantidad;
            if ($scope.n.cantidad.length > 0) {
                if ($scope.ShowMoneda === true) {
                    $scope.Pedidos.push({
                        IdDocumento: $scope.IdDoc,
                        TipoDocumento: $scope.hijos.HijosDoc1,
                        Documento: $scope.hijos.HijosDoc1.Descripcion,
                        Moneda: $scope.NuevoPedidos.Moneda.Descripcion,
                        IdMoneda: $scope.NuevoPedidos.Moneda,
                        Cantidad: $scope.NuevoPedidos.Cantidad,
                        Observacion: $scope.NuevoPedidos.Observacion
                    });
                }
                else {
                    $scope.Pedidos.push({
                        IdDocumento: $scope.IdDoc,
                        TipoDocumento: $scope.hijos.HijosDoc1,
                        Documento: $scope.hijos.HijosDoc1.Descripcion,
                        Moneda: 'NINGUNA',
                        IdMoneda: { "ID": 0 },
                        Cantidad: $scope.NuevoPedidos.Cantidad,
                        Observacion: $scope.NuevoPedidos.Observacion
                    });
                }
                $scope.datagrid.data = $scope.Pedidos;
                $scope.n.cantidad = "1";
                $scope.Cancelar();
            }

        };

        $scope.showB = function (row) {
            $scope.visibilidad = true;
            $scope.pasoCont = 1;
            $scope.mostrar = 'Mostrar';
            $scope.CorreoPedido = 'para ' + row + '.';
            $scope.TextoPedido = ' Paso 1: ';
        }

        $scope.hideB = function () {
            if ($scope.Pedidos.length > 0) {

                $scope.Pedidos = [];
                $scope.datagrid.data = [];
                $scope.visibilidad = true;
                $scope.pasoCont = 1;
                $scope.visibilidad2 = false;
                $scope.CorreoPedido = '';
                $scope.TextoPedido = '';
                $scope.mostrar = '';
                $scope.Cancelar();

            }
            else {
                $scope.datagrid.data = [];
                $scope.visibilidad = true;
                $scope.pasoCont = 1;
                $scope.visibilidad2 = false;
                $scope.CorreoPedido = '';
                $scope.TextoPedido = '';
                $scope.mostrar = '';
                $scope.Cancelar();
            }
        };

        $scope.hideC = function () {
            $scope.visibilidad2 = true;
            $scope.pasoCont = 2;
            $scope.TextoPedido = ' Paso 1: ';
        };

        $scope.elegirTipo = function (id) {
            var usuario = $rootScope.Usuariols;

            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'HijoCorrespondencia',
                { "IdTipoCorrespondencia": id }
            ).then(function (correspondencia) {
                var arrayTipo = [];

                arrayTipo.push({
                    Alias: '',
                    Descripcion: '',
                    ID: 0,
                    iTipo: 0,
                    tff: false
                });

                angular.forEach(correspondencia, function (value) {
                    var iAlias = parseInt(value.Alias);
                    var sAliasN = ''; var tf = false;
                    if (iAlias > 0) { sAliasN = 'Lo mas frecuentes'; tf = true; }
                    else { sAliasN = 'Lo menos frecuentes'; tf = false; }
                    arrayTipo.push({
                        Alias: sAliasN,
                        Descripcion: value.Descripcion,
                        ID: value.ID,
                        iTipo: value.iTipo,
                        tff: tf
                    });
                });
                $scope.HijosDoc = arrayTipo;
                $scope.hijos.HijosDoc1 = $scope.HijosDoc[0];
                $scope.visibilidad2 = true;
                $scope.pasoCont = 2;
                $scope.IdDoc = id;
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

        $scope.Seleccionar = function (row) {
            var index = $scope.datagrid.data.indexOf(row.entity);
            $scope.visibilidad2 = true;
            $scope.NuevoPedidos.TipoDocumento = $scope.Pedidos[index].TipoDocumento;
            $scope.NuevoPedidos.Documento = $scope.Pedidos[index].Documento;
            $scope.NuevoPedidos.Moneda = $scope.Pedidos[index].IdMoneda;
            $scope.NuevoPedidos.Cantidad = $scope.Pedidos[index].Cantidad;
            $scope.NuevoPedidos.Observacion = $scope.Pedidos[index].Observacion;
            $scope.botones = false;
            $scope.Sel = $scope.NuevoPedidos.id;
            $scope.hijos.HijosDoc1 = $scope.NuevoPedidos.TipoDocumento;
            $scope.indicePedido = index;
            if ($scope.Pedidos[index].IdMoneda.ID == '1' || $scope.Pedidos[index].IdMoneda.ID == '2' || $scope.Pedidos[index].IdMoneda.ID == '3') {
                $scope.ShowMoneda = true;
            }
            else {
                $scope.ShowMoneda = false;
            }
            $scope.n.cantidad = $scope.NuevoPedidos.Cantidad;
        };

        $scope.Cancelar = function () {
            if (typeof $scope.NuevoPedidos !== "undefined") {
                $scope.NuevoPedidos = [];
            }
            $scope.botones = true;
            $scope.indicePedido = -1;
            $scope.hijos.HijosDoc1 = $scope.HijosDoc[0];
            $scope.SelectIndexChange1();
            $scope.n.cantidad = '';
        }

        $scope.Eliminar2 = function () {
            $scope.Pedidos.splice($scope.indicePedido, 1);
            $scope.Cancelar();
        };

        $scope.Eliminar = function (row) {
            var index = $scope.datagrid.data.indexOf(row.entity);
            if (index > -1) {
                $scope.Pedidos.splice(index, 1);
                $scope.Cancelar();
            }
        };

        $scope.Modificar = function () {
            $scope.NuevoPedidos.Cantidad = $scope.n.cantidad;
            if (($scope.NuevoPedidos.Cantidad.length) > 0) {
                $scope.Pedidos[$scope.indicePedido].IdDocumento = $scope.IdDoc;
                $scope.Pedidos[$scope.indicePedido].TipoDocumento = $scope.hijos.HijosDoc1;
                $scope.Pedidos[$scope.indicePedido].Documento = $scope.hijos.HijosDoc1.Descripcion;

                $scope.Pedidos[$scope.indicePedido].Cantidad = $scope.NuevoPedidos.Cantidad;
                /*******************************/
                // $scope.wks = $scope.Pedidos[$scope.indicePedido].Cantidad;
                /*******************************/
                $scope.Pedidos[$scope.indicePedido].Observacion = $scope.NuevoPedidos.Observacion;
                if ($scope.ShowMoneda == true) {
                    $scope.Pedidos[$scope.indicePedido].Moneda = $scope.NuevoPedidos.Moneda.Descripcion;
                    $scope.Pedidos[$scope.indicePedido].IdMoneda = $scope.NuevoPedidos.Moneda;
                }
                else {
                    $scope.Pedidos[$scope.indicePedido].Moneda = 'NINGUNA';
                    $scope.Pedidos[$scope.indicePedido].IdMoneda = { "ID": 0 };
                }
                $scope.Cancelar();
            }
            else {

                var tipoCantidad = 'cantidad';

                if ($scope.ShowMoneda === true) {

                    tipoCantidad = 'monto';
                }

                $alert(
                    {
                        title: 'ALERTA!',
                        content: 'Ingrese ' + tipoCantidad + ', por favor',
                        placement: 'top-right2',
                        type: 'info',
                        container: "#contenedorAlert",
                        show: true,
                        duration: 3
                    });
            }

        };
        //2022
        $scope.Enviar = function () {
            var valores = [];
            angular.forEach($scope.Pedidos, function (value) {
                valores.push({
                    TipoDoc: value.TipoDocumento.ID,
                    IdMoneda: value.IdMoneda.ID,
                    Observacion: value.Observacion,
                    Cantidad: value.Cantidad
                });
            });

            console.log($scope.bandejaVirtualSeleccionado);

            $scope.Para = $rootScope.Persona.Nombre;
            var d = $scope.check.aviso;
            $scope.spinner = true;



            Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'RegistrarCorrespondenciaBandejaRemitente',
                {
                    "bandejaRemitenteId": $scope.bandejaVirtualSeleccionado.Id,
                    "para": $rootScope.Persona.Id,
                    "detalle": JSON.stringify(valores),
                    "Seguimiento": $scope.check.aviso
                }).then(function (resultado) {

                    $scope.bandejaVirtualSeleccionado.Id = 0;

                    $scope.spinner = false;
                    if (typeof resultado !== 'undefined') {
                        if (resultado.Autogenerado !== undefined && resultado.Autogenerado !== null &&  resultado.Autogenerado !== "") {
                            enviarAutogenerado = false;
                            $scope.visibilidad3 = false;
                            $scope.pasoCont = 3;
                            var res = resultado;
                            $rootScope.personaLista.Autogenerado = res.Autogenerado;
                            $scope.Cancelar();
                            $rootScope.blood_1 = 100;
                            $scope.asunto.opcion = "";

                        }
                        else {

                            $alert(
                                {
                                    title: 'ALERTA!',
                                    content: 'Se ha producido un error. Inténtelo nuevamente.',
                                    placement: 'top-right2',
                                    type: 'info',
                                    container: "#contenedorAlert",
                                    show: true,
                                    duration: 3
                                });
                        }
                    }
                    else {

                        $alert(
                            {
                                title: 'ALERTA!',
                                content: 'Se ha producido un error. Inténtelo nuevamente.',
                                placement: 'top-right2',
                                type: 'info',
                                container: "#contenedorAlert",
                                show: true,
                                duration: 3
                            });
                    }




                }, function (status) {

                    $scope.spinner = false;
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

        $scope.cerrarPag = function () {
            if ($scope.datagrid.data.length !== 0 && enviarAutogenerado) {
                $scope.cancelAviso = 48;
                $rootScope.notiAvisoCancel = [
                    {
                        Aviso: "Se perderán todos los documentos insertados.",
                        Autogenerado: "",
                        link: "#/Correspondencia",
                        linkDescripcion: " \n SI",
                        Cs: "alert-cerrarAviso alert-danger-aviso",
                        cuerpo: " ¿Esta seguro?"
                    }
                ];
            }
            else {
                // $modalInstance.close();  
                myOtherModal.$promise.then(myOtherModal.hide);
                $scope.visibilidad = true;
                $scope.visibilidad2 = false;
                $scope.visibilidad3 = true;
                $scope.Sel = 0;
                $scope.TextoPedido = '';
                $scope.botones = true;
                $scope.indicePedido = -1;
                $scope.Pedidos = [];
                $scope.NuevoPedidos = [];
                $scope.datagrid.data = [];
                $scope.pasoCont = 1;

                //   $scope.busqueda = false;
                $scope.busqueda = true;
                $scope.ShowMoneda = false;

                $scope.n.cantidad = "1";
                $scope.bandejaVirtualSeleccionado.Id = 0;
                //$scope.bandeja.Id = 0;
            }
        }



        $scope.cerrarPop = function () {

            //$modalInstance.close();
            myOtherModal.$promise.then(myOtherModal.hide);
            /********************************************/
            $scope.bandejaVirtualSeleccionado.Id = 0;

            $scope.visibilidad = true;
            $scope.visibilidad2 = false;
            $scope.visibilidad3 = true;
            $scope.Sel = 0;
            $scope.TextoPedido = '';
            $scope.botones = true;
            $scope.indicePedido = -1;
            $scope.Pedidos = [];
            $scope.NuevoPedidos = [];
            $scope.datagrid.data = [];
            $scope.pasoCont = 1;
            //   $scope.busqueda = false;
            $scope.busqueda = true;
            $scope.ShowMoneda = false;

            $scope.n.cantidad = "1";

            $scope.stopFight();
        }

        $scope.datagrid = {
            paginationPageSizes: [5, 10, 15],
            paginationPageSize: 5,
            rowHeight: 23,
            enableColumnReordering: false,
            enableGridMenu: true,
            enableSorting: false,
            columnDefs: [
                { name: 'ID', width: '5%', enableColumnResizing: true, visible: false },
                { name: 'Documento', width: '150', enableColumnResizing: true },
                { name: 'Moneda', width: '90', enableColumnResizing: true },
                { name: 'Cantidad/Monto', width: '150', cellTemplate: '<div class="ui-grid-cell-contents ng-binding ng-scope " style="text-align: right; height:auto;">{{row.entity.Cantidad}}</span></div>', enableColumnResizing: true },
                { name: 'Observacion', displayName: 'Observación', enableColumnResizing: true },
                { name: 'Modif.', width: '90', cellTemplate: '<div class="ui-grid-cell-contents ng-binding ng-scope " style="text-align:center; height:auto; color: #b87b0d;"><a ng-click="grid.appScope.Seleccionar(row)"><i class="fa fa-pencil"></i></a></div>' },
                { name: 'Elim.', width: '90', enableColumnResizing: true, cellTemplate: '<div class="ui-grid-cell-contents ng-binding ng-scope " style="text-align:center; height:auto; color: #b82d0d;"><a ng-click="grid.appScope.Eliminar(row)"><i class="fa fa-remove"></i></a></div>' }
            ]
        };
        //2022
        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarTiposCorrespondencia', {}).then(function (correspondencia) {
            $scope.TipoDocumentos = correspondencia;
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

        var persona = '';
        $scope.Pedidos = [];
        $scope.NuevoPedidos = [];

        $scope.TipoMoneda = [
            { ID: '0', Descripcion: '' },
            { ID: '1', Descripcion: 'Soles (S)' },
            { ID: '2', Descripcion: 'Dolares ($)' },
            { ID: '3', Descripcion: 'Euros (€)' }
        ];
        $scope.SelectIndexChange1 = function () {
            if ($scope.hijos.HijosDoc1.iTipo == '0') {
                $scope.ShowMoneda = false;
            }
            else {
                $scope.ShowMoneda = true;
            }
            $scope.NuevoPedidos.Moneda = $scope.TipoMoneda[0];
            $scope.n.cantidad = "";
        };



        $scope.NuevoPedidos.Moneda = $scope.TipoMoneda[0];
        $scope.lang = 'es';
        $scope.visibilidad = true;
        $scope.visibilidad2 = false;
        $scope.visibilidad3 = true;
        $scope.Sel = 0;
        $scope.TextoPedido = '';
        $scope.botones = true;
        $scope.indicePedido = -1;
        $scope.datagrid.data = $scope.Pedidos;
        $scope.busqueda = true;
        $scope.ShowMoneda = false;

        var stop;
        $rootScope.$watch('notiAvisoCancel', function () {
            $scope.bandejaVirtualSeleccionado.Id = 0;
            //$scope.bandeja.Id = 0;
            stop = $interval(function () {
                if ($scope.cancelAviso > 0) {
                    $scope.cancelAviso = $scope.cancelAviso - 3;
                    $scope.notiAviso2 = $scope.notiAvisoCancel;

                } else {
                    $scope.stopFight();
                }
            }, 500);
        });

        $scope.stopFight = function () {
            if (angular.isDefined(stop)) {
                $interval.cancel(stop);
                $scope.notiAviso2 = [];
                stop = 'undefined';
            }
        };

    }]);

var app = angular.module('simihApp');

app.directive('isNumber', function () {
    return {
        require: 'ngModel',
        link: function (scope) {

            scope.$watch('n.cantidad', function (newValue, oldValue) {
                if (scope.ShowMoneda) {
                    var arr = String(newValue).split("");
                    if (arr.length === 0) return;

                    if (arr.length === 2 && newValue === '-.') return;
                    if (isNaN(newValue) || arr[0] === "0" || arr[0] === ".") {
                        scope.n.cantidad = oldValue;
                    }
                }
                else {
                    var arr = String(newValue).split("");
                    if (arr.length === 0) {
                        scope.n.cantidad = newValue;
                        return;
                    }

                    if (isNaN(newValue) || arr[arr.length - 1] === '.' || arr[0] === "0") {
                        scope.n.cantidad = oldValue;
                    }
                }
            });
        }
    };
});


angular.module('simihApp').directive('optionsClass', function ($parse) {
    return {
        require: 'select',
        link: function (scope, elem, attrs, ngSelect) {
            // get the source for the items array that populates the select.
            var optionsSourceStr = attrs.ngOptions.split(' ').pop(),
                // use $parse to get a function from the options-class attribute
                // that you can use to evaluate later.
                getOptionsClass = $parse(attrs.optionsClass);

            scope.$watch(optionsSourceStr, function (items) {
                // when the options source changes loop through its items.
                angular.forEach(items, function (item, index) {
                    // evaluate against the item to get a mapping object for
                    // for your classes.
                    var classes = getOptionsClass(item),
                        // also get the option you're going to need. This can be found
                        // by looking for the option with the appropriate index in the
                        // value attribute.
                        option = elem.find('option[value=' + index + ']');

                    // now loop through the key/value pairs in the mapping object
                    // and apply the classes that evaluated to be truthy.
                    angular.forEach(classes, function (add, className) {
                        if (add) {
                            angular.element(option).addClass(className);
                        }
                    });
                });
            });
        }
    };
});