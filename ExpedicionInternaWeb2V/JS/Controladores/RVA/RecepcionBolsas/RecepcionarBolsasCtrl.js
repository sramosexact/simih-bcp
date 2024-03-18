/*Controlador de la página RecepcionBolsas.html*/
app.controller('RecepcionarBolsasCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', '$interval', 'Exportar', 'config', 'uiGridConstants', 'TIPO',
    function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, $interval,  Exportar, config, uiGridConstants, TIPO,) {

        /*********************
           Configuración
        *********************/
        $scope.setActive('vRecepcion');
        $scope.setActiveNavBar(true);


        /************************************************************************************************************
           Controles de formulario
        ************************************************************************************************************/

        $scope.nombreBotonRegistro = "Iniciar Recepción";
        $scope.enRegistro = false;
        $scope.TipoBolsaList = [];
        var BolsasActivas = [];
        var BolsasRecepcionadas = [];
        var LotesPendientes = [];
        var LotesEnCamino = [];
        var fechaServidor = null;
        var opc = true;


        var listarTipoBolsa = function () {

            ServiciosApi.ListarTipoBolsa().then(function (data) {
                $scope.TipoBolsaList = data;
                $scope.tipoBolsaSeleccionado = data[0];
                listarBolsasActivas();
            }, function (error) {
                console.error(error);
            });
        };

        var listarBolsasActivas = function () {

            ServiciosApi.ListarBolsasActivas().then(function (data) {
                BolsasActivas = data;
                listarLotesEnProceso();
                listarLotesEnviados();
            }, function (error) {
                console.error(error);
            });
        };

        var obtenerFechaServidor = function () {

            ServiciosApi.getFechaServidor().then(function (data) {
                fechaServidor = new Date(data[0].dFechaRecepcion);
                fechaServidor.setTime(fechaServidor.getTime());
            }, function (error) {
                fechaServidor = null;
            });
        };

        listarTipoBolsa();



        /************************************************************************************************************
           Bolsas sin lote
        ************************************************************************************************************/

        var tmpEliminar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.eliminar(row)" ng-disabled="enRegistroBool"><i class="fa fa-remove fondo-rojo-icono" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';

        var campoGridList = [
            { displayName: 'Código bolsa', field: 'sDescripcionBolsaNaranja', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Código agencia', field: 'sIdAgencia', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Nombre agencia', field: 'sDescripcionAgencia', width: '200', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Fecha recepción', field: 'dFechaRecepcionDT', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { name: 'Eliminar', displayName: 'Eliminar', width: '100', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpEliminar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' }
        ];


        $scope.myAppScopeProviderSinLote = {

            eliminar: function (row) {

                swal({
                    title: "\u00a1Un Momento!",
                    text: "Se eliminar\u00e1 el registro de la bolsa seleccionada. \u00bfDesea continuar?",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "Aceptar",
                    cancelButtonText: "Cancelar",
                    closeOnConfirm: true,
                    closeOnCancel: true
                }).then((isConfirm) => {
                        if (isConfirm) {
                            var index = $scope.gridRegistroBolsas.data.indexOf(row.entity);
                            $scope.gridRegistroBolsas.data.splice(index, 1);
                            $scope.gridApi.core.refresh();
                        }
                    });
            }
        };

        $scope.gridRegistroBolsas = {
            data: BolsasRecepcionadas,
            paginationPageSizes: [5, 50, 75],
            paginationPageSize: 5,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoGridList,
            appScopeProvider: $scope.myAppScopeProviderSinLote,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }
        };

        $scope.iniciarRecepcion = function () {

            if (opc) {
                obtenerFechaServidor();
                $scope.codBolsa = "";
                $scope.enRegistro = true;
                $scope.nombreBotonRegistro = "Cancelar";
                seleccionarCodigoBolsa();
                opc = false;
            }
            else {
                swal({
                    title: "\u00a1Un Momento!",
                    text: "Se cancelar\u00e1 la recepción. \u00bfDesea continuar? \n\n Los registros ingresados se quitarán de la lista",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "Si",
                    cancelButtonText: "No"
                }).then( (isConfirm) => {
                        if (isConfirm) {
                            BolsasRecepcionadas = [];
                            $scope.gridRegistroBolsas.data = BolsasRecepcionadas;
                            $scope.gridApi.core.refresh();
                            $scope.enRegistro = false;
                            $scope.nombreBotonRegistro = "Iniciar Recepción";
                            opc = true;
                            console.log('Operación cancelada por el usuario');
                        }
                }, (dismiss) => {
                    if (dismiss === 'cancel') {
                        // Manejar la cancelación aquí
                    }
                });
                
            }
        };

        $scope.presionar = function (KeyEvent) {
            if (KeyEvent.which === 13) {
                $scope.agregarBolsa();
                return;
            }
        };

        $scope.agregarBolsa = async function () {

            if ($scope.isUndefinedOrNullOrEmpty($scope.codBolsa)) {
                swal("Error", "Ingrese el código de bolsa", "error");
                seleccionarCodigoBolsa();
                return;
            }

            var bolsaIngresada;
            bolsaIngresada = buscarBolsaEnListaRecepcionadas($scope.codBolsa);

            if (!$scope.isUndefinedOrNullOrEmpty(bolsaIngresada)) {

                if (esBolsaNaranja(bolsaIngresada)) {

                    swal(confirmarRecepcionBolsaDuplicada(bolsaIngresada)).then( (isConfirm) => {
                        if (isConfirm) {
                            agregarBolsaALista(bolsaIngresada);
                        }
                        else {
                            seleccionarCodigoBolsa();
                        }
                    });
                }
                else {
                    seleccionarCodigoBolsa();
                }
            }
            else {
                bolsaIngresada = buscarBolsaEnListaActivos($scope.codBolsa);
                if (!$scope.isUndefinedOrNullOrEmpty(bolsaIngresada)) {
                    agregarBolsaALista(bolsaIngresada);
                }
                else {
                    swal("Error", "La bolsa con el código " + $scope.codBolsa + " no existe.", "error");
                    seleccionarCodigoBolsa();
                }
            }
        };

        var buscarBolsaEnListaRecepcionadas = function (codigoBolsa) {
            return BolsasRecepcionadas.find(x => x.sDescripcionBolsaNaranja === codigoBolsa.toString());
        };

        var buscarBolsaEnListaActivos = function (codigoBolsa) {
            return BolsasActivas.find(x => x.sDescripcionBolsaNaranja === codigoBolsa.toString());
        };

        var esBolsaNaranja = function (bolsaIngresada) {
            return bolsaIngresada.sIdAgencia === bolsaIngresada.sDescripcionBolsaNaranja ? true : false;
        };

        var confirmarRecepcionBolsaDuplicada = function (bolsaIngresada) {
            return {
                title: "\u00a1Un momento!",
                text: "Ya recepcionó la bolsa con el código : " + bolsaIngresada.sDescripcionBolsaNaranja + ". \u00bfDesea recepcionar nuevamente?",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Aceptar",
                cancelButtonText: "Cancelar"
            }
        };

        var agregarBolsaALista = function (bolsaIngresada) {
            if (bolsaIngresada.iIdTipoBolsaNaranja === $scope.tipoBolsaSeleccionado.iId) {
                bolsaIngresada.dFechaRecepcionDT = fechaServidor;
                BolsasRecepcionadas.push(bolsaIngresada);
                $scope.gridApi.core.refresh();
                limpiarCodigoBolsa();
            }
            else {
                swal("Error", "La bolsa no pertenece al tipo seleccionado.", "error");
                seleccionarCodigoBolsa();
            }
        };

        var seleccionarCodigoBolsa = function () {
            document.getElementById("txtCodBolsa").focus();
            document.getElementById("txtCodBolsa").select();
        };

        var limpiarCodigoBolsa = function () {
            $scope.codBolsa = "";
            document.getElementById("txtCodBolsa").value = "";
            document.getElementById("txtCodBolsa").focus();
        };

        $scope.agregarLote = function () {

            if (BolsasRecepcionadas.length === 0) {
                swal("Error", "Ingrese las bolsas del lote.", "error");
                return;
            }

            var lote = {};

            var scope = $scope.$new();
            var bolsasRecepcionadas = [];
            angular.copy(BolsasRecepcionadas, bolsasRecepcionadas);

            scope.bolsasRecepcionadas = bolsasRecepcionadas;
            scope.fecha = fechaServidor;

            $uibModal.open({
                animation: true,
                templateUrl: '/PAGINAS/RVA/Template/TmpGenerarLoteBolsas.html',
                controller: 'GenerarLoteBolsasCtrl',
                scope: scope
            }).result.then(function (data) {
                BolsasRecepcionadas = [];
                $scope.gridRegistroBolsas.data = BolsasRecepcionadas;
                $scope.gridApi.core.refresh();
                $scope.enRegistro = false;
                $scope.nombreBotonRegistro = "Iniciar Recepción";
                opc = true;
                listarLotesEnProceso();

            }, function () {
                console.log(lote);
                console.log("cancelado");
            });


        };


        /************************************************************************************************************
           Lotes en proceso
        ************************************************************************************************************/

        var campoLoteEnProcesoGridList = [
            { displayName: 'Código', field: 'sCodigoJumbo', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Cantidad de bolsas', field: 'iCantidadBolsas', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Tipo', field: 'sTipoBolsa', width: '200', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Observación', field: 'sObservacion', width: '200', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Estado', field: 'sEstado', width: '200', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' }
        ];

        $scope.gridLotesEnProceso = {
            data: LotesPendientes,
            paginationPageSizes: [5, 50, 75],
            paginationPageSize: 5,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoLoteEnProcesoGridList,
            onRegisterApi: function (gridApiLotesEnProceso) { $scope.gridApiLotesEnProceso = gridApiLotesEnProceso; }
        };

        var listarLotesEnProceso = function () {

            ServiciosApi.ListarLotesEnProceso().then(function (data) {
                LotesPendientes = data;
                $scope.gridLotesEnProceso.data = LotesPendientes;
                $scope.gridApiLotesEnProceso.core.refresh();
            }, function (error) {
                console.error(error);
            });
        };

        $scope.enviarLote = function () {
            var lotesSeleccionados = [];
            var lotesAEnviar = [];

            lotesSeleccionados = seleccionarLotes();

            if (lotesSeleccionados.length > 0) {
                angular.forEach(lotesSeleccionados, function (value, key) {
                    lotesAEnviar.push({ iId: value.iId });
                });
            }
            else {
                swal("Error", "No se han seleccionado lotes para enviar.", "error");
                return;
            }

            enviarLotesSeleccionados(lotesAEnviar);

        };

        var seleccionarLotes = function () {
            return $scope.gridApiLotesEnProceso.selection.getSelectedRows();
        };

        var enviarLotesSeleccionados = function (lotesAEnviar) {
            ServiciosApi.EnviarLotes(lotesAEnviar).then(function (data) {
                listarLotesEnProceso();
                listarLotesEnviados();
            }, function (error) {
                swal("Error", "Ha ocurrido un error. Inténtelo nuevamente.", "error");
                console.error(error);
            });
        };



        /************************************************************************************************************
           Envios en camino
        ************************************************************************************************************/


        var tmpTerminar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.terminar(row)" ng-disabled="enRegistroBool"><i class="fa fa-thumbs-up" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';
        var tmpExportar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.exportar(row)" ng-disabled="enRegistroBool"><i class="fa fa-file-excel-o" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';

        var campoLoteEnCaminoGridList = [
            { displayName: 'Código envío', field: 'codigoEnvio', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Nro. de lotes', field: 'numeroLotes', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Fecha y hora', field: 'fechaEnvio', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { name: 'Terminar', displayName: 'Terminar', width: '100', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpTerminar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' },
            { name: 'Exportar', displayName: 'Exportar', width: '100', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpExportar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' }
        ];

        $scope.myAppScopeProviderLotesEnCamino = {

            terminar: function (row) {
                var envioSeleccionado = row.entity;
                swal({
                    title: "\u00a1Un Momento!",
                    text: "Se terminar\u00e1 el envío seleccionado. \u00bfDesea continuar?",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "Aceptar",
                    cancelButtonText: "Cancelar",
                }).then( (isConfirm) => {
                        if (isConfirm) {
                            terminarEnvioLote(envioSeleccionado.codigoEnvio);
                        }
                }, (dismiss) => {
                    if (dismiss === 'cancel') {
                        // Manejar la cancelación aquí
                    }
                });

            },
            exportar: function (row) {
                var envioSeleccionado = row.entity;
                exportarEnvioLote(envioSeleccionado.codigoEnvio);

            }
        };

        $scope.gridLotesEnCamino = {
            data: LotesEnCamino,
            paginationPageSizes: [5, 50, 75],
            paginationPageSize: 5,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoLoteEnCaminoGridList,
            appScopeProvider: $scope.myAppScopeProviderLotesEnCamino,
            onRegisterApi: function (gridApiLotesEnCamino) { $scope.gridApiLotesEnCamino = gridApiLotesEnCamino; }
        };

        var listarLotesEnviados = function () {

            ServiciosApi.ListarLotesEnviados().then(function (data) {
                LotesEnCamino = data;
                $scope.gridLotesEnCamino.data = LotesEnCamino;
                $scope.gridApiLotesEnCamino.core.refresh();
            }, function (error) {
                console.error(error);
            });
        };


        var terminarEnvioLote = function (codigoEnvio) {

            ServiciosApi.TerminarEnvioLote(codigoEnvio).then(function (data) {
                if (data == 1) {
                    //$scope.gridApiLotesEnCamino.data = LotesEnCamino;
                    //$scope.gridApiLotesEnCamino.core.refresh();
                    exportarEnvioLote(codigoEnvio);
                    listarLotesEnviados()
                }
                else {
                    swal("Error", "Ha ocurrido un error. Inténtelo nuevamente.", "error");
                }
            }, function (error) {
                console.error(error);
            });
        };

        var exportarEnvioLote = function (codigoEnvio) {
            ServiciosApi.ExportarEnvioLote(codigoEnvio).then(function (data) {

                exportarTablaExcel(data);

            }, function (error) {
                console.error(error);
            });

        };




        var exportarTablaExcel = function (data) {
            var ObjetoExportar = new Exportar.Objeto();
            ObjetoExportar.Config.TitleBackgroundColor = "#808080";
            ObjetoExportar.Config.TitleFontColor = "#fff";
            ObjetoExportar.cabecera = [
                "Codigo agencia",
                "Agencia",
                "Codigo de bolsa",
                "Codigo de lote",
                "Tipo de lote",
                "Fecha y hora de entrega",
                "Fecha de entrega",
                "Codigo de envío"
            ];
            ObjetoExportar.NameReporte = "EnvioLoteBolsas";
            var obj = [];
            var datosExportar = [];
            angular.copy(data, datosExportar);
            //datosExportar = $filter('orderBy')(datosExportar, 'sIdAgencia');
            angular.forEach(datosExportar, function (value, index) {
                obj = [
                    value.sIdAgencia,
                    value.sDescripcionAgencia,
                    value.sDescripcionBolsaNaranja,
                    value.sCodigoJumbo,
                    value.sDescripcionTipoBolsaNaranja,
                    EvaluarFecha(value.dFechaEntrega),
                    EvaluarSoloFecha(value.dFechaEntrega),
                    value.codigoEnvio

                ];
                ObjetoExportar.detalle.push(obj);
            });
            Exportar.ExcelObjeto(ObjetoExportar);
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

        var EvaluarSoloFecha = function (fecha) {
            if (fecha === null || fecha === "") {
                return "";
            }
            else {
                date = new Date(fecha);
                return $filter('date')(fecha, 'yyyy-MM-dd', 'UTC / GMT');
            }

        };








        window.onbeforeunload = function (event) {
            if (i === 1) {
                return "Aviso: Por favor finalice la recepci\u00f3n de las agencias, en caso contrario perder\u00E1 sus cambios.";
            }
        };

        /*Evitar que el backspace retroceda a la ventana anterior*/
        $(document).unbind('keydown').bind('keydown', function (event) {
            var doPrevent = false;
            if (event.keyCode === 8) {
                var d = event.srcElement || event.target;
                if ((d.tagName.toUpperCase() === 'INPUT' &&
                    (
                        d.type.toUpperCase() === 'TEXT' ||
                        d.type.toUpperCase() === 'PASSWORD' ||
                        d.type.toUpperCase() === 'FILE' ||
                        d.type.toUpperCase() === 'SEARCH' ||
                        d.type.toUpperCase() === 'EMAIL' ||
                        d.type.toUpperCase() === 'NUMBER' ||
                        d.type.toUpperCase() === 'DATE')
                ) ||
                    d.tagName.toUpperCase() === 'TEXTAREA') {
                    doPrevent = d.readOnly || d.disabled;
                }
                else {
                    doPrevent = true;
                }
            }

            if (doPrevent) {
                event.preventDefault();
            }
        });

        /*Evitar que salga de la pantalla cuando se recepciona las valijas*/
        $scope.$on('$locationChangeStart', function (event) {
            if ($rootScope.enRegistro === 1) {
                swal("\u00a1Un momento...!", "No puedes salir mientras est\u00e1s registrando la recepci\u00f3n de valijas.", "error");
                event.preventDefault();
            }

        });


    }]);



