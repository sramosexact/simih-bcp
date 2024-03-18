/*Controlador de la página ListadoAgencia.html*/
app.controller('AuditoriaCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants',
    function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants) {

        /********************************
        Configuración
        *********************************/
        $scope.setActive('vReporte');
        $scope.setActiveNavBar(true);


        $scope.ListaReporteAuditoria = [

            { Id: 1, Descripcion: 'REGISTROS DE RECOJO' },
            { Id: 2, Descripcion: 'REGISTROS DE ENVIO' },
            { Id: 3, Descripcion: 'MANTENIMIENTO AGENCIA' },
            { Id: 4, Descripcion: 'MANTENIMIENTO CORREO' },
            { Id: 5, Descripcion: 'MANTENIMIENTO FERIADO' },
            { Id: 6, Descripcion: 'MANTENIMIENTO RANGOS RECEPCION' },
            { Id: 7, Descripcion: 'MANTENIMIENTO USUARIO' }

        ];

        $scope.reporteSeleccionado = $scope.ListaReporteAuditoria[0];

        $scope.ListaRegistros = [];
        $scope.ListaRegistroCampos = [];
        $scope.ListaAgencia = [];
        $scope.ListaAgenciaHorario = [];
        $scope.ListaFrecuencia = [];
        $scope.ListaCorreo = [];
        $scope.ListaCorreoReporte = [];
        $scope.ListaFeriado = [];
        $scope.ListaHorario = [];
        $scope.ListaUsuario = [];

        $("#datepicker").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());
        $("#datepicker2").datepicker({ dateFormat: 'dd-mm-yy', maxDate: '0' }).datepicker("setDate", new Date());

        var campoAgenciaTrasladoGridList = [];
        var campoTrasladoCampoGridList = [];

        var campoAgenciaGridList = [];
        var campoAgenciaHorarioGridList = [];
        var campoFrecuenciaGridList = [];

        var campoCorreoGridList = [];
        var campoCorreoReporteGridList = [];

        var campoFeriadoGridList = [];
        var campoHorarioGridList = [];
        var campoUsuarioGridList = [];
                
        var setCamposEstaticos = function () {

            campoAgenciaTrasladoGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdRegistro', field: 'IdRegistro', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'CodigoAgencia', field: 'CodigoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Agencia', field: 'Agencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Proveedor', field: 'Proveedor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Fecha', field: 'Fecha', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy"',headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'ArcoInferiorRecojo', field: 'ArcoInferiorRecojo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'ArcoSuperiorRecojo', field: 'ArcoSuperiorRecojo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdUsuarioRegistro', field: 'IdUsuarioRegistro', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdUsuarioRecepcion', field: 'IdUsuarioRecepcion', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'FechaRegistro', field: 'FechaRegistro', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'FechaRecepcion', field: 'FechaRecepcion', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Observacion', field: 'Observacion', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoTraslado', field: 'TipoTraslado', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },                
                { displayName: 'IdHorario', field: 'IdHorario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Estado', field: 'Estado', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdIndicadorRecojo', field: 'IdIndicadorRecojo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdGrupoHorarioProveedor', field: 'IdGrupoHorarioProveedor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Activo', field: 'Activo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'FechaRecojoProveedor', field: 'FechaRecojoProveedor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoRegistro', field: 'TipoRegistro', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'FechaEnvio', field: 'FechaEnvio', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'FechaEntrega', field: 'FechaEntrega', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdUsuarioEnvio', field: 'IdUsuarioEnvio', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdUsuarioEntrega', field: 'IdUsuarioEntrega', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'FechaTentativaRecepcion', field: 'FechaTentativaRecepcion', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'FechaHoraLectura', field: 'FechaHoraLectura', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
            ];

            campoTrasladoCampoGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdRegistroCampo', field: 'IdRegistroCampo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdRegistro', field: 'IdRegistro', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },                
                { displayName: 'IdCampo', field: 'IdCampo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Campo', field: 'Campo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Valor', field: 'Valor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                
            ];

            campoAgenciaGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'CodigoAgencia', field: 'CodigoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Agencia', field: 'Agencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoAgencia', field: 'TipoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'PlazoRecepcion', field: 'PlazoRecepcion', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Estado', field: 'Estado', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                
            ];

            campoAgenciaHorarioGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdAgenciaHorario', field: 'IdAgenciaHorario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'CodigoAgencia', field: 'CodigoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Agencia', field: 'Agencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'ArcoInferior', field: 'ArcoInferior', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'ArcoSuperior', field: 'ArcoSuperior', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Estado', field: 'Estado', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },

            ];

            campoFrecuenciaGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdFrecuencia', field: 'IdFrecuencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'DiaSemana', field: 'DiaSemana', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoRegistro', field: 'TipoRegistro', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                
            ];

            campoCorreoGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdCorreo', field: 'IdCorreo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Correo', field: 'Correo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                
            ];

            campoCorreoReporteGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdCorreo', field: 'IdCorreo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoCorreo', field: 'TipoCorreo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoReporte', field: 'TipoReporte', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },

            ];

            campoFeriadoGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdFeriado', field: 'IdFeriado', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Fecha', field: 'Fecha', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy"',headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoAgencia', field: 'TipoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },

            ];

            campoHorarioGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdHorario', field: 'IdHorario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Proveedor', field: 'Proveedor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'ArcoParcialInicial', field: 'ArcoParcialInicial', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'ArcoParcialFinal', field: 'ArcoParcialFinal', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Meta', field: 'Meta', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'GrupoHorario', field: 'GrupoHorario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoAgencia', field: 'TipoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                
            ];

            campoUsuarioGridList = [

                { displayName: 'AuditId', field: 'AuditId', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditIdTransaction', field: 'AuditIdTransaction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditAction', field: 'AuditAction', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditDate', field: 'AuditDate', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, type: 'date', cellFilter: 'date: "dd/MM/yyyy HH:mm:ss"', headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'AuditUser', field: 'AuditUser', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'IdUsuario', field: 'IdUsuario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Usuario', field: 'Usuario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Nombre', field: 'Nombre', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'TipoUsuario', field: 'TipoUsuario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'CodigoAgencia', field: 'CodigoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Proveedor', field: 'Proveedor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },

            ];
        }

        setCamposEstaticos();

        $scope.gridAgenciaTraslado = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoAgenciaTrasladoGridList,
            appScopeProvider: $scope.myAppScopeProvider,            
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; },

        };

        $scope.gridTrasladoCampo = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoTrasladoCampoGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridAgencia = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoAgenciaGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridAgenciaHorario = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoAgenciaHorarioGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridFrecuencia = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoFrecuenciaGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridCorreo = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoCorreoGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridCorreoReporte = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoCorreoReporteGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridFeriado = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoFeriadoGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridHorario = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoHorarioGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };

        $scope.gridUsuario = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoUsuarioGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        };



        $scope.ConsultarAuditoria = function () {

            var pFechaDesde = $.datepicker.formatDate('yy-mm-dd', $("#datepicker").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));
            var pFechaHasta = $.datepicker.formatDate('yy-mm-dd', $("#datepicker2").datepicker({ dateFormat: 'yy-mm-dd' }).datepicker("getDate"));

            var fechaDesde = new Date(pFechaDesde.split('-')[0], pFechaDesde.split('-')[1], pFechaDesde.split('-')[2]);
            var fechaHasta = new Date(pFechaHasta.split('-')[0], pFechaHasta.split('-')[1], pFechaHasta.split('-')[2]);

            $scope.ListaRegistros = [];
            $scope.ListaRegistroCampos = [];
            $scope.ListaAgencia = [];
            $scope.ListaAgenciaHorario = [];
            $scope.ListaFrecuencia = [];
            $scope.ListaCorreo = [];
            $scope.ListaCorreoReporte = [];
            $scope.ListaFeriado = [];
            $scope.ListaHorario = [];
            $scope.ListaUsuario = [];

            $scope.gridAgenciaTraslado.data = [];
            $scope.gridTrasladoCampo.data = [];
            $scope.gridAgencia.data = [];
            $scope.gridAgenciaHorario.data = [];
            $scope.gridFrecuencia.data = [];
            $scope.gridCorreo.data = [];
            $scope.gridCorreoReporte.data = [];
            $scope.gridFeriado.data = [];
            $scope.gridHorario.data = [];
            $scope.gridUsuario.data = [];

            ServiciosApi.ConsultarAuditoria(pFechaDesde, pFechaHasta, $scope.reporteSeleccionado.Id).then(function (data) {
                
                if ($scope.reporteSeleccionado.Id === 1 || $scope.reporteSeleccionado.Id === 2) {

                    $scope.ListaRegistros = data[0];
                    $scope.ListaRegistroCampos = data[1];

                    $scope.gridAgenciaTraslado.data = $scope.ListaRegistros;
                    $scope.gridTrasladoCampo.data = $scope.ListaRegistroCampos;
                }
                else if ($scope.reporteSeleccionado.Id === 3) {

                    $scope.ListaAgencia = data[0];
                    $scope.ListaAgenciaHorario = data[1];
                    $scope.ListaFrecuencia = data[2];

                    $scope.gridAgencia.data = $scope.ListaAgencia;
                    $scope.gridAgenciaHorario.data = $scope.ListaAgenciaHorario;
                    $scope.gridFrecuencia.data = $scope.ListaFrecuencia;
                }
                else if ($scope.reporteSeleccionado.Id === 4) {

                    $scope.ListaCorreo = data[0];
                    $scope.ListaCorreoReporte = data[1];

                    $scope.gridCorreo.data = $scope.ListaCorreo;
                    $scope.gridCorreoReporte.data = $scope.ListaCorreoReporte;
                }
                else if ($scope.reporteSeleccionado.Id === 5) {

                    $scope.ListaFeriado = data[0];

                    $scope.gridFeriado.data = $scope.ListaFeriado;
                }
                else if ($scope.reporteSeleccionado.Id === 6) {

                    $scope.ListaHorario = data[0];

                    $scope.gridHorario.data = $scope.ListaHorario;
                }
                else if ($scope.reporteSeleccionado.Id === 7) {

                    $scope.ListaUsuario = data[0];

                    $scope.gridUsuario.data = $scope.ListaUsuario;
                }


                


            }, function (error) {
                console.log(error);
            });
        }


        $scope.Exportar = function (reporteId) {
            
            var ObjetoExportar = new Exportar.Objeto();
            ObjetoExportar.Config.TitleBackgroundColor = "#808080";
            ObjetoExportar.Config.TitleFontColor = "#fff";

            ObjetoExportar.cabecera = [];
            ObjetoExportar.NameReporte = "";

            var obj = [];
            var datosExportar = [];

            if (reporteId === 1) {
                angular.forEach(campoAgenciaTrasladoGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Registros";                
                
                angular.copy($scope.ListaRegistros, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdRegistro,
                        value.CodigoAgencia,
                        value.Agencia,
                        value.Proveedor,
                        value.Fecha,
                        value.ArcoInferiorRecojo,
                        value.ArcoSuperiorRecojo,
                        value.IdUsuarioRegistro,
                        value.IdUsuarioRecepcion,
                        value.FechaRegistro,
                        value.FechaRecepcion,
                        value.Observacion,
                        value.TipoTraslado,
                        value.IdHorario,
                        value.Estado,
                        value.IdIndicadorRecojo,
                        value.IdGrupoHorarioProveedor,
                        value.Activo,
                        value.FechaRecojoProveedor,
                        value.TipoRegistro,
                        value.FechaEnvio,
                        value.FechaEntrega,
                        value.IdUsuarioEnvio,
                        value.IdUsuarioEntrega,
                        value.FechaTentativaRecepcion,
                        value.FechaHoraLectura

                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 2) {
                angular.forEach(campoTrasladoCampoGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Registro Campos";

                angular.copy($scope.ListaRegistroCampos, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdRegistroCampo,
                        value.IdRegistro,
                        value.IdCampo,
                        value.Campo,
                        value.Valor


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 3) {
                angular.forEach(campoAgenciaGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Agencia";

                angular.copy($scope.ListaAgencia, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.CodigoAgencia,
                        value.Agencia,
                        value.TipoAgencia,
                        value.PlazoRecepcion,
                        value.Estado


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 4) {
                angular.forEach(campoAgenciaHorarioGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Agencia Horario";

                angular.copy($scope.ListaAgenciaHorario, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdAgenciaHorario,
                        value.CodigoAgencia,
                        value.Agencia,
                        value.ArcoInferior,
                        value.ArcoSuperior,
                        value.Estado


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 5) {
                angular.forEach(campoFrecuenciaGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Frecuencia Traslado";

                angular.copy($scope.ListaFrecuencia, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdFrecuencia,
                        value.DiaSemana,
                        value.TipoRegistro


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 6) {
                angular.forEach(campoCorreoGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Correo";

                angular.copy($scope.ListaCorreo, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdCorreo,
                        value.Correo


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 7) {
                angular.forEach(campoCorreoReporteGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Correo Reporte";

                angular.copy($scope.ListaCorreoReporte, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdCorreo,
                        value.TipoCorreo,
                        value.TipoReporte


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 8) {
                angular.forEach(campoFeriadoGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Feriado";

                angular.copy($scope.ListaFeriado, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdFeriado,
                        value.Fecha,
                        value.TipoAgencia


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 9) {
                angular.forEach(campoHorarioGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Horario";

                angular.copy($scope.ListaHorario, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdHorario,
                        value.Proveedor,
                        value.ArcoParcialInicial,
                        value.ArcoParcialFinal,
                        value.Valor,
                        value.Valor,
                        value.Valor


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }
            else if (reporteId === 10) {
                angular.forEach(campoTrasladoCampoGridList, function (value, index) {
                    ObjetoExportar.cabecera.push(value.displayName);
                });

                ObjetoExportar.NameReporte = "Registro Campos";

                angular.copy($scope.ListaRegistroCampos, datosExportar);

                angular.forEach(datosExportar, function (value, index) {
                    obj = [
                        value.AuditId,
                        value.AuditIdTransaction,
                        value.AuditAction,
                        value.AuditDate,
                        value.AuditUser,
                        value.IdRegistroCampo,
                        value.IdRegistro,
                        value.IdCampo,
                        value.Campo,
                        value.Valor


                    ];
                    ObjetoExportar.detalle.push(obj);
                });
                Exportar.ExcelObjeto(ObjetoExportar);
            }            

        };


    }]);
