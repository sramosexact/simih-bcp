/*Controlador de la página RecepcionAgenciaDetalle.html*/
app.controller("RecepcionAgenciaDetalleCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "DatosCompartidosService",
  "$location",
  "$filter",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    DatosCompartidosService,
    $location,
    $filter
  ) {
    const sIdUsuario = $rootScope.Usuario.Id;

    $scope.setActive("vRecepcion");
    $scope.setActiveNavBar(true);

    $scope.camposDinamicos = $rootScope.camposDinamicos;
    console.log("$scope.camposDinamicos:", $scope.camposDinamicos);

    $scope.agencia = DatosCompartidosService.getDatos();
    console.log("$scope.agencia:", $scope.agencia);

    $scope.atras = () => {
      $location.path("/RecepcionAgencia");
    };

    $scope.recepcionar = () => {
      //var sIdUsuario = $rootScope.Usuario.Id;
      var iIdValija = $scope.agencia.iId;
      //var registroDinamico = [];
      /*
      angular.forEach($scope.camposDinamicos, function (value) {
        registroDinamico.push({ campo: value.campo, descripcion: $scope.agencia[value.campo] });
      });

      var jsonRegistroDinamico = JSON.stringify(registroDinamico);
      */
      console.log(iIdValija);

      ServiciosApi.getFechaServidor()
        .then((data1) => {
          const fechaServidor = new Date(data1[0].dFechaRecepcion);
          const fechaServidorFormatted = $filter("date")(
            fechaServidor,
            "yyyy-MM-ddTHH:mm:ss"
          );
          horaServidorFormatted = $filter("date")(fechaServidor, "HH:mm:ss");

          return ServiciosApi.RecepcionarValijaAgencia(
            sIdUsuario,
            iIdValija,
            fechaServidorFormatted
          );
        })
        .then((data2) => {
          if (data2 === 1) {
            $rootScope.mostrarSuccess(
              "\u00a1Recepci\u00f3n de valija exitosa!",
              "Se ha recibido la valija correctamente"
            );
            setTimeout($scope.atras, 1000);
          } else {
            // Manejar otros casos según la respuesta de la API
            $rootScope.mostrarError(
              "\u00a1Error en la recepci\u00f3n de valija!",
              "Hubo un problema al recibir la valija"
            );
          }
        })
        .catch((error) => {
          $rootScope.mostrarError(
            "Error",
            "No se puede continuar con la recepci\u00f3n de la valija. Verificar si se realiz\u00f3 la recepci\u00f3n"
          );
          console.error(error);
        });
    };
  },
]);