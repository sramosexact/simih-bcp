var simih = angular.module('simihApp', [
    'ngRoute',
    'ngTouch',  
    "ui.bootstrap",
    'ngAnimate',
    'LocalStorageModule',
    'ui.grid',
    'ui.grid.pagination',
    'ui.grid.moveColumns',
    'ui.grid.resizeColumns',
    'ui.grid.autoResize',
    'ui.grid.selection',
    'ui.grid.edit',    
    'ui.grid.cellNav',    
    'ui.grid.pinning',
    'ui.grid.expandable',    
    'swangular',
    'mgcrea.ngStrap',
    'MsalAngular',
    "ngTable",
]);

var app = simih;

simih.run(function ($rootScope, localStorageService) {

    $rootScope.appName = "Sistema Integral de Mensajeria in House";        
    $rootScope.rutaHost = AuthConfig.webService;
    $rootScope.claseMetodosWeb = 'metodosWEB.asmx/';
    $rootScope.rutaWebGeneral = $rootScope.rutaHost + $rootScope.claseMetodosWeb;
    $rootScope.rutaPDFWeb = '';
    $rootScope.encargadoValija = "";
    $rootScope.bandejasVirtuales = [];

    $rootScope.Tolerancia = 10;
    $rootScope.colores = {};
    $rootScope.enRegistro = 0;
    $rootScope.msjReporteBanRojo = "EXCEDIÓ LA TOLERANCIA";
    $rootScope.msjReporteBanAmbar = "TOLERANCIA";
    $rootScope.msjReporteBanVerde = "DENTRO DEL ARCO HORARIO";
    $rootScope.msjReporteBanBlanco = "ANTES DEL ARCO HORARIO";

    $rootScope.perfil = "SUPERVISOR";

    $rootScope.msjReporteBanRojoPro = "FUERA DEL DÍA PLANEADO"; //"DESPUÉS DEL DÍA PLANEADO";
    $rootScope.msjReporteBanAmbarPro = "FUERA DEL DÍA PLANEADO"; //"TOLERANCIA";
    $rootScope.msjReporteBanVerdePro = "DENTRO DEL DÍA PLANEADO";
    $rootScope.msjReporteBanBlancoPro = "FUERA DEL DÍA PLANEADO"; //"ANTES DEL DÍA PLANEADO";
    

    if (localStorageService.get('recordar') === 'true') {
        $rootScope.recordar = [
            { nombre: "ACTIVO" }
        ];
    }
    else {
        $rootScope.recordar = [];
    }

    $rootScope.$on('$routeChangeStart', function (event, next, current) {
        if (localStorageService.get('estaConectado') === false ||
            localStorageService.get('estaConectado') === null) {
        }
        else {
            $rootScope.actualizar = "";
        }


    });
});


