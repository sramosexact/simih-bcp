/*Controlador de la página RecValija.html*/
app.controller("EnviarValijaCtrl", [
  "$scope",
  "$rootScope",
  "$sce",
  "ServiciosApi",
  "$filter",
  "$uibModal",
  "$interval",
  "Exportar",
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
    uiGridConstants,
    TIPO,
    ESTADOS
  ) {
    /*********************
        Configuración
    **********************/
    $scope.setActive("vEnvio");
    $scope.setActiveNavBar(true);

    /***************************
       Variables Incializadas
    ****************************/
    const tipoRegistro = TIPO.TIPO_REGISTRO.ENVIO;
    const tipoUsuario = $rootScope.Usuario.Id;

    var CampoGridList = [];
    var i = 0;
    var arreglo;
    var cambioDeColor;

    var agenciasPendientesEnviar = [];

    $rootScope.fecha;
    $rootScope.proveedorRecepcion = null;
    $rootScope.enRegistro = 0;

    $scope.RegistroAgenciasDataSource = [];
    $scope.codAgencia = "";
    $scope.enRegistroBool = false;
    $scope.esSupervisor = false;
    $scope.nombreBotonRegistro = "Iniciar Registro";
    $scope.btnListarDisabled = true;
    $scope.txtCodAgenciaDisabled = true;
    $("#fechaEnvio")
      .datepicker({ dateFormat: "dd-mm-yy", maxDate: "0" })
      .datepicker("setDate", new Date());
    $scope.modelFecha = $("#fechaEnvio")
      .datepicker({ dateFormat: "dd-mm-yy" })
      .val();
    $scope.color = {};

    /*********************
        Metodos
    **********************/

    /*Funcion para llamar el color por la descripcion*/
    $scope.getColorPorDescripcion = function (descripcion) {
      var colores = $rootScope.colores;

      colores.forEach((value) => {
        if ($filter("uppercase")(descripcion) === value.sDescripcion) {
          encuentra = true;
          $scope.color = value;
        }
      });
    };

    /*Funcion para llamar el color por el Id*/
    $scope.getColorPorId = function (iId) {
      var colores = $rootScope.colores;

      colores.forEach((value) => {
        if (iId === value.iId) {
          encuentra = true;
          $scope.color = value;
        }
      });
    };

    /*Función para llamar a todas las agencias*/
    $scope.ObtenerAgencias = () => {
      $scope.RegistroAgenciasDataSource = [];
      var pFecha;
      if (
        $("#fechaEnvio")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate") === null
      ) {
        pFecha = new Date();
      } else {
        pFecha = $("#fechaEnvio")
          .datepicker({ dateFormat: "yy-mm-dd" })
          .datepicker("getDate");
      }
      ServiciosApi.getListarAgenciasPorEnviar(pFecha).then(
        function (data) {
          $scope.RegistroAgenciasDataSource = data;
          $scope.GridEnvioAgencias.data = $scope.RegistroAgenciasDataSource;
          obtenerAgenciasPendiente();
        },
        () => {
          $rootScope.mostrarError(
            "Error",
            "Hubo un error : Por favor revise su conexi\u00f3n a internet"
          );
        }
      );
    };

    /*Llamando a las agencias*/
    $scope.ObtenerAgencias();

    /*Nombre del botón programación*/
    $scope.getTextoBotonReprogramacion = function (texto) {
      if (texto === "NORMAL") return "Registrar";
      return "Cancelar";
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
          field: "dFechaEnvio",
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
          displayName: "Fecha de entrega",
          field: "dFechaEntrega",
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

    var tmpModificar =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.modificar(row)" ng-disabled="enRegistroBool" ><i class="fa fa-edit" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';
    var tmpEliminar =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.eliminar(row)" ng-disabled="enRegistroBool"><i class="fa fa-trash-o" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
    var tmpLimpiar =
      '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.limpiar(row)" ng-disabled="enRegistroBool"><i class="fa fa-ban" style="vertical-align : top; text-align : center; font-size : 18px;"></i></button>';
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
          $rootScope.mostrarError(
            "\u00a1Alto!",
            "No puedes modificar el registro mientras est\u00e1s registrando la recepci\u00f3n de valijas."
          );
          return;
        }

        $uibModal
          .open({
            animation: true,
            templateUrl: "../PAGINAS/RVA/Template/TmpModificarEnvioLima.html",
            controller: "ModificarRegistroEnvioLimaCtrl",
            scope: scope,
          })
          .result.then(() => {
            setTimeout($scope.ObtenerAgencias, 1000);
          })
          .catch(() => {
            // action on popup dismissal.
          });

        return;
      },
      eliminar: function (row) {
        var ag = row.entity;

        if ($scope.enRegistro === 1) {
          $rootScope.mostrarError(
            "¡Alto!",
            "No puedes limpiar el registro mientras estás registrando el envío de valijas."
          );
          return;
        }
        swal(
          {
            title: "¡Un Momento!",
            text: "Se eliminará la valija registrada para envío. ¿Desea continuar?",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
          }).then((isConfirm) => {
            if (isConfirm) {
              ServiciosApi.setEliminarValijaRegistrada(ag.sIdAgencia)
                .then(function (data) {
                  if (data === 1) {
                    $scope.ObtenerAgencias();
                    $rootScope.mostrarSuccess(
                      "¡Valija Eliminada!",
                      "Se ha eliminado correctamente la valija de la lista de envios."
                    );
                  } else if (data === -2) {
                    $rootScope.mostrarError(
                      "Error",
                      "No se puede eliminar una valija que no se encuentre en el estado de ENVIO PENDIENTE"
                    );
                  } else {
                    $rootScope.mostrarError(
                      "Error",
                      "Hubo un error, vuelva a intentarlo más tarde."
                    );
                  }
                })
                .catch(function () {
                  $rootScope.mostrarError(
                    "Error",
                    "Hubo un error: Por favor, revise su conexión a internet."
                  );
                });
            }
          });
      },
      limpiar: function (row) {
        var ag = row.entity;
        if ($scope.enRegistro === 1) {
          $rootScope.mostrarError(
            "\u00a1Alto!",
            "No puedes limpiar el registro mientras est\u00e1s registrando la recepci\u00f3n de valijas."
          );
          return;
        }
        if (ag.dFechaEnvio === "" || ag.dFechaEnvio === null) {
          $rootScope.mostrarError(
            "\u00a1Alto!",
            "No puedes limpiar el registro, no hubo visita a la agencia."
          );
          return;
        }
        if (ag.dFechaEnvio !== "" && ag.dFechaEntrega !== null) {
          if ($rootScope.Usuario.Nombre !== "bifsup") {
            $rootScope.mostrarError(
              "\u00a1Alto!",
              "No puedes limpiar el registro que ya tiene fecha de envío."
            );
            return;
          } else {
            if ($scope.opcionDesactivarLima === false) {
              $rootScope.mostrarError(
                "\u00a1Alto!",
                "No puedes limpiar el registro que ya tiene fecha de entrega."
              );
              return;
            }
          }
        }
        swal({
            title: "\u00a1Un Momento!",
            text: "Se limpiar\u00e1n los datos del envío. \u00bfDesea continuar?",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
          }).then((isConfirm) => {
            if (isConfirm) {
              ServiciosApi.setLimpiarDatosVisita(ag.iId).then(
                function (data) {
                  if (data[0].ERROR === 1) {
                    $scope.ObtenerAgencias();
                    $rootScope.mostrarSuccess(
                      "\u00a1Registro Limpio!",
                      "Se han limpiado los datos del envío a la agencia."
                    );
                  } else if (data[0].ERROR === -2) {
                    $rootScope.mostrarError("Error", data[0].MENSAJE);
                  } else {
                    $rootScope.mostrarError(
                      "Error",
                      "Hubo un error, vuelva a intentarlo m\u00e1s tarde."
                    );
                  }
                },
                function (error) {
                  $rootScope.mostrarError(
                    "Error",
                    "Hubo un error : Por favor revise su conexi\u00f3n a internet."
                  );
                }
              );
            }
          });
      },
      desactivar: function (row) {
        if ($scope.recepcionar === true) {
          $rootScope.mostrarError(
            "\u00a1Alto!",
            "Solo puedes desactivar registros del día actual"
          );
          return;
        }
        if ($scope.enRegistro === 1) {
          $rootScope.mostrarError(
            "\u00a1Alto!",
            "No puedes desactivar un registro de agencia mientras est\u00e1s registrando la recepci\u00f3n de valijas."
          );
          return;
        }
        var ag = row.entity;
        if (ag.Traslado !== "NORMAL") {
          $rootScope.mostrarError(
            "\u00a1Alto!",
            "No puedes desactivar una reprogramación"
          );
          return;
        }
        var registroModificado = false;
        ListaCamposDinamicos.forEach((value) => {
          if (ag[value.campo] !== value.valorInicial) {
            registroModificado = true;
            return;
          }
        });
        if (registroModificado === true) {
          $rootScope.mostrarError(
            "\u00a1Alto!",
            "No puedes desactivar una registro que ha sido modificado"
          );
          return;
        }
        swal({
            title: "\u00a1Un Momento!",
            text: "Se desactivará el registro a la agencia. \u00bfDesea continuar?",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Aceptar",
            cancelButtonText: "Cancelar",
          }).then((isConfirm) => {
            if (isConfirm) {
              ServiciosApi.desactivarRegistro(ag.iId).then(
                function (data) {
                  if (data[0].ERROR === 1) {
                    $scope.ObtenerAgencias();
                    $rootScope.mostrarSuccess(
                      "\u00a1Registro Desactivado!",
                      "Se ha desactivado el registro."
                    );
                  } else if (data[0].ERROR === 0) {
                    $rootScope.mostrarError("Error", data[0].MENSAJE);
                  } else if (data[0].ERROR === -2) {
                    $rootScope.mostrarError("Error", data[0].MENSAJE);
                  } else if (data[0].ERROR === -3) {
                    $rootScope.mostrarError("Error", data[0].MENSAJE);
                  } else if (data[0].ERROR === -4) {
                    $rootScope.mostrarError("Error", data[0].MENSAJE);
                  } else if (data[0].ERROR === -5) {
                    $rootScope.mostrarError("Error", data[0].MENSAJE);
                  } else {
                    $rootScope.mostrarError(
                      "Error",
                      "Hubo un error, vuelva a intentarlo m\u00e1s tarde."
                    );
                  }
                },
                function () {
                  $rootScope.mostrarError(
                    "Error",
                    "Hubo un error : Por favor revise su conexi\u00f3n a internet."
                  );
                }
              );
            }
          });
      },
      desactivadoEnviado: function (row) {
        var ag = row.entity;

        if (
          ag.iIdEstado != ESTADOS.ESTADOS_VALIJA.PENDIENTE_E &&
          ag.iIdEstado != ESTADOS.ESTADOS_VALIJA.ENVIO_PENDIENTE
        )
          return true;
        else return false;
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
            }).then((isConfirm) => {
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
                templateUrl: "../PAGINAS/RVA/modal/MostrarPDF.html",
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
          data.forEach((value) => {
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
          $scope.GridEnvioAgencias = {
            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: CampoGridList,
            appScopeProvider: $scope.myAppScopeProvider,
          };
        },
        function (error) {
          console.log(error);
        }
      );
    };

    getCamposDinamicos();

    /*Detectando cambio en la fecha*/
    //$scope.$watch('valorFecha', $rootScope.ObtenerAgencias);

    /*Función para Iniciar la Recepción de Valijas*/
    $scope.IniciarRecepcion = function () {
      if (i === 0) {
        $rootScope.proveedorRecepcion = null;
        $scope.nombreBotonRegistro = "Terminar Registro";
        $scope.btnListarDisabled = false;
        $scope.txtCodAgenciaDisabled = false;
        $scope.btnEnviarDisabled = true;
        $rootScope.enRegistro = 1;
        $scope.enRegistroBool = true;
        i = 1;
      } else {
        $scope.nombreBotonRegistro = "Iniciar Registro";
        $scope.codAgencia = "";
        $rootScope.enRegistro = 0;
        $scope.enRegistroBool = false;
        i = 0;
        $scope.btnListarDisabled = true;
        $scope.btnEnviarDisabled = agenciasPendientesEnviar.length === 0;
        $scope.txtCodAgenciaDisabled = true;
      }
    };

    /*Evento que llama a la función RegistrarRecepcion cuando se presiona Enter*/
    $scope.presionar = function (KeyEvent) {
      if (KeyEvent.which === 13) {
        $scope.ListarAgencia();
        return;
      }
    };

    $scope.ListarAgencia = () => {
      if (angular.isUndefined($scope.codAgencia)) {
        $rootScope.mostrarError(
          "¡Formato Incorrecto!",
          "Por favor, ingrese correctamente el código de la agencia a registrar."
        );
        return;
      }

      if (
        $scope.codAgencia === null ||
        $scope.codAgencia.toString().length === 0
      ) {
        $rootScope.mostrarError(
          "¡Te faltó algo!",
          "Por favor, ingrese el código de la agencia a listar."
        );
        return;
      }

      var agenciaDigitada = $scope.RegistroAgenciasDataSource.find((value) => {
        return $scope.codAgencia.toString() === value.sIdAgencia;
      });

      if (!agenciaDigitada) {
        $rootScope.mostrarError(
          "\u00a1No existe!",
          "No se encontraron resultados. Verifica el c\u00f3digo ingresado."
        );
        return;
      }

      if (
        agenciaDigitada.iIdEstado ===
        ESTADOS.ESTADOS_VALIJA.ENVIO_PENDIENTE
      ) {
        $rootScope.mostrarError(
          "¡Valija Listada!",
          "Ya se listó valijas para la agencia digitada"
        );
        return;
      } else if (
        agenciaDigitada.iIdEstado ===
        ESTADOS.ESTADOS_VALIJA.ENVIADO_AGENCIA
      ) {
        $rootScope.mostrarError(
          "¡Valija Enviada!",
          "Ya se envió valijas a la agencia digitada."
        );
        return;
      } else if (
        agenciaDigitada.iIdEstado ===
        ESTADOS.ESTADOS_VALIJA.RECEPCIONADO_AGENCIA
      ) {
        $rootScope.mostrarError(
          "¡Valija Recepcionada!",
          "La agencia digitada ya recepcionó las valijas enviadas"
        );
        return;
      }

      var ObjetoaEnviar = {};
      ObjetoaEnviar.sIdUsuarioEnvio = tipoUsuario;
      ObjetoaEnviar.dFechaEnvio = new Date();
      ObjetoaEnviar.lCodigo = [{ iId: agenciaDigitada.iId }];
      ObjetoaEnviar.estadoActual = agenciaDigitada.iIdEstado;

      arreglo = JSON.stringify(ObjetoaEnviar);

      ServiciosApi.setListarValija(arreglo)
        .then((data) => {
          if (data === -1) {
            $rootScope.mostrarError(
              "Error",
              "Hubo un error, vuelva a intentarlo más tarde"
            );
          } else if (data === 0) {
            $rootScope.mostrarError(
              "Valija Enviada",
              "La valija ya ha sido enviada"
            );
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "Hubo un error : Por favor revise su conexión a internet"
          );
        })
        .finally(() => {
          $scope.codAgencia = "";
          $scope.ObtenerAgencias();
        });
    };

    const obtenerAgenciasPendiente = () => {
      agenciasPendientesEnviar = [];

      var agenciasPendientes = $scope.RegistroAgenciasDataSource.filter(
        (value) => {
          return (
            value.iIdEstado ===
            ESTADOS.ESTADOS_VALIJA.ENVIO_PENDIENTE
          );
        }
      );

      agenciasPendientes.forEach((value) => {
        var agenciaPorEnviar = {
          iId: value.iId,
          sIdAgencia: value.sIdAgencia,
        };
        agenciasPendientesEnviar.push(agenciaPorEnviar);
      });

      $scope.btnEnviarDisabled =
        i === 1 || agenciasPendientesEnviar.length === 0;
    };

    $scope.EnviarValijas = function () {
      $uibModal
        .open({
          animation: true,
          templateUrl: "../PAGINAS/RVA/modal/SeleccionarProveedor.html",
          controller: "SeleccionarProveedorCtrl",
          windowClass: "modal-centered",
        })
        .result.then((proveedor) => {
          if (proveedor.iIdProveedor) {
            mostrarConfirmacion(proveedor);
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "¡Error!",
            "No se pudo enviar la valija. Inténtelo más tarde."
          );
        });
    };

      const mostrarConfirmacion = (proveedor) => {
          swal({
              title: `Envío para ${proveedor.sProveedor}`,
              text: `Se registrarán envíos de valija para ${proveedor.sProveedor}. ¿Desea continuar?`,
              type: "info", // En esta versión se utiliza 'type' en lugar de 'icon'
              showCancelButton: true,
              confirmButtonText: "Aceptar",
              cancelButtonText: "Cancelar",
              // 'closeOnConfirm' y 'closeOnCancel' no son necesarios, el comportamiento predeterminado ya maneja esto
          }).then((result) => {
              // En SweetAlert2 v6.4.3, 'result' directamente indica si el botón de confirmar fue presionado.
              if (result) {
                  procesarEnvioValijas(proveedor);
              } else {
                  // Si se presionó el botón de cancelar, 'result' es false.
                  // No hay necesidad de verificar 'result.dismiss', ya que esa sintaxis pertenece a versiones más recientes.
                  swal("Cancelado", "Tu operación ha sido cancelada.", "error");
              }
          });
      };



    const procesarEnvioValijas = (proveedor) => {
      ServiciosApi.getFechaServidor()
        .then((data) => {
          var fechaServidor = new Date(data[0].dFechaRecepcion);
          fecha = $filter("date")(fechaServidor, "yyyy-MM-ddTHH:mm:ss");

          var objetoEnviar = {
            sIdUsuarioEnvio: tipoUsuario,
            dFechaEnvio: fecha,
            lCodigo: agenciasPendientesEnviar.map((value) => ({
              iId: value.iId,
            })),
            estadoActual: ESTADOS.ESTADOS_VALIJA.ENVIO_PENDIENTE,
            IdProveedor: proveedor.iIdProveedor,
          };

          return ServiciosApi.setEnviarValija(JSON.stringify(objetoEnviar));
        })
        .then((data2) => {
          if (data2 === -2) {
            $rootScope.mostrarError(
              "Error",
              `No se preparó valijas para el proveedor ${proveedor.sProveedor}`
            );
          } else if (data2 === -1) {
            $rootScope.mostrarError(
              "Error",
              "Hubo un error, vuelva a intentarlo más tarde"
            );
          } else if (data2 === 0) {
            $rootScope.mostrarError(
              "Valija Ya Enviada",
              "La valija ya ha sido enviada"
            );
          } else {
            $rootScope.mostrarSuccess(
              "¡Envío Terminado!",
              "Se ha registrado el envío de las valijas correctamente"
            );
          }
        })
        .catch(() => {
          $rootScope.mostrarError(
            "Error",
            "Hubo un error: Por favor, revise su conexión a internet"
          );
        })
        .finally(() => {
          setTimeout($scope.ObtenerAgencias, 1000);
        });
    };

    $scope.GridEnvioAgencias = {
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
        $scope.gridApi.core.refresh();
      }
      if (cambioDeColor === true) {
        $scope.gridApi.core.refresh();
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

      ListaCamposDinamicos.forEach((value) => {
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

      datosExportar.forEach((value) => {
        obj = [
          value.sIdAgencia,
          value.sAgencia,
          value.sProveedor,
          EvaluarFecha(value.dFechaEnvio),
          EvaluarFecha(value.dFechaRecepcion),
          EvaluarFecha(value.dArcoInferior),
          EvaluarFecha(value.dArcoSuperior),
          EvaluarFecha(value.dArcoInferiorRecepcion),
          EvaluarFecha(value.dArcoSuperiorRecepcion),
          value.Traslado,
        ];

        ListaCamposDinamicos.forEach((value) => {
          obj.push(value[campo.campo]);
        });

        obj.push(EvaluarString(value.sObservacion));
        obj.push(EvaluarIndicador(value.iIdIndicadorRecojo));
        obj.push(ObtenerHora(value.dFechaEnvio));
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
      ListaCamposDinamicos.forEach((value) => {
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
      ListaCamposDinamicos.forEach((campo) => {
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
        $rootScope.mostrarError(
          "\u00a1Un momento...!",
          "No puedes salir mientras est\u00e1s registrando la recepci\u00f3n de valijas."
        );
        event.preventDefault();
      }
    });
  },
]);