app.controller('ReporteEntregaAgenciaLimaCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$location', '$timeout', 'Exportar', '$filter', 'uiGridConstants', 'NgTableParams', 'TIPO',
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

        var tipoRegistro = TIPO.TIPO_REGISTRO.ENVIO;

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
        var tablaCargada = 0;

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

            ServiciosApi.getGenerarReporteEntregaLima(strDesde, strHasta, 0).then(function (data) {
                if (data.length === 0) {
                    
                    $scope.verExportar = false;
                    $scope.mostrarError = true;
                    return;
                }
                angular.forEach(data, function (obj, index) {
                    $scope.Elemento = {
                        Vista: "Recogidos",
                        Objeto: obj,
                        "ArmadoChart": [
                            
                            {
                                value: obj.Entregados,
                                color: "#247EBA",
                                highlight: "#2EA1ED",
                                label: "Entregados"
                            },
                            {
                                value: obj.Recogidos,
                                color: "#F29A12",
                                highlight: "#F2CC12",
                                label: "Enviados"
                            }
                            ,
                            {
                                value: obj.Pendientes,
                                color: "#dedede",
                                highlight: "#F2CC12",
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
                    console.log(error);
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
                { displayName: 'Fecha de envío', field: 'dFechaEnvio', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Fecha de entrega', field: 'dFechaEntrega', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            ];
        };

        var tmpIndicador = '<i class="fa fa-flag" style="vertical-align : middle; font-size : 18px;"></i>';
        var tmpIndicadorRecepcion = '<i class="fa fa-flag" style="vertical-align : middle; font-size : 18px;"></i>';


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


            ServiciosApi.getGenerarReporteEntregaDetalleLima(pFechaDesde, pFechaHasta).then(function (data) {
                $scope.RegistroAgenciasDataSource = data;
                $scope.GridRegistroAgencias.data = $scope.RegistroAgenciasDataSource;
            }, function (error) {
                swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
                console.error(error);
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
                "Fecha de envío",
                "Fecha de entrega",
            ];

            angular.forEach(ListaCamposDinamicos, function (value, key) {
                ObjetoExportar.cabecera.push(value.titulo);
            });

            ObjetoExportar.cabecera.push("Observación");
            ObjetoExportar.cabecera.push("Estado");

            ObjetoExportar.NameReporte = "EntregaValija";
            var obj = [];
            var datosExportar = [];
            angular.copy($scope.RegistroAgenciasDataSource, datosExportar);
            datosExportar = $filter('orderBy')(datosExportar, 'Traslado');
            angular.forEach(datosExportar, function (value, index) {

                obj = [

                    value.sIdAgencia,
                    value.sAgencia,
                    value.sProveedor,
                    EvaluarFecha(value.dFechaEnvio),
                    EvaluarFecha(value.dFechaEntrega)
                ];

                angular.forEach(ListaCamposDinamicos, function (campo, key) {
                    obj.push(value[campo.campo]);
                });

                obj.push(EvaluarString(value.sObservacion));
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

        $scope.mostrarDetalle = function () {
            if ($scope.textoBotonDetalle === 'Mostrar detalle') {
                if (detalleCargado === false) {
                    $scope.getObtenerDetalleRecepcion();
                    detalleCargado = true;
                }
                $scope.textoBotonDetalle = 'Ocultar detalle'
                $scope.detalleMostrado = true;
            } else {
                $scope.detalleMostrado = false;
                $scope.textoBotonDetalle = 'Mostrar detalle';
            }
        };

        $scope.ExportarData = function (idProveedor) {
            var ListaExportar = [];
            var ObjetoExportar = new Exportar.Objeto();

            if (idProveedor !== 0) {
                angular.forEach($scope.Proveedores, function (value, index) {
                    if (idProveedor === value.Objeto.IdProveedor) {

                        ObjetoExportar.NameReporte = "ReporteEntrega";

                        ObjetoExportar.cabecera = [
                            "Total Asignados",
                            "100%",
                            value.Objeto.Asignados
                        ];

                        ObjetoExportar.detalle = [
                            ["Entregados", value.Objeto.EntregadosPorcentaje, value.Objeto.Entregados],
                            ["Enviados", value.Objeto.RecogidosPorcentaje, value.Objeto.Recogidos],
                            ["Pendientes", value.Objeto.PendientesPorcentaje, value.Objeto.Pendientes]
                        ];

                        ObjetoExportar.Config.TitleBackgroundColor = "rgb(43,108,167)";
                        ObjetoExportar.Config.TitleFontColor = "#fff";                        
                        ObjetoExportar.Config.RowBackgroundColor = "#fff";
                        ObjetoExportar.Config.RowFontColor = "rgb(117,113,113)";
                        ObjetoExportar.Config.FontWeight = "normal";

                        ListaExportar.push(ObjetoExportar);

                    }
                });
                Exportar.ExcelObjeto(ListaExportar);
                return;
            }
            else {
                //console.log("Aqui se agregará la funcion que exporté en excel todas las tablas");
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
            ObjetoExportar.NameReporte = "EntregaValija";
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

        var EvaluarSoloFecha = function (fecha) {
            if (fecha === null || fecha === "") {
                return "";
            }
            else {
                date = new Date(fecha);
                return $filter('date')(fecha, 'yyyy-MM-dd', 'UTC / GMT');
            }

        };


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
                   // break;
                /*Black*/
                case 4:
                    return $rootScope.msjReporteBanBlancoPro;
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


        /*Poniendo color a los indicadores*/
        $scope.getColorIndicador = function (row) {
            tablaCargada = 1;
            if (tablaCargada === 0) {
                $scope.getColorPorId(row.iIdIndicadorRecojo);
                tablaCargada = 1;
                return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
                //return $scope.color.sColor;

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
                    //return $scope.color.sColor;

                }

                if ((fechaRegistro > arcoConTolerancia) || (fechaRegistro === null && fecha > arcoConTolerancia)) {
                    $scope.getColorPorDescripcion("rojo");
                    if (row.iIdIndicadorRecojo !== $scope.color.iId) {
                        row.iIdIndicadorRecojo = $scope.color.iId;
                        cambioDeColor = true;
                    }
                    return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
                    //return $scope.color.sColor;
                }

                if ((fechaRegistro >= arcoSuperior) || (fechaRegistro === null && fecha > arcoSuperior)) {
                    $scope.getColorPorDescripcion("ambar");
                    if (row.iIdIndicadorRecojo !== $scope.color.iId) {
                        row.iIdIndicadorRecojo = $scope.color.iId;
                        cambioDeColor = true;
                    }

                    return 'indicador-' + $scope.color.sDescripcion.toLowerCase();
                    //return $scope.color.sColor;
                }
                $scope.getColorPorDescripcion("blanco");
                if (row.iIdIndicadorRecojo !== $scope.color.iId) {
                    row.iIdIndicadorRecojo = $scope.color.iId;
                    cambioDeColor = true;
                }
                //return $scope.color.sColor;
                return 'indicador-' + $scope.color.sDescripcion;
            }
        };

        /*Funcion para llamar el color por la descripcion*/
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

    }]);
