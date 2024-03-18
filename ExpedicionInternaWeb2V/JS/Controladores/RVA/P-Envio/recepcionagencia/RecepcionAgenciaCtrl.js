app.controller("RecepcionAgenciaCtrl", [
  "$scope",
  "ServiciosApi",
  "$rootScope",
  "DatosCompartidosServiceLS",
  "TIPO",
  "uiGridConstants",
  "$location",
  "DatosCompartidosService",
  function (
    $scope,
    ServiciosApi,
    $rootScope,
    DatosCompartidosServiceLS,
    TIPO,
    uiGridConstants,
    $location,
    DatosCompartidosService
  ) {
    const tipoRegistro = TIPO.TIPO_REGISTRO.ENVIO; //ENVIO = De UTD a Agencia

    var CampoGridList = [];

    $scope.setActive("vRecepcion");
    $scope.setActiveNavBar(true);
    $scope.agenciaCodigo = $rootScope.Usuario.sCodigoAgencia;
    $scope.agenciaNombre = $rootScope.Usuario.sAgencia;

    const getAgencia = () => {
      ServiciosApi.getListarRecepcionAgenciaLima($scope.agenciaCodigo)
        .then((data) => {
          //CAMBIAR POR LISTAR DE ESTA AGENCIA SUS REGISTROS DE ESTADO 6 (LOS CUALES PASARAN A 7)
          console.log(data);
          $scope.gridListEnvio.data = data;
          /*
        $scope.agencia = data.find((value) => {
          return value.sIdAgencia == $rootScope.Usuario.sCodigoAgencia
        })
        if ($scope.agencia) {
          $scope.gridListEnvio.data = [$scope.agencia]

        } else {
          $scope.gridListEnvio.data = []
        }
        */
        })
        .catch(() => {
          $rootScope.mostrarError(
            "No se pudo obtener los detalles de la valija"
          );
        });
    };

    getAgencia();

    var setCamposEstaticos = () => {
      CampoGridList = [
        {
          displayName: "Recojo de UTD",
          field: "dFechaRecojoProveedor",
          width: "145",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"',
          headerCellClass: "header-grid-color",
          cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) {
            return row.entity.iActivo === 1
              ? "row-style"
              : "row-style-disabled";
          },
        },
        {
          displayName: "Proveedor",
          field: "sProveedor",
          width: "90",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          headerCellClass: "header-grid-color",
          cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) {
            return row.entity.iActivo === 1
              ? "row-style"
              : "row-style-disabled";
          },
        },
        {
          displayName: "Entrega a Agencia",
          field: "dFechaEntrega",
          width: "145",
          enableColumnResizing: true,
          filter: { condition: uiGridConstants.filter.CONTAINS },
          type: "date",
          cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"',
          headerCellClass: "header-grid-color",
          cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) {
            return row.entity.iActivo === 1
              ? "row-style"
              : "row-style-disabled";
          },
        },
      ];
    };

    //var tmpRecepcionar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.recepcionar(row.entity)"><i class="fa fa-check" style="vertical-align: top; text-align: center; font-size: 18px;"></i></button>';

    $scope.myAppScopeProvider = {
      recepcionar: function (rowData) {
        console.log("rowData:", rowData);
        DatosCompartidosService.setDatos(rowData);

        $location.path(`/RecepcionAgencia/${rowData.iId}/Detalles`);
      },
    };

    var getCamposDinamicos = () => {
      ServiciosApi.listarCamposDinamicos(tipoRegistro).then(
        (data) => {
          $rootScope.camposDinamicos = [...data];
          console.log("$scope.camposDinamicos:", $scope.camposDinamicos);

          CampoGridList = [];

          setCamposEstaticos();

          angular.forEach(data, (value) => {
            var item = {
              field: value.campo,
              name: value.titulo,
              width: value.anchoColumna,
              enableColumnResizing: true,
              filter: { condition: uiGridConstants.filter.CONTAINS },
              headerCellClass: "header-grid-color",
              cellClass: (grid, row, col, rowRenderIndex, colRenderIndex) => {
                return row.entity.iActivo === 1
                  ? "row-style"
                  : "row-style-disabled";
              },
            };
            CampoGridList.push(item);
          });

          CampoGridList.push({
            name: "Estado",
            field: "sEstado",
            width: "140",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            headerCellClass: "header-grid-color",
            cellClass: function (
              grid,
              row,
              col,
              rowRenderIndex,
              colRenderIndex
            ) {
              return row.entity.iActivo === 1
                ? "row-style"
                : "row-style-disabled";
            },
          });

          CampoGridList.push({
            name: "Tipo traslado",
            field: "Traslado",
            width: "115",
            enableColumnResizing: true,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            headerCellClass: "header-grid-color",
            cellClass: function (
              grid,
              row,
              col,
              rowRenderIndex,
              colRenderIndex
            ) {
              return row.entity.iActivo === 1
                ? "row-style"
                : "row-style-disabled";
            },
          });

          ////MODIFICARLO A SOLO RECEPCIONAR
          //CampoGridList.push({
          //  name: 'Recepcionar',
          //  displayName: 'Recepcionar',
          //  width: '95',
          //  enableFiltering: false,
          //  filter: { condition: uiGridConstants.filter.CONTAINS },
          //  cellTemplate: tmpRecepcionar,
          //  headerCellClass: 'header-grid-color',
          //  cellClass: 'row-style row-button-style'
          //});

          $scope.gridListEnvio = {
            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: CampoGridList,
            appScopeProvider: $scope.myAppScopeProvider,
          };
        },
        function (error) {
          // Manejar errores aquí
        }
      );
    };

    getCamposDinamicos();

    $scope.actualizar = () => {
      getAgencia();
      getCamposDinamicos();
    };

    $scope.gridListEnvio = {
      paginationPageSizes: [10, 50, 75],
      paginationPageSize: 10,
      enableFiltering: true,
      showGridFooter: true,
      columnDefs: CampoGridList,
      appScopeProvider: $scope.myAppScopeProvider,
      onRegisterApi: (gridApi) => {
        $scope.gridApi = gridApi;
      },
    };
  },
]);