app.controller('MantenimientoCorreoCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', '$uibModalInstance', function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants, $uibModalInstance) {

    $scope.registro = {};

    $scope.tipoCorreoList = [

        { idTipoCorreo: 1, tipoCorreo: 'Para' },
        { idTipoCorreo: 2, tipoCorreo: 'CC' }
    ];

    


    $scope.guardar = function () {

        
        if ($scope.isUndefinedOrNullOrEmpty($scope.registro.sCorreo)) {
            swal("\u00a1Error!", "Ingrese un correo válido", "error");
            return;
        }

        if ($scope.isUndefinedOrNullOrEmpty($scope.tipoSeleccionado)) {
            swal("\u00a1Error!", "Seleccione el tipo de correo", "error");
            return;
        }

        $scope.registro.idTipoCorreo = $scope.tipoSeleccionado.idTipoCorreo;

        ServiciosApi.RegistrarCorreo($scope.registro.sCorreo,$scope.IdTipoReporteAutomatico,$scope.registro.idTipoCorreo).then(function (data) {
            if (data === 1) {
                $scope.obtenerCorreoMantenimiento();
                swal("\u00a1Ok!", "Se ha registrado el correo.", "success");
                $uibModalInstance.close();
            }
            else if (data === -1) {
                swal("Error", "Atenci\u00f3n, el correo ingresado ya se encuentra registrado para el tipo de reporte automático seleccionado.", "error");
            }
            else {
                swal("Error", "Hubo un error, vuelva a intentarlo m\u00e1s tarde.", "error");
            }
        }, function (error) {
            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet.", "error");
        });


       

    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancelar');
    };



}]);
