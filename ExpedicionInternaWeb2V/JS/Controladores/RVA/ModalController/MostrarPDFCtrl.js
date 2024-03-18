app.controller("MostrarPDFCtrl", [
  "$scope",
  "$uibModalInstance",
  "ServiciosApi",
  "$rootScope",
  "$filter",
  function ($scope, $uibModalInstance, ServiciosApi, $rootScope, $filter) {
    $scope.EliminarArchivo = () => {
      var idRegistro = $scope.idRegistro;
      swal(
        {
          title: "Eliminar Archivo",
          text: "Al aceptar se eliminar\u00e1 el archivo seleccionado. \u00bfDesea continuar?",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
        }).then((isConfirm) => {
          if (isConfirm) {
            ServiciosApi.getFechaServidor()
              .then((data) => {
                var fechaServidor = new Date(data[0].dFechaRecepcion);
                fechaServidor = $filter("date")(
                  fechaServidor,
                  "yyyy-MM-ddTHH:mm:ss"
                );
                return ServiciosApi.EliminarArchivo(idRegistro, fechaServidor);
              })
              .then((resp) => {
                if (resp === 1) {
                  $rootScope.mostrarSuccess(
                    "\u00a1Archivo Eliminado!",
                    "Se ha eliminado el archivo seleccionado exitosamente."
                  );
                } else {
                  throw new Error();
                }
              })
              .catch(() => {
                $rootScope.mostrarError(
                  "\u00a1Error!",
                  "Hubo un error al eliminar el archivo. Int\u00e9ntelo m\u00e1s tarde"
                );
              })
              .finally(() => {
                $uibModalInstance.close(true);
              });
          }
        });
    };

    $scope.Close = () => {
      $uibModalInstance.close(false);
    };
  },
]);