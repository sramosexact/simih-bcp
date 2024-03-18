app.controller("ListaRecojoUTDCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "DatosCompartidosService",
  "$location",
  "$filter",
  "$uibModal",
  "DatosCompartidosServiceLS",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    DatosCompartidosService,
    $location,
    $filter,
    $uibModal,
    DatosCompartidosServiceLS
  ) {
    const usuario = $rootScope.Usuario;
    const tituloInicio = "Iniciar Recojo";
    const tituloTermino = "Terminar Recojo";
    const objetoLS = "DatosRUTD";
    const sIdUsuario = $rootScope.Usuario.Id;
    const modalTypeLlegada = "Llegada";
    const modalTypeRecojo = "Recojo";

    var objeto = DatosCompartidosServiceLS.obtenerDatos(objetoLS);
    var fechaLlegada;
    var fechaRecojo;

    $scope.setActive("vRecojo");
    $scope.setActiveNavBar(true);
    $scope.tituloRecojo = "";
    $scope.registrando = false;
    $scope.idAgenciasSeleccionadas = [];
    $scope.idsRegistrosPorRecoger = [];
    $("#fechaRecojoUTD").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaRecojoUTD").datepicker("setDate", new Date());
    $scope.modelFecha = $("#fechaRecojoUTD").val();
    $scope.todasLasAgenciasSeleccionadas = false;

    DatosCompartidosService.setDatos("");

    const inicilizarDatePicker = () => {
      if (
        $("#fechaRecojoUTD")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate") === null
      ) {
        return new Date();
      } else {
        return $("#fechaRecojoUTD")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate");
      }
    };

    const obtenerAgencias = (fecha) => {
      return ServiciosApi.getListarAgenciasPorEnviar(fecha)
        .then(function (data) {
          $scope.Agencias = data.filter((value) => {
            return (
              value.iIdTipoUsuario === usuario.iIdProveedor &&
              value.dFechaEnvio !== null &&
              value.dFechaRecojoProveedor === null
            );
          });
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pueden mostrar las agencias para recojo"
          );
        });
    };

    const inicializarInformacion = () => {
      $scope.tituloRecojo = objeto.registrando ? tituloTermino : tituloInicio;
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

    $scope.verDetallesRecojo = (idRegistro) => {
      if ($scope.registrando) {
          $location.path("/ProveedorRecojoUtd/" + idRegistro + "/DetallesRecojo");
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

    $scope.iniciarTerminarRecojo = () => {
      if (!$scope.registrando) {
        iniciarRecojoYLlegada();
      } else {
        if ($scope.idAgenciasSeleccionadas.length > 0) {
          $scope.modalTerminarRecojo();
        } else {
          terminarRecojo();
          $rootScope.mostrarError(
            "No hubo recojo",
            "No seleccion\u00f3 ning\u00fan registro para recojo."
          );
        }
      }
    };

    const iniciarRecojoYLlegada = () => {
      if (!existenRegistros()) {
        $rootScope.mostrarError(
          "No hay env\u00edos",
          "UTD no ha registrado valijas de env\u00edo para agencias."
        );
        return;
      }

      swal(
        {
          title: "Iniciar Recojo",
          text: "Al continuar se registrar\u00e1 su llegada a la UTD. \u00bfDesea continuar?",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",

        }).then( (isConfirm) => {
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
          $scope.tituloRecojo = tituloTermino;
          $scope.registrando = !$scope.registrando;
          objetoInitialState(fechaLlegada);
          DatosCompartidosServiceLS.asignarDatos(objetoLS, objeto);
          mostrarModal(horaServidorFormatted, modalTypeLlegada);
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo registrar su llegada a la UTD"
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
      scope.confirmacionRegistro = `Se registr\u00f3 ${scope.tipoRegistro === "recojo"
          ? "el recojo de valijas de"
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
        .catch(() => {
          //
        });
    };

    $scope.modalTerminarRecojo = () => {
      swal(
        {
          title: "Terminar Recojo",
          text: "\u00bfEst\u00e1s seguro de terminar el recojo?",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",

        }).then((isConfirm) => {
          if (isConfirm) {
            terminarRecojo();
          }
        }
      );
    };

    const terminarRecojo = () => {
      var horaServidorFormatted;

      ServiciosApi.getFechaServidor()
        .then((data1) => {
          fechaRecojo = new Date(data1[0].dFechaRecepcion);
          fechaRecojo = $filter("date")(fechaRecojo, "yyyy-MM-ddTHH:mm:ss");
          horaServidorFormatted = $filter("date")(fechaRecojo, "HH:mm:ss");
          return ServiciosApi.registrarRecojoUTD(
            sIdUsuario,
            $scope.idAgenciasSeleccionadas,
            fechaRecojo,
            fechaLlegada
          );
        })
        .then((data2) => {
          if (data2 === 1) {
            restaurarDatosLS();
            if ($scope.idAgenciasSeleccionadas.length > 0) {
              mostrarModal(horaServidorFormatted, modalTypeRecojo);
            }
            $scope.InicializarFlujoAgencias();
          } else if (data2 === 0) {
            $rootScope.mostrarError(
              "Error",
              "Error al realizar el registro de recojo para UTD"
            );
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se puede continuar con el registro de recojo. Verificar si se realiz\u00f3 el registro"
          );
        });
    };
  },
]);