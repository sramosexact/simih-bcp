app.controller("ListaEntregaUTDCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "$location",
  "$filter",
  "$uibModal",
  "DatosCompartidosServiceLS",
  "DatosCompartidosService",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    $location,
    $filter,
    $uibModal,
    DatosCompartidosServiceLS,
    DatosCompartidosService
  ) {
    const usuario = $rootScope.Usuario;
    const tituloInicio = "Iniciar Entrega";
    const tituloTermino = "Terminar Entrega";
    const objetoLS = "DatosEUTD";
    const sIdUsuario = $rootScope.Usuario.Id;
    const modalTypeLlegada = "Llegada";
    const modalTypeEntrega = "Entrega";

    var objeto = DatosCompartidosServiceLS.obtenerDatos(objetoLS);
    var fechaEntrega;
    var fechaLlegada;

    $scope.setActive("vEntrega");
    $scope.setActiveNavBar(true);
    $scope.tituloEntrega = "";
    $scope.registrando = false;
    $scope.idAgenciasSeleccionadas = [];
    $("#fechaEntregaUTD").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaEntregaUTD").datepicker("setDate", new Date());
    $scope.modelFecha = $("#fechaEntregaUTD").val();
    $scope.todasLasAgenciasSeleccionadas = false;

    DatosCompartidosService.setDatos("");

    const inicilizarDatePicker = () => {
      if (
        $("#fechaEntregaUTD")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate") === null
      ) {
        return new Date();
      } else {
        return $("#fechaEntregaUTD")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate");
      }
    };

    const obtenerAgencias = (fecha) => {
      return ServiciosApi.getListarVisitaAgenciaLima(fecha)
        .then((data) => {
          $scope.Agencias = data.filter((value) => {
            return (
              value.iIdTipoUsuario === usuario.iIdProveedor &&
              value.dFechaRecojoProveedor !== null &&
              value.dFechaEntrega === null
            );
          });
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pueden mostrar los registros para entrega"
          );
        });
    };

    const inicializarInformacion = () => {
      $scope.tituloEntrega = objeto.registrando ? tituloTermino : tituloInicio;
      $scope.registrando = objeto.registrando ?? false;
      $scope.idAgenciasSeleccionadas = objeto.agenSelecc ?? [];
      fechaLlegada = objeto.fechaYHoraLlegada ?? new Date();
    };

    const verificarTodasLasAgenciasSeleccionadas = () => {
      return (
        $scope.Agencias.length > 0 &&
        $scope.Agencias.every((agencia) => agencia.agregado === true)
      );
    };

    const recuperarAgenciasSelecc = () => {
      if ($scope.idAgenciasSeleccionadas.length > 0) {
        $scope.Agencias.forEach((item) => {
          item.agregado = $scope.idAgenciasSeleccionadas.includes(item.iId);
        });
      } else {
        $scope.Agencias.forEach((value) => {
          value.agregado = false;
        });
      }
      $scope.todasLasAgenciasSeleccionadas =
        verificarTodasLasAgenciasSeleccionadas();
    };

    const restaurarDatosLS = () => {
      objeto = {};
      DatosCompartidosServiceLS.eliminarDatos(objetoLS);
    };

    $scope.InicializarFlujoAgencias = () => {
      var fecha = inicilizarDatePicker();
      obtenerAgencias(fecha).then(() => {
        if (!existenRegistros()) {
          restaurarDatosLS();
        }
        inicializarInformacion();
        recuperarAgenciasSelecc();
      });
    };

    $scope.InicializarFlujoAgencias();

    $scope.actualizar = () => {
      $scope.InicializarFlujoAgencias();
    };

    $scope.verDetallesEntrega = (idRegistro) => {
      if ($scope.registrando) {
          $location.path("/ProveedorEntregaUtd/" + idRegistro + "/DetallesEntrega");
      }
    };

    $scope.toggleSeleccionarTodasLasAgencias = () => {
      if ($scope.registrando) {
        toggleAgregadoEnTodasLasAgencias(!$scope.todasLasAgenciasSeleccionadas);
        toggleSeleccionTodasLasAgencias();
        $scope.todasLasAgenciasSeleccionadas =
          verificarTodasLasAgenciasSeleccionadas();
      }
    };

    const toggleAgregadoEnTodasLasAgencias = (valor) => {
      $scope.Agencias.forEach((agencia) => {
        agencia.agregado = valor;
      });
    };

    const toggleSeleccionTodasLasAgencias = () => {
      $scope.Agencias.forEach((agencia) => {
        var index = $scope.idAgenciasSeleccionadas.indexOf(agencia.iId);
        if ($scope.todasLasAgenciasSeleccionadas) {
          $scope.idAgenciasSeleccionadas.splice(index, 1);
        } else {
          if (index === -1) {
            $scope.idAgenciasSeleccionadas.push(agencia.iId);
          }
        }
      });

      objeto.agenSelecc = $scope.idAgenciasSeleccionadas;
      DatosCompartidosServiceLS.asignarDatos(objetoLS, objeto);
    };

    $scope.toggleSeleccionarAgencia = (agencia) => {
      if ($scope.registrando) {
        agencia.agregado = !agencia.agregado;
        toggleSeleccionAgencia(agencia);
        $scope.todasLasAgenciasSeleccionadas =
          verificarTodasLasAgenciasSeleccionadas();
      }
    };

    const toggleSeleccionAgencia = (agencia) => {
      var index = $scope.idAgenciasSeleccionadas.indexOf(agencia.iId);

      if (index === -1) {
        $scope.idAgenciasSeleccionadas.push(agencia.iId);
      } else if (index !== -1) {
        $scope.idAgenciasSeleccionadas.splice(index, 1);
      }

      objeto.agenSelecc = $scope.idAgenciasSeleccionadas;
      DatosCompartidosServiceLS.asignarDatos(objetoLS, objeto);
    };

    const existenRegistros = () => {
      return $scope.Agencias.length > 0;
    };

    $scope.iniciarTerminarEntrega = () => {
      if (!$scope.registrando) {
        iniciarEntregaYLlegada();
      } else {
        if ($scope.idAgenciasSeleccionadas.length > 0) {
          $scope.modalTerminarEntrega();
        } else {
          terminarEntrega();
          $rootScope.mostrarError(
            "No hubo entrega",
            "No seleccion\u00f3 ning\u00fan registro para entrega."
          );
        }
      }
    };

    const iniciarEntregaYLlegada = () => {
      if (!existenRegistros()) {
        $rootScope.mostrarError(
          "No hubo recojo",
          "Primero debe realizar recojo para continuar con la entrega"
        );
        return;
      }

      swal(
        {
          title: "Iniciar Entrega",
          text: "Al continuar se registrar\u00e1 su llegada a la UTD. \u00bfDesea continuar?",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
        }).then((isConfirm) => {
          if (isConfirm) {
            registrarLlegadaUTD();
          }
        }
      );
    };

    const registrarLlegadaUTD = () => {
      var horaServidorFormatted;

      ServiciosApi.getFechaServidor()
        .then((data) => {
          fechaLlegada = new Date(data[0].dFechaRecepcion);
          fechaLlegada = $filter("date")(fechaLlegada, "yyyy-MM-ddTHH:mm:ss");
          horaServidorFormatted = $filter("date")(fechaLlegada, "HH:mm:ss");
          $scope.tituloEntrega = tituloTermino;
          $scope.registrando = !$scope.registrando;
          objetoInitialState(fechaLlegada);
          DatosCompartidosServiceLS.asignarDatos(objetoLS, objeto);
          mostrarModal(horaServidorFormatted, modalTypeLlegada);
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo registrar su llegada a UTD"
          );
        });
    };

    const objetoInitialState = (fechaLlegada) => {
      objeto.fechaYHoraLlegada = fechaLlegada;
      objeto.registrando = $scope.registrando;
      objeto.agenSelecc = [];
    };

    const mostrarModal = (horaServidor, modalType) => {
      const scope = $scope.$new();
      scope.tituloModal = `${modalType} Proveedor`;
      scope.tipoRegistro = modalType.toLowerCase();
      scope.confirmacionRegistro = `Se registr\u00f3 ${scope.tipoRegistro === "entrega"
        ? "la entrega de valijas para la"
        : "la llegada a"
        }  UTD`;
      scope.horaRegistro = horaServidor;
      scope.idRegistro = "";
      scope.idTipoRegistro = 0;

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
          //
        });
    };

    $scope.modalTerminarEntrega = () => {
      swal(
        {
          title: "Terminar Entrega",
          text: "\u00bfEst\u00e1s seguro de terminar la entrega?",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
        }).then( (isConfirm) => {
          if (isConfirm) {
            terminarEntrega();
          }
        }
      );
    };

    const terminarEntrega = () => {
      var horaServidorFormatted;

      ServiciosApi.getFechaServidor()
        .then((data1) => {
          fechaEntrega = new Date(data1[0].dFechaRecepcion);
          fechaEntrega = $filter("date")(fechaEntrega, "yyyy-MM-ddTHH:mm:ss");
          horaServidorFormatted = $filter("date")(fechaEntrega, "HH:mm:ss");
          return ServiciosApi.registrarEntregaUTD(
            sIdUsuario,
            $scope.idAgenciasSeleccionadas,
            fechaEntrega,
            fechaLlegada
          );
        })
        .then((data2) => {
          if (data2 === 1) {
            restaurarDatosLS();
            if ($scope.idAgenciasSeleccionadas.length > 0) {
              mostrarModal(horaServidorFormatted, modalTypeEntrega);
            }
            $scope.InicializarFlujoAgencias();
          } else if (data2 === 0) {
            $rootScope.mostrarError(
              "Error",
              "Error al realizar el registro de entrega para UTD"
            );
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se puede continuar con el registro de entrega. Verificar si se realiz\u00f3 el registro"
          );
        });
    };
  },
]);