app.controller("ReporteEntregaRecojoLimaCtrl", [
  "$scope",
  "$rootScope",
  "ServiciosApi",
  "Exportar",
  "$filter",
  "uiGridConstants",
  "TIPO",
  "ESTADOS",
  "$sce",
  "$uibModal",
  function (
    $scope,
    $rootScope,
    ServiciosApi,
    Exportar,
    $filter,
    uiGridConstants,
    TIPO,
    ESTADOS,
    $sce,
    $uibModal
  ) {
    $("#fechaDesde").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaDesde").datepicker("setDate", new Date());
    $("#fechaHasta").datepicker({
      dateFormat: "dd-mm-yy",
      maxDate: 0,
    });
    $("#fechaHasta").datepicker("setDate", new Date());

    const tipoRegistro = TIPO.TIPO_REGISTRO.ENVIO;

    $scope.setActive("vReporte");
    $scope.setActiveNavBar(true);
    $scope.TipoServicioSeleccionado = {};
    $scope.TipoServicioList = [];
    $scope.EstadoRegistroSeleccionado = {};
    $scope.EstadoRegistroList = [];
    $scope.CodNombreAgencia = "";
    $scope.NumComprobante = "";
    $scope.FechaDesde = $("#fechaDesde").val();
    $scope.FechaHasta = $("#fechaHasta").val();
    $scope.NumPrecinto = "";
    $scope.TipoRegistroSeleccionado = {};
    $scope.TipoRegistroList = [];
    $scope.resultados = false;

    var tmpIndicador =
      '<i class="fa fa-flag" style="vertical-align : middle; font-size : 18px;"></i>';
    var tmpVer =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.ver(row)" ng-disabled="grid.appScope.desactivadoVer(row)"><i class="fa fa-eye" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
    var EstadoRegistroListOriginal = [];
    var CampoGridList = [];
    var camposDinamicos = [];
    var ListaCamposDinamicos = [];
    var RegistroEntregaRecojoDataSource = [];

    const myAppScopeProvider = {
      desactivadoVer: (row) => {
        var reg = row.entity;
        if (reg.sImagenRuta === null) return true;
        else return false;
      },
      ver: (row) => {
        var reg = row.entity;
        var ruta = reg.sImagenRuta;
        var nombreArchivo = reg.sImagenNombre;

        ServiciosApi.ObtenerArchivo(ruta)
          .then((resp) => {
            const blob = new Blob([resp], { type: "application/pdf" });
            const url = URL.createObjectURL(blob);
            const protectedUrl = $sce.trustAsResourceUrl(url);
            const scope = $scope.$new();

            scope.ruta = protectedUrl;
            scope.nombreArchivo = nombreArchivo;
            scope.mostrarbtnEliminar = false;

            $uibModal.open({
              animation: true,
              templateUrl: "/parcial/modal/MostrarPDF.html",
              controller: "MostrarPDFCtrl",
              scope: scope,
              windowClass: "modal-centered",
            });
          })
          .catch(function () {
            $rootScope.mostrarError(
              "\u00a1Error!",
              "No se puede mostrar el archivo"
            );
          });
      },
    };

    var setCamposEstaticos = function () {
      CampoGridList = [
        {
          displayName: "N\u00b0",
          name: "indexColumn",
          width: "50",
          enableColumnResizing: true,
          cellTemplate:
            '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row) + 1}}</div>',
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Tipo Servicio",
          field: "sTipoServicio",
          width: "110",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Modalidad de Servicio",
          field: "sTipoRegistro",
          width: "90",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Fecha de Servicio",
          field: "dFechaOrigen",
          width: "90",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "dd/MM/yyyy"',
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Hora de Punto Origen",
          field: "dFechaOrigen",
          width: "85",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "HH:mm"',
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "C\u00f3digo Agencia",
          field: "sIdAgenciaOrigen",
          width: "85",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Nombre Agencia",
          field: "sAgenciaOrigen",
          width: "145",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Fecha Entrega/Recojo",
          field: "dFechaDestino",
          width: "90",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "dd/MM/yyyy"',
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Hora de Punto Destino",
          field: "dFechaDestino",
          width: "85",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "HH:mm"',
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "C\u00f3digo Agencia",
          field: "sIdAgenciaDestino",
          width: "85",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
        {
          displayName: "Nombre Agencia",
          field: "sAgenciaDestino",
          width: "145",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color text-center",
          cellClass: "row-style text-center",
        },
      ];
    };

    var getCamposDinamicos = function () {
        return ServiciosApi.listarCamposDinamicosReporteGDIA()
        .then(function (data) {
          camposDinamicos = [...data];
        })
        .catch(function (error) {
          $rootScope.mostrarError(
            "Error",    
            "No se pudo obtener todos los campos"
          );
        });
    };

    function inicializarCampos() {
      setCamposEstaticos();
      getCamposDinamicos()
        .then(function () {
          camposDinamicos.forEach((value) => {
            var item = {
              field: value.campo,
              name: value.titulo,
              width: value.anchoColumna,
              enableColumnResizing: true,
              filter: { condition: uiGridConstants.filter.CONTAINS },
              headerCellClass: "header-grid-color text-center",
              cellClass: "row-style text-center",
            };
            CampoGridList.push(item);
            ListaCamposDinamicos.push({
              campo: value.campo,
              titulo: value.titulo,
              valorInicial: value.valorInicial,
            });
          });

          CampoGridList.push({
            displayName: "Estado",
            field: "sEstado",
            width: "110",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            headerCellClass: "header-grid-color text-center",
            cellClass: "row-style text-center",
          });

          CampoGridList.push({
            displayName: "Motivo",
            field: "sMotivo",
            width: "115",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            headerCellClass: "header-grid-color text-center",
            cellClass: "row-style text-center",
          });

          CampoGridList.push({
            displayName: "Estado Reprogramaci\u00F3n",
            field: "sEstado2",
            width: "165",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            headerCellClass: "header-grid-color text-center",
            cellClass: "row-style text-center",
          });

          CampoGridList.push({
            displayName: "Fecha de Reprogramaci\u00F3n",
            field: "dFechaReprogramacion",
            width: "160",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            type: "date",
            cellFilter: 'date: "dd/MM/yyyy"',
            headerCellClass: "header-grid-color text-center",
            cellClass: "row-style text-center",
          });

          CampoGridList.push({
            displayName: "Hora de Reprogramaci\u00F3n",
            field: "dFechaReprogramacion",
            width: "150",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            type: "date",
            cellFilter: 'date: "HH:mm"',
            headerCellClass: "header-grid-color text-center",
            cellClass: "row-style text-center",
          });

          CampoGridList.push({
            name: "Imagen Cargo",
            displayName: "Imagen Cargo",
            width: "70",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpVer,
            headerCellClass: "header-grid-color text-center",
            cellClass: "row-style row-button-style text-center",
          });

          CampoGridList.push({
            displayName: "Arco Horario Servicio",
            field: "sRangoHorario",
            width: "125",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            type: "date",
            cellFilter: 'date: "dd/MM/yyyy"',
            headerCellClass: "header-grid-color text-center",
            cellClass: "row-style text-center",
          });

          CampoGridList.push({
            name: "Indicador",
            displayName: "Indicador",
            width: "50",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpIndicador,
            headerCellClass: "header-grid-color",
            cellClass: function (
              _grid,
              row,
              _col,
              _rowRenderIndex,
              _colRenderIndex
            ) {
              return (
                $scope.EvaluarIndicadorClase(row.entity.iIdIndicadorRecojo) +
                " row-style text-center"
              );
            },
          });
        })
        .catch(function () {
          $rootScope.mostrarError("Error", "No se pudo mostrar el registro");
        });

      $scope.GridReporteEntregaRecojo = {
        paginationPageSizes: [10, 50, 75],
        paginationPageSize: 10,
        enableFiltering: true,
        showGridFooter: true,
        columnDefs: CampoGridList,
        appScopeProvider: myAppScopeProvider,
      };
    }

    inicializarCampos();

    function listarTipoServicio() {
      return ServiciosApi.ListarTipoServicio()
        .then((data) => {
          $scope.TipoServicioList = data;
          $scope.TipoServicioSeleccionado = inicializarOpcionesDeSelects(
            $scope.TipoServicioList,
            "iIdTipoServicio",
            "sTipoServicio"
          );
        })
        .catch(function () {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "Hubo un error: Por favor revise su conexi\u00f3n a internet"
          );
        });
    }

    listarTipoServicio();

    function inicializarOpcionesDeSelects(lista, idAttr, valueAttr) {
      if (lista.length > 1) {
        agregarOptionTodosAListas(lista, idAttr, valueAttr);
      }

      return lista[0];
    }

    function agregarOptionTodosAListas(lista, idAttr, valueAttr) {
      lista.unshift({ [idAttr]: 0, [valueAttr]: "TODOS" });
    }

    function listarTipoRegistro() {
      return ServiciosApi.ListarTipoRegistro().then(
        (data) => {
          data.forEach(function (item) {
            if (item.sTipoRegistro === "ENVIO") {
              item.sTipoRegistro = "ENTREGA";
            }
          });
          $scope.TipoRegistroList = [...data];
          $scope.TipoRegistroSeleccionado = inicializarOpcionesDeSelects(
            $scope.TipoRegistroList,
            "iIdTipoRegistro",
            "sTipoRegistro"
          );
        },
        () => {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "Hubo un error: Por favor revise su conexi\u00f3n a internet"
          );
        }
      );
    }

    listarTipoRegistro();

    $scope.SeleccionarTipoRegistro = function () {
      if ($scope.TipoRegistroSeleccionado) {

        if ($scope.TipoRegistroSeleccionado.iIdTipoRegistro === 0) {
          $scope.EstadoRegistroList = [...EstadoRegistroListOriginal];
        } else {
          $scope.EstadoRegistroList = EstadoRegistroListOriginal.filter(
            function (item) {
              return (
                item.iIdTipoRegistro ===
                $scope.TipoRegistroSeleccionado.iIdTipoRegistro
              );
            }
          );
        }

        $scope.EstadoRegistroSeleccionado = inicializarOpcionesDeSelects(
          $scope.EstadoRegistroList,
          "iIdEstadoRegistro",
          "sEstadoRegistro"
        );
      }
    };

    function diferenciarNombrePendientes(lista) {
      lista.forEach((objeto) => {
        if (objeto.iIdEstadoRegistro === ESTADOS.ESTADOS_VALIJA.PENDIENTE_R) {
          objeto.sEstadoRegistro = "PENDIENTE RECOJO";
        } else if (
          objeto.iIdEstadoRegistro === ESTADOS.ESTADOS_VALIJA.PENDIENTE_E
        ) {
          objeto.sEstadoRegistro = "PENDIENTE ENTREGA";
        }
      });

      return lista;
    }

    function listarEstadoRegistro() {
      return ServiciosApi.ListarEstadoRegistro().then(
        (data) => {
          data = diferenciarNombrePendientes(data);
          EstadoRegistroListOriginal = data;
          $scope.EstadoRegistroList = [...EstadoRegistroListOriginal];
          $scope.EstadoRegistroSeleccionado = inicializarOpcionesDeSelects(
            $scope.EstadoRegistroList,
            "iIdEstadoRegistro",
            "sEstadoRegistro"
          );
        },
        () => {
          $rootScope.mostrarError(
            "\u00a1Error!",
            "Hubo un error: Por favor revise su conexi\u00f3n a internet"
          );
        }
      );
    }

    listarEstadoRegistro();

    $scope.SeleccionarEstadoRegistro = function () {
      if ($scope.EstadoRegistroSeleccionado.iIdEstadoRegistro === 0) {
        if (
          $scope.EstadoRegistroList.length > EstadoRegistroListOriginal.length
        ) {
          $scope.TipoRegistroSeleccionado = $scope.TipoRegistroList.find(
            (value) => {
              return value.iIdTipoRegistro === 0;
            }
          );
        }
      } else {
        $scope.TipoRegistroSeleccionado = $scope.TipoRegistroList.find(
          (value) => {
            return (
              value.iIdTipoRegistro ===
              $scope.EstadoRegistroSeleccionado.iIdTipoRegistro
            );
          }
        );
      }
    };

    $scope.BuscaRegistrosConFiltro = function () {
      var fechaDesde = $.datepicker.formatDate(
        "yy-mm-dd",
        $("#fechaDesde")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate")
      );
      var fechaHasta = $.datepicker.formatDate(
        "yy-mm-dd",
        $("#fechaHasta")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate")
      );

      ServiciosApi.getGenerarReporteEntregaRecojoLima(
        fechaDesde,
        fechaHasta,
        $scope.TipoServicioSeleccionado.iIdTipoServicio,
        $scope.CodNombreAgencia,
        $scope.TipoRegistroSeleccionado.iIdTipoRegistro,
        $scope.EstadoRegistroSeleccionado.iIdEstadoRegistro,
        $scope.NumComprobante,
        $scope.NumPrecinto
      )
        .then((data) => {
          if (data.length === 0) {
            $scope.resultados = false;
            $rootScope.mostrarError("Error", "Sin Resultados");
            return;
          }
          $scope.resultados = true;
          RegistroEntregaRecojoDataSource = data;
          $scope.GridReporteEntregaRecojo.data =
            RegistroEntregaRecojoDataSource;
        })
        .catch(() => {
          $rootScope.mostrarError("Error", "Error en la búsqueda");
        });
    };

    $scope.ExportarReporteEntregaRecojo = function () {
      var ObjetoExportar = new Exportar.Objeto();
      var obj = [];
      var datosExportar = [];
      var indice = 1;

      ObjetoExportar.Config.TitleBackgroundColor = "#0070c0";
      ObjetoExportar.Config.TitleFontColor = "#fff";
      ObjetoExportar.cabecera = [
        "N\u00b0",
        "Tipo Servicio",
        "Modalidad de Servicio",
        "Fecha de Servicio",
        "Hora de Punto Origen",
        "C\u00f3digo Agencia",
        "Nombre Agencia",
        "Fecha Entrega/Recojo",
        "Hora de Punto Destino",
        "C\u00f3digo Agencia",
        "Nombre Agencia",
      ];
      ListaCamposDinamicos.forEach((value) => {
        ObjetoExportar.cabecera.push(value.titulo);
      });
      ObjetoExportar.cabecera.push("Estado");
      ObjetoExportar.cabecera.push("Motivo");
      ObjetoExportar.cabecera.push("Estado Reprogramaci\u00F3n");
      ObjetoExportar.cabecera.push("Fecha de Reprogramaci\u00F3n");
      ObjetoExportar.cabecera.push("Hora de Reprogramaci\u00F3n");
      ObjetoExportar.cabecera.push("Imagen Cargo");
      ObjetoExportar.cabecera.push("Arco Horario");
      ObjetoExportar.cabecera.push("Indicador");
      ObjetoExportar.NameReporte = "ReporteServicioEntregaRecojoLima";

      angular.copy(RegistroEntregaRecojoDataSource, datosExportar);

      datosExportar.forEach((value) => {
        obj = [
          indice++,
          value.sTipoServicio,
          value.sTipoRegistro,
          EvaluarFecha(value.dFechaOrigen),
          ObtenerHora(value.dFechaOrigen),
          EvaluarString(value.sIdAgenciaOrigen),
          EvaluarString(value.sAgenciaOrigen),
          EvaluarFecha(value.dFechaDestino),
          ObtenerHora(value.dFechaDestino),
          EvaluarString(value.sIdAgenciaDestino),
          EvaluarString(value.sAgenciaDestino),
        ];
        ListaCamposDinamicos.forEach((campo) => {
          obj.push(EvaluarString(value[campo.campo]));
        });
        obj.push(value.sEstado);
        obj.push(EvaluarString(value.sMotivo));
        obj.push(EvaluarString(value.sEstado2));
        obj.push(EvaluarFecha(value.dFechaReprogramacion));
        obj.push(ObtenerHora(value.dFechaReprogramacion));
        obj.push(EvaluarString(value.sImagenRuta) !== "" ? "S\u00ED" : "No");
        obj.push(value.sRangoHorario);
        obj.push(EvaluarIndicador(value.iIdIndicadorRecojo));

        ObjetoExportar.detalle.push(obj);
      });
      Exportar.ExcelObjeto(ObjetoExportar);
    };

    var EvaluarFecha = function (fecha) {
      if (fecha === null || fecha === "") {
        return "";
      } else {
        date = new Date(fecha);
        return $filter("date")(fecha, "yyyy-MM-dd", "UTC / GMT");
      }
    };

    var ObtenerHora = function (fecha) {
      if (fecha === null || fecha === "") {
        return "";
      } else {
        date = new Date(fecha);
        return $filter("date")(fecha, "HH:mm", "UTC / GMT");
      }
    };

    var EvaluarString = function (valor) {
      if (valor === null || valor === undefined) {
        return "";
      }
      return valor;
    };

    var EvaluarIndicador = function (indicador) {
      switch (indicador) {
        /*Rojo*/
        case 1:
          return $rootScope.msjReporteBanRojo;
        /*Ambar*/
        case 2:
          return $rootScope.msjReporteBanAmbar;
        /*Verde*/
        case 3:
          return $rootScope.msjReporteBanVerde;
        /*Black*/
        case 4:
          return $rootScope.msjReporteBanBlanco;
      }
    };

    $scope.EvaluarIndicadorClase = function (indicador) {
      switch (indicador) {
        /*Rojo*/
        case 1:
          return "indicador-rojo";
        /*Ambar*/
        case 2:
          return "indicador-ambar";
        /*Verde*/
        case 3:
          return "indicador-verde";
        /*Black*/
        case 4:
          return "indicador-blanco";
      }
    };
  },
]);