simih.factory("Exportar", function () {
    var DefaultTitleFontColor = "#000";
    var DefaultTitleBackgroundColor = "#fff";
    var DefaultBorderTable = "1";
    var DefaultRowFontColor = "#000";
    var DefaultRowBackgroundColor = "#fff";
    var DefaultFontWeight = "bold";
    var DefaultFontSizeEx = "h4";

    function Objeto() {
        var objeto = {};
        objeto.Config = {
            TitleFontColor: "#000",
            TitleBackgroundColor: "#fff",
            BorderTable: "1",
            RowFontColor: "#000",
            RowBackgroundColor: "#fff",
            FontWeight: "bold",
            FontSizeEx: "h4",
        };
        objeto.NameReporte = "Reporte";
        (objeto.pathReporte = function () {
            return objeto.NameReporte + ".xls";
        }),
            (objeto.length = 0);
        objeto.cabecera = [];
        objeto.detalle = [];
        return objeto;
    }

    function GenerarTableCabecera(obj) {
        try {
            var row = "";
            var cabeceraRetornar = "";

            if (obj.cabecera === undefined) {
                //console.error("Por favor cree la estructura : var obj = new Exportar.Objeto()");
                return;
            }

            if (obj.Config === undefined) {
                obj.Config.TitleBackgroundColor = DefaultTitleBackgroundColor;
                obj.Config.TitleFontColor = DefaultTitleFontColor;
                obj.Config.FontWeight = DefaultFontWeight;
                obj.Config.FontSizeEx = DefaultFontSizeEx;
            }

            for (var atribut in obj.cabecera) {
                row +=
                    "<th style='background-color:" +
                    obj.Config.TitleBackgroundColor +
                    ";color:" +
                    obj.Config.TitleFontColor +
                    ";font-weight:" +
                    obj.Config.FontWeight +
                    ";padding:25px 25px'><" +
                    obj.Config.FontSizeEx +
                    ">" +
                    obj.cabecera[atribut] +
                    "</" +
                    obj.Config.FontSizeEx +
                    "></th>";
            }
            cabeceraRetornar = "<tr>" + row + "</tr>";
            return cabeceraRetornar;
        } catch (error) {
            //console.error("Error : " + error + " Por favor cree el elemento con su atributo llamado cabecera (array)");
            return;
        }
    }

    function GenerarTableDetalle(obj) {
        try {
            var conjuntotd = "";
            var detalleRetornar = "";

            if (obj.detalle === undefined) {
                //console.error("Por favor cree la estructura : var obj = new Exportar.Objeto()");
                return;
            }

            if (obj.Config === undefined) {
                //obj.Config.BorderTable = DefaultBorderTable;
                obj.Config.RowFontColor = DefaultRowFontColor;
                obj.Config.RowBackgroundColor = DefaultRowBackgroundColor;
            } else {
                if (
                    obj.Config.RowFontColor === undefined &&
                    obj.Config.RowBackgroundColor === undefined
                ) {
                    obj.Config.RowFontColor = DefaultRowFontColor;
                    obj.Config.RowBackgroundColor = DefaultRowBackgroundColor;
                }
            }

            for (var indice in obj.detalle) {
                for (var indexDet in obj.detalle[indice]) {
                    conjuntotd +=
                        "<td style='background-color:" +
                        obj.Config.RowBackgroundColor +
                        ";color:" +
                        obj.Config.RowFontColor +
                        ";padding:25px 25px'>" +
                        obj.detalle[indice][indexDet] +
                        "</td>";
                }
                detalleRetornar += "<tr>" + conjuntotd + "</tr>";
                conjuntotd = "";
            }

            return detalleRetornar;
        } catch (error) {
            //console.error("Error : " + error + " Por favor cree el elemento con su atributo llamado cabecera (array)");
            return;
        }
    }

    function ObtenerTabla(obj) {
        try {
            var table = [];
            if (obj.length === 0) {
                if (obj.Config === undefined) {
                    obj.Config.BorderTable = DefaultBorderTable;
                } else {
                    if (obj.Config.BorderTable === undefined) {
                        obj.Config.BorderTable = DefaultBorderTable;
                    }
                }
                var Cabecera = GenerarTableCabecera(obj);
                var Detalle = GenerarTableDetalle(obj);
                table = [
                    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><table border='" +
                    obj.Config.BorderTable +
                    "'>" +
                    Cabecera +
                    Detalle +
                    "</table>",
                ];
                return table;
            } else {
                for (value in obj) {
                    Cabecera = GenerarTableCabecera(obj[value]);
                    Detalle = GenerarTableDetalle(obj[value]);
                    table.push(
                        "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><table border='" +
                        obj[value].Config.BorderTable +
                        "'>" +
                        Cabecera +
                        Detalle +
                        "</table>"
                    );
                }
                return table;
            }
        } catch (error) {
            //console.log(error);
        }
    }

    function ObtenerCabecera(obj) {
        if (typeof obj !== "object") {
            if (obj.length === 0) {
                //console.error("El elemento que estas enviando es un tipo diferente a un array, Necesariamente debes enviar un array");
                return;
            }
        }

        var Cabecera = [];
        for (var property in obj[0]) {
            if (
                typeof obj[property] !== "function" &&
                typeof obj[property] !== "unknown"
            ) {
                Cabecera.push(property);
            }
        }
        return Cabecera;
    }

    function ObtenerCabeceraHtml(CabeceraHtml) {
        var cabeceraHtml = "";
        var cabecera = "";
        for (var atribut in CabeceraHtml) {
            cabecera +=
                "<th style='background-color:" +
                TitleBackgroundColor +
                ";color:" +
                TitleFontColor +
                ";font-weight:bold;padding:25px 25px'><h4>" +
                CabeceraHtml[atribut] +
                "</h4></th>";
        }
        cabeceraHtml = "<tr>" + cabecera + "</tr>";
        return cabeceraHtml;
    }

    function ObtenerDetalle(obj) {
        if (typeof obj !== "object") {
            if (obj.length === 0) {
                //console.error("El elemento que estas enviando es un tipo diferente a un array, Necesariamente debes enviar un array");
                return;
            }
        }

        var Detalle = [];
        var Objeto = [];
        var i = 0;
        for (var row in obj) {
            for (var property in obj[row]) {
                if (
                    typeof obj[row][property] !== "function" &&
                    typeof row[property] !== "unknown"
                ) {
                    Objeto.push(obj[row][property]);
                }
            }
            Detalle.push(Objeto);
            Objeto = [];
        }
        return Detalle;
    }

    function ObtenerDetalleHtml(Detalle) {
        var filashtml = "";
        var conjuntotd = "";
        for (var Objeto in Detalle) {
            for (var valores in Detalle[Objeto]) {
                conjuntotd += "<td>" + Detalle[Objeto][valores] + "</td>";
            }
            filashtml += "<tr>" + conjuntotd + "</tr>";
            conjuntotd = "";
        }
        return filashtml;
    }

    function EnviarExcel(objeto, tabla) {
        var blob = null;

        if (objeto.length === 0) {
            blob = new Blob(tabla, {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8",
            });
            saveAs(blob, objeto.pathReporte());
        } else {
            blob = new Blob(tabla, {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8",
            });
            saveAs(blob, objeto[0].pathReporte());
        }
    }

    return {
        ExcelTable: function (idTable) {
            var blob = new Blob(
                [
                    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><table border='1'>" +
                    document.getElementById(idTable).innerHTML,
                ],
                {
                    type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8",
                }
            );
            saveAs(blob, "Reporte.xls");
        },
        ExcelObjeto: function (Objeto) {
            var tabla = ObtenerTabla(Objeto);
            EnviarExcel(Objeto, tabla);
        },
        Objeto: function () {
            return Objeto();
        },
    };
});

