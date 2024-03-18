app.controller("ListaEnvioUTDCtrl", [
    "$scope",
    "ServiciosApi",
    "$rootScope",
    "TIPO",
    "uiGridConstants",
    "$location",
    "DatosCompartidosService",
    "ESTADOS",
    "$uibModal",
    "config",
  function (
    $scope,
    ServiciosApi,
    $rootScope,
    TIPO,
    uiGridConstants,
    $location,
    DatosCompartidosService,
      ESTADOS,
      $uibModal,
      config
  ) {
    const fechaActual = new Date();
    const tipoRegistro = TIPO.TIPO_REGISTRO.RECOJO;

    var CampoGridList = [];

    $scope.setActive("vEnvio");
    $scope.setActiveNavBar(true);
    $scope.agenciaCodigo = $rootScope.Usuario.sCodigoAgencia;
    $scope.agenciaNombre = $rootScope.Usuario.sAgencia;


    const getListarEnvioPorAgencia = () => {
        ServiciosApi.ListarEnvioPorAgencia($rootScope.Usuario.sCodigoAgencia, fechaActual)
            .then((data) => {
          $scope.agencia = data.find((value) => {
            return value.sIdAgencia == $rootScope.Usuario.sCodigoAgencia;
          });
          if ($scope.agencia) {
            $scope.gridListEnvio.data = [$scope.agencia];
          } else {
            $scope.gridListEnvio.data = [];
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "No se pudo obtener los detalles de la valija"
          );
        });
    };

    getListarEnvioPorAgencia();

    var setCamposEstaticos = () => {
        CampoGridList = [
        {
            name: 'enviar',
            displayName: 'Enviar',
            width: '95',
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpEnviar,
            headerCellClass: 'header-grid-color',
            cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) {
                return row.entity.iIdEstado === 1 && row.entity.iActivo === 1
                    ? "row-style"
                    : "row-style-disabled";
            },
        },   
        {
          displayName: "Recojo de Agencia",
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
          displayName: "Entrega a UTD",
          field: "dFechaRecepcion",
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

    //var tmpModificar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.modificar(row)" ng-disabled="grid.appScope.desactivado(row)"><i class="fa fa-pencil" style="vertical-align: top; text-align: center; font-size: 18px;"></i></button>';
      var tmpEnviar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.enviar(row)" ng-disabled="grid.appScope.desactivadoEnvio(row)"><i class="fa fa-paper-plane" style="vertical-align: top; text-align: center; font-size: 18px;"></i></button>';

    
    $scope.myAppScopeProvider = {
      //modificar: (row) => {
        
      //},
      enviar: (row) => {
        var sIdUsuario = $rootScope.Usuario.Id;
        var sCodigoAgencia = $scope.agencia.sIdAgencia;
        var registroDinamico = [];
        var scope = $scope.$new();
        scope.ag = row.entity;
        scope.camposDinamicos = $rootScope.camposDinamicos;

        $uibModal
        .open({
            animation: true,
            templateUrl: config.Template_Dir + "Template/TmpRegistrarEnvioAgenciaAUTD.html",
            controller: "RegistrarEnvioAgenciaAUTDCtrl",
            scope: scope,
            size: 'sm'
        })
        .result.then(
            function (data) {
                //do logic
            },
            function () {
                // action on popup dismissal.
            }
        );
        
      },
        desactivadoEnvio: (row) => {
            var ag = row.entity;
            if (ag.iIdEstado === 1 && [$scope.agencia].length === 1 && ag.iIdTipoTraslado === 1) return false;
            else return true;
        }
    };

    const getCamposDinamicos = () => {
      ServiciosApi.listarCamposDinamicos(tipoRegistro).then(
        (data) => {
          $rootScope.camposDinamicos = [...data];
          CampoGridList = [];            

          setCamposEstaticos();

          data.forEach((value) => {
            var item = {
              field: value.campo,
              name: value.titulo,
              width: value.anchoColumna,
              enableColumnResizing: true,
              filter: { condition: uiGridConstants.filter.CONTAINS },
              headerCellClass: "header-grid-color",
/*                cellTemplate: `<div class="ui-grid-cell-contents">{{ value.tipoCampo === 3 ? 'xxx' : value.campo }}</div>`,*/
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

          //CampoGridList.push({
          //    name: 'modificar',
          //  displayName: 'Modificar',
          //  width: '95',
          //  enableFiltering: false,
          //    filter: { condition: uiGridConstants.filter.CONTAINS },
          //    cellTemplate: tmpModificar,
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
      getListarEnvioPorAgencia();
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