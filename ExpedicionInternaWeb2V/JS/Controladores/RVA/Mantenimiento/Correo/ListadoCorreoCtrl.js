app.controller('ListadoCorreoCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants) {


    /*********************
       Configuración
   **********************/
    $scope.setActive('vMantenimiento');
    $scope.setActiveNavBar(true);

    /***************************
       Variables Incializadas
   ****************************/
    $scope.correoList = [];
    $scope.tipoReporteAutomaticoList = [];

    $scope.EliminarCorreo = function (TipoReporteAutomatico, Correo) {

        swal({
            title: "\u00a1Un Momento!",
            text: "Se eliminar\u00e1n el correo " + Correo.Correo + " del listado de " + TipoReporteAutomatico.TipoReporteAutomatico + ". \u00bfDesea continuar?",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
            closeOnConfirm: false,
            closeOnCancel: true
        },
            function (isConfirm) {
                if (isConfirm) {

                    ServiciosApi.EliminarCorreo(TipoReporteAutomatico.IdTipoReporteAutomatico, Correo.IdCorreo).then(function (data) {
                        if (data === 1) {
                            $scope.obtenerCorreoMantenimiento();
                            swal("\u00a1Registro eliminado!", "Se han eliminado el registro seleccionado.", "success");
                        }
                        else {
                            swal("Error", "Hubo un error, vuelva a intentarlo m\u00e1s tarde.", "error");
                        }
                    }, function (error) {
                        swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet.", "error");
                    });


                }
            });
    };

    var ListarTipoReporteAutomatico = function () {

        ServiciosApi.ListarTipoReporteAutomatico().then(function (data) {

            $scope.tipoReporteAutomaticoList = data;

        }, function (error) {
            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            console.error(error);
        });
    };

    /*Función para llamar a todas las agencias*/
    $scope.obtenerCorreoMantenimiento = function () {

        $scope.correoList = [];

        ServiciosApi.ListarCorreoElectronicoMantenimiento().then(function (data) {

            $scope.correoList = data;
            ListarTipoReporteAutomatico();

        }, function (error) {
            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            console.error(error);
        });


    };

    $scope.obtenerCorreoMantenimiento();

    $scope.nuevoCorreo = function (IdTipoReporteAutomatico) {

        var scope = $scope.$new();
        scope.IdTipoReporteAutomatico = IdTipoReporteAutomatico;

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: '/parcial/Mantenimiento/Correo/MantenimientoCorreo.html',
            controller: 'MantenimientoCorreoCtrl',
            scope: scope
        }).result.then(function (data) {
            //do logic
        }, function () {
            // action on popup dismissal.
        });
        return;
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

}]);