simih.constant("config", {
    Template_Dir: "PAGINAS/RVA/",
    rol_user: -1,
});



app.constant("TIPO", {
    TIPO_USUARIO: {
        COLABORADOR_UTD_LIMA: 1,
        USUARIO_AGENCIA: 2,
        PROVEEDOR: 3,
        SUPERVISOR_UTD_LIMA: 4,
        COLABORADOR_UTD_PROVINCIA: 5,
        SUPERVISOR_UTD_PROVINCIA: 6,
        CLIENTE: 7,
        AUDITORIA: 8,
    },
    TIPO_AGENCIA: {
        LIMA: 270,
        PROVINCIA: 271,
    },
    TIPO_REGISTRO: {
        RECOJO: 1,
        ENVIO: 2,
    },
    TIPO_MOTIVO: {
        REPROGRAMACION: 1,
        PROVEEDOR: 2,
        NOHUBORECOJO: 3
    },
    TIPO_PROVEEDOR: {
        EXACT: 5,
        HERMES: 3
    }
});


app.constant("MOTIVOS", {
    MANIFESTACIONES: 5,
    HUELGAS: 6,
    DESASTRES_NATURALES: 7,
    DIAS_FESTIVOS_PROVINCIAS: 8,
    CALLES_BLOQUEADAS: 9,
    OTROS: 10
});

app.constant("ESTADOS", {
    ESTADOS_VALIJA: {
        PENDIENTE_R: 1,
        ENVIADO_UTD: 2,
        RECEPCIONADO_UTD: 3,
        RUTA: 4,
        TERMINADO: 5,
        ENVIADO_AGENCIA: 6,
        RECEPCIONADO_AGENCIA: 7,
        PENDIENTE_BN: 8,
        ENVIO_PENDIENTE: 9,
        PENDIENTE_E: 10,
        APLICADO: 11,
    },
    ESTADOS_PROVEEDOR: {
        VISITA_AGENCIA_R: 1,
        RECOGIDO_AGENCIA: 2,
        VISITA_UTD_R: 3,
        ENTREGADO_UTD: 4,
        VISITA_UTD_E: 5,
        RECOGIDO_UTD: 6,
        VISITA_AGENCIA_E: 7,
        ENTREGADO_AGENCIA: 8,
    },
});

app.factory("DatosCompartidosServiceLS", [
    "$window",
    function ($window) {
        return {
            obtenerDatos: (nombre) => {
                var datosGuardados = $window.localStorage.getItem(nombre);
                if (datosGuardados) {
                    return JSON.parse(datosGuardados);
                }
                return {};
            },
            asignarDatos: (nombre, nuevosDatos) => {
                $window.localStorage.setItem(nombre, JSON.stringify(nuevosDatos));
            },
            eliminarDatos: (nombre) => {
                $window.localStorage.removeItem(nombre);
            },
        };
    },
]);

app.factory("DatosCompartidosService", function () {
    var datosCompartidos = "";

    return {
        getDatos: function () {
            return datosCompartidos;
        },
        setDatos: function (nuevosDatos) {
            datosCompartidos = nuevosDatos;
        },
    };
});



app.filter("Porcentaje", function () {
    return function (text) {
        if (text !== undefined || text !== "") {
            var valor = text.substr(0, 4);
            return (Math.round(valor * 100) / 100).toString() + "%";
        }
        return text;
    };
});

