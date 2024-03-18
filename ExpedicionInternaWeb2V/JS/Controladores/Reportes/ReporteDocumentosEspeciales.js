'use strict';

/* App Module */
angular.module('simihApp').controller('ReporteDocumentosEspeciales',
    ['$scope', '$http', 'remoteResource', 'localStorageService', '$log', 'uiGridConstants', '$window', '$rootScope', '$modal', 'Requester', 'UtilsService', 'ExportarService',
        function ($scope, $http, remoteResource, localStorageService, $log, uiGridConstants, $window, $rootScope, $modal, Requester, UtilsService, ExportarService) {

            /****************************************/
            var _data = [];
            $scope.camposDinamicos = [];
            $scope.camposReporte = [];

            var listarTiposDocumentoEspeciales = function () {
                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ListarTipoDocumentoDigital', {})
                    .then(function (data) {
                        $scope.TipoDocumentos = angular.copy(data);
                        console.log(data);

                    });
            };

            var cargarFecha = function () {
                $scope.fromDate = new Date();
                $scope.untilDate = new Date();
            };

            $scope.TipoDocumentos = [];

            $scope.TipoDocumentoSeleccionado = '';

            $scope.reporteDocumentosEspeciales = function () {

                if ($scope.TipoDocumentoSeleccionado === '') {
                    //mensaje
                    return;
                }

                Requester.AuthorizationPost($rootScope.rutaWebGeneral + 'ReporteDocumentosEspeciales', {
                    tipodocumento: parseInt($scope.TipoDocumentoSeleccionado),
                    dFechaInicial: $scope.fromDate,
                    dFechaFinal: $scope.untilDate
                }).then(function (data) {

                    if (!UtilsService.isUndefinedOrNullOrEmpty(data)) {

                        _data = angular.copy(data);

                        $scope._camposDinamicos = angular.copy(Object.keys(_data[0]));                       
                        
                        console.log($scope._camposDinamicos);
                        
                        $scope.camposReporte = [];      

                        console.log($scope._camposDinamicos);

                        for (var i = 0; i < $scope._camposDinamicos.length; i++) {

                            var ot = {};
                            if (i === 2) {
                                ot = { field: $scope._camposDinamicos[i], name: $scope._camposDinamicos[i], width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm"'  };
                            }
                            else {
                                ot = { field: $scope._camposDinamicos[i], name: $scope._camposDinamicos[i], width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS } };
                            }
                            $scope.camposReporte.push(ot);
                            
                           
                        }

                        console.log($scope.camposReporte);

                        $scope.gridDocumentosEspeciales.columnDefs = $scope.camposReporte;

                        for (var j = 0; j < $scope._camposDinamicos.length; j++) {
                            $scope.gridDocumentosEspeciales.columnDefs[j].displayName = UtilsService.MaysPrimera($scope._camposDinamicos[j].toLowerCase());
                        }

                        $scope.gridDocumentosEspeciales.columnDefs[6].visible = false;
                        $scope.gridDocumentosEspeciales.columnDefs[7].visible = false;
                        $scope.gridDocumentosEspeciales.columnDefs[8].visible = false;
                        $scope.gridDocumentosEspeciales.data = data;                        

                    }
                    else {
                        $scope.gridDocumentosEspeciales.data = [];
                    }                    

                }, function (error) {

                    NotificacionService.mostrarNotificacionSimple('Ha ocurrido un problema en la petición HTTP. Comuníquese con el administrador del sistema', TipoNotificacion.ALERT);

                });
            };



            /****************Reporte documentos****************/
            $scope.gridDocumentosEspeciales = {

                paginationPageSizes: [10, 50, 75],
                paginationPageSize: 10,
                enableFiltering: true,
                columnDefs: $scope.camposReporte
            };
            
            $scope.exportar = function () {
                if (UtilsService.isUndefinedOrNullOrEmpty(_data)) {

                    NotificacionService.mostrarNotificacionSimple('No existen datos a exportar', TipoNotificacion.WARNING);
                    return;
                }

                var nombreReporte = 'Documentos especiales';


                var cabecera = [];

                var cuerpo = [];

                var j = 0;

                angular.forEach(_data, function (value, key) {

                    var obj = [];

                    for (var i = 0; i < $scope._camposDinamicos.length; i++) {

                        if (i === 6 || i === 7 || i === 8) {
                            continue;
                        }

                        if (j === 0) {
                            cabecera.push(UtilsService.MaysPrimera($scope._camposDinamicos[i].toLowerCase()).replace("_"," "));                            
                        }
                        
                        obj.push(UtilsService.reemplazarNulo(value[$scope._camposDinamicos[i]],''));

                    }      
                    
                    j++;

                    cuerpo.push(obj);

                });

                ExportarService.exportarData(nombreReporte, cabecera, cuerpo);

            };
           

            //$scope.actualizando = function () {
            //    $scope.josEnviados();
            //};

            /********************************/

            // Disashowtabsle weekend selection
            $scope.disabled = function (date, mode) {
                return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
            };


            $scope.dateOptions = {
                formatYear: 'yy',
                startingDay: 1
            };

            listarTiposDocumentoEspeciales();


            

            cargarFecha();
        }]);

angular.module('simihApp').config(function ($datepickerProvider) {
    angular.extend($datepickerProvider.defaults, {
        dateFormat: 'dd/MM/yyyy',
        startWeek: 1,
        autoclose: true
        
    });
});



//maxDate: new Date()$scope.myAppScopeProvider = {
            //    verTrack: function (row, tipo) {
            //        var myOtherModal = $modal({
            //            scope: $scope,
            //            template: 'modalTracking.html',
            //            show: false
            //        });
            //        myOtherModal.$promise.then(myOtherModal.show);
            //        /**se considera solo al tipo 2**/
            //        if (tipo == 1)
            //            $scope.id = row.entity.Id;
            //        else if (tipo == 2)
            //            $scope.id = row.entity.ID;
            //        console.log(row.entity.ID);
            //        console.log(row.entity.Id);

            //        $scope.Autogenerado = row.entity.Autogenerado;
            //        //getSeguimiento            
            //        remoteResource.getSeguimiento($scope.id).then(function (Correspondencia) {
            //            $scope.dataSeguimiento = Correspondencia;
            //        }, function (status) {
            //            alert("Ha fallado la petición. Estado HTTP:" + status);
            //        });
            //    }
            //}