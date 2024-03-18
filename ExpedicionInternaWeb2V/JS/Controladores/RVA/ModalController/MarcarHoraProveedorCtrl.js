app.controller("MarcarHoraProveedorCtrl", [
  "$scope",
  "$uibModalInstance",
  "DatosCompartidosServiceLS",
  "ServiciosApi",
  "ESTADOS",
  function (
    $scope,
    $uibModalInstance,
    DatosCompartidosServiceLS,
    ServiciosApi,
    ESTADOS
  ) {
    const agenciaSelecLS = "AgenciaSelec";
    const idRegistro = $scope.idRegistro;

    $scope.enAgencia = idRegistro !== "";

    $scope.aceptar = () => {
      if ($scope.enAgencia) {
        switch ($scope.agencia.iIdEstadoProveedor) {
          case ESTADOS.ESTADOS_PROVEEDOR.VISITA_AGENCIA_R:
            DatosCompartidosServiceLS.asignarDatos(
              agenciaSelecLS,
              $scope.agencia
            );
            $uibModalInstance.close();
                window.location.href = `#/ProveedorRecojoAgencia/${$scope.agencia.iId}/DetallesRecojo`;
            break;
          case ESTADOS.ESTADOS_PROVEEDOR.RECOGIDO_AGENCIA:
            $uibModalInstance.close();
                window.location.href = "#/ProveedorRecojoAgencia";
            break;
          case ESTADOS.ESTADOS_PROVEEDOR.VISITA_AGENCIA_E:
            $uibModalInstance.close();
                window.location.href = `#/ProveedorEntregaAgencia/${$scope.agencia.iId}/DetallesEntrega`;
            break;
          case ESTADOS.ESTADOS_PROVEEDOR.ENTREGADO_AGENCIA:
            $uibModalInstance.close();
                window.location.href = "#/ProveedorEntregaAgencia";
            break;
        }
      } else {
        $uibModalInstance.close();
      }
    };

    const getRegistro_UTD_AGENCIA = () => {
      return ServiciosApi.getAgenciaPorEnviar(idRegistro)
        .then((data) => {
          return data[0];
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener los detalles de env\u00edo de la agencia seleccionada"
          );
        });
    };

    const getRegistro_AGENCIA_UTD = () => {
      return ServiciosApi.getAgenciaLimaVisita(idRegistro)
        .then((data) => {
          return data[0];
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener los detalles de env\u00edo de la agencia seleccionada"
          );
        });
    };

    if ($scope.enAgencia) {
      if ($scope.idTipoRegistro === 1) {
        getRegistro_AGENCIA_UTD()
          .then((result) => {
            $scope.agencia = result;
          })
          .catch(() => {
            $rootScope.mostrarError(
              "Error",
              "No se pudo obtener detalles del registro."
            );
          });
      } else if ($scope.idTipoRegistro === 2) {
        getRegistro_UTD_AGENCIA()
          .then((result) => {
            $scope.agencia = result;
          })
          .catch(() => {
            $rootScope.mostrarError(
              "Error",
              "No se pudo obtener detalles del registro."
            );
          });
      }
    }
  },
]);