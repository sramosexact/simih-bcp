/*Controlador de la página MantenimientoAgencia.html*/
app.controller("MantenimientoAgenciaCtrl", [
  "$scope",
  "$rootScope",
  "$http",
  "ServiciosApi",
  "$uibModalInstance",
  "$filter",
  "$uibModal",
  function (
    $scope,
    $rootScope,
    $http,
    ServiciosApi,
    $uibModalInstance,
    $filter,
    $uibModal
  ) {
    $scope.setActive("vManAgencia");
    $scope.setActiveNavBar(true);

    $scope.tituloModal = "";

    $scope.deshabilitarDiasPlazoRecepcion = true;

    $scope.estadoList = [
      { idEstado: 1, estado: "ACTIVO" },
      { idEstado: 0, estado: "INACTIVO" },
    ];

    $scope.tipoAgenciaList = [
      { idTipoAgencia: 1, tipoAgencia: "LIMA" },
      { idTipoAgencia: 2, tipoAgencia: "PROVINCIA" },
    ];

    var op = false;

    var cargarDatos = function () {
      if ($scope.isUndefinedOrNullOrEmpty($scope.registroAgencia)) {
        op = true;
      }

      if (op) {
        $scope.tituloModal = "Registrar nueva agencia";
        $scope.disabled = false;
        $scope.deshabilitarDiasPlazoRecepcion = true;
        $scope.deshabilitarEliminar = true;

        $scope.estadoSeleccionado = {
          idEstado: 1,
          estado: "ACTIVO",
        };

        $scope.registro = {};

        $scope.registro.diasPlazoRecepcion = 0;
        $scope.registro.lunes = false;
        $scope.registro.martes = false;
        $scope.registro.miercoles = false;
        $scope.registro.jueves = false;
        $scope.registro.viernes = false;
        $scope.registro.sabado = false;

        $scope.registro.lunesE = false;
        $scope.registro.martesE = false;
        $scope.registro.miercolesE = false;
        $scope.registro.juevesE = false;
        $scope.registro.viernesE = false;
        $scope.registro.sabadoE = false;
      } else {
        $scope.tituloModal = "Modificar agencia";
        $scope.disabled = true;
        $scope.registro = Object.assign({}, $scope.registroAgencia);
        $scope.deshabilitarEliminar = false;

        if (!$scope.isUndefinedOrNullOrEmpty($scope.registro.arcoInferior)) {
          $scope.arcoInferior = new Date(
            "1970-01-01T" + $scope.registro.arcoInferior
          );
        }

        if (!$scope.isUndefinedOrNullOrEmpty($scope.registro.arcoSuperior)) {
          $scope.arcoSuperior = new Date(
            "1970-01-01T" + $scope.registro.arcoSuperior
          );
        }

        $scope.proveedorSeleccionado = {
          iIdProveedor: $scope.registro.iIdProveedor,
          sProveedor: $scope.registro.sProveedor,
        };

        $scope.tipoAgenciaSeleccionado = {
          idTipoAgencia: $scope.registro.idTipoAgencia,
          tipoAgencia: $scope.registro.tipoAgencia,
        };

        $scope.estadoSeleccionado = {
          idEstado: $scope.registro.idEstado,
          estado: $scope.registro.estado,
        };

        $scope.habilitarControlPorTipoAgencia();
      }
    };

    var listarProveedores = function () {
      ServiciosApi.ListarProveedor().then(
        function (data) {
          $scope.proveedorList = data;
          cargarDatos();
        },
        function (error) {
          swal(
            "\u00a1Error!",
            "Hubo un error : Por favor revise su conexi\u00f3n a internet",
            "error"
          );
        }
      );
    };

    var validarCampos = function () {
      if ($scope.isUndefinedOrNullOrEmpty($scope.registro.codigoAgencia)) {
        swal("\u00a1Error!", "Ingrese un código de agencia", "error");
        return true;
      }

      if ($scope.isUndefinedOrNullOrEmpty($scope.registro.agencia)) {
        swal("\u00a1Error!", "Ingrese una agencia", "error");
        return true;
      }

      if ($scope.isUndefinedOrNullOrEmpty($scope.proveedorSeleccionado)) {
        swal("\u00a1Error!", "Seleccione un proveedor de la lista", "error");
        return true;
      }

      if ($scope.isUndefinedOrNullOrEmpty($scope.tipoAgenciaSeleccionado)) {
        swal("\u00a1Error!", "Seleccione un tipo de agencia", "error");
        return true;
      }

      if ($scope.isUndefinedOrNullOrEmpty($scope.registro.diasPlazoRecepcion)) {
        swal(
          "\u00a1Error!",
          `El plazo de recepción debe estar entre ${$rootScope.diasPlazoRecepcionMin} y ${$rootScope.diasPlazoRecepcionMax} días`,
          "error"
        );
        return true;
      }

      if (
        $scope.registro.diasPlazoRecepcion < $rootScope.diasPlazoRecepcionMin ||
        $scope.registro.diasPlazoRecepcion > $rootScope.diasPlazoRecepcionMax
      ) {
        swal(
          "\u00a1Error!",
          `El plazo de recepción debe estar entre ${$rootScope.diasPlazoRecepcionMin} y ${$rootScope.diasPlazoRecepcionMax} días`,
          "error"
        );
        return true;
      }

      if ($scope.isUndefinedOrNullOrEmpty($scope.arcoInferior)) {
        swal(
          "\u00a1Error!",
          `El arco inferior de recojo no tiene una hora válida`,
          "error"
        );
        return true;
      }

      if ($scope.isUndefinedOrNullOrEmpty($scope.arcoSuperior)) {
        swal(
          "\u00a1Error!",
          `El arco superior de recojo no tiene una hora válida`,
          "error"
        );
        return true;
      }

      if ($scope.arcoInferior >= $scope.arcoSuperior) {
        swal(
          "\u00a1Error!",
          `El arco inferior debe ser menor al arco superior`,
          "error"
        );
        return true;
      }

      if (
        !$scope.registro.lunes &&
        !$scope.registro.martes &&
        !$scope.registro.miercoles &&
        !$scope.registro.jueves &&
        !$scope.registro.viernes &&
        !$scope.registro.sabado
      ) {
        swal(
          "\u00a1Error!",
          `La frecuencia de recojo debe tener seleccionado al menos un día`,
          "error"
        );
        return true;
      }

      if (
        !$scope.registro.lunesE &&
        !$scope.registro.martesE &&
        !$scope.registro.miercolesE &&
        !$scope.registro.juevesE &&
        !$scope.registro.viernesE &&
        !$scope.registro.sabadoE
      ) {
        swal(
          "\u00a1Error!",
          `La frecuencia de envío debe tener seleccionado al menos un día`,
          "error"
        );
        return true;
      }
    };

    $scope.habilitarControlPorTipoAgencia = function () {
      if ($scope.tipoAgenciaSeleccionado.idTipoAgencia === 1) {
        $scope.registro.diasPlazoRecepcion = 0;
        $scope.deshabilitarDiasPlazoRecepcion = true;
      } else {
        $scope.deshabilitarDiasPlazoRecepcion = false;
      }
    };

    $scope.guardar = function () {
      if (validarCampos()) {
        return;
      }

      var agencia = {};

      agencia.codigoAgencia = $scope.registro.codigoAgencia;
      agencia.agencia = $scope.registro.agencia;
      agencia.idProveedor = $scope.proveedorSeleccionado.iIdProveedor;
      agencia.idTipoAgencia = $scope.tipoAgenciaSeleccionado.idTipoAgencia;
      agencia.diasPlazoRecepcion = $scope.registro.diasPlazoRecepcion;
      agencia.arcoInferiorRecojo = $scope.arcoInferior;
      agencia.arcoSuperiorRecojo = $scope.arcoSuperior;

      agencia.frecuenciaRecojoLunes = $scope.registro.lunes;
      agencia.frecuenciaRecojoMartes = $scope.registro.martes;
      agencia.frecuenciaRecojoMiercoles = $scope.registro.miercoles;
      agencia.frecuenciaRecojoJueves = $scope.registro.jueves;
      agencia.frecuenciaRecojoViernes = $scope.registro.viernes;
      agencia.frecuenciaRecojoSabado = $scope.registro.sabado;

      agencia.frecuenciaEnvioLunes = $scope.registro.lunesE;
      agencia.frecuenciaEnvioMartes = $scope.registro.martesE;
      agencia.frecuenciaEnvioMiercoles = $scope.registro.miercolesE;
      agencia.frecuenciaEnvioJueves = $scope.registro.juevesE;
      agencia.frecuenciaEnvioViernes = $scope.registro.viernesE;
      agencia.frecuenciaEnvioSabado = $scope.registro.sabadoE;

      agencia.idEstado = $scope.estadoSeleccionado.idEstado;

      if (op) {
        ServiciosApi.RegistrarNuevaAgencia(agencia).then(
          function (data) {
            if (data === 1) {
              swal(
                "\u00a1Operaci\u00f3n existosa!",
                "Se registró la nueva agencia",
                "success"
              );
              $rootScope.obtenerAgenciasMantenimiento();
              $uibModalInstance.close();
            } else if (data === -1) {
              swal("\u00a1Error!", "El código de agencia ya existe", "error");
            } else if (data === -2) {
              swal(
                "\u00a1Error!",
                "El nombre de la agencia ya existe",
                "error"
              );
            } else if (data === -3) {
              swal("\u00a1Error!", "El código de proveedor no existe", "error");
            } else if (data === -4) {
              swal("\u00a1Error!", "El tipo de agencia no existe", "error");
            } else if (data === -5) {
              swal(
                "\u00a1Error!",
                "El arco inferior debe ser menor que el arco superior",
                "error"
              );
            } else if (data === -6) {
              swal(
                "\u00a1Error!",
                "La frecuencia de recojo debe tener al menos un día asignado",
                "error"
              );
            } else if (data === -7) {
              swal(
                "\u00a1Error!",
                "La frecuencia de recojo debe tener al menos un día asignado",
                "error"
              );
            } else {
              swal(
                "\u00a1Error!",
                "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde.",
                "error"
              );
            }
          },
          function (error) {
            swal(
              "\u00a1Error!",
              "Hubo un error : Por favor revise su conexi\u00f3n a internet",
              "error"
            );
            console.error(error);
          }
        );
      } else {
        ServiciosApi.ModificarAgencia(agencia).then(
          function (data) {
            if (data === 1) {
              swal(
                "\u00a1Operaci\u00f3n existosa!",
                "Se ha modificado los datos de la agencia",
                "success"
              );
              $rootScope.obtenerAgenciasMantenimiento();
              $uibModalInstance.close();
            } else if (data === -1) {
              swal("\u00a1Error!", "El código de agencia no existe", "success");
            } else if (data === -2) {
              swal(
                "\u00a1Error!",
                "El código de proveedor no existe",
                "success"
              );
            } else if (data === -3) {
              swal("\u00a1Error!", "El tipo de agencia no existe", "success");
            } else if (data === -4) {
              swal(
                "\u00a1Error!",
                "El arco inferior debe ser menor que el arco superior",
                "success"
              );
            } else if (data === -5) {
              swal(
                "\u00a1Error!",
                "La frecuencia de recojo debe tener al menos un día asignado",
                "success"
              );
            } else if (data === -6) {
              swal(
                "\u00a1Error!",
                "La frecuencia de envío debe tener al menos un día asignado",
                "success"
              );
            } else {
              swal(
                "\u00a1Error!",
                "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde.",
                "error"
              );
            }
          },
          function (error) {
            swal(
              "Error",
              "Hubo un error : Por favor revise su conexi\u00f3n a internet",
              "error"
            );
            console.error(error);
          }
        );
      }
    };

    $scope.eliminar = function () {
      swal(
        {
          title: "¿Estás seguro?",
          text: "Se eliminará la agencia seleccionada. ¿Desea continuar?",
          type: "warning",
          showCancelButton: true,
          confirmButtonClass: "btn-danger",
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
          closeOnConfirm: false,
          closeOnCancel: true,
        },
        function (isConfirm) {
          if (isConfirm) {
            var agencia = {};

            agencia.codigoAgencia = $scope.registro.codigoAgencia;

            ServiciosApi.EliminarAgencia(agencia).then(
              function (data) {
                if (data === 1) {
                  swal(
                    "\u00a1Operaci\u00f3n existosa!",
                    "Se eliminó la agencia",
                    "success"
                  );
                  $rootScope.obtenerAgenciasMantenimiento();
                  $uibModalInstance.close();
                } else if (data === -1) {
                  swal(
                    "\u00a1Error!",
                    "El código de agencia no existe",
                    "error"
                  );
                } else if (data === -2) {
                  swal(
                    "\u00a1Error!",
                    "No se puede eliminar porque existen registros históricos",
                    "error"
                  );
                } else {
                  swal(
                    "\u00a1Error!",
                    "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde.",
                    "error"
                  );
                }
              },
              function (error) {
                swal(
                  "\u00a1Error!",
                  "Hubo un error : Por favor revise su conexi\u00f3n a internet",
                  "error"
                );
                console.error(error);
              }
            );
          }
        }
      );
    };

    $scope.cancel = function () {
      $uibModalInstance.dismiss("cancelar");
    };

    listarProveedores();
  },
]);