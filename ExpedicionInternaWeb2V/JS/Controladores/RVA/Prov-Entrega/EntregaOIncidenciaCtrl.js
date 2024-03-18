app.controller("EntregaOIncidenciaCtrl", [
  "$scope",
  "$rootScope",
  "$routeParams",
  "DatosCompartidosServiceLS",
  "ServiciosApi",
  "$filter",
  "$uibModal",
  "$location",
  "$window",
  "TIPO",
  function (
    $scope,
    $rootScope,
    $routeParams,
    DatosCompartidosServiceLS,
    ServiciosApi,
    $filter,
    $uibModal,
    $location,
    $window,
    TIPO
  ) {
    const agenciaSelecLS = "AgenciaSelec";
    const idRegistro = $routeParams.id;

    var incidenciaProveedor = [];
    var registroIncidencia = false;

    $scope.setActive("vEntrega");
    $scope.setActiveNavBar(true);
    $scope.tituloRegistrarOVerDetalles = "REGISTRAR ENTREGA";
    $scope.tituloReportarOVerIncidencia = "REPORTAR INCIDENCIA";

    const getAgenciaSelec = () => {
      return ServiciosApi.getAgenciaPorEnviar(idRegistro)
        .then((data) => {
          $scope.agencia = data[0];
          DatosCompartidosServiceLS.asignarDatos(agenciaSelecLS, data[0]);
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener los detalles de env\u00edo de la agencia seleccionada"
          );
        });
    };

    const obtenerIncidenciaTipoProveedor = () => {
      ServiciosApi.ObtenerIncidenciaSegunTipo(
        $scope.agencia.iId,
        TIPO.TIPO_MOTIVO.PROVEEDOR
      )
        .then((data) => {
          incidenciaProveedor = data;

          if (incidenciaProveedor.length > 0) registroIncidencia = true;
          else registroIncidencia = false;

          verificarCambiosTitulos();
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener algunos detalles del registro."
          );
        });
    };

    const verificarCambiosTitulos = () => {
      if (marcoLlegada()) {
        cambiarTituloRegistrarOVerDetalles();
      }

      if (registroIncidencia) {
        cambiarTituloReportarOVerIncidencia();
      }
    };

    const marcoLlegada = () => {
      return $scope.agencia.dFechaLlegadaProveedor !== null;
    };

    const cambiarTituloRegistrarOVerDetalles = () => {
      $scope.tituloRegistrarOVerDetalles = "VER DETALLES";
    };

    const cambiarTituloReportarOVerIncidencia = () => {
      $scope.tituloReportarOVerIncidencia = "VER INCIDENCIA";
    };

    getAgenciaSelec()
      .then(() => {
        obtenerIncidenciaTipoProveedor();
      })
      .catch(() => {
        $rootScope.mostrarError(
          "Error",
          "No se pudo obtener datos de la agencia"
        );
      });

    $scope.empezarRegistroLlegada = () => {
      if (!marcoLlegada()) {
        confirmarLlegada();
      } else {
        redirigirADetallesEntrega();
      }
    };

    const confirmarLlegada = () => {
      swal(
        {
          title: "Registrar Llegada",
          text: "Al pasar a la siguiente ventana se registrar\u00e1 su llegada a la agencia. \u00bfDesea continuar?",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
        }).then((isConfirm) => {
          if (isConfirm) {
            registrarLlegadaAgencia();
          }
        }
      );
    };

    const registrarLlegadaAgencia = () => {
      var horaServidorFormatted;

      ServiciosApi.getFechaServidor()
        .then((data1) => {
          var sIdUsuario = $rootScope.Usuario.Id;
          var fechaServidor = new Date(data1[0].dFechaRecepcion);
          fechaServidor = $filter("date")(fechaServidor, "yyyy-MM-ddTHH:mm:ss");
          horaServidorFormatted = $filter("date")(fechaServidor, "HH:mm:ss");

          return ServiciosApi.registrarLlegadaAgencia(
            sIdUsuario,
            idRegistro,
            fechaServidor
          );
        })
        .then((data2) => {
          if (data2 === 1) {
            mostrarModalLlegadaExitosa(horaServidorFormatted);
          } else if (data2 === 0) {
            $rootScope.mostrarError(
              "Error",
              "Error al realizar el registro de llegada para esta agencia"
            );
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se puede continuar con el registro de llegada. Verificar si se realiz\u00f3 el registro"
          );
        });
    };

    const mostrarModalLlegadaExitosa = (horaServidor) => {
      var scope = $scope.$new();
      scope.tituloModal = "Llegada Proveedor";
      scope.tipoRegistro = "llegada";
      scope.confirmacionRegistro = "Se registr\u00f3 la llegada a la agencia";
      scope.horaRegistro = horaServidor;
      scope.idRegistro = idRegistro;
      scope.idTipoRegistro = 2;

      $uibModal
        .open({
          animation: true,
          templateUrl: "/PAGINAS/RVA/modal/MarcarHoraProveedor.html",
          controller: "MarcarHoraProveedorCtrl",
          scope: scope,
          backdrop: "static",
          keyboard: false,
          windowClass: "modal-centered",
        })
        .result.then(() => {
          // Lógica adicional si es necesario
        })
        .catch((error) => {
          console.error(error);
        });
    };

    const redirigirADetallesEntrega = () => {
      $location.path(
        "/ProveedorEntregaAgencia/" + $scope.agencia.sIdAgencia + "/DetallesEntrega"
      );
    };

    $scope.irRegistroODetallesIncidencia = () => {
        $location.path("/ProveedorEntregaAgencia/" + idRegistro + "/DetallesIncidencia");
    };

    $scope.irAtras = () => {
      $window.history.back();
    };
  },
]);