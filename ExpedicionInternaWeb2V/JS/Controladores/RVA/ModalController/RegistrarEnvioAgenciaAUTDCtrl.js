/*Controlador del modal para la modificación*/
app.controller("RegistrarEnvioAgenciaAUTDCtrl", [
    "$scope",
    "$rootScope",
    "ServiciosApi",
    "$uibModalInstance",
    "$filter",
    "ESTADOS",
    function (
        $scope,
        $rootScope,
        ServiciosApi,
        $uibModalInstance,
        $filter,
        ESTADOS
    ) {        
        $scope.tituloModificacion = "Registrar datos del envío";
        $scope.nombreBotonModificar = "Registrar";        
        
        $scope.AgenciaSeleccionada = Object.assign({}, $scope.ag);        
        console.log($scope.AgenciaSeleccionada);
        //$scope.CamposDinamicos = $scope.camposDinamicos;

        $scope.camposDinamicos.forEach(function (campo) {
            if (campo.tipoCampo === 3 && ($scope.AgenciaSeleccionada[campo.campo] === '0' || $scope.AgenciaSeleccionada[campo.campo] === undefined)) {
                $scope.AgenciaSeleccionada[campo.campo] = '0'; // Inicializar como '0' (no marcado)
            }
            else {
                $scope.AgenciaSeleccionada[campo.campo] = '1';
            }
        });

        if ( $scope.AgenciaSeleccionada.iIdEstado !== ESTADOS.ESTADOS_VALIJA.PENDIENTE_R) {
            $uibModalInstance.close();
        }        

        /*Función para modificar el registro*/
        $scope.guardarCambios = () => {            
            
            var registroModificado = {};
            var registrosDinamicoModificado = [];            
            var jsonRegistrosDinamicosModificados;                  

            registroModificado.iId = $scope.AgenciaSeleccionada.iId;

            angular.forEach($scope.camposDinamicos, function (value, key) {
                var item = {};
                registrosDinamicoModificado.push({
                    campo: value.campo,
                    descripcion: $scope.AgenciaSeleccionada[value.campo]
                });
            });
                        
            jsonRegistrosDinamicosModificados = JSON.stringify( registrosDinamicoModificado );

            ServiciosApi.RegistrarAgenciaEnvioAUTD(
                registroModificado.iId,
                jsonRegistrosDinamicosModificados
            )
                .then(function (data) {
                    if (data === 1) {
                        $rootScope.mostrarSuccess(
                            "\u00a1Valija Enviada !",
                            "Se ha modificado los datos de la valija correctamente."
                        );
                    } else {
                        $rootScope.mostrarError(
                            "Error",
                            "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde."
                        );
                    }
                })
                .catch(() => {
                    $rootScope.mostrarError(
                        "Error",
                        "Hubo un error : Por favor revise su conexi\u00f3n a internet."
                    );
                });

            $uibModalInstance.close();
        };

        const compararFechas = (fecha1, fecha2) => {
            var date1 = new Date(fecha1);
            var date2 = new Date(fecha2);

            var time1 = date1.getTime();
            var time2 = date2.getTime();

            if (time1 > time2) {
                return -1;
            } else if (time1 < time2) {
                return 1;
            } else {
                return 0;
            }
        };


        $scope.cambioCheckbox = function () {
            console.log($scope.modelo[campo.campo]); // Esto debería mostrar '1' o '0'
        };

        /*Función para cancelar la modificación*/
        $scope.cancel = function () {
            $uibModalInstance.dismiss("cancelar");
        };
    },
]);