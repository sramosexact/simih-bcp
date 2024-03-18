app.controller("ReporteIncidenciaLimaCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "$timeout",
  "Exportar",
  "$filter",
  "uiGridConstants",
  "MOTIVOS",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    $timeout,
    Exportar,
    $filter,
    uiGridConstants,
    MOTIVOS
  ) {
    $("#fechaDesdeIncidencia").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaDesdeIncidencia").datepicker("setDate", new Date());
    $("#fechaHastaIncidencia").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaHastaIncidencia").datepicker("setDate", new Date());

    var CampoGridList = [];

    $scope.setActive("vReporte");
    $scope.setActiveNavBar(true);
    $scope.Proveedores = [];
    $scope.verExportar = false;
    $scope.FechaDesde = $("#fechaDesdeIncidencia").val();
    $scope.FechaHasta = $("#fechaHastaIncidencia").val();
    $scope.textoBotonDetalle = "Mostrar detalle";

    var setCamposIncidencias = function () {
      CampoGridList = [
        {
          displayName: "N\u00b0",
          name: "indexColumn",
          width: "60",
          enableColumnResizing: true,
          cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row) + 1}}</div>',
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Mes de Incidencia",
          field: "dFechaIncidencia",
          width: "150",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: "TraduccionMeses",
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Fecha de Incidencia",
          field: "dFechaIncidencia",
          width: "160",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "dd/MM/yyyy"',
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Hora de Incidencia",
          field: "dFechaIncidencia",
          width: "150",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "HH:mm:ss"',
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Tipo Servicio",
          field: "sTipoRegistro",
          width: "110",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "N\u00b0 de Comprobante",
          field: "ComprobanteServicio",
          width: "165",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "C\u00f3digo Agencia",
          field: "idAgencia",
          width: "130",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Nombre Agencia",
          field: "sAgencia",
          width: "145",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Motivo",
          field: "sMotivo",
          width: "170",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Report\u00f3 Incidencia",
            field: "sUsuarioIncidencia",
          width: "170",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
      ];
    };

    const listarProveedores = () => {
      return ServiciosApi.ListarProveedor().then(
        (data) => {
          $scope.Proveedores = data;
          $scope.Proveedores.forEach(function (item) {
            item.detalleMostrado = false;
            item.mostrarError = true;
            item.textoBotonDetalle = "Mostrar detalle";
            item.RegistroIncidenciasDataSource = [];
            item.GridRegistroIncidencias = [];
            item.ArmadoChart = [];
            item.totalIncidencias = 0;
            item.GridRegistroIncidencias = {
              paginationPageSizes: [10, 50, 75],
              paginationPageSize: 10,
              enableFiltering: true,
              showGridFooter: true,
              columnDefs: CampoGridList,
            };
          });
        },
        () => {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "Hubo un error : Por favor revise su conexi\u00f3n a internet"
          );
        }
      );
    };

    $scope.ObtenerAgenciaIncidencias = function () {
      $scope.textoBotonDetalle = "Mostrar detalle";

      var strDesde = $.datepicker.formatDate(
        "yy-mm-dd",
        $("#fechaDesdeIncidencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate")
      );
      var strHasta = $.datepicker.formatDate(
        "yy-mm-dd",
        $("#fechaHastaIncidencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate")
      );

      ServiciosApi.getGenerarReporteIncidenciaLima(strDesde, strHasta)
        .then(function (data) {
          if (data.length === 0) {
            $scope.verExportar = false;
            return;
          }
          $scope.verExportar = true;
          data.forEach(function (obj) {
            $scope.Proveedores.find(function (proveedor) {
              if (
                obj.idProveedor === proveedor.iIdProveedor ||
                obj.idProveedor === null
              ) {
                var color = "";
                var highlight = "";

                switch (obj.idMotivo) {
                  case MOTIVOS.MANIFESTACIONES:
                        color = "#002D74";
                    highlight = "#80ccff";
                    break;
                  case MOTIVOS.HUELGAS:
                        color = "#00B2D5";
                    highlight = "#FF8C65";
                    break;
                  case MOTIVOS.DESASTRES_NATURALES:
                        color = "#2EBF34";
                    highlight = "#65FF8C";
                    break;
                  case MOTIVOS.DIAS_FESTIVOS_PROVINCIAS:
                        color = "#FFB81C";
                    highlight = "#8C65FF";
                    break;
                  case MOTIVOS.CALLES_BLOQUEADAS:
                        color = "#FF4F00";
                    highlight = "#FFED65";
                    break;
                  case MOTIVOS.OTROS:
                        color = "#E00070";
                    highlight = "#65FFF4";
                    break;
                  default:
                    color = "#33FFE0";
                    highlight = "#65FFF4";
                }

                proveedor.ArmadoChart.push({
                  id: obj.idMotivo,
                  value: obj.CantidadMotivos ?? 0,
                  color: color,
                  highlight: highlight,
                  label: obj.Motivo,
                });

                proveedor.totalIncidencias += obj.CantidadMotivos ?? 0;

                proveedor.mostrarError = false;
              }
            });
          });

          if ($scope.Proveedores.length > 0) {
            $timeout(function () {
              $scope.Proveedores.forEach(function (proveedor) {
                if (!proveedor.mostrarError) {
                  $scope.getObtenerDetalleIncidencias(proveedor);
                }

                if (proveedor.ArmadoChart.length > 0) {
                  $("#MainDiv").trigger("create");
                  CrearCanvasReporte(
                    proveedor.ArmadoChart,
                    proveedor.sProveedor
                  );
                }
              });
            }, 200);
          }
        })
        .catch(function () {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener los detalles de incidencias. Int\u00e9ntelo m\u00e1s tarde."
          );
        });
    };

    $scope.IniciarFlujoReporteIncidencias = () => {
      setCamposIncidencias();
      listarProveedores()
        .then(function () {
          $scope.ObtenerAgenciaIncidencias();
        })
        .catch(function () {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener las incidencias. Int\u00e9ntelo m\u00e1s tarde."
          );
        });
    };

    $scope.IniciarFlujoReporteIncidencias();

    $scope.getObtenerDetalleIncidencias = function (proveedor) {
      var pFechaDesde = $.datepicker.formatDate(
        "yy-mm-dd",
        $("#fechaDesdeIncidencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate")
      );
      var pFechaHasta = $.datepicker.formatDate(
        "yy-mm-dd",
        $("#fechaHastaIncidencia")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate")
      );

      ServiciosApi.getGenerarReporteIncidenciasDetalleLima(
        pFechaDesde,
        pFechaHasta,
        proveedor.iIdProveedor
      ).then(
        function (data) {
          proveedor.RegistroIncidenciasDataSource = data;
          proveedor.GridRegistroIncidencias.data =
            proveedor.RegistroIncidenciasDataSource;
        },
        function () {
          swal(
            "Error",
            "Hubo un error : Por favor revise su conexi\u00f3n a internet",
            "error"
          );
        }
      );
      $scope.mostrarErrorDetalle = false;
    };

    $scope.mostrarDetalle = function (proveedor) {
      if (!proveedor.detalleMostrado) {
        proveedor.textoBotonDetalle = "Ocultar detalle";
        proveedor.detalleMostrado = true;
      } else {
        proveedor.detalleMostrado = false;
        proveedor.textoBotonDetalle = "Mostrar detalle";
      }
    };

    function CrearCanvasReporte(detalle, nombre) {
      var ctx = document.getElementById(nombre).getContext("2d");
      window.myDoughnut = new Chart(ctx).Doughnut(detalle, {
        responsive: true,
      });
    }

    $scope.ExportarTablaDetalle = function (proveedor) {
      var ObjetoExportar = new Exportar.Objeto();
      var obj = [];
      var datosExportar = [];
      var indice = 1;

      ObjetoExportar.Config.TitleBackgroundColor = "#1f497d";
      ObjetoExportar.Config.TitleFontColor = "#fff";
      ObjetoExportar.cabecera = [
        "N\u00b0",
        "Mes de Incidencia",
        "Fecha de Incidencia",
        "Hora de Incidencia",
        "Tipo Servicio",
        "N\u00b0 de Comprobante",
        "C\u00f3digo Agencia",
        "Nombre Agencia",
        "Motivo",
        "Report\u00f3 Incidencia",
      ];
      ObjetoExportar.NameReporte = `IncidenciasProveedor_${proveedor.sProveedor}`;
      angular.copy(proveedor.RegistroIncidenciasDataSource, datosExportar);
      datosExportar.forEach(function (value) {
        obj = [
          indice++,
          $filter("TraduccionMeses")(value.dFechaIncidencia),
          $filter("date")(value.dFechaIncidencia, "dd/MM/yyyy"),
          $filter("date")(value.dFechaIncidencia, "HH:mm:ss"),
          value.sTipoRegistro,
          value.ComprobanteServicio,
          value.idAgencia,
          value.sAgencia,
          value.sMotivo,
          value.sUsuarioIncidencia,
        ];

        ObjetoExportar.detalle.push(obj);
      });
      Exportar.ExcelObjeto(ObjetoExportar);
    };

    $scope.ExportarTodasIncidenciasData = function () {
      var ObjetoExportar = new Exportar.Objeto();
      var obj = [];
      var prevDatosExportar = [];
      var datosExportar = [];
      var indice = 1;

      ObjetoExportar.Config.TitleBackgroundColor = "#1f497d";
      ObjetoExportar.Config.TitleFontColor = "#fff";
      ObjetoExportar.cabecera = [
        "N\u00b0",
        "Mes de Incidencia",
        "Fecha de Incidencia",
        "Hora de Incidencia",
        "Tipo Servicio",
        "N\u00b0 de Comprobante",
        "C\u00f3digo Agencia",
        "Nombre Agencia",
        "Motivo",
        "Report\u00f3 Incidencia",
      ];
      ObjetoExportar.NameReporte = `IncidenciasTotal`;

      $scope.Proveedores.forEach(function (prov) {
        if (prov.RegistroIncidenciasDataSource.length > 0)
          prevDatosExportar.push(prov.RegistroIncidenciasDataSource);
      });

      prevDatosExportar.forEach(function (lista) {
        datosExportar = datosExportar.concat(lista);
      });

      datosExportar.sort(function (a, b) {
        var fechaA = new Date(a.dFechaIncidencia);
        var fechaB = new Date(b.dFechaIncidencia);

        return fechaA - fechaB;
      });

      datosExportar.forEach(function (value) {
        obj = [
          indice++,
          $filter("TraduccionMeses")(value.dFechaIncidencia),
          $filter("date")(value.dFechaIncidencia, "dd/MM/yyyy"),
          $filter("date")(value.dFechaIncidencia, "HH:mm:ss"),
          value.sTipoRegistro,
          value.ComprobanteServicio,
          value.idAgencia,
          value.sAgencia,
          value.sMotivo,
          value.idUsuarioIncidencia,
        ];
        ObjetoExportar.detalle.push(obj);
      });

      Exportar.ExcelObjeto(ObjetoExportar);
    };
  },
]);