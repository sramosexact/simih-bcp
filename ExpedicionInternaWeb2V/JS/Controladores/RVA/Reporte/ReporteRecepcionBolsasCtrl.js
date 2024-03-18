app.controller('ReporteRecepcionBolsasCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$location', '$timeout', 'Exportar', '$filter', 'uiGridConstants', 'NgTableParams', 'TIPO',
    function ($scope, $rootScope, $http, ServiciosApi, $location, $timeout, Exportar, $filter, uiGridConstants, NgTableParams, TIPO) {

        /********************************
        Configuración
        *********************************/
        $scope.setActive('vReporte');
        $scope.setActiveNavBar(true);
        $scope.mostrarError = false;

        $scope.TipoBolsaList = [];
        var ReporteBolsas = [];

        $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
        $("#datepicker2").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
        $scope.FechaDesde = $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy' }).val();
        $scope.FechaHasta = $("#datepicker2").datepicker({ dateFormat: 'dd-mm-yy' }).val();

        var listarTipoBolsa = function () {

            ServiciosApi.ListarTipoBolsa().then(function (data) {
                $scope.TipoBolsaList = data;
                $scope.tipoBolsaSeleccionado = data[0];
                
            }, function (error) {
                console.error(error);
            });
        };

        var campoGridList = [
            { displayName: 'Código agencia', field: 'sIdAgencia', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Nombre agencia', field: 'sDescripcionAgencia', width: '200', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Código bolsa', field: 'sDescripcionBolsaNaranja', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Código lote', field: 'sCodigoJumbo', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Tipo bolsa', field: 'sDescripcionTipoBolsaNaranja', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Fecha y hora de entrega', field: 'dFechaEntrega', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Fecha de entrega', field: 'dFechaEntrega', width: '120', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            { displayName: 'Código envío', field: 'codigoEnvio', width: '150', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
        ];


        $scope.gridReporteBolsas = {
            data: ReporteBolsas,
            paginationPageSizes: [50, 100, 500],
            paginationPageSize: 50,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoGridList,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }
        };


        $scope.generarReporteBolsas = function () {

            var pFechaDesde = $.datepicker.formatDate('yy-mm-dd', $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));
            var pFechaHasta = $.datepicker.formatDate('yy-mm-dd', $("#datepicker2").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));
            var tipoBolsa = $scope.tipoBolsaSeleccionado.iId;
            ReporteBolsas = [];
            
            ServiciosApi.GenerarReporteBolsasTodo(tipoBolsa, pFechaDesde, pFechaHasta).then(function (data) {
                ReporteBolsas = data;
                $scope.gridReporteBolsas.data = ReporteBolsas;
                if (ReporteBolsas.length === 0) {
                    $scope.mostrarError = true;
                }
                else {
                    $scope.mostrarError = false;
                }
            }, function (error) {
                $scope.mostrarError = true;
                swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
                console.error(error);
            });

        };

        $scope.exportarTablaExcel = function () {

            if (ReporteBolsas.length === 0) {
                swal("Error", "No hay registros para exportar", "error");
                return;
            }

            var ObjetoExportar = new Exportar.Objeto();
            ObjetoExportar.Config.TitleBackgroundColor = "#808080";
            ObjetoExportar.Config.TitleFontColor = "#fff";
            ObjetoExportar.cabecera = [
                "Codigo agencia",
                "Nombre agencia",
                "Codigo de bolsa",
                "Codigo de lote",
                "Tipo de bolsa",
                "Fecha y hora de entrega",
                "Fecha de entrega",
                "Codigo de envío"
            ];
            ObjetoExportar.NameReporte = "ReporteRecepcionBolsas";
            var obj = [];
            var datosExportar = [];
            angular.copy(ReporteBolsas, datosExportar);
            //datosExportar = $filter('orderBy')(datosExportar, 'sIdAgencia');
            angular.forEach(datosExportar, function (value, index) {
                obj = [
                    value.sIdAgencia,
                    value.sDescripcionAgencia,
                    value.sDescripcionBolsaNaranja,
                    value.sCodigoJumbo,
                    value.sDescripcionTipoBolsaNaranja,
                    EvaluarFecha(value.dFechaEntrega),
                    EvaluarSoloFecha(value.dFechaEntrega),
                    value.codigoEnvio

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

        var EvaluarSoloFecha = function (fecha) {
            if (fecha === null || fecha === "") {
                return "";
            }
            else {
                date = new Date(fecha);
                return $filter('date')(fecha, 'yyyy-MM-dd', 'UTC / GMT');
            }

        };

        listarTipoBolsa();

    }]);