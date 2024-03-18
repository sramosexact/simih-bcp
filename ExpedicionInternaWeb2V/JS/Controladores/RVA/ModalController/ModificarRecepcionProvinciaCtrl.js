/*Controlador del modal para la modificación*/
app.controller('ModificarRecepcionProvinciaCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$uibModalInstance', '$filter',
    function ($scope, $rootScope, $http, ServiciosApi, $uibModalInstance, $filter) {

        /*Variables*/
        $scope.tituloModificacion = 'Modificar datos del traslado';
        $scope.nombreBotonModificar = 'Modificar';
        var RegistroOriginal = {};
        var fechaRegistroOriginal = '';
        var horaRegistroOriginal = '';
        var fechaRecepcionOriginal = '';
        var horaRecepcionOriginal = '';
        $scope.AgenciaSeleccionada = Object.assign({}, $scope.ag); 
        RegistroOriginal = Object.assign({}, $scope.AgenciaSeleccionada);
        $scope.CamposDinamicos = $scope.camposDinamicos;
        $scope.TipoAgencia = $scope.tipoAgencia;
        $scope.deshabilitarTipoAgencia = false;

        if ($scope.TipoAgencia === 1) {
            $scope.deshabilitarTipoAgencia = true;
        }
        else {
            $scope.deshabilitarTipoAgencia = false;
        }
        if ($scope.isUndefinedOrNullOrEmpty($scope.AgenciaSeleccionada.dFechaRegistro)) {
            $scope.fechaRegistro = '';
            $scope.horasVisita = '';
            $scope.minutosVisita = '';
            $scope.horaMinutoRegistro = '';
            fechaRegistroOriginal = '';
            horaRegistroOriginal = '';
        }
        else {
            $scope.fechaRegistro = new Date($scope.AgenciaSeleccionada.dFechaRegistro);
            $scope.fechaRegistro.setTime($scope.fechaRegistro.getTime());
            $scope.horasVisita = $scope.fechaRegistro.getHours();
            $scope.minutosVisita = $scope.fechaRegistro.getMinutes();
            $scope.horaMinutoRegistro = new Date(1970, 0, 1, $scope.horasVisita, $scope.minutosVisita, 0);
            fechaRegistroOriginal = new Date($scope.AgenciaSeleccionada.dFechaRegistro);
            fechaRegistroOriginal.setTime(fechaRegistroOriginal.getTime());
            horaRegistroOriginal = new Date(1970, 0, 1, $scope.horasVisita, $scope.minutosVisita, 0);
        }
        if ($scope.isUndefinedOrNullOrEmpty($scope.AgenciaSeleccionada.dFechaRecepcion)) {
            $scope.fechaRecepcion = '';
            $scope.horasRecepcion = '';
            $scope.minutosRecepcion = '';
            $scope.horaMinutoRecepcion = '';
            fechaRecepcionOriginal = '';
            horaRecepcionOriginal = '';
        }
        else {
            $scope.fechaRecepcion = new Date($scope.AgenciaSeleccionada.dFechaRecepcion);
            $scope.fechaRecepcion.setTime($scope.fechaRecepcion.getTime());
            $scope.horasRecepcion = $scope.fechaRecepcion.getHours();
            $scope.minutosRecepcion = $scope.fechaRecepcion.getMinutes();
            $scope.horaMinutoRecepcion = new Date(1970, 0, 1, $scope.horasRecepcion, $scope.minutosRecepcion, 0);
            fechaRecepcionOriginal = new Date($scope.AgenciaSeleccionada.dFechaRecepcion);
            fechaRecepcionOriginal.setTime(fechaRecepcionOriginal.getTime());
            horaRecepcionOriginal = new Date(1970, 0, 1, $scope.horasRecepcion, $scope.minutosRecepcion, 0);
        }

        $scope.fechaRegistro = $filter('date')($scope.fechaRegistro, "dd-MM-yyyy");
        $scope.fechaRecepcion = $filter('date')($scope.fechaRecepcion, "dd-MM-yyyy");
        fechaRegistroOriginal = $filter('date')(fechaRegistroOriginal, "dd-MM-yyyy");
        fechaRecepcionOriginal = $filter('date')(fechaRecepcionOriginal, "dd-MM-yyyy");

        /*Función para modificar el registro*/
        $scope.guardarCambios = function () {

            var fechaActual = new Date();
            var usuarioModificacion = $rootScope.Usuario.Id;
            var registroModificado = {};
            var registrosDinamicoModificado = [];
            var fechaRegistroVacio = true;
            var horaRegistroVacio = true;
            var fechaRecepcionVacio = true;
            var horaRecepcionVacio = true;
            var registroYearValue = '';
            var registroMonthValue = '';
            var registroDayValue = '';
            var registroHourValue = '';
            var registroMinuteValue = '';
            var dRegistro = '';
            var recepcionYearValue = '';
            var recepcionMonthValue = '';
            var recepcionDayValue = '';
            var recepcionHourValue = '';
            var recepcionMinuteValue = '';
            var dRecepcion = '';
            var camposDinamicosSinModificar = false;
            fechaRegistroVacio = $scope.isUndefinedOrNullOrEmpty($scope.fechaRegistro);
            horaRegistroVacio = $scope.isUndefinedOrNullOrEmpty($scope.horaMinutoRegistro);

            if (fechaRegistroVacio) {
                swal("\u00a1Error!", "Por favor, seleccione la fecha de recojo.", "error");
                return;
            }

            if (horaRegistroVacio) {
                swal("\u00a1Error!", "Por favor, ingrese la hora de recojo.", "error");
                return;
            }

            registroYearValue = $scope.fechaRegistro.split('-')[2];
            registroMonthValue = $scope.fechaRegistro.split('-')[1];
            registroDayValue = $scope.fechaRegistro.split('-')[0];
            registroHourValue = $scope.horaMinutoRegistro.getHours();
            registroMinuteValue = $scope.horaMinutoRegistro.getMinutes();
            dRegistro = new Date(registroYearValue, registroMonthValue - 1, registroDayValue, registroHourValue, registroMinuteValue, 0);
            fechaRecepcionVacio = $scope.isUndefinedOrNullOrEmpty($scope.fechaRecepcion);
            horaRecepcionVacio = $scope.isUndefinedOrNullOrEmpty($scope.horaMinutoRecepcion);

            if (dRegistro > fechaActual) {
                swal("\u00a1Error!", "La fecha y hora de recojo no puede ser mayor que la actual.", "error");
                return;
            }
            
            if ($scope.AgenciaSeleccionada.iIdEstado === 1) {
                // PENDIENTE = 1
                if (!fechaRecepcionVacio && !horaRecepcionVacio) {
                    recepcionYearValue = $scope.fechaRecepcion.split('-')[2];
                    recepcionMonthValue = $scope.fechaRecepcion.split('-')[1];
                    recepcionDayValue = $scope.fechaRecepcion.split('-')[0];
                    recepcionHourValue = $scope.horaMinutoRecepcion.getHours();
                    recepcionMinuteValue = $scope.horaMinutoRecepcion.getMinutes();
                    dRecepcion = new Date(recepcionYearValue, recepcionMonthValue - 1, recepcionDayValue, recepcionHourValue, recepcionMinuteValue, 0);
                    if (dRecepcion > fechaActual) {
                        swal("\u00a1Error!", "La fecha y hora de recepci\u00f3n no puede ser mayor que la actual.", "error");
                        return;
                    }
                    if (dRegistro > dRecepcion) {
                        swal("\u00a1Error!", "La fecha y hora de visita no puede ser mayor que la de recepci\u00f3n de las valijas.", "error");
                        return;
                    }
                }
                else if (fechaRecepcionVacio !== horaRecepcionVacio) {
                    swal("\u00a1Error!", "Debes ingresar fecha y hora de recepción a la vez", "error");
                    return;
                }
                registroModificado.iIdEstado = 2;
            }
            else if ($scope.AgenciaSeleccionada.iIdEstado === 2) {
                // ENVIADO = 2
                if (!fechaRecepcionVacio && !horaRecepcionVacio) {
                    recepcionYearValue = $scope.fechaRecepcion.split('-')[2];
                    recepcionMonthValue = $scope.fechaRecepcion.split('-')[1];
                    recepcionDayValue = $scope.fechaRecepcion.split('-')[0];
                    recepcionHourValue = $scope.horaMinutoRecepcion.getHours();
                    recepcionMinuteValue = $scope.horaMinutoRecepcion.getMinutes();
                    dRecepcion = new Date(recepcionYearValue, recepcionMonthValue - 1, recepcionDayValue, recepcionHourValue, recepcionMinuteValue, 0);

                    if (dRecepcion > fechaActual) {
                        swal("\u00a1Error!", "La fecha y hora de recepci\u00f3n no puede ser mayor que la actual.", "error");
                        return;
                    }
                    if (dRegistro > dRecepcion) {
                        swal("\u00a1Error!", "La fecha y hora de visita no puede ser mayor que la de recepci\u00f3n de las valijas.", "error");
                        return;
                    }
                    registroModificado.iIdEstado = 3;
                }
                else if (fechaRecepcionVacio !== horaRecepcionVacio) {
                    swal("\u00a1Error!", "Debes ingresar fecha y hora de recepción a la vez", "error");
                    return;
                }
                else {
                    registroModificado.iIdEstado = 2;
                }
            }
            else if ($scope.AgenciaSeleccionada.iIdEstado === 3) {
                // RECEPCIONADO = 3
                recepcionYearValue = $scope.fechaRecepcion.split('-')[2];
                recepcionMonthValue = $scope.fechaRecepcion.split('-')[1];
                recepcionDayValue = $scope.fechaRecepcion.split('-')[0];
                recepcionHourValue = $scope.horaMinutoRecepcion.getHours();
                recepcionMinuteValue = $scope.horaMinutoRecepcion.getMinutes();
                dRecepcion = new Date(recepcionYearValue, recepcionMonthValue - 1, recepcionDayValue, recepcionHourValue, recepcionMinuteValue, 0);

                if (dRecepcion > fechaActual) {
                    swal("\u00a1Error!", "La fecha y hora de recepci\u00f3n no puede ser mayor que la actual.", "error");
                    return;
                }

                if (dRegistro > dRecepcion) {
                    swal("\u00a1Error!", "La fecha y hora de visita no puede ser mayor que la de recepci\u00f3n de las valijas.", "error");
                    return;
                }

                registroModificado.iIdEstado = 3;     
            }          

            if (registroModificado.iIdEstado === 3) {
                registroModificado.dFechaRecepcion = $filter('date')(new Date(dRecepcion), 'yyyy-MM-ddTHH:mm:ss');
            }
            else {
                registroModificado.dFechaRecepcion = null;
            }

            registroModificado.iId = $scope.AgenciaSeleccionada.iId;
            registroModificado.sIdAgencia = $scope.AgenciaSeleccionada.sIdAgencia;
            registroModificado.dFechaRegistro = $filter('date')(new Date(dRegistro), 'yyyy-MM-ddTHH:mm:ss');
            registroModificado.sObservacion = $scope.AgenciaSeleccionada.sObservacion;
            registroModificado.sIdUsuarioRegistro = $rootScope.Usuario.Id,
            registroModificado.sIdUsuarioRecepcion = $rootScope.Usuario.Id,

            angular.forEach($scope.CamposDinamicos, function (value, key) {
                var item = {};                
                registrosDinamicoModificado.push({ campo: value.campo, descripcion: $scope.AgenciaSeleccionada[value.campo]});
            });           

            jsonRegistroModificado = JSON.stringify(registroModificado);
            jsonRegistrosDinamicosModificados = JSON.stringify(registrosDinamicoModificado);

            ServiciosApi.setModificarRecojoRecepcion(usuarioModificacion, jsonRegistroModificado, jsonRegistrosDinamicosModificados).then(function (data) {
                if (data[0].ERROR === 1) {
                    swal("\u00a1Recojo Modificado !", "Se ha modificado los datos del recojo correctamente.", "success");
                    $rootScope.ObtenerAgencias();
                } else {
                    swal("Error", "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde.", "error");
                }

            }, function (error) {
                swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet.", "error");
            });

            $uibModalInstance.close();
        };

        /*Función para cancelar la modificación*/
        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancelar');
        };
    }]);
