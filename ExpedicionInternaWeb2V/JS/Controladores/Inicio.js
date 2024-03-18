angular.module('simihApp').controller('contrInicio',
    function ($scope, $modal, $log, $rootScope, localStorageService, Requester, $alert) {
        
        $scope.tieneMenu = true;// $rootScope.tieneMenu;
        $scope.itemsMostrar = [];
        $rootScope.enInicio = true;
        $scope.visibilidad = true;
        var arrayItems = [];
        var items = '';
        var getFechaDDMMYYY = function (sFecha) {
            var elementos = sFecha.split("/");
            return new Date(elementos[1] + "/" + elementos[0] + "/" + elementos[2]);
        };
        var recienCarga = true;
        $scope.priceSlider = {
            min: 365,
            max: 0,
            ceil: 365,
            floor: 0
        };

        $scope.mouseup = function () {
            console.log('changed', $scope.priceSlider);
        };

        var d = new Date(); // today!
        var hoy = new Date();
        d.setDate(d.getDate() - 0);
        $scope.selectedFechaInicial = d;
        $scope.selectedFechaFinal = hoy;
        $scope.fechaActual = new Date();

        //2022
        /* Función que muestra todos los documentos activos, sin importar la fecha*/
        var verIndicadoresTodos = function () {
            if (typeof $rootScope.Bandejals !== "undefined") {
                if ($rootScope.Bandejals.length > 0) {
                    $scope.Tbandejas = $rootScope.Bandejals;
                    var index = localStorageService.get('b');
                    var fInicio = "01/01/1900";
                    var ff = new Date($scope.selectedFechaFinal);
                    var fFin = ff.getDate() + '/' + (ff.getMonth() + 1) + '/' + ff.getFullYear();

                    
                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ObtenerIndicadoresInicioPorUsuario', { "fechaI": fInicio, "fechaF": fFin })
                        .then(function (indicadores) {
                            items = indicadores;
                            var i_creadoTotal = 0, i_custodiaTotal = 0
                                , i_transitoTotal = 0, i_recibidoTotal = 0
                                , i_transitoJosTotal = 0;

                            var s_creadoTotal = 0, s_custodiaTotal = 0
                                , s_transitoTotal = 0, s_recibidoTotal = 0
                                , s_transitoJosTotal = 0;
                            var fechaMinima = new Date();
                            angular.forEach(items, function (item) {

                                var fechaRegistro = getFechaDDMMYYY(item.fecha);
                                if (fechaRegistro < fechaMinima) {
                                    fechaMinima = fechaRegistro;
                                }
                                if (item.I === 'I') {
                                    if (item.IdTipoEstado === 1)
                                        i_creadoTotal++;
                                    if (item.IdTipoEstado === 2)
                                        i_custodiaTotal++;
                                    if (item.IdTipoEstado === 3)
                                        i_transitoTotal++;
                                    if (item.IdTipoEstado === 4)
                                        i_recibidoTotal++;
                                    if (item.IdTipoEstado === 7)
                                        i_transitoJosTotal++;
                                }
                                if (item.I === 'S') {
                                    if (item.IdTipoEstado === 1)
                                        s_creadoTotal++;
                                    if (item.IdTipoEstado === 2)
                                        s_custodiaTotal++;
                                    if (item.IdTipoEstado === 3)
                                        s_transitoTotal++;
                                    if (item.IdTipoEstado === 4)
                                        s_recibidoTotal++;
                                    if (item.IdTipoEstado === 7)
                                        s_transitoJosTotal++;
                                }
                            });
                            $scope.selectedFechaInicial = fechaMinima;
                            $scope.s_i_creadoTotal = i_creadoTotal;
                            $scope.s_i_custodiaTotal = i_custodiaTotal;
                            $scope.s_i_transitoTotal = i_transitoTotal;
                            $scope.s_i_recibidoTotal = i_recibidoTotal;
                            $scope.s_i_transitoJosTotal = i_transitoJosTotal;

                            $scope.s_s_creadoTotal = s_creadoTotal;
                            $scope.s_s_custodiaTotal = s_custodiaTotal;
                            $scope.s_s_transitoTotal = s_transitoTotal;
                            $scope.s_s_recibidoTotal = s_recibidoTotal;
                            $scope.s_s_transitoJosTotal = s_transitoJosTotal;

                            $rootScope.indicadorNotificacion = [];
                            $rootScope.indicadorNotificacion.push({
                                s_i_creadoTotal: $scope.s_i_creadoTotal,
                                s_i_custodiaTotal: $scope.s_i_custodiaTotal,
                                s_i_transitoTotal: $scope.s_i_transitoTotal,
                                s_i_recibidoTotal: $scope.s_i_recibidoTotal,
                                s_i_transitoJosTotal: $scope.s_i_transitoJosTotal,

                                s_s_creadoTotal: $scope.s_s_creadoTotal,
                                s_s_custodiaTotal: $scope.s_s_custodiaTotal,
                                s_s_transitoTotal: $scope.s_s_transitoTotal,
                                s_s_recibidoTotal: $scope.s_s_recibidoTotal,
                                s_s_transitoJosTotal: $scope.s_s_transitoJosTotal
                            });

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
        };

        /*Llamando a los indicadores totales*/
        verIndicadoresTodos();
        //2022
        $scope.verIndicadores = function () {

            recienCarga = false;
            if (typeof $rootScope.Bandejals !== "undefined") {
                if ($rootScope.Bandejals.length > 0) {
                    $scope.Tbandejas = $rootScope.Bandejals;
                    var index = localStorageService.get('b');

                    var fI = new Date($scope.selectedFechaInicial);
                    var fInicio = fI.getDate() + '/' + (fI.getMonth() + 1) + '/' + fI.getFullYear();

                    var ff = new Date($scope.selectedFechaFinal);
                    var fFin = ff.getDate() + '/' + (ff.getMonth() + 1) + '/' + ff.getFullYear();

                    

                    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ObtenerIndicadoresInicioPorUsuario', { "fechaI": fInicio, "fechaF": fFin })
                        .then(function (indicadores) {

                            items = indicadores;
                            var i_creadoTotal = 0, i_custodiaTotal = 0
                                , i_transitoTotal = 0, i_recibidoTotal = 0
                                , i_transitoJosTotal = 0;

                            var s_creadoTotal = 0, s_custodiaTotal = 0
                                , s_transitoTotal = 0, s_recibidoTotal = 0
                                , s_transitoJosTotal = 0;
                            angular.forEach(items, function (item) {
                                if (item.I === 'I') {
                                    if (item.IdTipoEstado === 1)
                                        i_creadoTotal++;
                                    if (item.IdTipoEstado === 2)
                                        i_custodiaTotal++;
                                    if (item.IdTipoEstado === 3)
                                        i_transitoTotal++;
                                    if (item.IdTipoEstado === 4)
                                        i_recibidoTotal++;
                                    if (item.IdTipoEstado === 7)
                                        i_transitoJosTotal++;
                                }
                                if (item.I === 'S') {
                                    if (item.IdTipoEstado === 1)
                                        s_creadoTotal++;
                                    if (item.IdTipoEstado === 2)
                                        s_custodiaTotal++;
                                    if (item.IdTipoEstado === 3)
                                        s_transitoTotal++;
                                    if (item.IdTipoEstado === 4)
                                        s_recibidoTotal++;
                                    if (item.IdTipoEstado === 7)
                                        s_transitoJosTotal++;
                                }
                            });

                            $scope.s_i_creadoTotal = i_creadoTotal;
                            $scope.s_i_custodiaTotal = i_custodiaTotal;
                            $scope.s_i_transitoTotal = i_transitoTotal;
                            $scope.s_i_recibidoTotal = i_recibidoTotal;
                            $scope.s_i_transitoJosTotal = i_transitoJosTotal;


                            $scope.s_s_creadoTotal = s_creadoTotal;
                            $scope.s_s_custodiaTotal = s_custodiaTotal;
                            $scope.s_s_transitoTotal = s_transitoTotal;
                            $scope.s_s_recibidoTotal = s_recibidoTotal;
                            $scope.s_s_transitoJosTotal = s_transitoJosTotal;

                            $rootScope.indicadorNotificacion = [];
                            $rootScope.indicadorNotificacion.push({
                                s_i_creadoTotal: $scope.s_i_creadoTotal,
                                s_i_custodiaTotal: $scope.s_i_custodiaTotal,
                                s_i_transitoTotal: $scope.s_i_transitoTotal,
                                s_i_recibidoTotal: $scope.s_i_recibidoTotal,
                                s_i_transitoJosTotal: $scope.s_i_transitoJosTotal,

                                s_s_creadoTotal: $scope.s_s_creadoTotal,
                                s_s_custodiaTotal: $scope.s_s_custodiaTotal,
                                s_s_transitoTotal: $scope.s_s_transitoTotal,
                                s_s_recibidoTotal: $scope.s_s_recibidoTotal,
                                s_s_transitoJosTotal: $scope.s_s_transitoJosTotal
                            });

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

        };

        $rootScope.$watch('actualizarE', function () {
            if (recienCarga) {
                return;
            }
        });

        $scope.btn_i_creado = function () {
            $scope.getDataGrilla('I', 1);
        };

        $scope.btn_i_custodia = function () {
            $scope.getDataGrilla('I', 2);
        };

        $scope.btn_i_transito = function () {
            $scope.getDataGrilla('I', 3);
        };

        $scope.btn_i_transitoJOS = function () {
            $scope.getDataGrilla('I', 7);
        };

        $scope.btn_i_recibido = function () {
            $scope.getDataGrilla('I', 4);
        };        

        $scope.btn_s_creado = function () {
            $scope.getDataGrilla('S', 1);
        };

        $scope.btn_s_custodia = function () {
            $scope.getDataGrilla('S', 2);
        };

        $scope.btn_s_transitoJOS = function () {
            $scope.getDataGrilla('S', 7);
        };

        $scope.btn_s_transito = function () {
            $scope.getDataGrilla('S', 3);
        };

        $scope.btn_s_recibido = function () {
            $scope.getDataGrilla('S', 4);
        };
        
        $scope.getDataGrilla = function (tipo, estado) {
            $scope.visibilidad = false;
            arrayItems = [];
            var i = 0;
            var estadoDes = '';
            var person = '';
            var person2 = '';
            var tipoElemento = '';
            angular.forEach(items, function (item) {
                if (item.IdTipoEstado === estado && item.I === tipo) {
                    i++;
                    estadoDes = $scope.evalEstado(estado, tipo);
                    if (tipo === 'I') {
                        person = 'De: ' + item.CasillaDe;
                        person2 = 'Para: ' + item.CasillaPara;
                    }
                    else {
                        person = 'Para: ' + item.CasillaPara;
                        person2 = 'De: ' + item.CasillaDe;
                    }
                    arrayItems.push({
                        I: item.I,
                        nitem: i,
                        Autogenerado: item.Autogenerado,
                        sTipoElemento: item.sTipoElemento,
                        Persona: person,
                        Persona2: person2,
                        fecha: item.fecha,
                        hora: item.hora,
                        ID: item.ID
                    });
                }
            });
            $scope.tituloE = estadoDes;
            $scope.itemsMostrar = arrayItems;
            if (arrayItems.length === 0) {
                $scope.visibilidad = true;
                $rootScope.notiAviso = [
                    {
                        Aviso: "No se encontraron correspondencias.",
                        Autogenerado: '',
                        Cs: "alertaNotificacion",
                        tiempo: 3
                    }

                ];
            }
        };
        
        $scope.btnAtras = function () {
            $scope.visibilidad = true;
        };
        //2022
        $scope.sTracking = function (idx, Autogeneradox) {

            var myOtherModal = $modal({
                scope: $scope,
                template: 'modalTracking.html',
                show: false
            });
            myOtherModal.$promise.then(myOtherModal.show);

            $scope.id = idx;

            $scope.Autogenerado = Autogeneradox;
            //2022
            //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getSeguimiento', { "id": $scope.id }).then(function (Correspondencia) {
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

        };

        $scope.evalEstado = function (estado, tipo) {
            var textEstado = '';
            if (estado === 1 && tipo === 'I') {
                textEstado = 'Documentos enviados para mi';
            }
            if (estado === 2 && tipo === 'I') {
                textEstado = 'Documentos en custodia para mi';
            }
            if (estado === 3 && tipo === 'I') {
                textEstado = 'Documentos en ruta para mi';
            }
            if (estado === 4 && tipo === 'I') {
                textEstado = 'Documentos en bandeja para mi';
            }

            if (estado === 1 && tipo === 'S') {
                textEstado = 'Documentos enviados por mi';
            }
            if (estado === 2 && tipo === 'S') {
                textEstado = 'Documentos en Expedicion';
            }
            if (estado === 3 && tipo === 'S') {
                textEstado = 'Documentos en ruta hacia destino';
            }
            if (estado === 4 && tipo === 'S') {
                textEstado = 'Documentos en bandeja destino';
            }
            return textEstado;
        };

    });

