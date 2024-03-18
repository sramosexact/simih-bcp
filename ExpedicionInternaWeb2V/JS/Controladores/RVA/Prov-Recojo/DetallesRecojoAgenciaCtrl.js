app.controller("DetallesRecojoAgenciaCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "TIPO",
  "$window",
  "$filter",
  "DatosCompartidosServiceLS",
  "$uibModal",
  "ESTADOS",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    TIPO,
    $window,
    $filter,
    DatosCompartidosServiceLS,
    $uibModal,
    ESTADOS
  ) {
    const TIPOREGISTRO = TIPO.TIPO_REGISTRO.RECOJO;
    const AGENCIASELECLS = "AgenciaSelec";
    const CAMPOSAGENCIASELECLS = "CamposAgenciaSelec";

    var incidenciaNoHuboRecojo = [];
    var datosCompartidos =
      DatosCompartidosServiceLS.obtenerDatos(CAMPOSAGENCIASELECLS);

    $scope.setActive("vRecojo");
    $scope.setActiveNavBar(true);
    $scope.agencia = DatosCompartidosServiceLS.obtenerDatos(AGENCIASELECLS);
    $scope.camposDinamicos = [];
    $scope.btnRecogerVisitar = "Recoger";
    $scope.huboRecojo = true;
    $scope.camposIncompletos = true;

    const verificarCamposIncompletos = function () {
      $scope.camposIncompletos = false;
      $scope.camposDinamicos.forEach((value) => {
        if ($scope.agencia[value.campo] === "") {
          $scope.camposIncompletos = true;
          return;
        }
      });
    };

    const agregarWatchParaCamposDinamicos = () => {
      $scope.$watch(
        "agencia",
        function () {
          verificarCamposIncompletos();
        },
        true
      );
    };

    $scope.onCambioRecojo = () => {
      if (!$scope.huboRecojo) {
        $scope.agencia["cantidadValijas"] = 0;
        $scope.btnRecogerVisitar = "Continuar";
      } else {
        $scope.btnRecogerVisitar = "Recoger";
        $scope.agencia["cantidadValijas"] = "";
      }
    };

    $scope.verificarSiYaRecogio = () => {
      return $scope.agencia.dFechaRecojoProveedor !== null;
    };

    if ($scope.verificarSiYaRecogio()) {
      if (
        $scope.agencia.iIdEstado === ESTADOS.ESTADOS_VALIJA.APLICADO
      ) {
        $scope.huboRecojo = false;
      } else {
        $scope.huboRecojo = true;
      }
    }

    const getCamposDinamicos = () => {
      return ServiciosApi.listarCamposDinamicos(TIPOREGISTRO)
        .then(function (data) {
          $scope.camposDinamicos = [...data];
          DatosCompartidosServiceLS.asignarDatos(
            CAMPOSAGENCIASELECLS,
            $scope.camposDinamicos
          );
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

    const obtenerIncidenciaTipoNoHuboRecojo = () => {
      ServiciosApi.ObtenerIncidenciaSegunTipo(
        $scope.agencia.iId,
        TIPO.TIPO_MOTIVO.NOHUBORECOJO
      )
        .then((data) => {
          incidenciaNoHuboRecojo = data;
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener algunos detalles del registro."
          );
        });
    };

    obtenerIncidenciaTipoNoHuboRecojo();

    if (Object.keys(datosCompartidos).length === 0) {
      getCamposDinamicos()
        .then(() => {
          obtenerDetallesValija();
          agregarWatchParaCamposDinamicos();
        })
        .catch(function (error) {
          console.error(error);
        });
    } else {
      $scope.camposDinamicos = datosCompartidos;
      obtenerDetallesValija();
      agregarWatchParaCamposDinamicos();
    }

    $scope.irAtras = () => {
      $window.history.back();
    };

    $scope.modalRegistrar = () => {
      if (!$scope.huboRecojo) seleccionarMotivo();
      else
        swal(
          {
            title: "Registrar Recojo",
            text: "\u00bfEst\u00e1s seguro de registrar el recojo?",
            type: "info",
            showCancelButton: true,
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",

          }).then((isConfirm) => {
            if (isConfirm) registrarRecojo();
          }
        );
    };

    const seleccionarMotivo = () => {
      $uibModal
        .open({
          animation: true,
          templateUrl: "/PAGINAS/RVA/modal/SeleccionarMotivo.html",
          controller: "SeleccionarMotivoCtrl",
          windowClass: "modal-centered",
        })
        .result.then((motivo) => {
          if (motivo.iIdMotivo) {
            confirmarNoHuboRecojo(motivo);
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "¡Error!",
            "No se pudo continuar con el registro. Int\u00e9ntelo m\u00e1s tarde."
          );
        });
    };

    const confirmarNoHuboRecojo = (motivo) => {
      swal(
        {
          title: "\u00bfNo Hubo Recojo?",
          text: "Se registrar\u00e1 como visitado a la agencia y se marcar\u00e1 el estado como aplicado",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
        }).then( (isConfirm) => {
          if (isConfirm) registrarNoHuboRecojo(motivo);
        }
      );
    };

    const registrarNoHuboRecojo = (motivo) => {
      var horaServidorFormatted;
      var fechaServidorFormatted;

      ServiciosApi.getFechaServidor()
        .then((data1) => {
          const fechaServidor = new Date(data1[0].dFechaRecepcion);
          fechaServidorFormatted = $filter("date")(
            fechaServidor,
            "yyyy-MM-ddTHH:mm:ss"
          );
          horaServidorFormatted = $filter("date")(fechaServidor, "HH:mm:ss");
          $scope.agencia.sObservacionProveedor = (
            $scope.agencia.sObservacionProveedor ?? ""
          ).trim();

          var registroDinamico = [];

          $scope.camposDinamicos.forEach((value) => {
            registroDinamico.push({
              campo: value.campo,
              descripcion: $scope.agencia[value.campo],
            });
          });

          var jsonRegistroDinamico = JSON.stringify(registroDinamico);

          return ServiciosApi.registrarRecojoAgencia(
            $rootScope.Usuario.Id,
            $scope.agencia.iId,
            fechaServidorFormatted,
            $scope.agencia.sObservacionProveedor,
            jsonRegistroDinamico,
            $scope.huboRecojo
          );
        })
        .then((data2) => {
          if (data2 === 1) {
            $scope.camposDinamicos.forEach((campo) => {
              $scope.agencia[campo.campo] = campo.valor;
            });
            return ServiciosApi.registrarIncidenciaProveedor(
              $scope.agencia.iId,
              motivo.iIdMotivo,
              "",
              fechaServidorFormatted
            );
          } else {
            throw new Error();
          }
        })
        .then((data3) => {
          if (data3 === 1) {

            ServiciosApi.envioCorreoNoHuboRecojoAgencia(
              $scope.agencia,
              motivo.sMotivo,
              fechaServidorFormatted
            ).then(
              function (data) {
                //No se hace ninguna acción en caso de que se envie el correo
              },
              function (error) {
                $rootScope.mostrarError("Error", "No se pudo reportar el no hubo recojo");
                console.error(error);
              }
            );

            const modalType = $scope.huboRecojo ? "Recojo" : "Visita";
            mostrarModal(horaServidorFormatted, modalType);
          } else {
            throw new Error();
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se puede continuar con el registro. Int\u00e9ntelo m\u00e1s tarde."
          );
        });
    };

    const registrarRecojo = () => {
      var horaServidorFormatted;

      ServiciosApi.getFechaServidor()
        .then((data1) => {
          const sIdUsuario = $rootScope.Usuario.Id;
          const sIdRegistro = $scope.agencia.iId;
          const fechaServidor = new Date(data1[0].dFechaRecepcion);
          const fechaServidorFormatted = $filter("date")(
            fechaServidor,
            "yyyy-MM-ddTHH:mm:ss"
          );
          horaServidorFormatted = $filter("date")(fechaServidor, "HH:mm:ss");
          $scope.agencia.sObservacionProveedor = (
            $scope.agencia.sObservacionProveedor ?? ""
          ).trim();

          var registroDinamico = [];

          $scope.camposDinamicos.forEach((value) => {
            registroDinamico.push({
              campo: value.campo,
              descripcion: $scope.agencia[value.campo],
            });
          });

          var jsonRegistroDinamico = JSON.stringify(registroDinamico);

          return ServiciosApi.registrarRecojoAgencia(
            sIdUsuario,
            sIdRegistro,
            fechaServidorFormatted,
            $scope.agencia.sObservacionProveedor,
            jsonRegistroDinamico,
            $scope.huboRecojo
          );
        })
        .then((data2) => {
          if (data2 === 1) {
            $scope.camposDinamicos.forEach((campo) => {
              $scope.agencia[campo.campo] = campo.valor;
            });
            const modalType = $scope.huboRecojo ? "Recojo" : "Visita";
            mostrarModal(horaServidorFormatted, modalType);
          } else if (data2 === 0) {
            $rootScope.mostrarError(
              "Error",
              "Error al realizar el registro de recojo para esta agencia"
            );
          }
        })
        .catch((error) => {
          $rootScope.mostrarError(
            "Error",
            "No se puede continuar con el registro de recojo. Verificar si se realiz\u00f3 el registro"
          );
        });
    };

    const mostrarModal = (horaServidor, modalType) => {
      const scope = $scope.$new();
      scope.tituloModal = `${modalType} Proveedor`;
      scope.tipoRegistro = modalType.toLowerCase();
      scope.confirmacionRegistro = `Se registr\u00f3 ${scope.tipoRegistro === "recojo" ? "el recojo de" : "la visita a"
        } la agencia`;
      scope.horaRegistro = horaServidor;
      scope.idRegistro = $scope.agencia.iId;
      scope.idTipoRegistro = 1;

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
  },
]);