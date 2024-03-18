/*Controlador de la página MantenimientoUsuario.html*/
app.controller('MantenimientoUsuarioCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$uibModalInstance', '$filter', '$uibModal', 'TIPO',
    function ($scope, $rootScope, $http, ServiciosApi, $uibModalInstance, $filter, $uibModal, TIPO) {

        $scope.setActive('vManUsuario');
        $scope.setActiveNavBar(true);
        $scope.tituloModal = '';
        $scope.agenciaList = [];
        $scope.tipoUsuarioList = [];
        $scope.proveedorList = [];

        $scope.estadoList = [
            { iActivo: 1, sActivo: 'ACTIVO' },
            { iActivo: 0, sActivo: 'INACTIVO' }
        ];

        $scope.registro = {};        
        $scope.tipoUsuarioSeleccionado = {};
        $scope.agenciaSeleccionado = {};
        $scope.proveedorSeleccionado = {};

        var op = false;

        var cargarDatos = function () {

            if ($scope.isUndefinedOrNullOrEmpty($scope.registroUsuario)) {
                op = true;
            }

            if (op) {

                $scope.tituloModal = 'Registrar nueva usuario';
                
                $scope.deshabilitarEstado = false;
                $scope.deshabilitarEliminar = true;

                $scope.tipoUsuarioSeleccionado = {
                    idTipoUsuario: 1,
                    tipoUsuario: 'COLABORADOR UTD'
                };

                $scope.estadoSeleccionado = {
                    iActivo: 1,
                    sActivo: 'ACTIVO'
                };

                $scope.habilitarControlPorTipoUsuario();

            }
            else {

                $scope.tituloModal = 'Modificar usuario';
                $scope.deshabilitarEstado = true;
                $scope.registro = Object.assign({}, $scope.registroUsuario);
                $scope.deshabilitarEliminar = false;

                $scope.tipoUsuarioSeleccionado = {
                    idTipoUsuario: $scope.registro.idTipoUsuario,
                    sTipoUsuario: $scope.registro.sTipoUsuario
                };

                $scope.agenciaSeleccionado = {
                    sCodigoAgencia: $scope.registro.sCodigoAgencia,
                    sAgencia: $scope.registro.sAgencia
                };

                $scope.proveedorSeleccionado = {
                    iIdProveedor: $scope.registro.iIdProveedor,
                    sProveedor: $scope.registro.sProveedor
                };

                $scope.estadoSeleccionado = {
                    iActivo: $scope.registro.iActivo,
                    sActivo: $scope.registro.sActivo
                };
                
                $scope.habilitarControlPorTipoUsuario();
            }
        };

        $scope.habilitarControlPorTipoUsuario = function () {

            if ($scope.tipoUsuarioSeleccionado.idTipoUsuario === TIPO.TIPO_USUARIO.COLABORADOR_UTD_LIMA ||
                $scope.tipoUsuarioSeleccionado.idTipoUsuario === TIPO.TIPO_USUARIO.SUPERVISOR_UTD_LIMA ||
                $scope.tipoUsuarioSeleccionado.idTipoUsuario === TIPO.TIPO_USUARIO.CLIENTE) {
                deshabilitarAgencia();
                deshabilitarProveedor();
            }
            else if ($scope.tipoUsuarioSeleccionado.idTipoUsuario === TIPO.TIPO_USUARIO.USUARIO_AGENCIA) {
                habilitarAgencia();
                deshabilitarProveedor();
            }
            else if ($scope.tipoUsuarioSeleccionado.idTipoUsuario === TIPO.TIPO_USUARIO.PROVEEDOR) {
                habilitarProveedor();
                deshabilitarAgencia();
            }
            else {
                deshabilitarAgencia();
                deshabilitarProveedor();
            }

        };

        var habilitarAgencia = function () {
            $scope.deshabilitarAgencia = false;
        };

        var deshabilitarAgencia = function () {
            $scope.agenciaSeleccionado = {};
            $scope.deshabilitarAgencia = true;
        };

        var habilitarProveedor = function () {
            $scope.deshabilitarProveedor = false;
        };

        var deshabilitarProveedor = function () {
            $scope.proveedorSeleccionado = {};
            $scope.deshabilitarProveedor = true;
        };

        var listarAgencias = function () {
            ServiciosApi.ListarAgenciasActivasLP().then(function (data) {
                $scope.agenciaList = data;
                cargarDatos();
            }, function (error) {
                swal("\u00a1Error!", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            });
        };

        var listarProveedores = function () {
            ServiciosApi.ListarProveedor().then(function (data) {
                $scope.proveedorList = data;
                listarAgencias();
            }, function (error) {
                swal("\u00a1Error!", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            });
        };

        var listarTipoUsuario = function () {
            ServiciosApi.getListarTipoUsuario().then(function (data) {
                $scope.tipoUsuarioList = data;
                listarProveedores();
            }, function (error) {
                swal("\u00a1Error!", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            });
        };

        var validarCampos = function () {

            if ($scope.isUndefinedOrNullOrEmpty($scope.registro.sUsuario)) {
                swal("\u00a1Error!", "Ingrese un usuario", "error");
                return true;
            }

            if ($scope.tipoUsuarioSeleccionado.idTipoUsuario === TIPO.TIPO_USUARIO.USUARIO_AGENCIA &&
                $scope.isUndefinedOrNullOrEmpty($scope.agenciaSeleccionado.sCodigoAgencia)) {
                swal("\u00a1Error!", "Seleccione una agencia de la lista", "error");
                return true;
            }

            if ($scope.tipoUsuarioSeleccionado.idTipoUsuario === TIPO.TIPO_USUARIO.PROVEEDOR &&
                $scope.isUndefinedOrNullOrEmpty($scope.proveedorSeleccionado.iIdProveedor)) {
                swal("\u00a1Error!", "Seleccione un proveedor de la lista", "error");
                return true;
            }

        };

        $scope.guardar = function () {

            if (validarCampos()) {
                return;
            }

            var usuario = {};

            usuario.sIdUsuario = $scope.registro.sIdUsuario;
            usuario.sUsuario = $scope.registro.sUsuario;
            usuario.idTipoUsuario = $scope.tipoUsuarioSeleccionado.idTipoUsuario;
            usuario.sCodigoAgencia = "";
            usuario.iIdProveedor = 0;

            if (usuario.idTipoUsuario === TIPO.TIPO_USUARIO.USUARIO_AGENCIA)
                usuario.sCodigoAgencia = $scope.agenciaSeleccionado.sCodigoAgencia;

            if (usuario.idTipoUsuario === TIPO.TIPO_USUARIO.PROVEEDOR)
                usuario.iIdProveedor = $scope.proveedorSeleccionado.iIdProveedor;

            usuario.iActivo = $scope.estadoSeleccionado.iActivo;


            if (op) {
                RegistrarUsuario(usuario);
            }
            else {
                ActualizarUsuario(usuario);
            }
            
        };

        var PrepararRegistro = function(registro) {
            return
        }

        var RegistrarUsuario = function (registro) {
            ServiciosApi.RegistrarUsuario(registro).then(function (data) {
                if (data === 1) {
                    swal("\u00a1Operaci\u00f3n existosa!", "Se registr\u00f3 el nuevo usuario", "success");
                    $scope.obtenerUsuarioMantenimiento();
                    $uibModalInstance.close();
                } else if (data === -1) {
                    swal("\u00a1Error!", "El usuario ingresado ya existe", "error");
                }else {
                    swal("\u00a1Error!", "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde.", "error");
                }
            }, function (error) {
                    swal("\u00a1Error!", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            });
        };

        var ActualizarUsuario = function (registro) {
            ServiciosApi.ActualizarUsuario(registro).then(function (data) {
                if (data === 1) {
                    swal("\u00a1Operaci\u00f3n existosa!", "Se actualizó el registro de usuario", "success");
                    $scope.obtenerUsuarioMantenimiento();
                    $uibModalInstance.close();
                } else if (data === -1) {
                    swal("\u00a1Error!", "El usuario ingresado ya existe", "error");
                }else {
                    swal("\u00a1Error!", "No se pudo completar la operaci\u00f3n, int\u00e9ntelo m\u00e1s tarde.", "error");
                }
            }, function (error) {
                    swal("\u00a1Error!", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
            });
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancelar');
        };

        listarTipoUsuario();


    }]);
