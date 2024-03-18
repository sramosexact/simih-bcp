/*Controlador de la página RecepcionProvincia.html*/
app.controller('RecepcionarProvinciaCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', '$interval', 'Exportar', 'config', 'uiGridConstants', 'TIPO',
  function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, $interval, Exportar, config, uiGridConstants, TIPO) {

    /*********************
       Configuración
   **********************/
    $scope.setActive('vRecepcion');
    $scope.setActiveNavBar(true);


    /***************************
       Variables Incializadas
   ****************************/
    var tipoAgencia = TIPO.TIPO_AGENCIA.PROVINCIA;
    var tipoRegistro = TIPO.TIPO_REGISTRO.RECOJO;
    var tipoUsuario = $rootScope.Usuarios.IdTipoAcceso;
    $scope.visualizarColumna = false;
    if (tipoUsuario === TIPO.TIPO_USUARIO.SUPERVISOR_UTD_PROVINCIA && $scope.opcionDesactivarProvincia === true) {
      $scope.visualizarColumna = true;
    }
    var AgenciasProvinciaList = [];
    var CampoGridList = [];
    $rootScope.AgenciasRecepcionadasFront = [];
    $rootScope.fecha;
    var i = 0;
    var arreglo;
    $scope.RegistroAgenciasDataSource = [];
    $scope.codAgencia = "";
    $rootScope.proveedorRecepcion = null;
    $rootScope.enRegistro = 0;
    $scope.nombreBotonRegistro = "Iniciar Registro";
    document.getElementById("btnRegistrar").disabled = true;
    document.getElementById("txtCodAgencia").disabled = true;
    $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
    $scope.modelFecha = $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy' }).val();
    $("#datepickerRecojo").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
    $scope.modelFechaRecojo = $("#datepickerRecojo").datepicker({ dateFormat: 'dd-mm-yy' }).val();
    $scope.color = {};
    $scope.recepcionar = true;
    var cambioDeColor;
    var tablaCargada = 0;
    var fechaServidor = new Date();
    var fechaInicioConsulta;
    var fechaActualServidor;
    var ServerDate = new Date();

    /*********************
        Metodos
    **********************/
    /*Funcion para cargar la fecha del servidor*/
    getFechaServidor = function () {
      ServiciosApi.getFechaServidor().then(function (data) {
        ServerDate = new Date(data[0].dFechaRecepcion);
        return ServerDate;
      }, function (error) {
        return null;
      });
    };
    /*Cargando la fecha del servidor*/
    getFechaServidor();

    $scope.getColorPorDescripcion = function (descripcion) {
      var colores = $rootScope.colores;
      var encuentra = false;
      angular.forEach(colores, function (value, key) {
        if ($filter('uppercase')(descripcion) === value.sDescripcion) {
          encuentra = true;
          $scope.color = value;
        }
      });
    };

    $scope.getColorPorId = function (iId) {
      var colores = $rootScope.colores;
      var encuentra = false;
      angular.forEach(colores, function (value, key) {
        if (iId === value.iId) {
          encuentra = true;
          $scope.color = value;
        }
      });
    };

    $rootScope.ObtenerAgencias = function () {
      $scope.RegistroAgenciasDataSource = [];
      var pFecha;
      if ($("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate") === null) {
        pFecha = new Date();
      }
      else {
        pFecha = $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate");
      }
      var controlYearValue = pFecha.getFullYear();
      var controlMonthValue = pFecha.getMonth();
      var controlDayValue = pFecha.getDate();
      var serverYearValue = ServerDate.getFullYear();
      var serverMonthValue = ServerDate.getMonth();
      var serverDayValue = ServerDate.getDate();
      var fechaControl = new Date(controlYearValue, controlMonthValue, controlDayValue);
      var fechaServidor = new Date(serverYearValue, serverMonthValue, serverDayValue);
      if (fechaServidor - fechaControl === 0) {
        $scope.recepcionar = false;
      }
      else {
        $scope.recepcionar = true;
      }
      ServiciosApi.getListarVisitaAgenciaProvincia(pFecha).then(function (data) {
        $scope.RegistroAgenciasDataSource = data;
        $scope.GridRegistroAgencias.data = $scope.RegistroAgenciasDataSource;
      }, function (error) {
        swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
      });
    };

    $scope.getColorIndicador = function (row) {
      if (tablaCargada === 0) {
        $scope.getColorPorId(row.iIdIndicadorRecojo);
        tablaCargada = 1;
        return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
      } else {
        cambioDeColor = false;
        var fecha = new Date();
        var tolerancia = $rootScope.Tolerancia * 60 * 1000;
        var fechaRegistro = null;
        if (row.dFechaRegistro !== null) {
          fechaRegistro = new Date(row.dFechaRegistro);
          fechaRegistro.setTime(fechaRegistro.getTime() + 3600 * 1000 * 5);
        }
        var arcoSuperior = new Date(row.dArcoSuperior);
        arcoSuperior.setTime(arcoSuperior.getTime() + 3600 * 1000 * 5);
        var arcoInferior = new Date(row.dArcoInferior);
        arcoInferior.setTime(arcoInferior.getTime() + 3600 * 1000 * 5);
        var arcoConTolerancia = new Date();
        arcoConTolerancia.setTime(arcoSuperior.getTime() + tolerancia);
        if ((fechaRegistro <= arcoSuperior && fechaRegistro >= arcoInferior) || (fechaRegistro === null && fecha <= arcoSuperior && fecha >= arcoInferior)) {
          $scope.getColorPorDescripcion("verde");
          if (row.iIdIndicadorRecojo !== $scope.color.iId) {
            row.iIdIndicadorRecojo = $scope.color.iId;
            cambioDeColor = true;
          }
          return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
        }
        if ((fechaRegistro > arcoConTolerancia) || (fechaRegistro === null && fecha > arcoConTolerancia)) {
          $scope.getColorPorDescripcion("rojo");
          if (row.iIdIndicadorRecojo !== $scope.color.iId) {
            row.iIdIndicadorRecojo = $scope.color.iId;
            cambioDeColor = true;
          }
          return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
        }
        if ((fechaRegistro >= arcoSuperior) || (fechaRegistro === null && fecha > arcoSuperior)) {
          $scope.getColorPorDescripcion("ambar");
          if (row.iIdIndicadorRecojo !== $scope.color.iId) {
            row.iIdIndicadorRecojo = $scope.color.iId;
            cambioDeColor = true;
          }
          return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
        }
        $scope.getColorPorDescripcion("blanco");
        if (row.iIdIndicadorRecojo !== $scope.color.iId) {
          row.iIdIndicadorRecojo = $scope.color.iId;
          cambioDeColor = true;
        }
        return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
      }
    };

    /*Nombre del botón programación*/
    $scope.getTextoBotonReprogramacion = function (texto) {
      if (texto === 'NORMAL') return 'Registrar';
      return 'Cancelar';
    };

    var setCamposEstaticos = function () {
      CampoGridList = [
        { displayName: 'Codigo', field: 'sIdAgencia', width: '60', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        { displayName: 'Agencia', field: 'sAgencia', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        { displayName: 'Plazo', field: 'iHorasPlazoRecepcion', width: '50', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        { displayName: 'Fecha planeada de llegada a UTD', field: 'dFechaTentativaRecepcion', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy"', headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        { displayName: 'Fecha de recojo', field: 'dFechaRegistro', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm"', headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        { displayName: 'Fecha de recepción', field: 'dFechaRecepcion', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm"', headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        { displayName: 'Arco inf.', field: 'dArcoInferior', width: '70', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "HH:mm"', headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        { displayName: 'Arco sup.', field: 'dArcoSuperior', width: '70', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "HH:mm"', headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } },
        {
          displayName: 'Fecha lectura', field: 'dFechaHoraLectura', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; }, visible: false
        }
      ];
    };

    var tmpModificar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.modificar(row)" ng-disabled="grid.appScope.desactivado(row)"><i class="fa fa-pencil" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
    var tmpLimpiar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.limpiar(row)" ng-disabled="enRegistro"><i class="fa fa-ban" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
    var tmpIndicador = '<i class="fa fa-flag" style="vertical-align : middle; font-size : 18px;"></i>';
    var tmpDesactivar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.desactivar(row)" ng-disabled="grid.appScope.desactivado(row)"><i class="fa fa-times" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';

    $scope.myAppScopeProvider = {
      modificar: function (row) {
        var scope = $scope.$new();
        scope.ag = row.entity;
        scope.camposDinamicos = $rootScope.camposDinamicos;
        scope.tipoAgencia = 2;
        $uibModal.open({
          animation: true,
          templateUrl: '/parcial/Template/TmpModificarProvincia.html',
          controller: 'ModificarRecepcionProvinciaCtrl',
          scope: scope,
          /* size: 'lg'*/
        }).result.then(function (data) {
          //do logic
        }, function () {
          // action on popup dismissal.
        });
        return;
      },
      desactivar: function (row) {
        if ($scope.recepcionar === true) {
          swal("\u00a1Alto!", "Solo puedes eliminar registros del día actual", "error");
          return;
        }
        if ($scope.enRegistro === 1) {
          swal("\u00a1Alto!", "No puedes eliminar un registro de agencia mientras est\u00e1s registrando la recepci\u00f3n de valijas.", "error");
          return;
        }
        var ag = row.entity;
        if (ag.Traslado !== 'NORMAL') {
          swal("\u00a1Alto!", "No puedes eliminar una reprogramación mediante esta opción", "error");
          return;
        }
        var registroModificado = false;
        angular.forEach(ListaCamposDinamicos, function (value, index) {
          if (ag[value.campo] !== value.valorInicial) {
            registroModificado = true;
            return;
          }
        });
        if (registroModificado === true || ag.dFechaRegistro !== ag.dFechaRecepcion) {
          swal("\u00a1Alto!", "No puedes eliminar una registro que ha sido modificado", "error");
          return;
        }
        swal({
          title: "\u00a1Un Momento!",
          text: "Se eliminará el registro a la agencia. \u00bfDesea continuar?",
          type: "warning",
          showCancelButton: true,
          confirmButtonClass: "btn-danger",
          confirmButtonText: "Aceptar",
          cancelButtonText: "Cancelar",
          closeOnConfirm: false,
          closeOnCancel: true
        },
          function (isConfirm) {
            if (isConfirm) {
              ServiciosApi.desactivarRegistro(ag.iId).then(function (data) {
                if (data[0].ERROR === 1) {
                  $rootScope.ObtenerAgencias();
                  swal("\u00a1Registro Eliminado!", "Se ha eliminado el registro.", "success");
                } else if (data[0].ERROR === 0) {
                  swal("Error", data[0].MENSAJE, "error");
                } else if (data[0].ERROR === -2) {
                  swal("Error", data[0].MENSAJE, "error");
                } else if (data[0].ERROR === -3) {
                  swal("Error", data[0].MENSAJE, "error");
                }
                else if (data[0].ERROR === -4) {
                  swal("Error", data[0].MENSAJE, "error");
                } else if (data[0].ERROR === -5) {
                  swal("Error", data[0].MENSAJE, "error");
                }
                else {
                  swal("Error", "Hubo un error, vuelva a intentarlo m\u00e1s tarde.", "error");
                }
              }, function (error) {
                swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet.", "error");
              });
            }
          });
      },
      desactivado: function (row) {
        var ag = row.entity;
        if (ag.iActivo === 1) return false;
        else return true;
      }
    };

    /* Obtener lista de agencias provincia activas*/
    var getAgenciasProvincia = function () {
      ServiciosApi.getAgenciasActivasPorTipo(2).then(function (data) {
        AgenciasProvinciaList = data;
      }, function (error) {
        AgenciasProvinciaList = [];
      });
    };

    $rootScope.camposDinamicos = [];
    var ListaCamposDinamicos = [];

    var getCamposDinamicos = function () {
      ServiciosApi.listarCamposDinamicos(tipoRegistro).then(function (data) {
        $rootScope.camposDinamicos = [...data];
        CampoGridList = [];
        setCamposEstaticos();
        angular.forEach(data, function (value, key) {
          var item = { field: value.campo, name: value.titulo, width: value.anchoColumna, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } };
          CampoGridList.push(item);
          ListaCamposDinamicos.push({ campo: value.campo, titulo: value.titulo, valorInicial: value.valorInicial });
        });

        CampoGridList.push({ name: 'Estado', field: 'sEstado', width: '100', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) { return row.entity.iActivo === 1 ? 'row-style' : 'row-style-disabled'; } });
        CampoGridList.push({ name: 'Modificar', displayName: 'Modificar', width: '60', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpModificar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' });
        CampoGridList.push({ name: 'Desactivar', displayName: 'Eliminar', width: '60', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpDesactivar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style', visible: $scope.visualizarColumna });
        CampoGridList.push({
          name: 'Indicador', displayName: 'Ind.', width: '50', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpIndicador, headerCellClass: 'header-grid-color',
          cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) {
            return $scope.getColorIndicador(row.entity) + ' row-style';
          }
        });
        $scope.GridRegistroAgencias = {
          paginationPageSizes: [10, 50, 75],
          paginationPageSize: 10,
          enableFiltering: true,
          showGridFooter: true,
          enableSorting: true,
          columnDefs: CampoGridList,
          appScopeProvider: $scope.myAppScopeProvider
        };
      }, function (error) {

      });
    };

    getAgenciasProvincia();
    getCamposDinamicos();

    /*Detectando cambio en la fecha*/
    $scope.$watch('valorFecha', $rootScope.ObtenerAgencias());

    /*Función para Iniciar la Recepción de Valijas*/
    $scope.IniciarRecepcion = function () {
      if (i === 0) {
        $rootScope.proveedorRecepcion = null;
        $scope.nombreBotonRegistro = "Terminar Registro";
        ServiciosApi.getFechaServidor().then(function (data) {
          fechaInicioConsulta = new Date();
          fechaServidor = new Date(data[0].dFechaRecepcion);
          fechaServidor.setTime(fechaServidor.getTime());
          $rootScope.fecha = $filter('date')(fechaServidor, 'yyyy-MM-ddTHH:mm:ss');
          document.getElementById("btnRegistrar").disabled = false;
          document.getElementById("txtCodAgencia").disabled = false;
          $rootScope.enRegistro = 1;
          i = 1;
        }, function (error) {

        });
      } else {
        $scope.nombreBotonRegistro = "Iniciar Registro";
        $scope.codAgencia = "";
        if ($rootScope.AgenciasRecepcionadasFront.length > 0) {
          var ObjetoaEnviar = {};
          ObjetoaEnviar.sIdUsuarioRecepcion = $rootScope.Usuario.Id;
          ObjetoaEnviar.dFechaRecepcion = $rootScope.fecha;
          ObjetoaEnviar.AgenciaList = [];
          angular.forEach($rootScope.AgenciasRecepcionadasFront, function (value, index) {
            ObjetoaEnviar.AgenciaList.push({ sId: value.sIdAgencia, dFechaRegistro: value.dFechaRegistro, dFechaHoraLectura: value.dFechaHoraLectura });
          });
          arreglo = JSON.stringify(ObjetoaEnviar);
          ServiciosApi.setRegistrarRecepcionValijaProvincia(arreglo).then(function (data) {
            if (data.length === 0) {
              swal("Error", "Hubo un error, vuelva a intentarlo m\u00e1s tarde.", "error");
              $rootScope.ObtenerAgencias();
              $rootScope.AgenciasRecepcionadasFront = [];
              return;
            }
            $scope.RegistroAgenciasDataSource = data;
            $scope.GridRegistroAgencias.data = $scope.RegistroAgenciasDataSource;
            $rootScope.AgenciasRecepcionadasFront = [];
            swal("\u00a1Registro Terminado!", "Se ha registrado la recepci\u00f3n de las valijas correctamente", "success");
          }, function (error) {
            swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            $rootScope.ObtenerAgencias();
            $rootScope.AgenciasRecepcionadasFront = [];
          });
        } else {
          swal("\u00bfNo hubo valijas?", "No ha registrado ninguna recepci\u00f3n de valija", "error");
        }
        $rootScope.enRegistro = 0;
        i = 0;
        document.getElementById("btnRegistrar").disabled = true;
        document.getElementById("txtCodAgencia").disabled = true;
        $rootScope.AgenciasRecepcionadasFront = [];
      }
    };

    /*Evento que llama a la función RegistrarRecepcion cuando se presiona Enter*/
    $scope.presionar = function (KeyEvent) {
      if (KeyEvent.which === 13) {
        $scope.RegistrarRecepcion();
        return;
      }
    };

    $scope.RegistrarRecepcion = function () {
      if (angular.isUndefined($scope.codAgencia)) {
        swal("\u00a1Formato Incorrecto!", "Por favor, ingrese correctamente el c\u00f3digo de la agencia a registrar.", "error");
        document.getElementById("txtCodAgencia").select();
        return;
      }
      if ($scope.codAgencia === null || $scope.codAgencia.toString().length === 0) {
        swal("\u00a1Te falt\u00f3 algo!", "Por favor, ingrese el c\u00f3digo de la agencia a registrar.", "error");
        document.getElementById("txtCodAgencia").select();
        return;
      }
      var AgenciasRecibidasTemp = [];
      angular.copy($scope.RegistroAgenciasDataSource, AgenciasRecibidasTemp);
      $scope.RegistroAgenciasDataSource = [];
      var agenciaRecibidaTemp = null;
      var codigoValija = "";
      if ($rootScope.codigoValijaProvinciaCompleto) {
        codigoValija = $scope.codAgencia.toString();
      }
      else {
        codigoValija = $scope.codAgencia.toString().substr(0, $scope.codAgencia.toString().trim().length - 2);
      }
      angular.forEach(AgenciasProvinciaList, function (value, key) {
        if ($scope.codAgencia.toString() === value.sIdAgencia || codigoValija === value.sIdAgencia) {
          agenciaRecibidaTemp = Object.assign({}, value);
        }
      });
      if (agenciaRecibidaTemp === null) {
        swal("\u00a1No existe!", "No se encontraron resultados. Verifica el c\u00f3digo ingresado.", "error");
        angular.copy(AgenciasRecibidasTemp, $scope.RegistroAgenciasDataSource);
        $scope.GridRegistroAgencias.data = $scope.RegistroAgenciasDataSource;
        document.getElementById("txtCodAgencia").select();
        return;
      }
      if ($rootScope.proveedorRecepcion === null) {
        $rootScope.proveedorRecepcion = agenciaRecibidaTemp.sProveedor;
      } else {
        if ($rootScope.proveedorRecepcion !== agenciaRecibidaTemp.sProveedor) {
          swal("\u00a1No te confundas!", "En este momento solo puedes registrar la recepci\u00f3n de valijas del proveedor " + agenciaRecibidaTemp.sProveedor + ".", "error");
          document.getElementById("txtCodAgencia").select();
          return;
        }
      }
      var pFechaRecojo;
      if ($("#datepickerRecojo").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate") === null) {
        pFechaRecojo = new Date();
      }
      else {
        pFechaRecojo = $("#datepickerRecojo").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate");
      }
      var controlYearValue = pFechaRecojo.getFullYear();
      var controlMonthValue = pFechaRecojo.getMonth();
      var controlDayValue = pFechaRecojo.getDate();
      var fechaControlRecojo = new Date(controlYearValue, controlMonthValue, controlDayValue);
      var fechaHoraLectura = new Date();

      /** Completar datos del registro temporal */
      agenciaRecibidaTemp.Id = 0;
      agenciaRecibidaTemp.dFechaHoraLectura = fechaHoraLectura;
      agenciaRecibidaTemp.dFechaRegistro = fechaControlRecojo;
      agenciaRecibidaTemp.dFechaRecepcion = $rootScope.fecha;
      agenciaRecibidaTemp.dFechaTentativaRecepcion = $rootScope.fecha;
      agenciaRecibidaTemp.iHorasPlazoRecepcion = 0;
      //agenciaRecibidaTemp.sValija = 'SI';
      //agenciaRecibidaTemp.iValijaOperativa = 2;
      agenciaRecibidaTemp.sComprobanteServicio = '';
      agenciaRecibidaTemp.sObservacion = '';
      agenciaRecibidaTemp.sEstado = "RECEPCIONADO";
      agenciaRecibidaTemp.sIdUsuarioRecepcion = $rootScope.Usuario.Id;
      agenciaRecibidaTemp.iActivo = 1;
      $scope.codAgencia = "";
      var agenciaPorRecepcionadaFront = {
        iId: 0,
        dFechaRecepcion: "",
        sIdUsuarioRecepcion: "",
        dFechaHoraLectura: ""
      };
      agenciaPorRecepcionadaFront.sIdAgencia = agenciaRecibidaTemp.sIdAgencia;
      agenciaPorRecepcionadaFront.iId = agenciaRecibidaTemp.iId;
      agenciaPorRecepcionadaFront.dFechaRegistro = agenciaRecibidaTemp.dFechaRegistro;
      agenciaPorRecepcionadaFront.dFechaRecepcion = agenciaRecibidaTemp.dFechaRecepcion;
      agenciaPorRecepcionadaFront.sIdUsuarioRecepcion = $rootScope.Usuario.Id;
      agenciaPorRecepcionadaFront.dFechaHoraLectura = agenciaRecibidaTemp.dFechaHoraLectura;
      /* Lista de agencias que se visualizaran en la vista*/
      AgenciasRecibidasTemp.push(agenciaRecibidaTemp);
      /* Lista de agencias que serán registradas*/
      $rootScope.AgenciasRecepcionadasFront.push(agenciaPorRecepcionadaFront);
      AgenciasRecibidasTemp.sort((x, y) => {
        var a = new Date(x.dFechaHoraLectura);
        var b = new Date(y.dFechaHoraLectura);
        if (a === b) return 0;
        if (a < b) return 1;
        return -1;
      });
      angular.copy(AgenciasRecibidasTemp, $scope.RegistroAgenciasDataSource);
      $scope.GridRegistroAgencias.data = $scope.RegistroAgenciasDataSource;
      return;

    };

    abrirModalTipoTraslado = function () {
      var modalInstance = $uibModal.open({
        animation: true,
        templateUrl: config.Template_Dir + 'modal/tipoTraslado.html',
        controller: 'tipoTrasladoCtrl',
        size: 'lg'
      }).result.then(function (data) {
        //do logic
      }, function () {
        // action on popup dismissal.
      });
    };

    /*Función para limpiar el registro del recojo de valijas de una agencia*/
    $scope.limpiar = function (ag) {
      if (ag.dFechaRegistro === "" || ag.dFechaRegistro === null) {
        swal("\u00a1Alto!", "No puedes limpiar el registro, no hubo visita a la agencia.", "error");
        return;
      }
      if (ag.dFechaRecepcion !== "" && ag.dFechaRecepcion !== null) {
        swal("\u00a1Alto!", "No puedes limpiar el registro que ya tiene fecha de recepci\u00f3n.", "error");
        return;
      }
      if ($scope.enRegistro === 1) {
        swal("\u00a1Alto!", "No puedes limpiar el registro mientras est\u00e1s registrando la recepci\u00f3n de valijas.", "error");
        return;
      }

      swal({
        title: "\u00a1Un Momento!",
        text: "Se limpiar\u00e1n los datos de la visita a la agencia. \u00bfDesea continuar?",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Aceptar",
        cancelButtonText: "Cancelar",
        closeOnConfirm: false,
        closeOnCancel: true
      },
        function (isConfirm) {
          if (isConfirm) {
            ServiciosApi.setLimpiarDatosVisita(ag.iId).then(function (data) {
              if (data[0].ERROR === 1) {
                $rootScope.ObtenerAgencias();
                swal("\u00a1Registro Limpio!", "Se han limpiado los datos de la visita a la agencia.", "success");
              } else if (data[0].ERROR === -2) {
                swal("Error", data[0].MENSAJE, "error");
              }
              else {
                swal("Error", "Hubo un error, vuelva a intentarlo m\u00e1s tarde.", "error");
              }
            }, function (error) {
              swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet.", "error");
            });
          }
        });
    };

    $scope.GridRegistroAgencias = {
      paginationPageSizes: [10, 50, 75],
      paginationPageSize: 10,
      enableFiltering: true,
      showGridFooter: true,
      enableSorting: true,
      columnDefs: CampoGridList,
      appScopeProvider: $scope.myAppScopeProvider,
      onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }
    };

    /*Funcion para exportar la tabla a un excel*/
    $scope.ExportarData = function () {
      var ObjetoExportar = new Exportar.Objeto();
      ObjetoExportar.Config.TitleBackgroundColor = "#808080";
      ObjetoExportar.Config.TitleFontColor = "#fff";
      ObjetoExportar.cabecera = [
        "Codigo Agencia",
        "Agencia",
        "Horas plazo",
        "Fecha planeada de llegada a UTD",
        "Proveedor",
        "Fecha y hora de recojo",
        "Fecha y hora de recepción",
        "Arco Inferior - Recojo",
        "Arco Superior - Recojo",
        "Arco Inferior - Recepción",
        "Arco Superior - Recepción"
      ];

      angular.forEach(ListaCamposDinamicos, function (value, key) {
        ObjetoExportar.cabecera.push(value.titulo);
      });

      ObjetoExportar.cabecera.push("Observacion");
      ObjetoExportar.cabecera.push("Cumplimiento recojo");
      ObjetoExportar.cabecera.push("Cumplimiento recepción");
      ObjetoExportar.cabecera.push("Hora de recojo de OFICINA");
      ObjetoExportar.cabecera.push("Hora de llegada a UTD");

      ObjetoExportar.NameReporte = "RecepcionValija";
      var obj = [];
      var datosExportar = [];
      angular.copy($scope.RegistroAgenciasDataSource, datosExportar);
      datosExportar = $filter('orderBy')(datosExportar, 'Traslado');
      angular.forEach(datosExportar, function (value, index) {

        obj = [
          value.sIdAgencia,
          value.sAgencia,
          value.iHorasPlazoRecepcion,
          EvaluarSoloFecha(value.dFechaTentativaRecepcion),
          value.sProveedor,
          EvaluarFecha(value.dFechaRegistro),
          EvaluarFecha(value.dFechaRecepcion),
          EvaluarFecha(value.dArcoInferior),
          EvaluarFecha(value.dArcoSuperior),
          EvaluarFecha(value.dArcoInferiorRecepcion),
          EvaluarFecha(value.dArcoSuperiorRecepcion)

        ];
        angular.forEach(ListaCamposDinamicos, function (campo, key) {
          obj.push(value[campo.campo]);
        });
        obj.push(EvaluarString(value.sObservacion));
        obj.push(EvaluarIndicador(value.iIdIndicadorRecojo));
        obj.push(EvaluarIndicadorProvincia(value.iIdIndicadorRecojo));
        obj.push(ObtenerHora(value.dFechaRegistro));
        obj.push(ObtenerHora(value.dFechaRecepcion));
        ObjetoExportar.detalle.push(obj);
      });
      Exportar.ExcelObjeto(ObjetoExportar);
    };

    $scope.ExportarFormato = function () {
      var ObjetoExportar = new Exportar.Objeto();
      ObjetoExportar.Config.TitleBackgroundColor = "#808080";
      ObjetoExportar.Config.TitleFontColor = "#fff";
      ObjetoExportar.cabecera = [
        "Codigo Agencia",
        "Agencia",
        "Proveedor",
        "Fecha y hora de recojo",
        "Fecha y hora de recepción",
        "Observacion"
      ];
      angular.forEach(ListaCamposDinamicos, function (value, key) {
        ObjetoExportar.cabecera.push(value.titulo);
      });
      ObjetoExportar.NameReporte = "ContingenciaProvincia";
      var obj = [];
      var datosExportar = [];
      angular.copy($scope.RegistroAgenciasDataSource, datosExportar);
      datosExportar = $filter('orderBy')(datosExportar, 'Traslado');
      obj = [
        '90009',
        'AGENCIA EJEMPLO',
        'HERMES',
        '20/08/2020 13:30',
        '20/08/2020 16:30',
        ''
      ];
      angular.forEach(ListaCamposDinamicos, function (campo, key) {
        obj.push(campo.valorInicial);
      });
      ObjetoExportar.detalle.push(obj);
      Exportar.ExcelObjeto(ObjetoExportar);
    };

    /*Funcion para cambiar una fecha null a un texto vacio*/
    var EvaluarFecha = function (fecha) {
      if (fecha === null || fecha === "") {
        return "";
      }
      else {
        date = new Date(fecha);
        return $filter('date')(fecha, 'yyyy-MM-dd HH:mm:ss', 'UTC / GMT');
      }
    };

    var ObtenerModalidad = function (value) {
      var tipoTraslado = value.Traslado === "NORMAL" ? "" : "REPROGRAMACION ";
      var distancia = estaContenido(agenciasLejanas, value.sIdAgencia) ? ". LEJANO" : " REGULAR";
      return "OFICINA LIMA A UTD - SERV" + tipoTraslado + distancia;
    };


    var estaContenido = function (array, value) {
      for (var i = 0; i < array.length; i++) {
        if (array[i] === value) {
          return true;
        }
      }
      return false;
    };

    var EvaluarSoloFecha = function (fecha) {
      if (fecha === null || fecha === "") {
        return "";
      }
      else {
        date = new Date(fecha);
        return $filter('date')(fecha, 'yyyy-MM-dd', 'UTC / GMT');
      }
    };

    var ObtenerHora = function (fecha) {
      if (fecha === null || fecha === "") {
        return "";
      }
      else {
        date = new Date(fecha);
        return $filter('date')(fecha, 'HH:mm', 'UTC / GMT');
      }
    };

    var EvaluarString = function (valor) {
      if (valor === null || valor === undefined) {
        return "";
      }
      return valor;
    };

    /*Funcion para poner una descripcion al indicador*/
    var EvaluarIndicador = function (indicador) {
      var resultado = $rootScope.msjReporteBanBlanco;
      switch (indicador) {
        /*Rojo*/
        case 1:
          resultado = $rootScope.msjReporteBanRojo;
          break;
        /*Ambar*/
        case 2:
          resultado = $rootScope.msjReporteBanAmbar;
          break;
        /*Verde*/
        case 3:
          resultado = $rootScope.msjReporteBanVerde;
          break;
        /*Black*/
        case 4:
          resultado = $rootScope.msjReporteBanBlanco;
          break;
      }
      return resultado;
    };

    var EvaluarIndicadorProvincia = function (indicador) {
      switch (indicador) {
        /*Rojo*/
        case 1:
          return $rootScope.msjReporteBanRojoPro;
        //break;
        /*Ambar*/
        case 2:
          return $rootScope.msjReporteBanAmbarPro;
        //break;
        /*Verde*/
        case 3:
          return $rootScope.msjReporteBanVerdePro;
        //break;
        /*Black*/
        case 4:
          return $rootScope.msjReporteBanBlancoPro;
        //break;
      }
    };

    /*mostrarNumeroValijas*/
    $scope.mostrarNumeroValijas = function (sEstado, iValijas) {
      if (sEstado === 'PENDIENTE') {
        return '';
      }
      return iValijas;
    };

    /*Llamando la recarga cada 1 minuto*/
    //$interval(recargarTabla, 600);

    /*Llamando a las agencias*/
    $rootScope.ObtenerAgencias();

    window.onbeforeunload = function (event) {
      if (i === 1) {
        return "Aviso: Por favor finalice la recepci\u00f3n de las agencias, en caso contrario perder\u00E1 sus cambios.";
      }
    };

    /*Evitar que el backspace retroceda a la ventana anterior*/
    $(document).unbind('keydown').bind('keydown', function (event) {
      var doPrevent = false;
      if (event.keyCode === 8) {
        var d = event.srcElement || event.target;
        if ((d.tagName.toUpperCase() === 'INPUT' &&
          (
            d.type.toUpperCase() === 'TEXT' ||
            d.type.toUpperCase() === 'PASSWORD' ||
            d.type.toUpperCase() === 'FILE' ||
            d.type.toUpperCase() === 'SEARCH' ||
            d.type.toUpperCase() === 'EMAIL' ||
            d.type.toUpperCase() === 'NUMBER' ||
            d.type.toUpperCase() === 'DATE')
        ) ||
          d.tagName.toUpperCase() === 'TEXTAREA') {
          doPrevent = d.readOnly || d.disabled;
        }
        else {
          doPrevent = true;
        }
      }
      if (doPrevent) {
        event.preventDefault();
      }
    });

    /*Evitar que salga de la pantalla cuando se recepciona las valijas*/
    $scope.$on('$locationChangeStart', function (event) {
      if ($rootScope.enRegistro === 1) {
        swal("\u00a1Un momento...!", "No puedes salir mientras est\u00e1s registrando la recepci\u00f3n de valijas.", "error");
        event.preventDefault();
      }

    });


  }]);



