app.controller("ListaRecojoAgenciaCtrl", [
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

    $scope.setActive("vRecojo");
    $scope.setActiveNavBar(true);
    $("#fechaRecojoAgencia").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaRecojoAgencia").datepicker("setDate", new Date());
    $scope.modelFecha = $("#fechaRecojoAgencia").val();

    DatosCompartidosServiceLS.eliminarDatos(camposAgenciaSelecLS);
    DatosCompartidosServiceLS.eliminarDatos(agenciaSelecLS);

    DatosCompartidosService.setDatos("");

    $scope.ObtenerAgencias = () => {
      var fecha;
      if (
        $("#fechaRecojoAgencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate") === null
      ) {
        fecha = new Date();
      } else {
        fecha = $("#fechaRecojoAgencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate");
      }
      ServiciosApi.getListarVisitaAgenciaLima(fecha)
        .then(function (data) {
          $scope.RegistroAgenciasDataSource = data.filter((value) => {
            return value.iIdTipoUsuario === usuario.iIdProveedor;
          });
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pueden mostrar las agencias para recojo"
          );
        });
    };

    $scope.ObtenerAgencias();

    $scope.irRecojoOIncidencia = (idRegistro) => {
        $location.path("/ProveedorRecojoAgencia/" + idRegistro + "/RecojoOIncidencia");
    };
  },
]);