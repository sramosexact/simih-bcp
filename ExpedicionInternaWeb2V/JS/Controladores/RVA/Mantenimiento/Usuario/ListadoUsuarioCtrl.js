app.controller('ListadoUsuarioCtrl', ['$scope', '$rootScope', '$http', 'ServiciosApi', '$filter', '$uibModal', '$log', 'NgTableParams', 'Exportar', 'config', 'uiGridConstants', 'INGESTA_USUARIOS',
    function ($scope, $rootScope, $http, ServiciosApi, $filter, $uibModal, $log, NgTableParams, Exportar, config, uiGridConstants, INGESTA_USUARIOS) {

        /*********************
           Configuración
        **********************/
        $scope.setActive('vMantenimiento');
        $scope.setActiveNavBar(true);


        /***************************
        Variables Incializadas
        ****************************/

        $scope.usuarioList = [];

        var campoGridList = [];

        var tmpEditar = '<button type="button" name="button" class="btn btn-link button-grid-style" ng-click="grid.appScope.editar(row)" ng-disabled="enRegistro"><i class="fa fa-edit" style="vertical-align : top; text-align : center; font-size : 18px; "></i></button>';

        var setCamposEstaticos = function () {

            campoGridList = [

                { displayName: 'Usuario', field: 'sUsuario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Tipo Usuario', field: 'sTipoUsuario', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                //{ displayName: 'Codigo Agencia', field: 'sCodigoAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Agencia', field: 'sAgencia', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Proveedor', field: 'sProveedor', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { displayName: 'Estado', field: 'sActivo', width: '*', enableColumnResizing: true, filter: { condition: uiGridConstants.filter.CONTAINS }, headerCellClass: 'header-grid-color', cellClass: 'row-style' },
                { name: 'Editar', displayName: 'Editar', width: '100', enableFiltering: false, filter: { condition: uiGridConstants.filter.CONTAINS }, cellTemplate: tmpEditar, headerCellClass: 'header-grid-color', cellClass: 'row-style row-button-style' }
            ];

        }

        setCamposEstaticos();


        $scope.myAppScopeProvider = {

            editar: function (row) {
                var scope = $scope.$new();
                scope.registroUsuario = row.entity;
                var modalInstance = $uibModal.open({
                    animation: true,
                    templateUrl: '/parcial/Mantenimiento/Usuario/MantenimientoUsuario.html',
                    controller: 'MantenimientoUsuarioCtrl',
                    scope: scope
                }).result.then(function (data) {
                    //do logic
                }, function () {
                    // action on popup dismissal.
                });
                return;
            }
        };

        $scope.gridUsuario = {

            paginationPageSizes: [10, 50, 75],
            paginationPageSize: 10,
            enableFiltering: true,
            showGridFooter: true,
            columnDefs: campoGridList,
            appScopeProvider: $scope.myAppScopeProvider,
            onRegisterApi: function (gridApi) { $scope.gridApi = gridApi; }

        }

        $scope.obtenerUsuarioMantenimiento = function () {

            $scope.usuarioList = [];

            ServiciosApi.getListarUsuarios().then(function (data) {

                $scope.usuarioList = data;
                $scope.gridUsuario.data = $scope.usuarioList;

            }, function (error) {
                swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
                console.error(error);
            });


        };

        $scope.nuevoUsuario = function () {

            var scope = $scope.$new();
            scope.registroUsuario = null;

            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: '/parcial/Mantenimiento/Usuario/MantenimientoUsuario.html',
                controller: 'MantenimientoUsuarioCtrl',
                scope: scope
            }).result.then(function (data) {
                //do logic
            }, function () {
                // action on popup dismissal.
            });
            return;
        };

        $scope.loadFile = function (files) {

            $scope.$apply(function () {
                var nombre = document.getElementById('txtFile').value.split('\\');                
                $scope.nombreArchivo = nombre[nombre.length - 1];
                $scope.selectedFile = files[0];                
            })

        }  

        $scope.cargarUsuarios = function () {

            var file = $scope.selectedFile;

            if (file) {

                var reader = new FileReader();

                reader.onload = function (e) {

                    var data = e.target.result;

                    var workbook = XLSX.read(data, { type: 'binary' });

                    var first_sheet_name = workbook.SheetNames[0];

                    var dataObjects = XLSX.utils.sheet_to_row_object_array(workbook.Sheets[first_sheet_name]);
                    //var dataObjects = XLSX.utils.sheet_to_json(workbook.Sheets[first_sheet_name]);
                    
                    //console.log(dataObjects);

                    if (dataObjects.length > 0) {

                        for (var j = 0; j < INGESTA_USUARIOS.CAMPOS.length; j++) {
                            var nombreCampo = INGESTA_USUARIOS.CAMPOS[j];
                            var campo = dataObjects[0][nombreCampo];
                            if (campo === undefined) {
                                console.log("El campo " + nombreCampo + ' no se encuentra en el archivo seleccionado');
                                return;
                            }
                        }

                        var registrosList = [];

                        for (var i = 0; i < dataObjects.length; i++) {

                            if (dataObjects[i]['sede']?.trim().toUpperCase() === 'OFICINA') {

                                var r = {
                                    correo: dataObjects[i]['correo'],
                                    agencia: dataObjects[i]['cod agencia'],
                                    nombres: dataObjects[i]['Nombres'] + ' ' + dataObjects[i]['Apellido Paterno'] + ' ' + dataObjects[i]['Apellido Materno'],
                                }

                                registrosList.push(r);
                            }
                        }

                        //console.log(registrosList);
                        ServiciosApi.IngestaUsuario(registrosList).then(function (data) {
                            console.log("OK : ", data);
                            swal("\u00a1Operaci\u00f3n existosa!", "Se carg\u00f3 los datos del archivo", "success");


                        }, function (error) {
                            console.error("ERROR : ", error);
                                swal("Error", "Hubo un error : Por favor revise su conexi\u00f3n a internet", "error");
                                
                        });                                ;


                    } else {
                        $scope.msg = "Error : Something Wrong !";
                    }

                }

                reader.onerror = function (ex) {
                    console.error(ex);
                }

                reader.readAsBinaryString(file);
            }  

        };

        $(document).unbind('keydown').bind('keydown', function (event) {
            var doPrevent = false;
            if (event.keyCode === 8) {
                var d = event.srcElement || event.target;
                if ((d.tagName.toUpperCase() === 'INPUT' &&
                    (
                        d.type.toUpperCase() === 'TEXT' ||
                        d.type.toUpperCase() === 'PASSWORD' ||
                        d.type.toUpperCase() === 'FILE' ||
                        d.type.toUpperCase() === 'SEARCH' ||
                        d.type.toUpperCase() === 'EMAIL' ||
                        d.type.toUpperCase() === 'NUMBER' ||
                        d.type.toUpperCase() === 'DATE')
                ) ||
                    d.tagName.toUpperCase() === 'TEXTAREA') {
                    doPrevent = d.readOnly || d.disabled;
                }
                else {
                    doPrevent = true;
                }
            }

            if (doPrevent) {
                event.preventDefault();
            }
        });

        $scope.obtenerUsuarioMantenimiento();

    }]);


