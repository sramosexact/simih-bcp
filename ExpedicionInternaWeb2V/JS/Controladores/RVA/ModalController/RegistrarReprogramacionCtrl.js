app.controller("RegistrarReprogramacionCtrl", [
  "$scope",
  "$rootScope",
  "$uibModalInstance",
  "ServiciosApi",
  "TIPO",
  "ESTADOS",
  function ($scope, $rootScope, $uibModalInstance, ServiciosApi, TIPO, ESTADOS) {
    /***************************
    Variables Incializadas
    ****************************/
    $scope.EstadosValija = ESTADOS.ESTADOS_VALIJA;
    $scope.motivos = [];
    var dFechaActual = new Date();
    $scope.incidenciaNoHuboRecojo = {};

    $scope.zeroFill = function (number, width) {
      var numberOutput = Math.abs(number); /* Valor absoluto del número */
      var length = number.toString().length; /* Largo del número */
      var zero = "0"; /* String de cero */

      if (width <= length) {
        if (number < 0) {
          return "-" + numberOutput.toString();
        } else {
          return numberOutput.toString();
        }
      } else {
        if (number < 0) {
          return "-" + zero.repeat(width - length) + numberOutput.toString();
        } else {
          return zero.repeat(width - length) + numberOutput.toString();
        }
      }
    };

    $scope.horasInicio = dFechaActual.getHours();
    $scope.minutosInicio = dFechaActual.getMinutes();

    $scope.horasRecojo = dFechaActual.getHours() + 1;
    $scope.minutosRecojo = dFechaActual.getMinutes();

    var arcoInf =
      $scope.zeroFill($scope.horasInicio.toString(), 2) +
      ":" +
      $scope.zeroFill($scope.minutosInicio.toString(), 2);
    var arcoSup =
      $scope.zeroFill($scope.horasRecojo.toString(), 2) +
      ":" +
      $scope.zeroFill($scope.minutosRecojo.toString(), 2);

    $scope.arcoInferior = new Date("1970-01-01T" + arcoInf);
    $scope.arcoSuperior = new Date("1970-01-01T" + arcoSup);

    /*********************
    Metodos
    **********************/
    ListarMotivos = function () {
      ServiciosApi.getListarMotivos(TIPO.TIPO_MOTIVO.REPROGRAMACION).then(
        function (data) {
          $scope.motivos = data;
        },
        function (error) {
          console.error(error);
        }
      );
    };

    function obtenerIncidenciaTipoNoHuboRecojo() {
      ServiciosApi.ObtenerIncidenciaSegunTipo(
        $rootScope.AgenciaParaRegistrarReprogramacion.iId,
        TIPO.TIPO_MOTIVO.NOHUBORECOJO
      )
        .then((resp) => {
          if (resp.length > 0) $scope.incidenciaNoHuboRecojo = resp[0];
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener algunos detalles del registro."
          );
        });
    }

    obtenerIncidenciaTipoNoHuboRecojo();

    RegistrarReprogramacion = function (
      idAgenciaTraslado,
      dFechaInicial,
      dFechaFinal,
      iMotivo
    ) {
      ServiciosApi.setRegistrarReprogramacion(
        idAgenciaTraslado,
        dFechaInicial,
        dFechaFinal,
        iMotivo
      ).then(
        function (data) {
          if (data > 0) {
            swal(
              "\u00a1Traslado Reprogramado!",
              "Se ha registrado la reprogramacion de la agencia " +
              $rootScope.AgenciaParaRegistrarReprogramacion.sIdAgencia +
              ".",
              "success"
            );
            $rootScope.ObtenerAgencias();
          } else {
            swal(
              "Error",
              "Hubo un error en la base de datos, contactese con su proveedor de servicios",
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
        }
      );
    };

    $scope.ok = function () {
      fechaInicio = new Date();
      fechaRecojo = new Date();
      if (
        $scope.arcoInferior === undefined ||
        $scope.arcoSuperior === undefined ||
        $scope.motivoReprogramacion === undefined
      ) {
        //($scope.horasInicio === undefined || $scope.horasRecojo === undefined || $scope.minutosInicio === undefined || $scope.minutosRecojo === undefined || $scope.motivoReprogramacion === undefined) {
        swal(
          "Error",
          "Debe llenar todos los datos de reprogramaci\u00f3n.",
          "error"
        );
        return;
      }

      var horasInicio = $scope.zeroFill(
        $scope.arcoInferior.getHours().toString(),
        2
      );
      var minutosInicio = $scope.zeroFill(
        $scope.arcoInferior.getMinutes().toString(),
        2
      );
      var horasRecojo = $scope.zeroFill(
        $scope.arcoSuperior.getHours().toString(),
        2
      );
      var minutosRecojo = $scope.zeroFill(
        $scope.arcoSuperior.getMinutes().toString(),
        2
      );

      fechaInicio.setHours(horasInicio);
      fechaInicio.setMinutes(minutosInicio);
      fechaRecojo.setHours(horasRecojo);
      fechaRecojo.setMinutes(minutosRecojo);
      if (fechaInicio >= fechaRecojo) {
        swal(
          "\u00a1Error!",
          "La hora del arco inferior no puede ser mayor que la del arco superior.",
          "error"
        );
        return;
      }
      RegistrarReprogramacion(
        $rootScope.AgenciaParaRegistrarReprogramacion.iId,
        fechaInicio,
        fechaRecojo,
        $scope.motivoReprogramacion.iIdMotivo
      );
      $uibModalInstance.close();
    };

    $scope.cancel = function () {
      $uibModalInstance.dismiss("cancelar");
    };

    /*Llamar a los motivos*/
    ListarMotivos();
  },
]);