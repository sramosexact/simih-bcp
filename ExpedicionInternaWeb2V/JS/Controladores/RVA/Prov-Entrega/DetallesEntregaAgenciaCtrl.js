app.controller("DetallesEntregaAgenciaCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "TIPO",
  "$filter",
  "$uibModal",
  "$window",
  "DatosCompartidosServiceLS",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    TIPO,
    $filter,
    $uibModal,
    $window,
    DatosCompartidosServiceLS
  ) {
    const TIPOREGISTRO = TIPO.TIPO_REGISTRO.ENVIO;
    const AGENCIASELECLS = "AgenciaSelec";
    const CAMPOSAGENCIASELECLS = "CamposAgenciaSelec";

    var datosCompartidos =
      DatosCompartidosServiceLS.obtenerDatos(CAMPOSAGENCIASELECLS);

    $scope.setActive("vEntrega");
    $scope.setActiveNavBar(true);
    $scope.agencia = DatosCompartidosServiceLS.obtenerDatos(AGENCIASELECLS);
    $scope.camposDinamicos = [];
    $scope.btnRecogerVisitar = "Recoger";
    $scope.sObservacionProveedor = $scope.agencia.sObservacionProveedor ?? "";

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

    if (Object.keys(datosCompartidos).length === 0) {
      getCamposDinamicos()
        .then(() => {
          obtenerDetallesValija();
        })
        .catch(function (error) {
          console.error(error);
        });
    } else {
      $scope.camposDinamicos = datosCompartidos;
      obtenerDetallesValija();
    }

    $scope.modalRegistrarEntrega = () => {
      swal(
        {
          title: "Registrar Entrega",
          text: "\u00bfEst\u00e1s seguro de registrar la entrega?",
          type: "info",
          showCancelButton: true,
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
        }).then( (isConfirm) =>{
          if (isConfirm) {
            registrarEntrega();
          }
        }
      );
    };

    const registrarEntrega = () => {
      var horaServidorFormatted;

      ServiciosApi.getFechaServidor()
        .then((data1) => {
          const fechaServidor = new Date(data1[0].dFechaRecepcion);
          const fechaServidorFormatted = $filter("date")(
            fechaServidor,
            "yyyy-MM-ddTHH:mm:ss"
          );
          horaServidorFormatted = $filter("date")(fechaServidor, "HH:mm:ss");

          return ServiciosApi.registrarEntregaAgencia(
            $scope.agencia.iId,
            fechaServidorFormatted
          );
        })
        .then((data2) => {
          if (data2 === 1) {
            mostrarModal(horaServidorFormatted);
          } else if (data2 === 0) {
            $rootScope.mostrarError(
              "Error",
              "Error al realizar el registro de entrega para esta agencia"
            );
          }
        })
        .catch((error) => {
          $rootScope.mostrarError(
            "Error",
            "No se puede continuar con el registro de entrega. Verificar si se realiz\u00f3 el registro"
          );
        });
    };

    const mostrarModal = (horaServidor) => {
      const scope = $scope.$new();
      scope.tituloModal = "Entrega Proveedor";
      scope.tipoRegistro = "entrega";
      scope.confirmacionRegistro = "Se registr\u00f3 la entrega a la agencia";
      scope.horaRegistro = horaServidor;
      scope.idRegistro = $scope.agencia.iId;
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

    $scope.irAtras = () => {
      $window.history.back();
    };
  },
]);