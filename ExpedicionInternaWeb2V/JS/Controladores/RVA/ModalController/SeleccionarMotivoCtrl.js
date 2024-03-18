app.controller("SeleccionarMotivoCtrl", [
  "$scope",
  "$uibModalInstance",
  "ServiciosApi",
  "$rootScope",
  "TIPO",
  function ($scope, $uibModalInstance, ServiciosApi, $rootScope, TIPO) {
    $scope.motivoSeleccionado = {};

    const listarMotivosNoHuboRecojo = () => {
      ServiciosApi.getListarMotivos(TIPO.TIPO_MOTIVO.NOHUBORECOJO).then(
        (data) => {
          $scope.motivosList = data;
        },
        () => {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "No se pudo obtener las opciones. Int\u00e9ntelo m\u00e1s tarde."
          );
        }
      );
    };

    listarMotivosNoHuboRecojo();

    $scope.escogerMotivo = () => {
      if (Object.keys($scope.motivoSeleccionado).length === 0) {
        $rootScope.mostrarError(
          "\u00a1Error!",
          "Seleccione un motivo de la lista"
        );
        return;
      }
      $uibModalInstance.close($scope.motivoSeleccionado);
    };

    $scope.Close = () => {
      $uibModalInstance.close({});
    };
  },
]);