app.filter("RecortarFecha", function () {
    return function (text) {
        if (text !== undefined || text !== "") {
            var rango = text.replace(":00.0000000", "");
            rango = rango.replace(":00.0000000", "");
            return rango;
        }
    };
});

app.filter("RecortarFechaHorayMinuto", function () {
    return function (text) {
        if (text !== undefined || text !== "") {
            var rango = text.replace(":00.0000000", "");
            rango = rango.replace(":00.0000000", "");
            return rango;
        }
    };
});

app.filter("CantidadPorcentaje", function () {
    return function (porcentaje, total) {
        return Math.round((total * porcentaje) / 100);
    };
});

app.filter('TraduccionMeses', function ($filter) {
    return function (input) {
        var date = $filter('date')(input, 'MMMM');
        var monthTranslations = {
            January: 'Enero',
            February: 'Febrero',
            March: 'Marzo',
            April: 'Abril',
            May: 'Mayo',
            June: 'Junio',
            July: 'Julio',
            August: 'Agosto',
            September: 'Septiembre',
            October: 'Octubre',
            November: 'Noviembre',
            December: 'Diciembre'
        };
        date = monthTranslations[date] || date;
        return date;
    };
});

app.filter('transformarValorBolsa', function () {
    return function (valor) {
        if (valor === '1') {
            return 'Sí';
        } else if (valor === '0') {
            return 'No';
        } else {
            return 'No'; // Para cuando el valor esté vacío o sea undefined
        }
    };
});

app.directive("camposDinamicos", function () {
    return {
        restrict: "E",
        scope: {
            campos: "=campos",
            modelo: "=modelo",
            yaRegistrado: "=yaRegistrado",
            huboRecojo: "=huboRecojo"
        },
        templateUrl: "/PAGINAS/RVA/Template/TmpControlesDinamicos.html",
        controller: function ($scope) {
            $scope.cambioCheckbox = function (campo) {
                console.log('Checkbox cambiado para', campo.campo, 'valor:', $scope.modelo[campo.campo]);

                // Llamar a la función del padre, si es necesario
                if ($scope.onChange) {
                    $scope.onChange({ campo: campo });
                }
            };
        }
    };
});

app.directive("buttonReprogramacion", function () {
    return {
        restrict: "E",
        scope: {
            row: "=row",
            enRegistro: "=enRegistro",
        },
        templateUrl: "/PAGINAS/RVA/Template/TmpButtonReprogramacion.html",
    };
});

app.directive("onlyNumbers", function () {
    return {
        restrict: "A",
        link: function (scope, elm, attrs, ctrl) {
            elm.on("keydown", function (event) {
                if (event.shiftKey && event.keyCode === 9) {
                    //shift was down when tab was pressed
                } else if (event.shiftKey) {
                    event.preventDefault();
                    return false;
                }

                if ([8, 9, 13, 27, 37, 38, 39, 40, 16].indexOf(event.which) > -1) {
                    // backspace, enter, escape, arrows, shift

                    return true;
                } else if ([110, 190].indexOf(event.which) > -1) {
                    // numbers . teclado o . teclado numerico
                    if (this.value.length === 0) {
                        event.preventDefault();
                        return false;
                    }
                    if (this.value.indexOf(".") >= 0 || this.value.indexOf(",") >= 0) {
                        event.preventDefault();
                        return false;
                    }
                    return true;
                } else if (event.which >= 48 && event.which <= 57) {
                    // numbers 0 to 9
                    return true;
                } else if (event.which >= 96 && event.which <= 105) {
                    // numpad number
                    return true;
                } else {
                    event.preventDefault();
                    return false;
                }
            });
        },
    };
});

app.directive("onlyNumbersInt", function () {
    return {
        restrict: "A",
        link: function (scope, elm, attrs, ctrl) {
            elm.on("keydown", function (event) {
                if (event.shiftKey && event.keyCode === 9) {
                    //shift was down when tab was pressed
                } else if (event.shiftKey) {
                    event.preventDefault();
                    return false;
                }

                if ([8, 9, 13, 27, 37, 38, 39, 40, 16].indexOf(event.which) > -1) {
                    // backspace, enter, escape, arrows, shift

                    return true;
                } else if ([110, 190].indexOf(event.which) > -1) {
                    // numbers . teclado o . teclado numerico
                    if (this.value.length === 0) {
                        event.preventDefault();
                        return false;
                    }
                    return true;
                } else if (event.which >= 48 && event.which <= 57) {
                    // numbers 0 to 9
                    return true;
                } else if (event.which >= 96 && event.which <= 105) {
                    // numpad number
                    return true;
                } else {
                    event.preventDefault();
                    return false;
                }
            });
        },
    };
});