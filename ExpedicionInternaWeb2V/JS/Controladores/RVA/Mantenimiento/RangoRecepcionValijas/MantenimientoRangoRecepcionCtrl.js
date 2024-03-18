app.controller('MantenimientoRangoRecepcionCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', '$uibModalInstance', function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants, $uibModalInstance) {

    $scope.registro = {};

    $scope.rangoList = [];


    $scope.rangoMenor = {};
    $scope.rangoMenor.arcoInferiorRecepcion = new Date(1970, 0, 1, 0, 0, 0, 0);
    $scope.rangoMenor.arcoSuperiorRecepcion = new Date(1970, 0, 1, 0, 1, 0, 0);
    $scope.rangoMenor.meta = 0;
    $scope.rangoMenor.activo = true;

    $scope.rangoMayor = {};
    $scope.rangoMayor.arcoInferiorRecepcion = new Date(1970, 0, 1, 0, 1, 0, 0);
    $scope.rangoMayor.arcoSuperiorRecepcion = new Date(1970, 0, 1, 23, 59, 0, 0);
    $scope.rangoMayor.meta = 100;
    $scope.rangoMayor.activo = true;

    $scope.rango = {};

    var arcoSuperiorMinimo = new Date(1970, 0, 1, 0, 1, 0, 0);

    var rangoActivo = {};

    var metaMinima = 0;

    



    $scope.tipoAgenciaList = [

        { idTipoAgencia: 1, tipoAgencia: 'LIMA' },
        { idTipoAgencia: 2, tipoAgencia: 'PROVINCIA' }
    ];

    var listarProveedores = function () {

        ServiciosApi.ListarProveedor().then(function (data) {
            $scope.proveedorList = data;
        }, function (error) {
            swal("\u00a1Error!", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
        });
    };

    listarProveedores();

    var validarCamposRango = function () {

        
        if ($scope.isUndefinedOrNullOrEmpty($scope.rango.arcoInferiorRecepcion)) {
            swal("\u00a1Error!", "Ingrese un arco inferior de recepción válido", "error");
            return true;
        }

        if ($scope.rango.arcoInferiorRecepcion < arcoSuperiorMinimo) {
            swal("\u00a1Error!", "El arco inferior de recepción debe ser mayor a " + $scope.dateToStringHHmm(arcoSuperiorMinimo), "error");
            return true;
        }

        if ($scope.isUndefinedOrNullOrEmpty($scope.rango.arcoSuperiorRecepcion)) {
            swal("\u00a1Error!", "Ingrese un arco superior de recepción válido", "error");
            return true;
        }

        if ($scope.rango.arcoSuperiorRecepcion <= $scope.rango.arcoInferiorRecepcion) {
            swal("\u00a1Error!", "El arco superior de recepción debe ser mayor a " + $scope.dateToStringHHmm($scope.rango.arcoInferiorRecepcion), "error");
            return true;
        }

        if ($scope.isUndefinedOrNullOrEmpty($scope.rango.meta)) {
            swal("\u00a1Error!", "Ingrese un valor de meta válida", "error");
            return true;
        }

        if ($scope.rango.meta < metaMinima) {
            swal("\u00a1Error!", "La ingresada no puede ser menor a " + metaMinima.toString() + '%', "error");
            return true;
        }

        if ($scope.rango.meta > 100) {
            swal("\u00a1Error!", "El valor máximo de la meta es 100%", "error");
            return true;
        }

    };

    $scope.add = function () {

        
        if (validarCamposRango()) {
            return;
        }
        

        rangoActivo = Object.assign({}, $scope.rango);
        rangoActivo.activo = true;
        

        var myFinaltDate = $scope.sustractMinutesFromDate(rangoActivo.arcoInferiorRecepcion, 1);
        var myStartDate = $scope.addMinutesFromDate(rangoActivo.arcoSuperiorRecepcion, 1);

        if ($scope.rangoList.length === 0) $scope.rangoMenor.arcoSuperiorRecepcion = myFinaltDate;

        angular.forEach($scope.rangoList, function (r) {
            r.activo = false;
        });

        
        $scope.rangoList.push(rangoActivo);        

        $scope.rangoMayor.arcoInferiorRecepcion = myStartDate;

        $scope.rango.arcoInferiorRecepcion = myStartDate;
        
        arcoSuperiorMinimo = myStartDate;

        metaMinima = rangoActivo.meta;

    };

    $scope.remove = function () {

        
        for (var i = 0; i < $scope.rangoList.length; i++) {
            if ($scope.rangoList[i].activo) {
                $scope.rangoList.splice(i, 1); // removes the matched element
                i = $scope.rangoList.length;  // break out of the loop. Not strictly necessary
            }
        }

        if ($scope.rangoList.length > 0) {

            $scope.rangoList[$scope.rangoList.length - 1].activo = true;
            var myStartDate = $scope.addMinutesFromDate($scope.rangoList[$scope.rangoList.length - 1].arcoSuperiorRecepcion, 1);
            $scope.rangoMayor.arcoInferiorRecepcion = myStartDate;
            $scope.rango.arcoInferiorRecepcion = myStartDate;
            arcoSuperiorMinimo = myStartDate;            
            metaMinima = $scope.rangoList[$scope.rangoList.length - 1].meta;            
        }
        else {
            
            $scope.rangoMenor.arcoSuperiorRecepcion = new Date(1970, 1, 1, 0, 1, 0, 0);
            $scope.rangoMayor.arcoInferiorRecepcion = new Date(1970, 1, 1, 0, 1, 0, 0);
            metaMinima = $scope.rangoMenor.meta;
            arcoSuperiorMinimo = new Date(1970, 0, 1, 0, 1, 0, 0);
        }

        

        
    };

    $scope.guardar = function () {

        if ($scope.isUndefinedOrNullOrEmpty($scope.tipoSeleccionado)) {
            swal("\u00a1Error!", "Seleccione el tipo de agencia", "error");
            return;
        }


        if ($scope.isUndefinedOrNullOrEmpty($scope.proveedorSeleccionado)) {
            swal("\u00a1Error!", "Seleccione un proveedor", "error");
            return;
        }

        if ($scope.rangoList.length === 0) {
            swal("\u00a1Error!", "Agregue un rango de recepción", "error");
            return;
        }

        var rangoAEnviar = [];


        var rMenor = {};

        rMenor.dArcoParcialInicial = $scope.rangoMenor.arcoInferiorRecepcion;
        rMenor.dArcoParcialFinal = $scope.rangoMenor.arcoSuperiorRecepcion;
        rMenor.iMeta = $scope.rangoMenor.meta;

        rangoAEnviar.push(rMenor);

        //rangoAEnviar.push($scope.rangoMenor);

        angular.forEach($scope.rangoList, function (value, key) {
            var r = {};
            r.dArcoParcialInicial = value.arcoInferiorRecepcion;
            r.dArcoParcialFinal = value.arcoSuperiorRecepcion;
            r.iMeta = value.meta;
            rangoAEnviar.push(r);
            //rangoAEnviar.push(value);
        });

        var rMayor = {};

        rMayor.dArcoParcialInicial = $scope.rangoMayor.arcoInferiorRecepcion;
        rMayor.dArcoParcialFinal = $scope.rangoMayor.arcoSuperiorRecepcion;
        rMayor.iMeta = $scope.rangoMayor.meta;

        rangoAEnviar.push(rMayor);

        //rangoAEnviar.push($scope.rangoMayor);

        var json = JSON.stringify(rangoAEnviar);

        ServiciosApi.RegistrarRangoRecepcion($scope.tipoSeleccionado.idTipoAgencia, $scope.proveedorSeleccionado.idProveedor, json).then(function (data) {

            if (data === 1) {
                swal("\u00a1Operaci\u00f3n existosa!", "Se ha registrado los nuevos rangos de recepción", "success");
                $scope.obtenerRangoRecepcionMantenimiento();
                $uibModalInstance.close();
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
