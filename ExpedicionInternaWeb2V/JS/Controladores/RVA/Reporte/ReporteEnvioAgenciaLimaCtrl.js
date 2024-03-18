app.controller('ReporteEnvioAgenciaLimaCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$location', '$timeout', 'Exportar', function ($scope, $rootScope, $http, ServiciosApi, $location, $timeout, Exportar) {

    /********************************
    Configuración
    *********************************/
    $scope.setActive('vReporte');
    $scope.setActiveNavBar(true);


    /* *******************************
    Funciones de Configuración
    ******************************** */
    $scope.VerMapping = function (valor, key) {
        $scope.Proveedores[key].Vista = valor;
    };

    $scope.ActivarMapping = function (key, valor) {
        if ($scope.Proveedores[key].Vista === valor) {
            return true;
        }
        return false;
    };


    /*******************************
    Inicialización de Variables
    ********************************/
    $scope.TipoProveedor = 0;
    $scope.Proveedores = [];
    $scope.verExportar = false;
    $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
    $("#datepicker2").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
    $scope.FechaDesde = $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy' }).val();
    $scope.FechaHasta = $("#datepicker2").datepicker({ dateFormat: 'dd-mm-yy' }).val();
    $scope.mostrarError = false;

    $scope.RangoDias = false;

    /*******************************
    Metodos
    *******************************/
    $scope.ObtenerAgenciaReportadas = function () {
        $scope.Proveedores = [];
        var strDesde = $.datepicker.formatDate('yy-mm-dd', $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));
        var strHasta = $.datepicker.formatDate('yy-mm-dd', $("#datepicker2").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));

        if (strDesde === strHasta) {
            $scope.RangoDias = true;
        }
        else {
            $scope.RangoDias = false;
        }
        ServiciosApi.getGenerarReporteEnvioLima(strDesde, strHasta, $scope.TipoProveedor).then(function (data) {
            if (data.length === 0) {
                //swal("Error", "No se han encontrado registros para la fecha ingresada.", "error");
                $scope.verExportar = false;
                $scope.mostrarError = true;
                return;
            }
            angular.forEach(data, function (obj, index) {
                $scope.Elemento = {
                    Vista: "Recogidos",
                    Objeto: obj,
                    "ArmadoChart": [{
                        value: obj.Recogidos,
                        color: "#247EBA",
                        highlight: "#2EA1ED",
                        label: "Recogidos"
                    },
                    {
                        value: obj.Pendientes,
                        color: "#D8D8D8",
                        highlight: "#dedede",
                        label: "No recogidos"
                    }

                    ]
                };
                console.log($scope.Elemento);
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
                //$scope.verExportar = true;
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
    $scope.ObtenerAgenciaReportadas();

    $scope.CrearCanvasReporte = function (detalle, nombre) {
        var ctx = document.getElementById(nombre).getContext("2d");
        window.myDoughnut = new Chart(ctx).Doughnut(detalle, { responsive: true });
    };


    $scope.ExportarData = function (idProveedor) {
        var ListaExportar = [];
        var ObjetoExportar = new Exportar.Objeto();
        if (idProveedor !== 0) {
            angular.forEach($scope.Proveedores, function (value, index) {
                if (idProveedor === value.Objeto.IdProveedor) {

                    ListaExportar.push(ObjetoExportar);

                    ObjetoExportar = new Exportar.Objeto();

                    ObjetoExportar.NameReporte = "ReporteEnvio";

                    ObjetoExportar.cabecera = [
                        value.Objeto.Proveedor,
                    ];

                    ObjetoExportar.Config.TitleFontColor = "#fff";
                    ObjetoExportar.Config.TitleBackgroundColor = "rgb(43,108,167)";
                    ObjetoExportar.Config.RowBackgroundColor = "#fff";
                    ObjetoExportar.Config.RowFontColor = "rgb(117,113,113)";
                    ObjetoExportar.Config.FontWeight = "normal"

                    ListaExportar.push(ObjetoExportar);

                    ObjetoExportar = new Exportar.Objeto();

                    ObjetoExportar.cabecera = [
                        "Total Registros",
                        "100.00%        ",
                        value.Objeto.Asignados
                    ];

                    ObjetoExportar.Config.TitleFontColor = "#fff";
                    ObjetoExportar.Config.TitleBackgroundColor = "rgb(43,108,167)";
                    ObjetoExportar.Config.RowBackgroundColor = "#fff";
                    ObjetoExportar.Config.RowFontColor = "rgb(117,113,113)";
                    ObjetoExportar.Config.FontWeight = "normal"


                    ObjetoExportar.detalle = [
                        ["Enviados",
                            value.Objeto.RecogidosPorcentaje,
                            value.Objeto.Recogidos],
                        ["Pendientes",
                            value.Objeto.PendientesPorcentaje,
                            value.Objeto.Pendientes]
                    ];

                    ListaExportar.push(ObjetoExportar);

                    
                }
            });

            Exportar.ExcelObjeto(ListaExportar);
            return;
        }
        else {
            console.log("Aqui se agregará la funcion que exporté en excel todas los proveedores");
            return;
        }

    };
}]);
