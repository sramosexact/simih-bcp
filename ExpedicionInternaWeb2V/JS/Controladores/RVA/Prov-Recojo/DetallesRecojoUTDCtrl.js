app.controller("DetallesRecojoUTDCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "$routeParams",
  "TIPO",
  "$window",
  function ($scope, $rootScope, ServiciosApi, $routeParams, TIPO, $window) {
    const tipoRegistro = TIPO.TIPO_REGISTRO.ENVIO;
    const idAgenciaTraslado = $routeParams.id;

    $scope.camposDinamicos = [];
    $scope.setActive("vRecojo");
    $scope.setActiveNavBar(true);
    $scope.sObservacionProveedor = "";
    $scope.btnAtrasCancelar = "";

    const getAgenciaSelec = () => {
      return ServiciosApi.getAgenciaPorEnviar(idAgenciaTraslado)
        .then((data) => {
          $scope.agencia = data[0];
          $scope.sObservacionProveedor =
            $scope.agencia.sObservacionProveedor ?? "";
          $scope.txtObsProvDisabled =
            $scope.agencia.sObservacionProveedor !== null;
          $scope.btnGuardarEditar = $scope.txtObsProvDisabled
            ? "Editar"
            : "Guardar";
          $scope.btnAtrasCancelar = "Atras";
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener los detalles de env\u00edo de la agencia seleccionada"
          );
        });
    };

    const getCamposDinamicos = () => {
      return ServiciosApi.listarCamposDinamicos(tipoRegistro)
        .then((data) => {
          $scope.camposDinamicos = [...data];
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener los campos para las agencias"
          );
        });
    };

    const obtenerDetallesValija = () => {
      $scope.camposDinamicos.forEach((campo) => {
        var nombreCampo = campo.campo;

        if ($scope.agencia.hasOwnProperty(nombreCampo)) {
          campo.valor = $scope.agencia[nombreCampo];
        }
      });
    };

    Promise.all([getAgenciaSelec(), getCamposDinamicos()])
      .then(() => {
        obtenerDetallesValija();
      })
      .catch(() => {
        $rootScope.mostrarError(
          "Error",
          "Hubo un problema al obtener los datos. Int\u00e9ntelo m\u00e1s tarde."
        );
      });

    $scope.irAtrasOCancelar = () => {
      if (
        !$scope.txtObsProvDisabled &&
        $scope.sObservacionProveedor.length > 0
      ) {
        $scope.btnGuardarEditar = "Editar";
        $scope.btnAtrasCancelar = "Atras";
        $scope.txtObsProvDisabled = true;
        $scope.sObservacionProveedor = $scope.agencia.sObservacionProveedor;
      } else {
        $window.history.back();
      }
    };

    $scope.modalGuardarObs = () => {
      if ($scope.txtObsProvDisabled) {
        $scope.btnGuardarEditar = "Guardar";
        $scope.btnAtrasCancelar = "Cancelar";
        $scope.txtObsProvDisabled = false;
      } else {
        swal(
          {
            title: "Registrar Observaci\u00f3n",
            text: "\u00bfEst\u00e1s seguro de registrar la observaci\u00f3n?",
            type: "info",
            showCancelButton: true,
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
          }).then(
          (isConfirm) => {
            if (isConfirm) {
              confirmacionObsProve();
            }
          }
        );
      }
    };

    const registrarObsProve = () => {
      $scope.sObservacionProveedor = (
        $scope.sObservacionProveedor ?? ""
      ).trim();
      return ServiciosApi.guardarObsRecojoUTD(
        idAgenciaTraslado,
        $scope.sObservacionProveedor
      );
    };

    const confirmacionObsProve = () => {
      registrarObsProve()
        .then((data) => {
          if (data === 1) {
            obtenerDatos();
            $rootScope.mostrarSuccess("Observaci\u00f3n Registrada", "");
          } else if (data === 0) {
            $rootScope.mostrarError(
              "Error",
              "No se pudo guardar su observación. Int\u00e9ntelo m\u00e1s tarde."
            );
          }
        })
        .catch(() => {
          //
        });
    };
  },
]);