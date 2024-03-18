angular.module('simihApp').controller('ControladorNotificacionesCtrl', ['$scope', 'localStorageService', '$rootScope', '$interval', '$alert', 'Requester',
    function ($scope, localStorageService, $rootScope, $interval, $alert, Requester) {

        var totalAcu = 0;
        var revisaJOS = false;
        $scope.iconM = 1;
        $scope.iconClase = "glyphicon-lateral-JOS glyphicon-plus";


        $scope.limpiarIndicadoresNotificaciones = function () {
            $scope.Tbandejas = $rootScope.Bandejals;
        }


        ////2022
        //var getFacNotificaciones = function () {
        //    Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getFacNotificacionesJson', {}).then(function (data) {

        //        var acuCan = 0;
        //        angular.forEach(data, function (value) {
        //            acuCan += value.CANTIDAD;
        //        });
        //        $scope.totalNotificiones = acuCan;
        //    });
        //}

        ////2022
        //$scope.getPuntoE = function () {
        //    if ($scope.iconM == 1) {
        //        Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'getFacNotificacionesJson', {

        //        }).then(function (data) {
        //            var acuCan = 0;
        //            angular.forEach(JSON.parse(data), function (value) {
        //                acuCan += value.CANTIDAD;
        //            });
        //            $scope.totalNotificiones = acuCan;
        //        });
        //    }
        //    else if ($scope.iconM == 0) {
        //        $scope.getPuntosEntrega = [];
        //        $scope.iconM = 1;
        //        $scope.iconClase = "glyphicon-lateral-JOS glyphicon-plus ";
        //    }
        //}

        //$rootScope.$watch('notiAviso', function () {
        //    if ($rootScope.mostroNoti == false && $rootScope.enInicio == true) {
        //        $rootScope.mostroNoti = true;
        //        var alertas = $rootScope.notiAviso;

        //        angular.forEach(alertas, function (value) {
        //            $alert({
        //                title: '',
        //                content: value.Aviso,
        //                placement: 'top-right2',
        //                type: value.Cs,
        //                container: "#nuevoal",
        //                show: true,
        //                duration: value.tiempo
        //            });
        //        });
        //    }

        //});

        //2022
        //$rootScope.$watch('Configuracionls', function () {
        //    $scope.mostrar = $rootScope.barraNotificacion;

        //    if (typeof $rootScope.Bandejals !== "undefined") {
        //        if ($rootScope.Bandejals.length > 0) {
        //            $rootScope.$watch('indicadorNotificacion', function () {
        //                if ($rootScope.indicadorNotificacion != null) {
        //                    angular.forEach(($rootScope.Configuracionls), function (value) {
        //                        if (value.Valor3 === 'CONF_BANDEJA_INDICADOR') {

        //                            switch (value.Descripcion2) {
        //                                case 'Enviados':
        //                                    value.Valor1 = $rootScope.indicadorNotificacion[0].s_i_creadoTotal;
        //                                    value.Valor2 = $rootScope.indicadorNotificacion[0].s_s_creadoTotal;
        //                                    break;
        //                                case 'Custodia':
        //                                    value.Valor1 = $rootScope.indicadorNotificacion[0].s_i_custodiaTotal;
        //                                    value.Valor2 = $rootScope.indicadorNotificacion[0].s_s_custodiaTotal;
        //                                    break;
        //                                case 'Transito ':
        //                                    value.Valor1 = $rootScope.indicadorNotificacion[0].s_i_transitoTotal;
        //                                    value.Valor2 = $rootScope.indicadorNotificacion[0].s_s_transitoTotal;
        //                                    break;
        //                                case 'Recibidos':
        //                                    value.Valor1 = $rootScope.indicadorNotificacion[0].s_i_recibidoTotal;
        //                                    value.Valor2 = $rootScope.indicadorNotificacion[0].s_s_recibidoTotal;
        //                                    break;
        //                                case 'Transito por JOS':
        //                                    value.Valor1 = $rootScope.indicadorNotificacion[0].s_i_transitoJosTotal;
        //                                    value.Valor2 = $rootScope.indicadorNotificacion[0].s_s_transitoJosTotal;
        //                                    break;
        //                            }

        //                            $scope.indicadoresData = $rootScope.Configuracionls;
        //                        }
        //                        if (value.Valor3 === 'CONFIRMACION') {
        //                            $rootScope.plazoConfirmacion = value.Valor1;
        //                        }
        //                    });

        //                }
        //            });

        //            $scope.ver = "Ver";
        //            $scope.Tbandejas = $rootScope.Bandejals;
        //            var index = localStorageService.get('b');

        //            //if ($rootScope.Usuariols.usuFac > 0) {
        //            //    $scope.JOS = true;
        //            //}
        //            //else {
        //            //    $scope.JOS = false;
        //            //}
        //            $scope.limpiarIndicadoresNotificaciones();
        //            ////2022
        //            //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'BandejaIndicadores', { "tipo": 0 }).then(function (indicadores) {
        //            //    var rm = 0;
        //            //    if (indicadores.length > 0) {
        //            //        if (indicadores[0].Autogenerado !== "") {
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado == 'Por confirmar')
        //            //                    rm++;
        //            //            });
        //            //            var rd = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado == 'Recibidos destino')
        //            //                    rd++;
        //            //            });
        //            //            var sf = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado == 'Sin Fisico')
        //            //                    sf++;
        //            //            });

        //            //            var de = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado === 'Digitalización')
        //            //                    de++;
        //            //            });

        //            //            var total = rm + rd;
        //            //            totalAcu = total;
        //            //            $rootScope.notiAviso = []
        //            //            if (rm > 0) {
        //            //                $rootScope.notiAviso = [
        //            //                    {
        //            //                        Aviso: "Nuevas correspondencias por revisar",
        //            //                        Cs: "alertaNotificacion-normal",
        //            //                        tiempo: 3
        //            //                    }
        //            //                ];
        //            //            }

        //            //            $rootScope.iNotificaciones = [];
        //            //            $rootScope.iNotificaciones =
        //            //                [
        //            //                    { tipo: 'Por confirmar', val: rm },
        //            //                    { tipo: 'Recibidos destino ', val: rd },
        //            //                    { tipo: 'Sin Fisico', val: sf },
        //            //                    { tipo: 'Digitalización', val: de }
        //            //                ];



        //            //            $rootScope.autoJson = JSON.parse(indicadores[0].Autogenerado);
        //            //        }
        //            //    }
        //            //    else {


        //            //        $rootScope.iNotificaciones = [];
        //            //        $rootScope.iNotificaciones =
        //            //            [
        //            //                { tipo: 'Por confirmar', val: 0 },
        //            //                { tipo: 'Recibidos destino ', val: 0 },
        //            //                { tipo: 'Sin Fisico', val: 0 },
        //            //                { tipo: 'Digitalización', val: 0 }
        //            //            ];


        //            //    }
        //            //});

        //            if (typeof $rootScope.Usuariols !== "undefined") {
        //                var idUsuario = $rootScope.Usuariols.ID;
        //                getFacNotificaciones();
        //            }
        //        }



        //        $rootScope.$watch('barraNotificacion', function () {
        //            $scope.mostrar = $rootScope.barraNotificacion;
        //        });

        //        //if ($scope.JOS == true) {
        //        //    if (revisaJOS == false) {
        //        //        $interval(function () {
        //        //            if (typeof $rootScope.Usuariols !== "undefined" && $rootScope.Usuariols.length !== 0) {
        //        //                getFacNotificaciones();
        //        //                revisaJOS = true;
        //        //            }
        //        //        }, 3000);

        //        //    }

        //        //}


        //    }
        //});

        //2022
        //$rootScope.$watch('bandejaActual', function () {
        //    var index = localStorageService.get('b');
        //    if (typeof $rootScope.Bandejals !== "undefined") {
        //        if ($rootScope.Bandejals.length > 0) {
        //            d = 1;
        //            $scope.limpiarIndicadoresNotificaciones();
        //            //2022
        //            //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'BandejaIndicadores', { "idCasilla": $scope.Tbandejas[index].Id, "tipo": 0 }).then(function (indicadores) {
        //            //    var rm = 0;
        //            //    if (indicadores.length > 0) {
        //            //        if (indicadores[0].Autogenerado !== "") {



        //            //            angular.forEach((JSON.parse(indicadores[0].Autogenerado)), function (value) {
        //            //                if (value.IdTipoResultado == 'Por confirmar')
        //            //                    rm++;
        //            //            });
        //            //            var rd = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado == 'Recibidos destino ')
        //            //                    rd++;
        //            //            });
        //            //            var sf = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado == 'Sin Fisico')
        //            //                    sf++;
        //            //            });
        //            //            var de = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado === 'Digitalización')
        //            //                    de++;
        //            //            });
        //            //            var total = rm + rd;
        //            //            if (total != totalAcu) {

        //            //                totalAcu = total;
        //            //            }


        //            //            $rootScope.iNotificaciones = [];
        //            //            $rootScope.iNotificaciones =
        //            //                [
        //            //                    { tipo: 'Por confirmar', val: rm },
        //            //                    { tipo: 'Recibidos destino ', val: rd },
        //            //                    { tipo: 'Sin Fisico', val: sf },
        //            //                    { tipo: 'Digitalización', val: de }
        //            //                ];

        //            //            $rootScope.autoJson = JSON.parse(indicadores[0].Autogenerado);
        //            //        }
        //            //    }
        //            //    else {

        //            //        $rootScope.iNotificaciones = [];
        //            //        $rootScope.iNotificaciones =
        //            //            [
        //            //                { tipo: 'Por confirmar', val: 0 },
        //            //                { tipo: 'Recibidos destino ', val: 0 },
        //            //                { tipo: 'Sin Fisico', val: 0 },
        //            //                { tipo: 'Digitalización', val: 0 }
        //            //            ];


        //            //    }
        //            //});

        //        }
        //    }
        //});

        //2022
        //$interval(function () {
        //    var index = localStorageService.get('b');
        //    if (typeof $rootScope.Bandejals !== "undefined") {
        //        if ($rootScope.Bandejals.length > 0) {
        //            d = 1;
        //            $scope.limpiarIndicadoresNotificaciones();
        //            //2022
        //            //Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'BandejaIndicadores', { "tipo": 0 }).then(function (indicadores) {
        //            //    var rm = 0;
        //            //    if (indicadores.length > 0) {
        //            //        if (indicadores[0].Autogenerado !== "") {


        //            //            angular.forEach((JSON.parse(indicadores[0].Autogenerado)), function (value) {
        //            //                if (value.IdTipoResultado == 'Por confirmar')
        //            //                    rm++;
        //            //            });
        //            //            var rd = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado == 'Recibidos destino ')
        //            //                    rd++;
        //            //            });
        //            //            var sf = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado == 'Sin Fisico')
        //            //                    sf++;
        //            //            });
        //            //            var de = 0;
        //            //            angular.forEach(JSON.parse(indicadores[0].Autogenerado), function (value) {
        //            //                if (value.IdTipoResultado === 'Digitalización')
        //            //                    de++;
        //            //            });
        //            //            var total = rm + rd;
        //            //            if (total != totalAcu) {

        //            //                totalAcu = total;
        //            //            }


        //            //            $rootScope.iNotificaciones = [];
        //            //            $rootScope.iNotificaciones =
        //            //                [
        //            //                    { tipo: 'Por confirmar', val: rm },
        //            //                    { tipo: 'Recibidos destino ', val: rd },
        //            //                    { tipo: 'Sin Fisico', val: sf },
        //            //                    { tipo: 'Digitalización', val: de }
        //            //                ];

        //            //            $rootScope.autoJson = JSON.parse(indicadores[0].Autogenerado);
        //            //        }
        //            //    }
        //            //    else {

        //            //        $rootScope.iNotificaciones = [];
        //            //        $rootScope.iNotificaciones =
        //            //            [
        //            //                { tipo: 'Por confirmar', val: 0 },
        //            //                { tipo: 'Recibidos destino ', val: 0 },
        //            //                { tipo: 'Sin Fisico', val: 0 },
        //            //                { tipo: 'Digitalización', val: 0 }
        //            //            ];


        //            //    }
        //            //});

        //        }
        //    }
        //}, 5000);

    }]);
