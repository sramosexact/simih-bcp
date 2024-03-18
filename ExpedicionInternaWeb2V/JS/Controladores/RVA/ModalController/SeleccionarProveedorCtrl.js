app.controller("SeleccionarProveedorCtrl", [
  "$scope",
  "$uibModalInstance",
  "ServiciosApi",
  "$rootScope",
  function ($scope, $uibModalInstance, ServiciosApi, $rootScope) {
    $scope.proveedorSeleccionado = {};

    const listarProveedores = () => {
      ServiciosApi.ListarProveedor().then(
        (data) => {
          $scope.proveedorList = data;
        },
        () => {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "Hubo un error : Por favor revise su conexi\u00f3n a internet"
          );
        }
      );
    };

    listarProveedores();

    $scope.escogerProveedor = () => {
      if (Object.keys($scope.proveedorSeleccionado).length === 0) {
        $rootScope.mostrarError(
          "\u00a1Error!",
          "Seleccione un proveedor de la lista"
        );
        return;
      }
      $uibModalInstance.close($scope.proveedorSeleccionado);
    };

    $scope.Close = () => {
      $uibModalInstance.close({});
    };
  },
]);