app.controller('ReporteRecepcionLimaCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$location', '$timeout', 'Exportar', '$filter', 'uiGridConstants', 'NgTableParams', 'TIPO',
    function ($scope, $rootScope, $http, ServiciosApi, $location, $timeout, Exportar, $filter, uiGridConstants, NgTableParams, TIPO) {

        /********************************
        Configuración
        *********************************/
        $scope.setActive('vReporte');
        $scope.setActiveNavBar(true);



        /********************************
        Funciones de Configuración
        ******************************** */

        $scope.VerMapping = function (valor, key) {
            $scope.Proveedores[key].Vista = valor;
        }

        $scope.ActivarMapping = function (key, valor) {
            if ($scope.Proveedores[key].Vista === valor) {
                return true;
            }
            return false;
        }


        /*******************************
        Inicialización de Variables
        ********************************/

        var tipoAgencia = TIPO.TIPO_AGENCIA.LIMA;

        var tipoRegistro = TIPO.TIPO_REGISTRO.RECOJO;

        var tipoUsuario = $rootScope.Usuario.IdTipoAcceso;

        $scope.RegistroAgenciasDataSource = [];
        var CampoGridList = [];
        $scope.TipoProveedor = 0;
        $scope.Proveedores = [];
        $scope.verExportar = false;
        $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
        $("#datepicker2").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
        $scope.FechaDesde = $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy' }).val();
        $scope.FechaHasta = $("#datepicker2").datepicker({ dateFormat: 'dd-mm-yy' }).val();
        $scope.mostrarError = false;
        $scope.textoBotonDetalle = "Mostrar detalle";
        var detalleCargado = false;
        $scope.detalleMostrado = true;

        $scope.RangoDias = false;

        /*******************************
          Metodos
        *******************************/
        $scope.ObtenerAgenciaReportadas = function () {
            $scope.detalleMostrado = false;
            detalleCargado = false;
            $scope.textoBotonDetalle = "Mostrar detalle";
            $scope.Proveedores = [];
            var strDesde = $.datepicker.formatDate('yy-mm-dd', $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));
            var strHasta = $.datepicker.formatDate('yy-mm-dd', $("#datepicker2").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));

            if (strDesde === strHasta) {
                $scope.RangoDias = true;
            }
            else {
                $scope.RangoDias = false;
            }

            ServiciosApi.getGenerarReporteRecepcionLima(strDesde, strHasta, 0).then(function (data) {
                if (data.length === 0) {
                    $scope.verExportar = false;
                    $scope.mostrarError = true;
                    return;
                }
                angular.forEach(data, function (obj, index) {
                    $scope.Elemento = {
                        Vista: "Recogidos",
                      Objeto: obj,
                      detalleCargado: false,
                      detalleMostrado: false,
                      textoBotonDetalle: "Mostrar detalle",
                        "ArmadoChart": [{
                            value: obj.Entregados,
                            color: "#247EBA",
                            highlight: "#2EA1ED",
                            label: "Recibidos"
                        }, {
                            value: obj.Faltantes,
                            color: "#F29A12",
                            highlight: "#F2CC12",
                            label: "Visitados"
                        },
                        {
                            value: obj.Pendientes,
                            color: "#D8D8D8",
                            highlight: "#D8D8D8",
                            label: "Pendientes"
                        }

                        ]
                    };
                    $scope.Proveedores.push($scope.Elemento);
                });
                
                $scope.mostrarError = false;

                $("#MainDiv").trigger('create');

                if ($scope.Proveedores.length > 0) {
                    $timeout(function () {
                        angular.forEach($scope.Proveedores, function (objeto, index) {
                            $scope.CrearCanvasReporte(objeto.ArmadoChart, objeto.Objeto.Proveedor);
                        });
                    }, 200);

                }
            }
                ,
                function (error) {
                    return;
                }
            );

        };

        /*************************************
        Llamando a las agencias del dia
        *************************************/

        var setCamposEstaticos = function () {
            CampoGridList = [
                { displayName: 'Codigo', field: 'sIdAgencia', width: '60', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Agencia', field: 'sAgencia', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Proveedor', field: 'sProveedor', width: '70', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Fecha de recojo', field: 'dFechaRegistro', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Fecha de recepción', field: 'dFechaRecepcion', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Arco inferior - recojo', field: 'dArcoInferior', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Arco superior - recojo', field: 'dArcoSuperior', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Arco inferior - recepción', field: 'dArcoInferiorRecepcion', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Arco superior - recepción', field: 'dArcoSuperiorRecepcion', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Tipo de traslado', field: 'Traslado', width: '70', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' }

            ];
        };

        var tmpIndicador = '<i class="fa fa-flag" style="vertical-align : middle; font-size : 18px;"></i>';


        $rootScope.camposDinamicos = [];

        var ListaCamposDinamicos = [];

        var getCamposDinamicos = function () {
 
            ServiciosApi.listarCamposDinamicosReporte(tipoRegistro, tipoAgencia).then(function (data) {
                $rootScope.camposDinamicos = [...data];
                CampoGridList = [];

                setCamposEstaticos();

                angular.forEach(data, function (value, key) {
                    var item = { field: value.campo, name: value.titulo, width: value.anchoColumna, enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' };
                    CampoGridList.push(item);
                    ListaCamposDinamicos.push({ campo: value.campo, titulo: value.titulo });
                });



                CampoGridList.push({ name: 'Estado', field: 'sEstado', width: '100', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' });
                CampoGridList.push({
                    name: 'Indicador', displayName: 'Ind.', width: '50', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpIndicador, headerCellClass: 'header-grid-color',
                    cellClass: function (grid, row, col, rowRenderIndex, colRenderIndex) {
                        return $scope.EvaluarIndicadorClase(row.entity.iIdIndicadorRecojo) + ' row-style';
                    }
                });

                $scope.GridRegistroAgencias = {

                    paginationPageSizes: [10, 50, 75],
                    paginationPageSize: 10,
                    enableFiltering: true,
                    showGridFooter: true,
                    columnDefs: CampoGridList

                };

            }, function (error) {

            });
        };

        $scope.GridRegistroAgencias = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: CampoGridList
        };

        getCamposDinamicos();

        $scope.ObtenerAgenciaReportadas();

        $scope.CrearCanvasReporte = function (detalle, nombre) {
            var ctx = document.getElementById(nombre).getContext("2d");
            window.myDoughnut = new Chart(ctx).Doughnut(detalle, { responsive: true });
        };

        $scope.getObtenerDetalleRecepcion = function () {
            var pFechaDesde = $.datepicker.formatDate('yy-mm-dd', $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));
            var pFechaHasta = $.datepicker.formatDate('yy-mm-dd', $("#datepicker2").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));


            ServiciosApi.getGenerarReporteRecepcionDetalleLima(pFechaDesde, pFechaHasta).then(function (data) {
                $scope.RegistroAgenciasDataSource = data;
                $scope.GridRegistroAgencias.data = $scope.RegistroAgenciasDataSource;
            }, function (error) {
                swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            });
            $scope.mostrarErrorDetalle = false;
        };

        /*Funcion para exportar la tabla a un excel*/
        $scope.ExportarTablaDetalle = function () {
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
                "Tipo de Traslado"


            ];

            angular.forEach(ListaCamposDinamicos, function (value, key) {
                ObjetoExportar.cabecera.push(value.titulo);
            });

            ObjetoExportar.cabecera.push("Observacion");
            ObjetoExportar.cabecera.push("Cumplimiento recojo");
            ObjetoExportar.cabecera.push("Hora de recojo de OFICINA");
            ObjetoExportar.cabecera.push("Hora de llegada a UTD");
            ObjetoExportar.cabecera.push("Estado");

            ObjetoExportar.NameReporte = "RecepcionValija";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.RegistroAgenciasDataSource, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'Traslado');
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
                    value.Traslado

                ];

                angular.forEach(ListaCamposDinamicos, function (campo, key) {
                    obj.push(value[campo.campo]);
                });

                obj.push(EvaluarString(value.sObservacion));
                obj.push(EvaluarIndicador(value.iIdIndicadorRecojo));
                obj.push(ObtenerHora(value.dFechaRegistro));
                obj.push(ObtenerHora(value.dFechaRecepcion));
                obj.push(ObtenerHora(value.sEstado));

                ObjetoExportar.detalle.push(obj);
            });
            Exportar.ExcelObjeto(ObjetoExportar);
        };

        $scope.getColorPorId = function (iId) {
            var colores = $rootScope.colores;
            var color;
            angular.forEach(colores, function (value, key) {
                if (iId === value.iId) {
                    color = value.sColor;
                    return;
                }
            });
            return color;
        };

        $scope.mostrarNumeroValijas = function (sEstado, iValijas) {
            if (sEstado === 'PENDIENTE') {
                return '';
            }
            return iValijas;
        };

        $scope.mostrarDetalle = function (index) {
          var proveedor = $scope.Proveedores[index];

          if (proveedor.textoBotonDetalle === 'Mostrar detalle') {
              if (!proveedor.detalleCargado) {
                $scope.getObtenerDetalleRecepcion();
                proveedor.detalleCargado = true;
              }
              proveedor.textoBotonDetalle = 'Ocultar detalle';
              proveedor.detalleMostrado = true;
          } else {
              proveedor.detalleMostrado = false;
              proveedor.textoBotonDetalle = 'Mostrar detalle';
          }
        };


        $scope.ExportarData = function (idProveedor) {
            var ObjetoExportar = new Exportar.Objeto();

            if (idProveedor !== 0) {
                angular.forEach($scope.Proveedores, function (value, index) {
                    if (idProveedor === value.Objeto.IdProveedor) {
                        ObjetoExportar.cabecera = [
                            "Rangos Horarios",
                            "Resultado Esperado - Meta Porcentaje",
                            "Resultado - Meta Porcentaje",
                            "Cant.Valijas Esperado",
                            "Cant.Valijas"
                        ];

                        ObjetoExportar.Config.TitleBackgroundColor = "rgb(51,63,79)";
                        ObjetoExportar.Config.TitleFontColor = "#fff";
                        ObjetoExportar.NameReporte = "ReporteRecepcion";
                        ObjetoExportar.RowBackgroundColor = "#fff";
                        ObjetoExportar.RowFontColor = "rgb(46,57,72)";
                        ObjetoExportar.Config.FontWeight = "lighter";
                        ObjetoExportar.Config;

                        angular.forEach(value.Objeto.IndicadorRecepcion, function (valor, index1) {
                            var row = [
                                valor.sArcoHorario.replace(".0000000", "").replace(".0000000", ""),
                                valor.sMetaPorcentaje,
                                valor.sResultadoPorcentaje,
                                $filter("CantidadPorcentaje")(value.Objeto.Asignados, valor.iMeta),
                                valor.iResultado
                            ]
                            ObjetoExportar.detalle.push(row);
                            row = [];
                        });
                    }
                });
                Exportar.ExcelObjeto(ObjetoExportar);
                return;
            }
            else {
                return;
            }
        };

        $scope.ExportarTabla = function () {
            var ObjetoExportar = new Exportar.Objeto();
            ObjetoExportar.Config.TitleBackgroundColor = "#808080";
            ObjetoExportar.Config.TitleFontColor = "#fff";
            ObjetoExportar.cabecera = [
                "Codigo Agencia",
                "Agencia",
                "Proveedor",
                "Fecha y hora de recojo de OFICINA",
                "Fecha y hora de llegada a UTD",
                "Valija",
                "Bolsa Naranja",
                "C/S",
                "Observacion",
                "Arco Inferior",
                "Arco Superior",
                "Estado",
                "Indicador",
                "Hora de recojo de OFICINA",
                "Hora de llegada a UTD"
            ];
            ObjetoExportar.NameReporte = "RecepcionValija";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.dataTabla, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'sIdAgencia');
            angular.forEach(datosExportar, function (value, index) {
                obj = [
                    value.sIdAgencia,
                    value.sAgencia,
                    value.sProveedor,
                    EvaluarFecha(value.dFechaRegistro),
                    EvaluarFecha(value.dFechaRecepcion),
                    value.sValija,
                    value.sNaranja,
                    value.sComprobanteServicio,
                    EvaluarString(value.sObservacion),
                    EvaluarFecha(value.dArcoInferior),
                    EvaluarFecha(value.dArcoSuperior),
                    value.sEstado,
                    EvaluarIndicador(value.iIdIndicadorRecojo),
                    ObtenerHora(value.dFechaRegistro),
                    ObtenerHora(value.dFechaRecepcion)

                ];
                ObjetoExportar.detalle.push(obj);
            });
            Exportar.ExcelObjeto(ObjetoExportar);
        };

        var EvaluarFecha = function (fecha) {
            if (fecha === null || fecha === "") {
                return "";
            }
            else {
                date = new Date(fecha);
                return $filter('date')(fecha, 'yyyy-MM-dd HH:mm:ss', 'UTC / GMT');
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

        /*Funcion para llamar el color por la descripcion*/
        //$scope.getColorPorDescripcion = function (descripcion) {
        //    var colores = $rootScope.colores;
        //    var encuentra = false;
        //    angular.forEach(colores, function (value, key) {
        //        if ($filter('uppercase')(descripcion) === value.sDescripcion) {
        //            encuentra = true;
        //            $scope.color = value;
        //        }
        //    });
        //};

        /*Poniendo color a los indicadores*/
        //$scope.getColorIndicador = function (row) {
        //    if (tablaCargada === 0) {
        //        $scope.getColorPorId(row.iIdIndicadorRecojo);
        //        tablaCargada = 1;
        //        return 'indicador-' + $scope.color.sDescripcion.toLowerCase();

        //    } else {


        //        cambioDeColor = false;
        //        var fecha = new Date();
        //        var tolerancia = $rootScope.Tolerancia * 60 * 1000;
        //        var fechaRegistro = null;
        //        if (row.dFechaRegistro !== null) {
        //            fechaRegistro = new Date(row.dFechaRegistro);
        //            fechaRegistro.setTime(fechaRegistro.getTime() + 3600 * 1000 * 5);
        //        }
        //        var arcoSuperior = new Date(row.dArcoSuperior);
        //        arcoSuperior.setTime(arcoSuperior.getTime() + 3600 * 1000 * 5);
        //        var arcoInferior = new Date(row.dArcoInferior);
        //        arcoInferior.setTime(arcoInferior.getTime() + 3600 * 1000 * 5);
        //        var arcoConTolerancia = new Date();
        //        arcoConTolerancia.setTime(arcoSuperior.getTime() + tolerancia);

        //        if ((fechaRegistro <= arcoSuperior && fechaRegistro >= arcoInferior) || (fechaRegistro === null && fecha <= arcoSuperior && fecha >= arcoInferior)) {
        //            $scope.getColorPorDescripcion("verde");
        //            if (row.iIdIndicadorRecojo !== $scope.color.iId) {
        //                row.iIdIndicadorRecojo = $scope.color.iId;
        //                cambioDeColor = true;
        //            }
        //            return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
        //            //return $scope.color.sColor;

        //        }

        //        if ((fechaRegistro > arcoConTolerancia) || (fechaRegistro === null && fecha > arcoConTolerancia)) {
        //            $scope.getColorPorDescripcion("rojo");
        //            if (row.iIdIndicadorRecojo !== $scope.color.iId) {
        //                row.iIdIndicadorRecojo = $scope.color.iId;
        //                cambioDeColor = true;
        //            }
        //            return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
        //            //return $scope.color.sColor;
        //        }

        //        if ((fechaRegistro >= arcoSuperior) || (fechaRegistro === null && fecha > arcoSuperior)) {
        //            $scope.getColorPorDescripcion("ambar");
        //            if (row.iIdIndicadorRecojo !== $scope.color.iId) {
        //                row.iIdIndicadorRecojo = $scope.color.iId;
        //                cambioDeColor = true;
        //            }

        //            return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
        //            //return $scope.color.sColor;
        //        }
        //        $scope.getColorPorDescripcion("blanco");
        //        if (row.iIdIndicadorRecojo !== $scope.color.iId) {
        //            row.iIdIndicadorRecojo = $scope.color.iId;
        //            cambioDeColor = true;
        //        }
        //        //return $scope.color.sColor;
        //        return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
        //    }
        //};

        var EvaluarIndicador = function (indicador) {
            switch (indicador) {
                /*Rojo*/
                case 1:
                    return $rootScope.msjReporteBanRojo;
                    //break;
                /*Ambar*/
                case 2:
                    return $rootScope.msjReporteBanAmbar;
                    //break;
                /*Verde*/
                case 3:
                    return $rootScope.msjReporteBanVerde;
                    //break;
                /*Black*/
                case 4:
                    return $rootScope.msjReporteBanBlanco;
                    //break;
            }
        };

        $scope.EvaluarIndicadorClase = function (indicador) {
            var style = 'indicador-blanco';
            switch (indicador) {
                /*Rojo*/
                case 1:
                    style = 'indicador-rojo';
                    break;
                /*Ambar*/
                case 2:
                    style = 'indicador-ambar';
                    break;
                /*Verde*/
                case 3:
                    style = 'indicador-verde';
                    break;
                /*Black*/
                case 4:
                    style = 'indicador-blanco';
                    break;
            }
            return style;
        };
    }]);
