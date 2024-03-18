//var app = angular.module("AplicativoRAV.ServiciosApi", []);

angular.module('simihApp').service("ServiciosApi", [
    "$http",
    "$q",
    "$rootScope",    
    "Requester",    
    function ($http, $q, $rootScope, Requester) {
        var urlServerWebApi = AuthConfig.webApiEndpointRVA;

        /* ********************
         * ** AgenciaTraslado *
         * *******************/
        this.getListarVisitaAgenciaLima = function (fechaIn) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ListarVisitaAgenciaLima',
                {
                    fecha: fechaIn
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;


        };

        this.ListarEnvioPorAgencia = function (codigoAgencia, fechaIn) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ListarEnvioPorAgencia',
                {
                    codigoAgencia: codigoAgencia,
                    fecha: fechaIn
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;


        };


        this.getAgenciaLimaVisita = function (idRegistro) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/AgenciaLimaVisita',
                {
                    idRegistro: idRegistro
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getListarRecepcionAgenciaLima = function (codigoAgencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ListarRecepcionAgenciaLima',
                {
                    codigo: codigoAgencia
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.RecepcionarValijaAgencia = function (
            codigoUsuario,
            valijaId,
            fechaRecepcion
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/AgenciaTraslado/RecepcionarValijaAgencia',
                {
                    codigoUsuario: codigoUsuario,
                    valijaId: valijaId,
                    fechaRecepcion: fechaRecepcion,
                },
                {}
            )
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.getListarVisitaAgenciaProvincia = function (fechaIn) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ListarVisitaAgenciaProvincia',
                {
                    fecha: fechaIn
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.getListarAgenciasPorEnviar = function (fechaIn) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ListarAgenciasPorEnviar',
                {
                    fecha: fechaIn
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getAgenciaPorEnviar = function (idRegistro) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/AgenciaPorEnviar',
                {
                    idRegistro: idRegistro
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getFechaServidor = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ObtenerFechaHora',
                null)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.setLimpiarDatosVisita = function (iId) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/LimpiarValija',
                {
                    idRegistro: iId,
                    userApp: $rootScope.Usuario.Id
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.setCancelarReprogramacion = function (idAgenciaTraslado) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/CancelarReprogramacion',
                {
                    idAgenciaTraslado: idAgenciaTraslado,
                    userApp: $rootScope.Usuario.Id,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.desactivarRegistro = function (iId) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/DesactivarRegistro',
                {
                    idRegistro: iId,
                    userApp: $rootScope.Usuario.Id,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.setRegistrarReprogramacion = function (
            idAgenciaTraslado,
            dFechaInicial,
            dFechaFinal,
            iMotivo
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/RegistrarReprogramacion',
                {
                    idAgenciaTraslado: idAgenciaTraslado,
                    dFechaInicial: dFechaInicial,
                    dFechaFinal: dFechaFinal,
                    iMotivo: iMotivo,
                    userApp: $rootScope.Usuario.Id,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.setModificarRecojoRecepcion = function (
            usuarioModificacion,
            jsonRegistro,
            jsonCamposDinamicos
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ModificarRecojoRecepcion',
                {
                    usuarioModificacion: usuarioModificacion,
                    sJSON: jsonRegistro,
                    sJSONCampos: jsonCamposDinamicos,
                    userApp: $rootScope.Usuario.Id,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.RegistrarAgenciaEnvioAUTD = function (
            idRegistro,
            jsonCamposDinamicos
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/AgenciaTraslado/RegistrarAgenciaEnvioAUTD',
                {},
                {
                    idRegistro: idRegistro,
                    sJSONCampos: jsonCamposDinamicos,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.setModificarEnvioRecepcion = function (
            usuarioModificacion,
            jsonRegistro,
            jsonCamposDinamicos
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ModificarEnvioRecepcion',
                {
                    usuarioModificacion: usuarioModificacion,
                    sJSON: jsonRegistro,
                    sJSONCampos: jsonCamposDinamicos,
                    userApp: $rootScope.Usuario.Id,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.getGenerarReporteEntregaDetalleLima = function (
            fechaDesde,
            fechaHasta
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/GenerarReporteEntregaDetalleLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.getGenerarReporteRecepcionDetalleProvincia = function (
            fechaDesde,
            fechaHasta
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/GenerarReporteRecepcionDetalleProvincia',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.getGenerarReporteRecepcionDetalleLima = function (
            fechaDesde,
            fechaHasta
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;
            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/GenerarReporteRecepcionDetalleLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.getGenerarReporteIncidenciasDetalleLima = function (
            fechaDesde,
            fechaHasta,
            idProveedor
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/GenerarReporteIncidenciasDetalleLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    idProveedor: idProveedor,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getGenerarReporteEntregaRecojoLima = function (
            fechaDesde,
            fechaHasta,
            idTipoServicio,
            agencia,
            idModalidadServicio,
            idEstado,
            comprobanteServicio,
            precinto
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/GenerarReporteEntregaRecojoLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    idTipoServicio: idTipoServicio,
                    agencia: agencia,
                    idModalidadServicio: idModalidadServicio,
                    idEstado: idEstado,
                    comprobanteServicio: comprobanteServicio,
                    precinto: precinto,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            
            return q.promise;
        };
        this.RegistrarRecojo = function (codigoUsuario, codigoAgencia, camposJSON) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id,
            };
            let data = {
                codigoUsuario: codigoUsuario,
                codigoAgencia: codigoAgencia,
                campos: camposJSON,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/AgenciaTraslado/RegistrarRecojoAgencia',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.PrepararEnvio = function (codigoUsuario, codigoAgencia, camposJSON) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id,
            };
            let data = {
                codigoUsuario: codigoUsuario,
                codigoAgencia: codigoAgencia,
                campos: camposJSON,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/AgenciaTraslado/PrepararEnvioAgencia',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.SubirArchivo = (nombreArchivo, idRegistro, archivo, fechaSubida) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            var formData = new FormData();
            formData.append("file", archivo);
            formData.append("userApp", $rootScope.Usuario.Id);
            formData.append("nombreArchivo", nombreArchivo);
            formData.append("idRegistro", idRegistro);
            formData.append("fechaSubida", fechaSubida);

            Requester.AuthorizationPostFile(urlServerWebApi + 'api/AgenciaTraslado/SubirArchivo',
                formData
            )
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(respuesta.data);
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ObtenerArchivo = (ruta) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGetFile(ruta,
                {
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(respuesta.data);
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.EliminarArchivo = (idRegistro, fechaEliminada) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {};
            let data = {
                idRegistro: idRegistro,
                fechaEliminada: fechaEliminada,
                userApp: $rootScope.Usuario.Id,
            };

            Requester.AuthorizationDelete(urlServerWebApi + 'api/AgenciaTraslado/EliminarArchivo',
                params,
                data,
            )
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            
            return q.promise;
        };

        this.ObtenerIncidenciaSegunTipo = (idRegistro, idTipoMotivo) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/AgenciaTraslado/ObtenerIncidenciaSegunTipo',
                {
                    idRegistro: idRegistro,
                    idTipoMotivo: idTipoMotivo
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            
            return q.promise;
        };

        /* ********************
         * ConfiguracionCampo *
         * *******************/


        this.listarCamposDinamicos2 = function (tipoRegistro, tipoAgencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/ConfiguracionCampo/ListarCamposDinamicosWeb',
                {
                    tipoRegistro: tipoRegistro,
                    tipoAgencia: tipoAgencia
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.listarCamposDinamicosReporte = function (tipoRegistro, tipoAgencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/ConfiguracionCampo/ListarCamposDinamicosReporte',
                {
                    tipoRegistro: tipoRegistro,
                    tipoAgencia: tipoAgencia
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.listarCamposDinamicos = function (tipoRegistro) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/ConfiguracionCampo/ListarCamposDinamicos',
                {
                    tipoRegistro: tipoRegistro
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.listarCamposDinamicosReporteGDIA = function (tipoRegistro) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/ConfiguracionCampo/ListarCamposDinamicosReporteGDIA',
                {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * **** Recepcion *****
         * *******************/

        this.setRegistrarRecepcionValija = function (json) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Recepcion/RecepcionarValijas',
                {
                    sJS: json
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.setRegistrarRecepcionValijaProvincia = function (json) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Recepcion/RecepcionarValijasProvincia',
                {
                    json: json
                },{})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * ***** Agencia  *****
         * *******************/
        this.getAgenciasActivasPorTipo = function (tipoAgencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Agencia/ListarAgenciasActivasPorTipo',
                {
                    tipoAgencia: tipoAgencia
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.ListarAgenciasRegistradas = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Agencia/ListarAgenciasRegistradas',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ListarProveedor = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Agencia/ListarProveedores',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.RegistrarNuevaAgencia = function (agencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id
            };
            let data = {
                idAgencia: agencia.codigoAgencia,
                agencia: agencia.agencia,
                idProveedor: agencia.idProveedor,
                idTipoAgencia: agencia.idTipoAgencia,
                diasPlazoRecepcion: agencia.diasPlazoRecepcion,
                arcoInferiorRecojo: agencia.arcoInferiorRecojo,
                arcoSuperiorRecojo: agencia.arcoSuperiorRecojo,
                frecuenciaRecojoLunes: agencia.frecuenciaRecojoLunes,
                frecuenciaRecojoMartes: agencia.frecuenciaRecojoMartes,
                frecuenciaRecojoMiercoles: agencia.frecuenciaRecojoMiercoles,
                frecuenciaRecojoJueves: agencia.frecuenciaRecojoJueves,
                frecuenciaRecojoViernes: agencia.frecuenciaRecojoViernes,
                frecuenciaRecojoSabado: agencia.frecuenciaRecojoSabado,
                frecuenciaEnvioLunes: agencia.frecuenciaEnvioLunes,
                frecuenciaEnvioMartes: agencia.frecuenciaEnvioMartes,
                frecuenciaEnvioMiercoles: agencia.frecuenciaEnvioMiercoles,
                frecuenciaEnvioJueves: agencia.frecuenciaEnvioJueves,
                frecuenciaEnvioViernes: agencia.frecuenciaEnvioViernes,
                frecuenciaEnvioSabado: agencia.frecuenciaEnvioSabado,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Agencia/RegistrarNuevaAgencia',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.ModificarAgencia = function (agencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id
            };
            let data = {
                idAgencia: agencia.codigoAgencia,
                agencia: agencia.agencia,
                idProveedor: agencia.idProveedor,
                idTipoAgencia: agencia.idTipoAgencia,
                diasPlazoRecepcion: agencia.diasPlazoRecepcion,
                arcoInferiorRecojo: agencia.arcoInferiorRecojo,
                arcoSuperiorRecojo: agencia.arcoSuperiorRecojo,

                frecuenciaRecojoLunes: agencia.frecuenciaRecojoLunes,
                frecuenciaRecojoMartes: agencia.frecuenciaRecojoMartes,
                frecuenciaRecojoMiercoles: agencia.frecuenciaRecojoMiercoles,
                frecuenciaRecojoJueves: agencia.frecuenciaRecojoJueves,
                frecuenciaRecojoViernes: agencia.frecuenciaRecojoViernes,
                frecuenciaRecojoSabado: agencia.frecuenciaRecojoSabado,

                frecuenciaEnvioLunes: agencia.frecuenciaEnvioLunes,
                frecuenciaEnvioMartes: agencia.frecuenciaEnvioMartes,
                frecuenciaEnvioMiercoles: agencia.frecuenciaEnvioMiercoles,
                frecuenciaEnvioJueves: agencia.frecuenciaEnvioJueves,
                frecuenciaEnvioViernes: agencia.frecuenciaEnvioViernes,
                frecuenciaEnvioSabado: agencia.frecuenciaEnvioSabado,

                estado: agencia.idEstado,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Agencia/ModificarAgencia',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.EliminarAgencia = function (agencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Agencia/EliminarAgencia',
                {
                    userApp: $rootScope.Usuario.Id,
                    idAgencia: agencia.codigoAgencia,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.ListarAgenciasActivasLP = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Agencia/ListarAgenciasActivasLP',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        /* ********************
         * ****** Envio  ******
         * *******************/
        this.setEnviarValija = function (json) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                sJS: json,
                userApp: $rootScope.Usuario.Id
            };
            let data = {};

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Envio/EnviarValijasAgencias',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.setListarValija = function (json) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                sJS: json,
                userApp: $rootScope.Usuario.Id
            };

            let data = {};

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Envio/ListarValijasAgencias',
                data,
                params,
                )
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.setRegistrarEnvioValija = function (json) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Envio/EnviarValijasAgencias',
                {
                    sJS: json,
                    userApp: $rootScope.Usuario.Id
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * ****** Motivo  *****
         * *******************/

        this.getListarMotivos = function (idTipoMotivo) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Motivo/ListarMotivos',
                {
                    idTipoMotivo: idTipoMotivo
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        /* ********************
         * ***** Reporte  *****
         * *******************/

        this.getGenerarReporteEntregaLima = function (
            fechaDesde,
            fechaHasta,
            idProveedor
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteEntregaLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    iProveedor: idProveedor,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getGenerarReporteEnvioLima = function (
            fechaDesde,
            fechaHasta,
            idProveedor
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteEnvioLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    iProveedor: idProveedor,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getGenerarReporteRecojoProvincia = function (
            fechaDesde,
            fechaHasta,
            idProveedor
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteRecojoProvincia',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    iProveedor: idProveedor,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getGenerarReporteRecepcionProvincia = function (
            fechaDesde,
            fechaHasta,
            idProveedor
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteRecepcionProvincia',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    iProveedor: idProveedor,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.getGenerarReporteRecojoLima = function (
            fechaDesde,
            fechaHasta,
            idProveedor
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteRecojoLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    iProveedor: idProveedor,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getGenerarReporteRecepcionLima = function (
            fechaDesde,
            fechaHasta,
            idProveedor
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteRecepcionLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    iProveedor: idProveedor,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getGenerarReporteIncidenciaLima = function (
            fechaDesde,
            fechaHasta
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteIncidenciaLima',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        /* ********************
         * *****  Correo  *****
         * *******************/

        this.RegistrarCorreo = function (
            correo,
            IdTipoReporteAutomatico,
            IdTipoCorreo
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                sCorreo: correo,
                IdTipoReporteAutomatico: IdTipoReporteAutomatico,
                IdTipoCorreo: IdTipoCorreo,
                userApp: $rootScope.Usuario.Id,
            };
            let data = {};

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Correo/RegistrarCorreo',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.EliminarCorreo = function (IdTipoReporteAutomatico, IdCorreo) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                IdTipoReporteAutomatico: IdTipoReporteAutomatico,
                IdCorreo: IdCorreo,
                userApp: $rootScope.Usuario.Id,
            };
            let data = {};

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Correo/EliminarCorreo',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ListarCorreos = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Correo/ListarCorreos',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ListarCorreoElectronicoMantenimiento = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Correo/ListarCorreoElectronicoMantenimiento',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ListarTipoReporteAutomatico = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Correo/ListarTipoReporteAutomatico',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * *****  Feriado  *****
         * *******************/

        this.EliminarFeriado = function (id) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Feriado/EliminarFeriado',
                {
                    idFeriado: id
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.ListarFeriadosActivos = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Feriado/ListarFeriadosActivos',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.RegistrarFeriado = function (feriado) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id,
            };
            let data = {
                dFecha: feriado.dFecha,
                sDescripcion: feriado.sDescripcion,
                iIdTipoAgencia: feriado.idTipoAgencia,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Feriado/RegistrarFeriado',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * ** RangoRecepcion  **
         * ********************/

        this.ListarRangoRecepcion = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/RangoRecepcion/ListarRangoRecepcionActivos',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.RegistrarRangoRecepcion = function (
            idTipoAgencia,
            idProveedor,
            rangoAEnviar
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id,
            };
            let data = {
                idTipoAgencia: idTipoAgencia,
                idProveedor: idProveedor,
                rango: rangoAEnviar,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/RangoRecepcion/RegistrarRangoRecepcion',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        /* ********************
         * ** Login Básico  ****
         * ********************/

        this.getLogin = function (user, pass) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Usuario/ValidarUsuario',
                {
                    sUsuario: user, sPassword: pass
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });



            return q.promise;
        };

        /* ********************
         * ** Login AzureAD  ***
         * ********************/

        this.getLoginAAD = function (accessToken) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Usuario/ValidarUsuarioAzureAD',
                {

                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getListarUsuarios = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Usuario/ListarUsuarioMantenimiento',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.getListarTipoUsuario = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Usuario/ListarTipoUsuario',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.RegistrarUsuario = function (registro) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id
            };
            let data = {
                sUsuario: registro.sUsuario,
                idTipoUsuario: registro.idTipoUsuario,
                sCodigoAgencia: registro.sCodigoAgencia,
                iIdProveedor: registro.iIdProveedor,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Usuario/RegistrarUsuario',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ActualizarUsuario = function (registro) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                userApp: $rootScope.Usuario.Id
            };
            let data = {
                sIdUsuario: registro.sIdUsuario,
                sUsuario: registro.sUsuario,
                idTipoUsuario: registro.idTipoUsuario,
                sCodigoAgencia: registro.sCodigoAgencia,
                iIdProveedor: registro.iIdProveedor,
                iActivo: registro.iActivo,
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Usuario/ActualizarUsuario',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.IngestaUsuario = function (data) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Usuario/IngestaUsuario',
                {
                    usuarios: JSON.stringify(data),
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * ** Configuracion  ***
         * ********************/

        this.ValidarOpcionesWeb = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Configuracion/ValidarOpcionesWeb',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * **** Indicador  ****
         * ********************/

        this.getColoresIndicador = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Indicador/ListarIndicadorColor',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        /* ********************
         * ******** Menu *******
         * *******************/
        this.ListarMenuPorTipoUsuario = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Menu/ListarMenuPorTipoUsuario',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        /* ********************
         * **** Auditoria *****
         * *******************/
        this.ConsultarAuditoria = function (fechaDesde, fechaHasta, IdTipoReporte) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Auditoria/ConsultarAuditoria',
                {
                    fechaDesde: fechaDesde,
                    fechaHasta: fechaHasta,
                    IdTipoReporte: IdTipoReporte,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    var datos = [];
                    angular.forEach(respuesta.data, function (value, key) {
                        var registro = value;
                        datos.push(registro);
                    });
                    $rootScope.cargando = false;
                    q.resolve(datos);
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * **** Bolsas *****
         * *******************/

        this.ListarTipoBolsa = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Bolsa/ListarTipoBolsa',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ListarBolsasActivas = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Bolsa/ListarBolsasActivas',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.GenerarLoteBolsa = function (data) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Bolsa/GenerarLoteBolsa',
                {
                    codigoLote: data.sCodigoJumbo,
                    fecha: data.fecha,
                    observacion: data.observacion,
                    bolsasJson: JSON.stringify(data.bolsas),
                },
                {}
            )
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ListarLotesEnProceso = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Bolsa/ListarLotesEnProceso',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.EnviarLotes = function (data) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Bolsa/EnviarLotes',
                {
                    lotesJson: JSON.stringify(data)
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ListarLotesEnviados = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Bolsa/ListarLotesEnviados',
                {

                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.TerminarEnvioLote = function (codigoEnvio) {
            var q = $q.defer();
            $rootScope.cargando = true;

            let params = {
                codigoEnvio: codigoEnvio
            };
            let data = {};

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Bolsa/TerminarEnvioLote',
                data,
                params)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(respuesta.data);
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ExportarEnvioLote = function (codigoEnvio) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Bolsa/ExportarEnvioLote',
                {
                    codigoEnvio: codigoEnvio
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.ReporteBolsasPorFechaHorario = function (dFechaInicio, dFechaFin) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteBolsasPorFechaHorario',
                {
                    dFechaInicio: dFechaInicio,
                    dFechaFin: dFechaFin
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.DiasConTraslado = function (dFechaInicio, dFechaFin) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/DiasConTraslado',
                {
                    dFechaInicio: dFechaInicio,
                    dFechaFin: dFechaFin
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

            return q.promise;
        };

        this.BolsasNaranjasPorFechasResumen = function (dFechaInicio, dFechaFin) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/BolsasNaranjasPorFechasResumen',
                {
                    dFechaInicio: dFechaInicio,
                    dFechaFin: dFechaFin
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.BolsasNaranjasPorFechasDetalle = function (dFechaInicio, dFechaFin) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/BolsasNaranjasPorFechasDetalle',
                {
                    dFechaInicio: dFechaInicio,
                    dFechaFin: dFechaFin
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.GenerarReporteBolsasTodo = function (
            tipoBolsa,
            dFechaInicio,
            dFechaFin
        ) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/Reporte/GenerarReporteBolsasTodo',
                {
                    tipoBolsa: tipoBolsa,
                    dFechaInicio: dFechaInicio,
                    dFechaFin: dFechaFin,
                })
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        /* ********************
         * **** PROVEEDOR *****
         * *******************/

        this.registrarLlegadaAgencia = (
            codigoUsuario,
            codigoRegistro,
            fechaLlegada
        ) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Proveedor/RegistrarLlegadaAgencia',
                {
                    codigoUsuario: codigoUsuario,
                    codigoRegistro: codigoRegistro,
                    fechaLlegada: fechaLlegada,
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });



            return q.promise;
        };

        this.registrarRecojoAgencia = (
            codigoUsuario,
            codigoRegistro,
            fechaRecojo,
            obsProveedor,
            jsonRegistroDinamico,
            huboRecojo
        ) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Proveedor/RegistrarRecojoAgencia',
                {
                    codigoUsuario: codigoUsuario,
                    codigoRegistro: codigoRegistro,
                    fechaRecojo: fechaRecojo,
                    obsProveedor: obsProveedor,
                    jsonRegistroDinamico: jsonRegistroDinamico,
                    huboRecojo: huboRecojo
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.guardarObsRecojoUTD = (idRegistro, obsProveedor) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Proveedor/GuardarObsRecojoUTD',
                {
                    userApp: $rootScope.Usuario.Id,
                    idRegistro: idRegistro,
                    obsProveedor: obsProveedor,
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.registrarRecojoUTD = (
            codigoUsuario,
            codigoRegistros,
            fechaRecojo,
            fechaLlegada
        ) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Proveedor/RegistrarRecojoUTD',
                {
                    codigoUsuario: codigoUsuario,
                    codigoRegistros: codigoRegistros,
                    fechaRecojo: fechaRecojo,
                    fechaLlegada: fechaLlegada,
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });



            return q.promise;
        };

        this.registrarEntregaUTD = (
            codigoUsuario,
            codigoRegistros,
            fechaEntrega,
            fechaLlegada
        ) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Proveedor/RegistrarEntregaUTD',
                {
                    codigoUsuario: codigoUsuario,
                    codigoRegistros: codigoRegistros,
                    fechaEntrega: fechaEntrega,
                    fechaLlegada: fechaLlegada,
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.registrarEntregaAgencia = (            
            codigoRegistro,
            fechaEntrega
        ) => {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Proveedor/RegistrarEntregaAgencia',
                {
                    codigoUsuario: $rootScope.Usuario.Id,
                    codigoRegistro: codigoRegistro,
                    fechaEntrega: fechaEntrega,
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };

        this.registrarIncidenciaProveedor = function (idRegistro, idMotivo, motivoOtro, fechaIncidencia) {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationPost2(urlServerWebApi + 'api/Proveedor/RegistrarIncidenciaAgencia',
                {
                    idUsuario: $rootScope.Usuario.Id,
                    idRegistro: idRegistro,
                    idMotivo: idMotivo,
                    motivoOtro: motivoOtro,
                    fechaIncidencia: fechaIncidencia
                }, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(respuesta.data);
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        }

        this.envioCorreoIncidenciaRecojoAgencia = function (agencia, sMotivo, otroMotivo, fechaServidor) {
            var q = $q.defer();

            var data = {
                agencia: agencia,
                sMotivo: sMotivo,
                otroMotivo: otroMotivo,
                fechaServidor: fechaServidor
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/EnvioCorreo/EnviarCorreoIncidenciaRecojoAgencia',
                data ,null)
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(respuesta.data);
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };


        ///////////////////////////////////////
        this.envioCorreoNoHuboRecojoAgencia = function (agencia, sMotivo, fechaServidor) {
            var q = $q.defer();

            var data = {
                agencia: agencia,
                sMotivo: sMotivo,
                fechaServidor: fechaServidor
            };

            Requester.AuthorizationPost2(urlServerWebApi + 'api/EnvioCorreo/EnviarCorreoNoHuboRecojoAgencia',
                data, {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(respuesta.data);
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al reportar la incidencia");
                });
            
            return q.promise;
        };

        /* ********************
         * * Estado Registro *
         * *******************/

        this.ListarEstadoRegistro = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/EstadoRegistro/ListarEstadoRegistro',
                {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });
            
            return q.promise;
        };

        /* ********************
         * * Tipo Servicio *
         * *******************/


        this.ListarTipoServicio = function () {
            var q = $q.defer();
            $rootScope.cargando = true;

            Requester.AuthorizationGet(urlServerWebApi + 'api/TipoServicio/ListarTipoServicio',
                {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });


            return q.promise;
        };


        /* ********************
         * ** Tipo Registro **
         * *******************/

        this.ListarTipoRegistro = function () {
            var q = $q.defer();
            $rootScope.cargando = true;
            Requester.AuthorizationGet(urlServerWebApi + 'api/TipoRegistro/ListarTipoRegistro',
                {})
                .then(function (respuesta) {
                    $rootScope.cargando = false;
                    q.resolve(JSON.parse(respuesta.data));
                }, function (error) {
                    $rootScope.cargando = false;
                    q.reject("Error al cargar");
                });

           
            return q.promise;
        };
    },
]);