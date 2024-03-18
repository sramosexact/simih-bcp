app.controller("DetallesEntregaUTDCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "$routeParams",
  "TIPO",
  "$window",
  function ($scope, $rootScope, ServiciosApi, $routeParams, TIPO, $window) {
    const tipoRegistro = TIPO.TIPO_REGISTRO.RECOJO;
    const idAgenciaTraslado = $routeParams.id;

    $scope.camposDinamicos = [];
    $scope.setActive("vEntrega");
    $scope.setActiveNavBar(true);
    $scope.sObservacionProveedor = "";

    const getAgenciaSelec = () => {
      return ServiciosApi.getAgenciaLimaVisita(idAgenciaTraslado)
        .then((data) => {
          $scope.agencia = data[0];
          $scope.sObservacionProveedor = $scope.agencia.sObservacionProveedor;
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

    $scope.irAtras = () => {
      $window.history.back();
    };
  },
]);