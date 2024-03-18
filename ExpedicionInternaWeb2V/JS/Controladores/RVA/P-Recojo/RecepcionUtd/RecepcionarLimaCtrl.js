/*Controlador de la página RecepcionLima.html*/
app.controller("RecepcionarLimaCtrl", [
  "$scope",
  "$rootScope",
  "$sce",
  "ServiciosApi",
  "$filter",
  "$uibModal",
  "$interval",
  "Exportar",
  "config",
  "uiGridConstants",
  "TIPO",
  "ESTADOS",
  function (
    $scope,
    $rootScope,
    $sce,
    ServiciosApi,
    $filter,
    $uibModal,
    $interval,
    Exportar,
    config,
    uiGridConstants,
    TIPO,
    ESTADOS
  ) {
    /*********************
       Configuración
   **********************/
    $scope.setActive("vRecepcion");
    $scope.setActiveNavBar(true);

    /***************************
       Variables Incializadas
   ****************************/
    var tipoAgencia = TIPO.TIPO_AGENCIA.LIMA;
    var tipoRegistro = TIPO.TIPO_REGISTRO.RECOJO;
      var tipoUsuario = $rootScope.Usuario.IdTipoAcceso;
      var recojoVisible = $rootScope.RECOJO_PROVEEDOR;

      $scope.model = {};

    $scope.visualizarColumnaLima = false;
    if (
      tipoUsuario === TIPO.TIPO_USUARIO.SUPERVISOR_UTD_LIMA &&
      $scope.opcionDesactivarLima === true
    ) {
      $scope.visualizarColumnaLima = true;
    }
    var CampoGridList = [];
    $rootScope.AgenciasRecepcionadasFront = [];
    $rootScope.agenciasRecepcionadas = [];
    $rootScope.fecha;
    var i = 0;
    var arreglo;
    $scope.RegistroAgenciasDataSource = [];
    //$scope.codAgencia = "";
    $rootScope.proveedorRecepcion = null;
    $scope.enRegistroBool = false;
    $rootScope.enRegistro = 0;
    $scope.esSupervisor = false;
    $scope.nombreBotonRegistro = "Iniciar Registro";
    document.getElementById("btnRegistrar").disabled = true;
    document.getElementById("txtCodAgencia").disabled = true;
    $("#fechaRecepcion")
      .datepicker({ dateFormat: "dd-mm-yy", maxDate: "0" })
      .datepicker("setDate", new Date());
    $scope.modelFecha = $("#fechaRecepcion")
      .datepicker({ dateFormat: "dd-mm-yy" })
      .val();
    $scope.color = {};
    var cambioDeColor;
    var tablaCargada = 0;

    /*********************
        Metodos
    **********************/
    $scope.getColorPorDescripcion = function (descripcion) {
      var colores = $rootScope.colores;
      var encuentra = false;
      angular.forEach(colores, function (value, key) {
        if ($filter("uppercase")(descripcion) === value.sDescripcion) {
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
      if (
        $("#fechaRecepcion")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate") === null
      ) {
        pFecha = new Date();
      } else {
        pFecha = $("#fechaRecepcion")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate");
      }
      ServiciosApi.getListarVisitaAgenciaLima(pFecha).then(
        function (data) {
          $scope.RegistroAgenciasDataSource = data;
          $scope.GridRegistroAgencias.data = $scope.RegistroAgenciasDataSource;
        },
        function (error) {
          swal(
            "Error",
            "Hubo un error : Por favor revise su conexi\u00f3n a internet",
            "error"
          );
        }
      );
    };

    /*Poniendo color a los indicadores*/
    $scope.getColorIndicador = function (row) {
      if (tablaCargada === 0) {
        $scope.getColorPorId(row.iIdIndicadorRecojo);
        tablaCargada = 1;
        //return 'indicador-' + angular.lowercase($scope.color.sDescripcion);
        return "indicador-" + $scope.color.sDescripcion.toLowerCase();
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

        if (
          (fechaRegistro <= arcoSuperior && fechaRegistro >= arcoInferior) ||
          (fechaRegistro === null &&
            fecha <= arcoSuperior &&
            fecha >= arcoInferior)
        ) {
          $scope.getColorPorDescripcion("verde");
          if (row.iIdIndicadorRecojo !== $scope.color.iId) {
            row.iIdIndicadorRecojo = $scope.color.iId;
            cambioDeColor = true;
          }
          //return 'indicador-' + angular.lowercase($scope.color.sDescripcion);
          return "indicador-" + $scope.color.sDescripcion.toLowerCase();
        }

        if (
          fechaRegistro > arcoConTolerancia ||
          (fechaRegistro === null && fecha > arcoConTolerancia)
        ) {
          $scope.getColorPorDescripcion("rojo");
          if (row.iIdIndicadorRecojo !== $scope.color.iId) {
            row.iIdIndicadorRecojo = $scope.color.iId;
            cambioDeColor = true;
          }
          //return 'indicador-' + angular.lowercase($scope.color.sDescripcion);
          return "indicador-" + $scope.color.sDescripcion.toLowerCase();
        }

        if (
          fechaRegistro >= arcoSuperior ||
          (fechaRegistro === null && fecha > arcoSuperior)
        ) {
          $scope.getColorPorDescripcion("ambar");
          if (row.iIdIndicadorRecojo !== $scope.color.iId) {
            row.iIdIndicadorRecojo = $scope.color.iId;
            cambioDeColor = true;
          }

          //return 'indicador-' + angular.lowercase($scope.color.sDescripcion);
          return "indicador-" + $scope.color.sDescripcion.toLowerCase();
        }
        $scope.getColorPorDescripcion("blanco");
        if (row.iIdIndicadorRecojo !== $scope.color.iId) {
          row.iIdIndicadorRecojo = $scope.color.iId;
          cambioDeColor = true;
        }

        //return 'indicador-' + angular.lowercase($scope.color.sDescripcion);
        return "indicador-" + $scope.color.sDescripcion.toLowerCase();
      }
    };

    /*Nombre del botón programación*/
    $scope.getTextoBotonReprogramacion = function (texto) {
      if (texto === "NORMAL") return "Registrar";
      return "Cancelar";
    };

    /*Abrir el módulo de reprogramación*/
    var abrirRegistrarReprogramacion = function (ag) {
      var encuentra = false;
      var fechaTraslado = new Date(ag.dFecha);
      fechaTraslado.setTime(fechaTraslado.getTime() + 3600 * 1000 * 5);
      var diaTraslado =
        fechaTraslado.getDate() + fechaTraslado.getMonth() * 100;
      var diaActual = new Date();
      diaActual = diaActual.getDate() + diaActual.getMonth() * 100;

      if (diaTraslado !== diaActual) {
        swal(
          "Error",
          "No puedes registrar Reprogramaci\u00f3n para traslados de dias anteriores.",
          "error"
        );
        return;
      }

      angular.forEach(
        $scope.RegistroAgenciasDataSource,
        function (value, index) {
          if (
            value.sIdAgencia === ag.sIdAgencia &&
            value.Traslado !== "NORMAL"
          ) {
            swal("Error", "La agencia ya tiene reprogramaci\u00f3n", "error");
            encuentra = true;
            return;
          }
        }
      );
      /*Si no encuentra*/
      if (encuentra === false) {
        $rootScope.AgenciaParaRegistrarReprogramacion = ag;
        var modalInstance = $uibModal
          .open({
            animation: true,
            templateUrl: config.Template_Dir + "modal/RegReprogramacion.html",
            controller: "RegistrarReprogramacionCtrl",
            /*size: 'lg'*/
          })
          .result.then(
            function (data) {
              //do logic
            },
            function () {
              // action on popup dismissal.
            }
          );
      }
    };

    var setCamposEstaticos = function () {
      CampoGridList = [
        {
          displayName: "Codigo",
          field: "sIdAgencia",
          width: "60",
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
          displayName: "Agencia",
          field: "sAgencia",
          width: "120",
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
          displayName: "Proveedor",
          field: "sProveedor",
          width: "70",
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
          displayName: "Fecha de envío",
          field: "dFechaRegistro",
          width: "120",
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
          displayName: "Fecha recojo proveedor",
          field: "dFechaRecojoProveedor",
          width: "120",
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
          visible: recojoVisible,
        },
        {
          displayName: "Fecha de recepción",
          field: "dFechaRecepcion",
          width: "120",
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
          displayName: "Arco inferior",
          field: "dArcoInferior",
          width: "120",
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
          displayName: "Arco superior",
          field: "dArcoSuperior",
          width: "120",
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

    var tmpReprogramar =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.gestionarReprogramacion(row)" ng-disabled="$scope.enRegistroBool"><i class="fa fa-refresh" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';
    var tmpModificar =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.modificar(row)" ng-disabled="enRegistroBool"><i class="fa fa-pencil" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';
    var tmpLimpiar =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.limpiar(row)" ng-disabled="enRegistroBool"><i class="fa fa-ban" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
    var tmpIndicador =
      '<i class="fa fa-flag" style="vertical-align : middle; font-size : 18px;"></i>';
    var tmpDesactivar =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.desactivar(row)" ng-disabled="grid.appScope.desactivado(row)"><i class="fa fa-times" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
    var tmpSubir =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.subir(row)" ng-disabled="enRegistroBool"><i class="fa fa-upload" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
    var tmpVer =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.ver(row)" ng-disabled="grid.appScope.desactivadoVer(row)"><i class="fa fa-eye" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';

    $scope.myAppScopeProvider = {
      modificar: function (row) {
        var scope = $scope.$new();
        scope.ag = row.entity;
        scope.camposDinamicos = $rootScope.camposDinamicos;

        if ($scope.enRegistro === 1) {
          swal(
            "\u00a1Alto!",
            "No puedes modificar el registro mientras est\u00e1s registrando la recepci\u00f3n de valijas.",
            "error"
          );
          return;
        }

        $uibModal
          .open({
            animation: true,
            templateUrl: config.Template_Dir + "Template/TmpModificarLima.html",
            controller: "ModificarRecepcionLimaCtrl",
            scope: scope,
              size: 'lg'
          })
          .result.then(
            function (data) {
              //do logic
            },
            function () {
              // action on popup dismissal.
            }
          );
        return;
      },
      limpiar: function (row) {
        var ag = row.entity;

        if ($scope.enRegistro === 1) {
          swal(
            "\u00a1Alto!",
            "No puedes limpiar el registro mientras est\u00e1s registrando la recepci\u00f3n de valijas.",
            "error"
          );
          return;
        }

        if (ag.dFechaRegistro === "" || ag.dFechaRegistro === null) {
          swal(
            "\u00a1Alto!",
            "No puedes limpiar el registro, no hubo visita a la agencia.",
            "error"
          );
          return;
        }

        if (ag.dFechaRecepcion !== "" && ag.dFechaRecepcion !== null) {
          if ($rootScope.Usuario.Nombre === $rootScope.perfil) {
            swal(
              "\u00a1Alto!",
              "No puedes limpiar el registro que ya tiene fecha de recepci\u00f3n.",
              "error"
            );
            return;
          } else {
            if ($scope.opcionDesactivarLima === false) {
              swal(
                "\u00a1Alto!",
                "No puedes limpiar el registro que ya tiene fecha de recepci\u00f3n.",
                "error"
              );
              return;
            }
          }
        }

        swal(
          {
            title: "\u00a1Un Momento!",
            text: "Se limpiar\u00e1n los datos de la visita a la agencia. \u00bfDesea continuar?",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
          }).then( (isConfirm) => {
            if (isConfirm) {
              ServiciosApi.setLimpiarDatosVisita(ag.iId).then(
                function (data) {
                  if (data[0].ERROR === 1) {
                    $rootScope.ObtenerAgencias();
                    swal(
                      "\u00a1Registro Limpio!",
                      "Se han limpiado los datos de la visita a la agencia.",
                      "success"
                    );
                  } else if (data[0].ERROR === -2) {
                    swal("Error", data[0].MENSAJE, "error");
                  } else {
                    swal(
                      "Error",
                      "Hubo un error, vuelva a intentarlo m\u00e1s tarde.",
                      "error"
                    );
                  }
                },
                function (error) {
                  swal(
                    "Error",
                    "Hubo un error : Por favor revise su conexi\u00f3n a internet.",
                    "error"
                  );
                }
              );
            }
          });
      },
      getTextoBotonReprogramacion: function (texto) {
        if (texto === "NORMAL") return "Registrar";
        return "Cancelar";
      },
      gestionarReprogramacion: function (row) {
        if ($scope.enRegistro === 1) {
          swal(
            "\u00a1Alto!",
            "No puedes reprogramar una agencia mientras est\u00e1s registrando la recepci\u00f3n de valijas.",
            "error"
          );
          return;
        }

        var ag = row.entity;

        if (ag.Traslado === "NORMAL") {
          abrirRegistrarReprogramacion(ag);
        } else {
          if (ag.iIdEstado !== 1) {
            swal(
              "Error",
              "Solo puedes cancelar la reprogramaci\u00f3n que est\u00e1 en estado PENDIENTE.",
              "error"
            );
            return;
          }
          swal(
            {
              title: "\u00a1Un Momento!",
              text:
                "Se cancelar\u00e1 la reprogramaci\u00f3n de la agencia " +
                ag.sIdAgencia +
                ". \u00bfDesea continuar?",
              type: "warning",
              showCancelButton: true,
              confirmButtonClass: "btn-danger",
              confirmButtonText: "Aceptar",
              cancelButtonText: "Cancelar",
            }).then( (isConfirm) => {
              if (isConfirm) {
                ServiciosApi.setCancelarReprogramacion(ag.iId).then(
                  function (data) {
                    if (data === 1) {
                      $rootScope.ObtenerAgencias();
                      swal(
                        "\u00a1Reprogramaci\u00f3n Cancelada!",
                        "Se ha cancelado la reprogramaci\u00f3n de la agencia " +
                        ag.sIdAgencia +
                        ".",
                        "success"
                      );
                    } else {
                      swal(
                        "Error",
                        "Hubo un error, vuelva a intentarlo m\u00e1s tarde.",
                        "error"
                      );
                    }
                  },
                  function (error) {
                    swal(
                      "Error",
                      "Hubo un error : Por favor revise su conexi\u00f3n a internet.",
                      "error"
                    );
                  }
                );
              }
            });
        }
      },
      desactivar: function (row) {
        if ($scope.recepcionar === true) {
          swal(
            "\u00a1Alto!",
            "Solo puedes desactivar registros del día actual",
            "error"
          );
          return;
        }

        if ($scope.enRegistro === 1) {
          swal(
            "\u00a1Alto!",
            "No puedes desactivar un registro de agencia mientras est\u00e1s registrando la recepci\u00f3n de valijas.",
            "error"
          );
          return;
        }

        var ag = row.entity;

        if (ag.Traslado !== "NORMAL") {
          swal(
            "\u00a1Alto!",
            "No puedes desactivar una reprogramación",
            "error"
          );
          return;
        }

        var registroModificado = false;

        angular.forEach(ListaCamposDinamicos, function (value, index) {
          if (ag[value.campo] !== value.valorInicial) {
            registroModificado = true;
            return;
          }
        });

        if (registroModificado === true) {
          swal(
            "\u00a1Alto!",
            "No puedes desactivar una registro que ha sido modificado",
            "error"
          );
          return;
        }

        swal(
          {
            title: "\u00a1Un Momento!",
            text: "Se desactivará el registro a la agencia. \u00bfDesea continuar?",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
          }).then( (isConfirm) => {
            if (isConfirm) {
              ServiciosApi.desactivarRegistro(ag.iId).then(
                function (data) {
                  if (data[0].ERROR === 1) {
                    $rootScope.ObtenerAgencias();
                    swal(
                      "\u00a1Registro Desactivado!",
                      "Se ha desactivado el registro.",
                      "success"
                    );
                  } else if (data[0].ERROR === 0) {
                    swal("Error", data[0].MENSAJE, "error");
                  } else if (data[0].ERROR === -2) {
                    swal("Error", data[0].MENSAJE, "error");
                  } else if (data[0].ERROR === -3) {
                    swal("Error", data[0].MENSAJE, "error");
                  } else if (data[0].ERROR === -4) {
                    swal("Error", data[0].MENSAJE, "error");
                  } else if (data[0].ERROR === -5) {
                    swal("Error", data[0].MENSAJE, "error");
                  } else {
                    swal(
                      "Error",
                      "Hubo un error, vuelva a intentarlo m\u00e1s tarde.",
                      "error"
                    );
                  }
                },
                function (error) {
                  swal(
                    "Error",
                    "Hubo un error : Por favor revise su conexi\u00f3n a internet.",
                    "error"
                  );
                }
              );
            }
          });
      },
      desactivado: function (row) {
        var ag = row.entity;

        if (ag.iActivo === 1) return false;
        else return true;
      },
      desactivadoVer: (row) => {
        var ag = row.entity;
        if (ag.sRuta === null) return true;
        else return false;
      },
      subir: (row) => {
        var ag = row.entity;
        var fileInput = angular.element(
          '<input type="file" accept=".pdf" style="display: none" />'
        );
        angular.element(document.body).append(fileInput);
        fileInput[0].click();

        fileInput.on("change", function () {
          swal(
            {
              title: "Subir Archivo",
              text: "Al aceptar se subirá el archivo seleccionado. ¿Desea continuar?",
              type: "info",
              showCancelButton: true,
              confirmButtonText: "Aceptar",
              cancelButtonText: "Cancelar",
            }).then( (isConfirm) => {
              if (isConfirm) {
                ServiciosApi.getFechaServidor()
                  .then((data) => {
                    var fechaServidor = new Date(data[0].dFechaRecepcion);
                    fechaServidor = $filter("date")(
                      fechaServidor,
                      "yyyy-MM-ddTHH:mm:ss"
                    );
                    var nombreArchivo = fileInput[0].files[0].name.replace(
                      ".pdf",
                      ""
                    );
                    return ServiciosApi.SubirArchivo(
                      nombreArchivo,
                      ag.iId,
                      fileInput[0].files[0],
                      fechaServidor
                    );
                  })
                  .then((resp) => {
                    if (resp === 1) {
                      $scope.ObtenerAgencias();
                      $rootScope.mostrarSuccess(
                        "¡Archivo Subido!",
                        "Se ha subido correctamente el archivo seleccionado."
                      );
                    } else {
                      throw new Error();
                    }
                  })
                  .catch(() => {
                    $rootScope.mostrarError(
                      "¡Error!",
                      "Hubo un error al guardar el archivo. Inténtelo más tarde"
                    );
                  });
              }
              fileInput.remove();
            });
        });
      },
      ver: (row) => {
        var ag = row.entity;
        var ruta = ag.sRuta;
        var nombreArchivo = ag.sNombre;
        var idRegistro = ag.iId;

        ServiciosApi.ObtenerArchivo(ruta)
          .then((resp) => {
            const blob = new Blob([resp], { type: "application/pdf" });
            const url = URL.createObjectURL(blob);
            const protectedUrl = $sce.trustAsResourceUrl(url);

            const scope = $scope.$new();
            scope.ruta = protectedUrl;
            scope.nombreArchivo = nombreArchivo;
            scope.idRegistro = idRegistro;
            scope.mostrarbtnEliminar = true;

            $uibModal
              .open({
                animation: true,
                templateUrl: config.Template_Dir + "modal/MostrarPDF.html",
                controller: "MostrarPDFCtrl",
                scope: scope,
                windowClass: "modal-centered",
              })
              .result.then((isEliminado) => {
                if (isEliminado) {
                  setTimeout($scope.ObtenerAgencias, 1000);
                }
              })
              .catch(() => {
                //
              });
          })
          .catch(function () {
            $rootScope.mostrarError(
              "¡Error!",
              "No se puede mostrar el archivo"
            );
          });
      },
    };

    $rootScope.camposDinamicos = [];

    var ListaCamposDinamicos = [];

    var getCamposDinamicos = function () {
      ServiciosApi.listarCamposDinamicos(tipoRegistro).then(
        function (data) {
          $rootScope.camposDinamicos = [...data];
          CampoGridList = [];
          setCamposEstaticos();

          angular.forEach(data, function (value, key) {
            var item = {
              field: value.campo,
              name: value.titulo,
              width: value.anchoColumna,
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
            };
            CampoGridList.push(item);
            ListaCamposDinamicos.push({
              campo: value.campo,
              titulo: value.titulo,
              valorInicial: value.valorInicial,
            });
          });

          CampoGridList.push({
            name: "Estado",
            field: "sEstado",
            width: "100",
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
            width: "100",
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
            name: "Reprogramar",
            displayName: "Reprogramar",
            width: "60",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpReprogramar,
            headerCellClass: "header-grid-color",
            cellClass: "row-style row-button-style",
          });
          CampoGridList.push({
            name: "Modificar",
            displayName: "Modificar",
            width: "60",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpModificar,
            headerCellClass: "header-grid-color",
            cellClass: "row-style row-button-style",
          });
          CampoGridList.push({
            name: "Limpiar",
            displayName: "Limpiar",
            width: "60",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpLimpiar,
            headerCellClass: "header-grid-color",
            cellClass: "row-style row-button-style",
          });
          CampoGridList.push({
            name: "Desactivar",
            displayName: "Eliminar",
            width: "60",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpDesactivar,
            headerCellClass: "header-grid-color",
            cellClass: "row-style row-button-style",
            visible: $scope.visualizarColumnaLima,
          });
          CampoGridList.push({
            name: "Indicador",
            displayName: "Ind.",
            width: "50",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpIndicador,
            headerCellClass: "header-grid-color",
            cellClass: function (
              grid,
              row,
              col,
              rowRenderIndex,
              colRenderIndex
            ) {
              return $scope.getColorIndicador(row.entity) + " row-style";
            },
          });
          CampoGridList.push({
            name: "Subir",
            displayName: "Subir",
            width: "60",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpSubir,
            headerCellClass: "header-grid-color",
            cellClass: "row-style row-button-style",
          });
          CampoGridList.push({
            name: "Ver",
            displayName: "Ver",
            width: "60",
            enableFiltering: false,
            filter: { condition: uiGridConstants.filter.CONTAINS },
            cellTemplate: tmpVer,
            headerCellClass: "header-grid-color",
            cellClass: "row-style row-button-style",
          });
          $scope.GridRegistroAgencias = {
            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: CampoGridList,
            appScopeProvider: $scope.myAppScopeProvider,
          };
        },
        function (error) { }
      );
    };

    getCamposDinamicos();

    /*Detectando cambio en la fecha*/
    $scope.$watch("valorFecha", $rootScope.ObtenerAgencias());

    /*Función para Iniciar la Recepción de Valijas*/
    $scope.IniciarRecepcion = function () {
      if (i === 0) {
        $rootScope.proveedorRecepcion = null;
        $scope.nombreBotonRegistro = "Terminar Registro";
        ServiciosApi.getFechaServidor().then(
          function (data) {
            var fechaServidor = new Date(data[0].dFechaRecepcion);
            $rootScope.fecha = $filter("date")(
              fechaServidor,
              "yyyy-MM-ddTHH:mm:ss"
            );
            document.getElementById("btnRegistrar").disabled = false;
            document.getElementById("txtCodAgencia").disabled = false;
            $rootScope.enRegistro = 1;
            $scope.enRegistroBool = true;
            i = 1;
          },
          function (error) {
            //console.error(error);
          }
        );
      } else {
        $scope.nombreBotonRegistro = "Iniciar Registro";
          $scope.model.sCodigoAgenciaLima = "";
        if ($rootScope.AgenciasRecepcionadasFront.length > 0) {
          var ObjetoaEnviar = {};
          ObjetoaEnviar.sIdUsuarioRecepcion = $rootScope.Usuario.Id;
          ObjetoaEnviar.dFechaRecepcion = $rootScope.fecha;
          ObjetoaEnviar.lCodigo = [];
          angular.forEach(
            $rootScope.AgenciasRecepcionadasFront,
            function (value, index) {
              ObjetoaEnviar.lCodigo.push({ iId: value.iId });
            }
          );
          arreglo = JSON.stringify(ObjetoaEnviar);
          ServiciosApi.setRegistrarRecepcionValija(arreglo).then(
            function (data) {
              if (data.length === 0) {
                swal(
                  "Error",
                  "Hubo un error, vuelva a intentarlo m\u00e1s tarde.",
                  "error"
                );
                $rootScope.ObtenerAgencias();
                $rootScope.AgenciasRecepcionadasFront = [];
                return;
              }
              $scope.RegistroAgenciasDataSource = data;
              $scope.GridRegistroAgencias.data =
                $scope.RegistroAgenciasDataSource;
              $rootScope.AgenciasRecepcionadasFront = [];
              swal(
                "\u00a1Registro Terminado!",
                "Se ha registrado la recepci\u00f3n de las valijas correctamente",
                "success"
              );
            },
            function (error) {
              swal(
                "Error",
                "Hubo un error : Por favor revise su conexi\u00f3n a internet",
                "error"
              );
              $rootScope.ObtenerAgencias();
              $rootScope.AgenciasRecepcionadasFront = [];
            }
          );
        } else {
          swal(
            "\u00bfNo hubo valijas?",
            "No ha registrado ninguna recepci\u00f3n de valija",
            "error"
          );
        }
        $rootScope.enRegistro = 0;
        $scope.enRegistroBool = false;
        i = 0;
        document.getElementById("btnRegistrar").disabled = true;
        document.getElementById("txtCodAgencia").disabled = true;
        $rootScope.AgenciasRecepcionadasFront = [];
      }
    };

    /*Evento que llama a la función RegistrarRecepcion cuando se presiona Enter*/
      $scope.presionar = function (KeyEvent) {
          //console.log($scope.codAgencia);
      if (KeyEvent.which === 13) {
        $scope.RegistrarRecepcion();
        return;
      }
    };

    $scope.RegistrarRecepcion = function () {
        if (angular.isUndefined($scope.model.sCodigoAgenciaLima)) {
        swal(
          "\u00a1Formato Incorrecto!",
          "Por favor, ingrese correctamente el c\u00f3digo de la agencia a registrar.",
          "error"
        );
        document.getElementById("txtCodAgencia").select();
        return;
      }

      if (
          $scope.model.sCodigoAgenciaLima === null ||
          $scope.model.sCodigoAgenciaLima.toString().length === 0
      ) {
        swal(
          "\u00a1Te falt\u00f3 algo!",
          "Por favor, ingrese el c\u00f3digo de la agencia a registrar.",
          "error"
        );
        document.getElementById("txtCodAgencia").select();
        return;
      }

      $rootScope.agenciasConsultadas = [];

      angular.forEach($scope.RegistroAgenciasDataSource, function (value, key) {
          if ($scope.model.sCodigoAgenciaLima.toString() === value.sIdAgencia) {
          $rootScope.agenciasConsultadas.push(value);
        }
      });

      if ($rootScope.agenciasConsultadas.length === 0) {
        swal(
          "\u00a1No existe!",
          "No se encontraron resultados. Verifica el c\u00f3digo ingresado.",
          "error"
        );
        document.getElementById("txtCodAgencia").select();
        return;
      }

      if ($rootScope.agenciasConsultadas.length === 1) {
        var agenciaRecibidaTemp = $rootScope.agenciasConsultadas[0];

        if ($rootScope.proveedorRecepcion === null) {
          $rootScope.proveedorRecepcion = agenciaRecibidaTemp.sProveedor;
        } else {
          if (
            $rootScope.proveedorRecepcion !== agenciaRecibidaTemp.sProveedor
          ) {
            swal(
              "\u00a1No te confundas!",
              "En este momento solo puedes registrar la recepci\u00f3n de valijas del proveedor " +
              agenciaRecibidaTemp.sProveedor +
              ".",
              "error"
            );
            document.getElementById("txtCodAgencia").select();
            return;
          }
        }

        /** Completar datos del registro temporal */

        if (
          agenciaRecibidaTemp.iIdEstado !==
          ESTADOS.ESTADOS_VALIJA.PENDIENTE_R
        ) {
          if (agenciaRecibidaTemp.iIdEstadoProveedor !==
            ESTADOS.ESTADOS_PROVEEDOR.ENTREGADO_UTD) {
            $rootScope.mostrarError("\u00a1Sin Entrega!",
              "El proveedor aún no ha entregado la valija a UTD.");
          } else if (
            agenciaRecibidaTemp.iIdEstado ===
            ESTADOS.ESTADOS_VALIJA.ENVIADO_UTD ||
            agenciaRecibidaTemp.iIdEstado ===
            ESTADOS.ESTADOS_VALIJA.APLICADO
          ) {
            agenciaRecibidaTemp.dFechaRecepcion = $rootScope.fecha;
            if (
              agenciaRecibidaTemp.iIdEstado ===
              ESTADOS.ESTADOS_VALIJA.ENVIADO_UTD
            ) {
              agenciaRecibidaTemp.sEstado = "RECEPCIONADO";
            }
            if (agenciaRecibidaTemp.sObservacion === null) {
              agenciaRecibidaTemp.sObservacion = "";
            }
            agenciaRecibidaTemp.sIdUsuarioRecepcion =
              $rootScope.Usuario.Id;

              $scope.model.sCodigoAgenciaLima = "";

            var agenciaPorRecepcionadaFront = {
              iId: 0,
              dFechaRecepcion: "",
              sIdUsuarioRecepcion: "",
            };

            agenciaPorRecepcionadaFront.iId = agenciaRecibidaTemp.iId;
            agenciaPorRecepcionadaFront.sIdAgencia =
              agenciaRecibidaTemp.sIdAgencia;
            agenciaPorRecepcionadaFront.dFechaRecepcion =
              agenciaRecibidaTemp.dFechaRecepcion;
            agenciaPorRecepcionadaFront.sIdUsuarioRecepcion =
              $rootScope.Usuario.Id;

            /* Lista de agencias que serán registradas*/
            $rootScope.AgenciasRecepcionadasFront.push(
              agenciaPorRecepcionadaFront
            );
          } else {
            $rootScope.mostrarError("\u00a1Ya Registrada!",
              "Ya se registr\u00f3 la recepci\u00f3n de las valijas de la agencia ingresada.");
            document.getElementById("txtCodAgencia").select();
          }
        } else {
          $rootScope.mostrarError("\u00a1No te adelantes..!",
            "A\u00fan no se han recogido las valijas de la agencia ingresada.");
          document.getElementById("txtCodAgencia").select();
        }

        return;
      }

      if ($rootScope.agenciasConsultadas.length === 2) {
        abrirModalTipoTraslado();

          $rootScope.codAgencia = $scope.model.sCodigoAgenciaLima;
      }
    };

    abrirModalTipoTraslado = function () {
      var modalInstance = $uibModal.open({
        animation: true,
        templateUrl: config.Template_Dir + "modal/tipoTraslado.html",
        controller: "tipoTrasladoCtrl",
      });
    };

    $scope.GridRegistroAgencias = {
      paginationPageSizes: [10, 50, 75],
      paginationPageSize: 10,
      enableFiltering: true,
      showGridFooter: true,
      columnDefs: CampoGridList,
      appScopeProvider: $scope.myAppScopeProvider,
      onRegisterApi: function (gridApi) {
        $scope.gridApi = gridApi;
      },
    };

    /*Funcion para refrescar la Tabla*/
    var recargarTabla = function () {
      if ($rootScope.tableParamsProvincia !== "") {
        //$rootScope.tableParamsProvincia.reload();
        $scope.gridApi.core.refresh();
      }
      if (cambioDeColor === true) {
        $scope.gridApi.core.refresh();
        //$rootScope.tableParamsProvincia.sorting({ iIdEstado: 'asc', iIdIndicadorRecojo: 'asc', dArcoSuperior: 'asc' });
      }
    };

    /*Funcion para exportar la tabla a un excel*/
    $scope.ExportarData = function () {
      var ObjetoExportar = new Exportar.Objeto();
      ObjetoExportar.Config.TitleBackgroundColor = "#808080";
      ObjetoExportar.Config.TitleFontColor = "#fff";
      ObjetoExportar.cabecera = [
        "Codigo Agencia",
        "Agencia",
        "Proveedor",
        "Fecha y hora de recojo",
        "Fecha y hora de recepción",
        "Arco Inferior - Recojo",
        "Arco Superior - Recojo",
        "Arco Inferior - Recepción",
        "Arco Superior - Recepción",
        "Tipo de Traslado",
      ];

      angular.forEach(ListaCamposDinamicos, function (value, key) {
        ObjetoExportar.cabecera.push(value.titulo);
      });

      ObjetoExportar.cabecera.push("Observacion");
      ObjetoExportar.cabecera.push("Cumplimiento recojo");
      ObjetoExportar.cabecera.push("Hora de recojo de OFICINA");
      ObjetoExportar.cabecera.push("Hora de llegada a UTD");

      ObjetoExportar.NameReporte = "RecepcionValija";
      var obj = [];
      var datosExportar = [];
      angular.copy($scope.RegistroAgenciasDataSource, datosExportar);
      datosExportar = $filter("orderBy")(datosExportar, "Traslado");
      angular.forEach(datosExportar, function (value, index) {
        obj = [
          value.sIdAgencia,
          value.sAgencia,
          value.sProveedor,
          EvaluarFecha(value.dFechaRegistro),
          EvaluarFecha(value.dFechaRecepcion),
          EvaluarFecha(value.dArcoInferior),
          EvaluarFecha(value.dArcoSuperior),
          EvaluarFecha(value.dArcoInferiorRecepcion),
          EvaluarFecha(value.dArcoSuperiorRecepcion),
          value.Traslado,
        ];

        angular.forEach(ListaCamposDinamicos, function (campo, key) {
          obj.push(value[campo.campo]);
        });

        obj.push(EvaluarString(value.sObservacion));
        obj.push(EvaluarIndicador(value.iIdIndicadorRecojo));
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
        "Tipo de Traslado",
        "Observacion",
      ];
      angular.forEach(ListaCamposDinamicos, function (value, key) {
        ObjetoExportar.cabecera.push(value.titulo);
      });
      ObjetoExportar.NameReporte = "ContingenciaLima";
      var obj = [];
      var datosExportar = [];
      angular.copy($scope.RegistroAgenciasDataSource, datosExportar);
      datosExportar = $filter("orderBy")(datosExportar, "Traslado");
      obj = [
        "10001",
        "AGENCIA EJEMPLO",
        "HERMES",
        "20/08/2020 13:30",
        "20/08/2020 16:30",
        "NORMAL|REPROGRAMADO",
        "",
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
      } else {
        date = new Date(fecha);
        var d = $filter("date")(fecha, "yyyy-MM-dd HH:mm:ss", "UTC / GMT");
        return $filter("date")(fecha, "yyyy-MM-dd HH:mm:ss", "UTC / GMT");
      }
    };

    var ObtenerModalidad = function (value) {
      var tipoTraslado = value.Traslado === "NORMAL" ? "" : "REPROGRAMACION ";
      var distancia = estaContenido(agenciasLejanas, value.sIdAgencia)
        ? ". LEJANO"
        : " REGULAR";
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

    /*mostrarNumeroValijas*/
    $scope.mostrarNumeroValijas = function (sEstado, iValijas) {
      if (sEstado === "PENDIENTE") {
        return "";
      }
      return iValijas;
    };

    /*Llamando la recarga cada 1 minuto*/
    $interval(recargarTabla, 6000);

    /*Llamando a las agencias*/
    $rootScope.ObtenerAgencias();

    window.onbeforeunload = function (event) {
      if (i === 1) {
        return "Aviso: Por favor finalice la recepci\u00f3n de las agencias, en caso contrario perder\u00E1 sus cambios.";
      }
    };

    /*Evitar que el backspace retroceda a la ventana anterior*/
    $(document)
      .unbind("keydown")
      .bind("keydown", function (event) {
        var doPrevent = false;
        if (event.keyCode === 8) {
          var d = event.srcElement || event.target;
          if (
            (d.tagName.toUpperCase() === "INPUT" &&
              (d.type.toUpperCase() === "TEXT" ||
                d.type.toUpperCase() === "PASSWORD" ||
                d.type.toUpperCase() === "FILE" ||
                d.type.toUpperCase() === "SEARCH" ||
                d.type.toUpperCase() === "EMAIL" ||
                d.type.toUpperCase() === "NUMBER" ||
                d.type.toUpperCase() === "DATE")) ||
            d.tagName.toUpperCase() === "TEXTAREA"
          ) {
            doPrevent = d.readOnly || d.disabled;
          } else {
            doPrevent = true;
          }
        }

        if (doPrevent) {
          event.preventDefault();
        }
      });

    /*Evitar que salga de la pantalla cuando se recepciona las valijas*/
    $scope.$on("$locationChangeStart", function (event) {
      if ($rootScope.enRegistro === 1) {
        swal(
          "\u00a1Un momento...!",
          "No puedes salir mientras est\u00e1s registrando la recepci\u00f3n de valijas.",
          "error"
        );
        event.preventDefault();
      }
    });
    
  },
]);

app.controller("tipoTrasladoCtrl", [
  "$scope",
  "$rootScope",
  "$http",
  "Servicios",
  "$uibModalInstance",
  "$filter",
  function ($scope, $rootScope, $http, Servicios, $uibModalInstance, $filter) {
    $rootScope.tipoTrasladoElegido = "";
    $scope.ok = function () {
      if ($rootScope.tipoTrasladoElegido === "") {
        swal(
          "Se te olvido algo?",
          "Tienes que elegir un tipo de traslado",
          "error"
        );
        return;
      }
      angular.forEach($rootScope.agenciasConsultadas, function (value, key) {
        if (
          value.iIdTipoTraslado === parseInt($rootScope.tipoTrasladoElegido)
        ) {
          if (
            $rootScope.proveedorRecepcion === undefined ||
            $rootScope.proveedorRecepcion === null
          ) {
            $rootScope.proveedorRecepcion = value.sProveedor;
          } else {
            if ($rootScope.proveedorRecepcion !== value.sProveedor) {
              swal(
                "\u00a1No te confundas!",
                "En este momento solo puedes registrar la recepci\u00f3n de valijas del proveedor " +
                value.sProveedor +
                ".",
                "error"
              );
              return;
            }
          }
          if (value.dFechaRegistro !== null) {
            if (value.dFechaRecepcion === null) {
              value.dFechaRecepcion = $rootScope.fecha;
              value.sEstado = "RECEPCIONADO";
              if (value.sObservacion === null) {
                value.sObservacion = "";
              }
              value.sIdUsuarioRecepcion = $rootScope.Usuario.Id;
              $rootScope.codAgencia = "";
              $rootScope.tableParams.sorting({
                iIdEstado: "asc",
                iIdIndicadorRecojo: "asc",
                dArcoSuperior: "asc",
              });
              var agenciaRecepcionada = {
                iId: 0,
                dFechaRecepcion: "",
                sIdUsuarioRecepcion: "",
              };
              agenciaRecepcionada.iId = value.iId;
              agenciaRecepcionada.dFechaRecepcion = value.dFechaRecepcion;
              agenciaRecepcionada.sIdUsuarioRecepcion =
                $rootScope.Usuario.Id;
              $rootScope.agenciasRecepcionadas.push(agenciaRecepcionada);
            } else {
              swal(
                "\u00a1Ya Registrada!",
                "Ya se registr\u00f3 la recepci\u00f3n de las valijas de la agencia ingresada.",
                "error"
              );
            }
          } else {
            swal(
              "\u00a1No te adelantes..!",
              "A\u00fan no se han recogido las valijas de la agencia ingresada.",
              "error"
            );
          }
          return;
        }
      });
      $uibModalInstance.close();
    };
    $scope.cancelar = function () {
      $uibModalInstance.dismiss("cancelar");
    };
  },
]);