app.controller("IncidenciaParaAgenciaCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "$window",
  "$filter",
  "DatosCompartidosServiceLS",
  "TIPO",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    $window,
    $filter,
    DatosCompartidosServiceLS,
    TIPO
  ) {
    const AGENCIASELECLS = "AgenciaSelec";
    const IDTIPOMOTIVO = TIPO.TIPO_MOTIVO.PROVEEDOR;

    var incidenciaProveedor = [];

    $scope.setActiveNavBar(true);
    $scope.agencia = DatosCompartidosServiceLS.obtenerDatos(AGENCIASELECLS);
    $scope.motivoProveedorSeleccionado = {};
    $scope.noElegioMotivoOtro = true;
    $scope.otroMotivo = "";
    $scope.enviado = false;
    $scope.tituloTipoRegistro = "";
    $scope.conMotivoOtroSinValor = false;
    $scope.sinEleccionMotivo = true;

    if ($scope.agencia.iIdTipoRegistro == 1) {
      $scope.setActive("vRecojo");
      $scope.tituloTipoRegistro = "Recojo de Agencia";
    } else if ($scope.agencia.iIdTipoRegistro == 2) {
      $scope.setActive("vEntrega");
      $scope.tituloTipoRegistro = "Entrega a Agencia";
    }

    const obtenerIncidenciaTipoProveedor = () => {
      return ServiciosApi.ObtenerIncidenciaSegunTipo(
        $scope.agencia.iId,
        TIPO.TIPO_MOTIVO.PROVEEDOR
      )
        .then((data) => {
          incidenciaProveedor = data;

          if (incidenciaProveedor.length > 0) $scope.enviado = true;
          else $scope.enviado = false;
        })
        .catch((error) => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener algunos detalles del registro."
          );
        });
    };

    const listarMotivo = () => {
      return ServiciosApi.getListarMotivos(IDTIPOMOTIVO).then(
        (data) => {
          $scope.motivoList = data;
        },
        () => {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "Hubo un error: Por favor revise su conexi\u00f3n a internet"
          );
        }
      );
    };

    const existeMotivoAgregado = function () {
      if ($scope.enviado) {
        const objectIncidencia = incidenciaProveedor[0];
        const motivoRegistrado = objectIncidencia.MotivoIncidencia;

        $scope.otroMotivo = objectIncidencia.MotivoOtro;
        $scope.motivoProveedorSeleccionado = $scope.motivoList.filter(function (
          motivo
        ) {
          return motivo.sMotivo === motivoRegistrado;
        })[0];
      }
    };

    Promise.all([listarMotivo(), obtenerIncidenciaTipoProveedor()])
      .then(() => {
        existeMotivoAgregado();
      })
      .catch(() => {
        $rootScope.mostrarError(
          "Error",
          "No se pudo obtener el motivo de incidencia."
        );
      });

    $scope.verificarMotivo = function () {
      $scope.sinEleccionMotivo = false;
      $scope.noElegioMotivoOtro =
        $scope.motivoProveedorSeleccionado.sMotivo !== "Otros";
      if ($scope.noElegioMotivoOtro) {
        $scope.otroMotivo = "";
      }
    };

    const camposValidados = function () {
      if (Object.keys($scope.motivoProveedorSeleccionado).length === 0) {
        $rootScope.mostrarError(
          "No Motivo",
          "Debe seleccionar alg\u00fan motivo para registrar la incidencia."
        );
        return false;
      }

      if (
        $scope.motivoProveedorSeleccionado.sMotivo === "Otros" &&
        $scope.otroMotivo === ""
      ) {
        $rootScope.mostrarError("No Motivo", "Digite la incidencia ocurrida.");
        return false;
      }

      return true;
    };

    $scope.confirmarRegistroIncidencia = function () {
      if (camposValidados()) {
        swal(
          {
            title: "Registrar Incidencia",
            text: "Al aceptar se notificar\u00e1 la incidencia a la agencia y a UTD. \u00bfDesea continuar?",
            type: "info",
            showCancelButton: true,
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
          }).then( (isConfirm) => {
            if (isConfirm) {
              registrarIncidencia();
            }
          }
        );
      }
    };

    const registrarIncidencia = function () {
      let fechaServidor;
      ServiciosApi.getFechaServidor()
        .then((fecha) => {
          fechaServidor = new Date(fecha[0].dFechaRecepcion);
          fechaServidor = $filter("date")(fechaServidor, "yyyy-MM-ddTHH:mm:ss");
          return ServiciosApi.registrarIncidenciaProveedor(
            $scope.agencia.iId,
            $scope.motivoProveedorSeleccionado.iIdMotivo,
            $scope.otroMotivo,
            fechaServidor
          );
        })
        .then((resp) => {
          if (resp === 1) {
            $rootScope.mostrarSuccess("Incidencia Registrada", "");
            $scope.enviado = true;

            ServiciosApi.envioCorreoIncidenciaRecojoAgencia(
              $scope.agencia,
              $scope.motivoProveedorSeleccionado.sMotivo,
              $scope.otroMotivo,
              fechaServidor
            ).then(
              function (data) {
                //No se hace ninguna acción en caso de que se envie el correo
              },
              function (error) {
                $rootScope.mostrarError("Error", "No se pudo reportar la incidencia");
                console.error(error);
              }
            );
          } else {
            throw new Error();
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo registrar la incidencia. Int\u00e9ntelo m\u00e1s tarde"
          );
        });
    };

    $scope.irAtras = () => {
      $window.history.back();
    };
  },
]);