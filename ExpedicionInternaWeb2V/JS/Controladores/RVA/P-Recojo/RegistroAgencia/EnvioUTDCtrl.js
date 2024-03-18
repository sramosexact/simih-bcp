/*Controlador de la página EnvioUTD.html*/
app.controller("EnvioUTDCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "TIPO",
  "DatosCompartidosService",
  "$location",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    TIPO,
    DatosCompartidosService,
    $location
  ) {
    $scope.setActive("vEnvio");
    $scope.setActiveNavBar(true);
    $scope.camposDinamicos = $rootScope.camposDinamicos;
    $scope.agencia = DatosCompartidosService.getDatos();

    $scope.atras = () => {
      $location.path("/EnviarUTD");
    };

    $scope.prepararEnvio = () => {
      var sIdUsuario = $rootScope.Usuario.Id;
      var sCodigoAgencia = $scope.agencia.sIdAgencia;
      var registroDinamico = [];

      $scope.camposDinamicos.forEach((value) => {
        registroDinamico.push({
          campo: value.campo,
          descripcion: $scope.agencia[value.campo],
        });
      });

      var jsonRegistroDinamico = JSON.stringify(registroDinamico);

      ServiciosApi.PrepararEnvio(
        sIdUsuario,
        sCodigoAgencia,
        jsonRegistroDinamico
      ).then(
        function (data) {
          if (data === 1) {
            swal(
              "\u00a1Preparación de valija exitosa!",
              "Se ha guardado los valores de envío de la valija correctamente",
              "success"
            );
            setTimeout($scope.atras, 1000);
          } else if (data === -1) {
            swal(
              "\u00a1Atenci\u00f3n!",
              "No existe registro de envío para el d\u00eda en curso",
              "error"
            );
            return;
          } else if (data === 0) {
            $rootScope.mostrarError(
              "Error",
              "Hubo un error, int\u00e9ntelo m\u00e1s tarde"
            );
          }
        },
        function () {
          $rootScope.mostrarError(
            "Error",
            "Hubo un error: Por favor revise su conexi\u00f3n a internet"
          );
        }
      );
    };
  },
]);