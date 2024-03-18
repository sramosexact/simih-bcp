app.controller("ListaEntregaAgenciaCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "DatosCompartidosServiceLS",
  "$location",
  "DatosCompartidosService",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    DatosCompartidosServiceLS,
    $location,
    DatosCompartidosService
  ) {
    const camposAgenciaSelecLS = "CamposAgenciaSelec";
    const agenciaSelecLS = "AgenciaSelec";
    const usuario = $rootScope.Usuario;

    $scope.setActive("vEntrega");
    $scope.setActiveNavBar(true);
    $("#fechaEntregaAgencia").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaEntregaAgencia").datepicker("setDate", new Date());
    $scope.modelFecha = $("#fechaEntregaAgencia").val();

    DatosCompartidosServiceLS.eliminarDatos(camposAgenciaSelecLS);
    DatosCompartidosServiceLS.eliminarDatos(agenciaSelecLS);

    DatosCompartidosService.setDatos("");

    $scope.ObtenerAgencias = () => {
      var fecha;
      if (
        $("#fechaEntregaAgencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate") === null
      ) {
        fecha = new Date();
      } else {
        fecha = $("#fechaEntregaAgencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate");
      }
      ServiciosApi.getListarAgenciasPorEnviar(fecha)
        .then(function (data) {
          $scope.RegistroAgenciasDataSource = data.filter((value) => {
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
            "No se pueden mostrar las agencias para entrega"
          );
        });
    };

    $scope.ObtenerAgencias();

    $scope.irEntregaOIncidencia = (idRegistro) => {
        $location.path("/ProveedorEntregaAgencia/" + idRegistro + "/EntregaOIncidencia");
    };
  },
]);