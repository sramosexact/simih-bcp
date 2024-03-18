/*Controlador del modal para la modificación*/
app.controller("ModificarRegistroEnvioLimaCtrl", [
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
    $scope.tituloModificacion = "Modificar datos del envío";
    $scope.nombreBotonModificar = "Modificar";
    $scope.AgenciaSeleccionada = Object.assign({}, $scope.ag);
    $scope.CamposDinamicos = $scope.camposDinamicos;

    if (
      $scope.AgenciaSeleccionada.iIdEstado ===
      ESTADOS.ESTADOS_VALIJA.PENDIENTE_E
    ) {
      $scope.tituloModificacion = "Registrar datos del envío";
      $scope.nombreBotonModificar = "Registrar";
    }

    if (
      $scope.isUndefinedOrNullOrEmpty($scope.AgenciaSeleccionada.dFechaEnvio)
    ) {
      $scope.horaMinutoEnvio = "";
    } else {
      var horaEnvio = $filter("date")(
        $scope.AgenciaSeleccionada.dFechaEnvio,
        "HH"
      );
      var minutoEnvio = $filter("date")(
        $scope.AgenciaSeleccionada.dFechaEnvio,
        "mm"
      );

      $scope.horaMinutoEnvio = new Date(1970, 0, 1, horaEnvio, minutoEnvio, 0);
    }

    if (
      $scope.isUndefinedOrNullOrEmpty($scope.AgenciaSeleccionada.dFechaEntrega)
    ) {
      $scope.horaMinutoEntrega = "";
    } else {
      var horaEntrega = $filter("date")(
        $scope.AgenciaSeleccionada.dFechaEntrega,
        "HH"
      );
      var minutoEntrega = $filter("date")(
        $scope.AgenciaSeleccionada.dFechaEntrega,
        "mm"
      );

      $scope.horaMinutoEntrega = new Date(
        1970,
        0,
        1,
        horaEntrega,
        minutoEntrega,
        0
      );
    }

    /*Función para modificar el registro*/
    $scope.guardarCambios = () => {
      var fechaHoraActual = new Date();
      var fechaActual = $filter("date")(fechaHoraActual, "yyyy-MM-dd");

      if ($scope.horaMinutoEnvio != "") {
        var horaEnvio = $filter("date")($scope.horaMinutoEnvio, "HH:mm:00");
        $scope.AgenciaSeleccionada.dFechaEnvio = new Date(
          `${fechaActual}T${horaEnvio}`
        );
      }

      if ($scope.horaMinutoEntrega != "") {
        var horaEntrega = $filter("date")($scope.horaMinutoEntrega, "HH:mm:00");
        $scope.AgenciaSeleccionada.dFechaEntrega = new Date(
          `${fechaActual}T${horaEntrega}`
        );
      }

      var usuarioModificacion = $rootScope.Usuario.Id;
      var registroModificado = {};
      var registrosDinamicoModificado = [];
      var jsonRegistroModificado;
      var jsonRegistrosDinamicosModificados;

      registroModificado.sIdUsuarioEnvio =
        $scope.AgenciaSeleccionada.iIdUsuarioEnvio;
      registroModificado.dFechaEnvio = $scope.AgenciaSeleccionada.dFechaEnvio;
      registroModificado.sIdUsuarioEntrega =
        $scope.AgenciaSeleccionada.iIdUsuarioEntrega;
      registroModificado.dFechaEntrega =
        $scope.AgenciaSeleccionada.dFechaEntrega;
      registroModificado.iIdEstado = $scope.AgenciaSeleccionada.iIdEstado;

      if ($scope.AgenciaSeleccionada.dFechaEntrega !== null) {
        var result = compararFechas(
          $scope.AgenciaSeleccionada.dFechaEntrega,
          fechaHoraActual
        );
        if (result === -1) {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "La hora de entrega no puede ser mayor que la actual."
          );
          return;
        }

        if ($scope.AgenciaSeleccionada.dFechaEnvio === null) {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "No puede haber hora de entrega sin establecer una hora de envío."
          );
          return;
        } else {
          var result = compararFechas(
            $scope.AgenciaSeleccionada.dFechaEnvio,
            $scope.AgenciaSeleccionada.dFechaEntrega
          );

          if (result === -1 || result === 0) {
            $rootScope.mostrarError(
              "\u00a1Error!",
              "La hora de entrega debe ser mayor que la hora de envío de las valijas."
            );
            return;
          } else if (result === 1) {
            registroModificado.sIdUsuarioEnvio = $rootScope.Usuario.Id;
            registroModificado.dFechaEnvio = $filter("date")(
              new Date($scope.AgenciaSeleccionada.dFechaEnvio),
              "yyyy-MM-ddTHH:mm:ss"
            );
            registroModificado.sIdUsuarioEntrega =
              $rootScope.Usuario.Id;
            registroModificado.dFechaEntrega = $filter("date")(
              new Date($scope.AgenciaSeleccionada.dFechaEntrega),
              "yyyy-MM-ddTHH:mm:ss"
            );
            registroModificado.iIdEstado =
              ESTADOS.ESTADOS_VALIJA.RECEPCIONADO_AGENCIA;
          }
        }
      } else {
        if ($scope.AgenciaSeleccionada.dFechaEnvio !== null) {
          registroModificado.iIdEstado =
            ESTADOS.ESTADOS_VALIJA.ENVIADO_AGENCIA;
          if (
            $scope.AgenciaSeleccionada.iIdUsuarioEnvio !==
            $rootScope.Usuario.Id
          ) {
            registroModificado.sIdUsuarioEnvio = $rootScope.Usuario.Id;
          }
          registroModificado.dFechaEnvio = $filter("date")(
            new Date($scope.AgenciaSeleccionada.dFechaEnvio),
            "yyyy-MM-ddTHH:mm:ss"
          );
        }
      }

      registroModificado.iId = $scope.AgenciaSeleccionada.iId;
      registroModificado.sIdAgencia = $scope.AgenciaSeleccionada.sIdAgencia;
      registroModificado.sObservacion =
        $scope.AgenciaSeleccionada.sObservacion ?? "";

      $scope.CamposDinamicos.forEach((value) => {
        registrosDinamicoModificado.push({
          campo: value.campo,
          descripcion: $scope.AgenciaSeleccionada[value.campo],
        });
      });

      jsonRegistroModificado = JSON.stringify(registroModificado);
      jsonRegistrosDinamicosModificados = JSON.stringify(
        registrosDinamicoModificado
      );

      ServiciosApi.setModificarEnvioRecepcion(
        usuarioModificacion,
        jsonRegistroModificado,
        jsonRegistrosDinamicosModificados
      )
        .then(function (data) {
          if (data === 1) {
            $rootScope.mostrarSuccess(
              "\u00a1Valija Modificado !",
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

    /*Función para cancelar la modificación*/
    $scope.cancel = function () {
      $uibModalInstance.dismiss("cancelar");
    };
  },
]);