simih.config(['$routeProvider', '$httpProvider', '$compileProvider', '$locationProvider', 'localStorageServiceProvider',
    function ($routeProvider, $httpProvider, $compileProvider, $locationProvider, localStorageServiceProvider) {

        $locationProvider.html5Mode(false).hashPrefix('');

        localStorageServiceProvider.setPrefix('ls');

        $routeProvider.
            when('/', {
                controller: 'loginCtrol',
                templateUrl: 'Login.html'
            }).
            when('/Inicio', {
                controller: 'contrInicio',
                templateUrl: 'PAGINAS/Inicio.html'
            }).
            when('/Correspondencia', {
                controller: 'contr1',
                templateUrl: 'PAGINAS/DOCUMENTOS/Correspondencia.html'
            }).
            when('/Activo', {
                controller: 'contrActivo',
                templateUrl: 'PAGINAS/DOCUMENTOS/Activo.html'
            }).
            when('/Historico', {
                controller: 'HistoricoCorreos',
                templateUrl: 'PAGINAS/CONSULTAS/Historico.html'
            }).
            when('/ConfirmarEnvio', {
                controller: 'controllerConfirmado',
                templateUrl: 'PAGINAS/ACCIONES/Confirmar.html'
            }).
            when('/Valijas', {
                controller: 'TabsDemoCtrl',
                templateUrl: 'PAGINAS/JOS/Valija.html'
            }).
            when('/ConsultaPorAutogenerado', {
                controller: 'ReportePorAutogeneradoController',
                templateUrl: 'PAGINAS/REPORTES/BCP/ReportePorAutogenerado.html'
            }).
            when('/ConsultaPorMatricula', {
                controller: 'ReportePorMatriculaController',
                templateUrl: 'PAGINAS/REPORTES/BCP/ReportePorMatricula.html'
            }).
            when('/ReportePorEstado', {
                controller: 'ReportePorEstadoController',
                templateUrl: 'PAGINAS/REPORTES/BCP/ReportePorEstado.html'
            }).
            when('/ReporteDocumentosEntreExpediciones', {
                controller: 'ReporteDocumentosEntreExpedicionesController',
                templateUrl: 'PAGINAS/REPORTES/BCP/ReporteDocumentosEntreExpediciones.html'
            }).
            when('/ReporteDocumentosHaciaAgencias', {
                controller: 'ReporteDocumentosHaciaAgenciasController',
                templateUrl: 'PAGINAS/REPORTES/BCP/ReporteDocumentosHaciaAgencias.html'
            }).

            when('/ReporteServicioRVA', {
                controller: 'ReporteEntregaRecojoLimaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteEntregaRecojoLima.html'
            }).

            when('/ReporteProveedorTrasladoAgenciaAUTD', {
                controller: 'ReporteProveedorTrasladoAgenciaAUTDCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteProveedorTrasladoAgenciaAUTD.html'
            }).

            when('/RecepcionUtdLima', {
                controller: 'RecepcionarLimaCtrl',
                templateUrl: 'PAGINAS/RVA/RecepcionUtdDesdeAgencia/RecepcionLima.html'
            }).
            when('/EnvioUtdLima', {
                controller: 'EnviarValijaCtrl',
                templateUrl: 'PAGINAS/RVA/EnvioUtdHaciaAgencia/EnvioValija.html'
            }).
            when('/RecepcionBolsasLima', {
                controller: 'RecepcionarBolsasCtrl',
                templateUrl: 'PAGINAS/RVA/RecepcionBolsas/RecepcionBolsas.html'
            }).

            when('/ReporteRecojoLima', {
                controller: 'ReporteRecojoLimaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteRecojoLima.html'
            }).
            when('/ReporteRecepcionLima', {
                controller: 'ReporteRecepcionLimaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteRecepcionLima.html'
            }).
            when('/ReporteEnvioLima', {
                controller: 'ReporteEnvioAgenciaLimaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteEnvioAgenciaLima.html'
            }).
            when('/ReporteEntregaLima', {
                controller: 'ReporteEntregaAgenciaLimaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteEntregaAgenciaLima.html'
            }).
            when('/ReporteBolsasLima', {
                controller: 'ReporteRecepcionBolsasCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteRecepcionBolsas.html'
            }).




            when('/EnvioAgencia', {
                controller: 'ListaEnvioUTDCtrl',
                templateUrl: 'PAGINAS/RVA/EnvioAgenciaHaciaUtd/ListaEnvioUTD.html'
            }).
            when('/RecepcionAgencia', {
                controller: 'RecepcionAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/RecepcionAgenciaDesdeUtd/RecepcionAgencia.html'
            }).



            when('/ProveedorRecojoAgencia', {
                controller: 'ListaRecojoAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorRecojo/ListaRecojoAgencia.html'
            }).
            when('/ProveedorRecojoAgencia/:id/RecojoOIncidencia', {
                controller: 'RecojoOIncidenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorRecojo/RecojoOIncidencia.html'
            }).
            when('/ProveedorRecojoAgencia/:id/DetallesRecojo', {
                controller: 'DetallesRecojoAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorRecojo/DetallesRecojoAgencia.html'
            }).
            when('/ProveedorRecojoAgencia/:id/DetallesIncidencia', {
                controller: 'IncidenciaParaAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorIncidencia/IncidenciaParaAgencia.html'
            }).

            when('/ProveedorRecojoUtd', {
                controller: 'ListaRecojoUTDCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorRecojo/ListaRecojoUTD.html'
            }).
            when('/ProveedorRecojoUtd/:id/DetallesRecojo', {
                controller: 'DetallesRecojoUTDCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorRecojo/DetallesRecojoUTD.html'
            }).


            when('/ProveedorEntregaUtd', {
                controller: 'ListaEntregaUTDCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorEntrega/ListaEntregaUTD.html'
            }).
            when('/ProveedorEntregaUtd/:id/DetallesEntrega', {
                controller: 'DetallesEntregaUTDCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorEntrega/DetallesEntregaUTD.html'
            }).


            
            when('/ProveedorEntregaAgencia', {
                controller: 'ListaEntregaAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorEntrega/ListaEntregaAgencia.html'
            }).
            when('/ProveedorEntregaAgencia/:id/EntregaOIncidencia', {
                controller: 'EntregaOIncidenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorEntrega/EntregaOIncidencia.html'
            }).
            when('/ProveedorEntregaAgencia/:id/DetallesEntrega', {
                controller: 'DetallesEntregaAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorEntrega/DetallesEntregaAgencia.html'
            }).
            when('/ProveedorEntregaAgencia/:id/DetallesIncidencia', {
                controller: 'IncidenciaParaAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/ProveedorEntrega/IncidenciaParaAgencia.html'
            }).                   



            when('/ProveedorGestorAgenciaAUTD', {
                controller: 'IncidenciaParaAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteIncidenciaLima.html'
            }). 
            when('/ProveedorGestorUTDAAgencia', {
                controller: 'IncidenciaParaAgenciaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteIncidenciaLima.html'
            }). 

            when('/ProveedorReporteIncidencia', {
                controller: 'ReporteIncidenciaLimaCtrl',
                templateUrl: 'PAGINAS/RVA/Reporte/ReporteIncidenciaLima.html'
            }). 

            //when("/RecogerAgencia/:id/DetallesRecojo", {
            //    controller: 'IncidenciaParaAgenciaCtrl',
            //    templateUrl: 'PAGINAS/RVA/ProveedorRecojo/IncidenciaParaAgencia.html'
            //}).    

            otherwise({
                redirectTo: '/'
            });


    }])