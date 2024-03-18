app.controller('MantenimientoFeriadoCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', '$uibModalInstance', function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants, $uibModalInstance) {

    $scope.registro = {};

    $scope.tipoAgenciaList = [
        
        { idTipoAgencia: 1, tipoAgencia: 'LIMA' },
        { idTipoAgencia: 2, tipoAgencia: 'PROVINCIA' },
        { idTipoAgencia: 0, tipoAgencia: 'LIMA Y PROVINCIA' }
    ];

    $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());


    $scope.modelFecha = $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy' }).val();

    var op = false; 

   

    $scope.guardar = function () {

        if ($scope.isUndefinedOrNullOrEmpty($scope.modelFecha)) {
            swal("\u00a1Error!", "Seleccione una fecha válida", "error");
            return;
        }


        if ($scope.isUndefinedOrNullOrEmpty($scope.registro.sDescripcion)) {
            swal("\u00a1Error!", "Ingrese una descripción", "error");
            return;
        }

        if ($scope.isUndefinedOrNullOrEmpty($scope.tipoSeleccionado)) {
            swal("\u00a1Error!", "Seleccione el tipo de agencia", "error");
            return;
        }

        $scope.registro.idTipoAgencia = $scope.tipoSeleccionado.idTipoAgencia;


        var pFecha;

        pFecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate");

        var controlYearValue = pFecha.getFullYear();
        var controlMonthValue = pFecha.getMonth();
        var controlDayValue = pFecha.getDate();

        $scope.registro.dFecha = new Date(controlYearValue, controlMonthValue, controlDayValue);


        ServiciosApi.RegistrarFeriado($scope.registro).then(function (data) {

            if (data === 1) {
                swal("\u00a1Operaci\u00f3n existosa!", "Se ha registrado un nuevo feriado", "success");        
                $scope.obtenerFeriadoMantenimiento();
                $uibModalInstance.close();
            } else if (data === -1) {
                swal("\u00a1Error!", "Ya existe un registro para la fecha seleccionada", "error");
            
            } else {
                swal("\u00a1Error!", "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde.", "error");
            }

        }, function (error) {
            swal("\u00a1Error!", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            console.error(error);
        });

    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancelar');
    };

   

}]);
