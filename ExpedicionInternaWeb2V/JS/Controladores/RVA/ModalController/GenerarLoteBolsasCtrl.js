app.controller('GenerarLoteBolsasCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', '$interval', 'Exportar', 'config', 'uiGridConstants', 'TIPO', '$uibModalInstance',
    function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, $interval, Exportar, config, uiGridConstants, TIPO, $uibModalInstance) {

        var datosLote = {};

        $scope.crearLote = function () {

            if (validarControles()) {
                return;
            }

            prepararLote();

            ServiciosApi.GenerarLoteBolsa(datosLote).then(function (data) {
                $uibModalInstance.close(data);
            }, function (error) {
                console.error(error);
                $uibModalInstance.dismiss('error');
            });



        };

        $scope.cancelar = function () {
            $uibModalInstance.dismiss('cancelar');
        };


        var validarControles = function () {
            if ($scope.codigoLote.trim().length === 0) {
                swal("Error", "Ingrese el código del lote.", "error");
                return true;
            }

        };

        var prepararLote = function () {
            datosLote.sCodigoJumbo = $scope.codigoLote;
            datosLote.observacion = $scope.observacion;
            var bolsaIdLista = [];

            angular.forEach($scope.bolsasRecepcionadas, function (value, index) {
                bolsaIdLista.push({ iId: value.iId });
            });

            datosLote.bolsas = bolsaIdLista;

            datosLote.fecha = $scope.fecha;
        };

    }]);