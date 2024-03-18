angular.module('simihApp').service('Requester', ['$http', '$q', '$rootScope', 'UtilsService', '$alert',
    function ($http, $q, $rootScope, UtilsService, $alert) {

        var requester = this;

        this.AuthorizationPost = function (url, data) {

            var defered = $q.defer();
            var promise = defered.promise;

            this.post(url, data, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data1) {
                defered.resolve(data1);
            }, function (error) {
                if (error === 498) {
                    requester.RefreshToken().then(function (data2) {
                        if (!(data2 === null || data2 === undefined)) {
                            var dataObject = data2;
                            $rootScope.token = dataObject.token;
                            $rootScope.refreshToken = dataObject.refreshToken;

                            requester.post(url, data, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data3) {
                                defered.resolve(data3);
                            }, function (error) {
                                defered.reject(error);
                            });

                        } else {
                            defered.reject(error.status);
                        }

                    }, function (error) {
                        defered.reject(error);
                    });

                } else {
                    defered.reject(error);
                }
            });

            return promise;
        };

        this.AuthorizationGet = function (url, params) {

            var defered = $q.defer();
            var promise = defered.promise;

            this.get(url, params, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data1) {
                defered.resolve(data1);
            }, function (error) {
                if (error === 498 || error === 401) {
                    requester.RefreshToken().then(function (data2) {
                        if (!(data2 === null || data2 === undefined)) {
                            var dataObject = data2;
                            $rootScope.token = dataObject.token;
                            $rootScope.refreshToken = dataObject.refreshToken;

                            requester.get(url, params, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data3) {
                                defered.resolve(data3);
                            }, function (error) {
                                defered.reject(error);
                            });

                        } else {
                            defered.reject(error.status);
                        }

                    }, function (error) {
                        defered.reject(error);
                    });

                } else {
                    defered.reject(error);
                }
            });

            return promise;
        };

        this.AuthorizationDelete = function (url, params, data) {

            var defered = $q.defer();
            var promise = defered.promise;

            this.delete(url, params, data, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data1) {
                defered.resolve(data1);
            }, function (error) {
                if (error === 498 || error === 401) {
                    requester.RefreshToken().then(function (data2) {
                        if (!(data2 === null || data2 === undefined)) {
                            var dataObject = data2;
                            $rootScope.token = dataObject.token;
                            $rootScope.refreshToken = dataObject.refreshToken;

                            requester.delete(url, params, data, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data3) {

                                defered.resolve(data3);

                            }, function (error) {
                                defered.reject(error);
                            });

                        } else {
                            defered.reject(error.status);
                        }

                    }, function (error) {
                        defered.reject(error);
                    });

                } else {
                    defered.reject(error);
                }
            });

            return promise;
        };

        this.AuthorizationPostFile = function (url, formData) {

            var defered = $q.defer();
            var promise = defered.promise;

            this.postFileAuthorization(url, formData, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data1) {
                defered.resolve(data1);
            }, function (error) {
                if (error === 498 || error === 401) {
                    requester.RefreshToken().then(function (data2) {
                        if (!(data2 === null || data2 === undefined)) {
                            var dataObject = data2;
                            $rootScope.token = dataObject.token;
                            $rootScope.refreshToken = dataObject.refreshToken;

                            requester.postFile(url, formData, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data3) {
                                defered.resolve(data3);
                            }, function (error) {
                                defered.reject(error);
                            });

                        } else {
                            defered.reject(error.status);
                        }

                    }, function (error) {
                        defered.reject(error);
                    });

                } else {
                    defered.reject(error);
                }
            });

            return promise;
        };

        this.AuthorizationGetFile = function (url, params) {

            var defered = $q.defer();
            var promise = defered.promise;

            this.getFile(url, params, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data1) {
                defered.resolve(data1);
            }, function (error) {
                if (error === 498 || error === 401) {
                    requester.RefreshToken().then(function (data2) {
                        if (!(data2 === null || data2 === undefined)) {
                            var dataObject = data2;
                            $rootScope.token = dataObject.token;
                            $rootScope.refreshToken = dataObject.refreshToken;

                            requester.getFile(url, params, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data3) {
                                defered.resolve(data3);
                            }, function (error) {
                                defered.reject(error);
                            });

                        } else {
                            defered.reject(error.status);
                        }

                    }, function (error) {
                        defered.reject(error);
                    });

                } else {
                    defered.reject(error);
                }
            });

            return promise;
        };
        this.AuthorizationPost2 = function (url, data, params) {

            var defered = $q.defer();
            var promise = defered.promise;

            this.post2(url, data, params, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data1) {
                defered.resolve(data1);
            }, function (error) {
                if (error === 498 || error === 401) {
                    requester.RefreshToken().then(function (data2) {
                        if (!(data2 === null || data2 === undefined)) {
                            var dataObject = data2;
                            $rootScope.token = dataObject.token;
                            $rootScope.refreshToken = dataObject.refreshToken;

                            requester.post2(url, data, params, 'Bearer ' + UtilsService.stringToBase64($rootScope.token)).then(function (data3) {
                                defered.resolve(data3);
                            }, function (error) {
                                defered.reject(error);
                            });

                        } else {
                            defered.reject(error.status);
                        }

                    }, function (error) {
                        defered.reject(error);
                    });

                } else {
                    defered.reject(error);
                }
            });

            return promise;
        };

        this.SimplePost = function (url, data) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: url,
                data: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Data-Type': 'json'
                },
            }).then(function (response) {
                defered.resolve(JSON.parse(response.data.d));
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

        this.RefreshToken = function () {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: $rootScope.rutaHost + 'Auth.asmx/refreshToken',
                data: null,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Data-Type': 'json',
                    'Authorization': 'Bearer ' + UtilsService.stringToBase64($rootScope.refreshToken)
                },
            }).then(function (response) {
                defered.resolve(JSON.parse(response.data.d));
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

        this.post = function (url, data, authorizationHeader) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: url,
                data: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Data-Type': 'json',
                    'Authorization': authorizationHeader
                },
            }).then(function (response) {
                defered.resolve(JSON.parse(response.data.d));
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

        this.get = function (url, params, authorizationHeader) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'GET',
                url: url,
                params: params,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Data-Type': 'json',
                    'Authorization': authorizationHeader
                },
            }).then(function (response) {
                defered.resolve(response);
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

        this.delete = function (url, params, data, authorizationHeader) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'DELETE',
                url: url,
                params: params,
                data: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Data-Type': 'json',
                    'Authorization': authorizationHeader
                },
            }).then(function (response) {
                defered.resolve(response);
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

        this.winLogin = function (dominio, usuario) {

            var defered = $q.defer();
            var promise = defered.promise;
            var parameter = {};

            var credenciales = dominio + ':' + usuario;
            var credencialesByte = toUTF8Array(credenciales);
            var credencialesBase64 = arrayBufferToBase64(credencialesByte);

            $http({
                method: 'POST',
                url: $rootScope.rutaHost + 'SeguridadWS.asmx/WinLoginWeb',
                data: JSON.stringify(parameter),
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',
                    'Data-Type': 'json',
                    'Authorization': 'Basic ' + credencialesBase64
                },
            }).then(function (response) {
                defered.resolve(JSON.parse(response.data.d));
            }, function (response) {

                if (response.status === 401) {
                    $alert(
                        {
                            title: 'Credenciales incorrectas',
                            content: 'Ingrese correctamente sus credenciales',
                            placement: 'top-right',
                            type: 'danger',
                            container: "#loginMessage",
                            show: true,
                            duration: 5
                        });
                    return;
                }
                $alert(
                    {
                        title: 'Hubo un error en la comunicación HTTP',
                        content: 'Comuníquese con el administrador del sistema',
                        placement: 'top-right',
                        type: 'danger',
                        container: "#loginMessage",
                        show: true,
                        duration: 5
                    });
            });

            return promise;
        }

        var toUTF8Array = function (str) {
            var utf8 = [];
            for (var i = 0; i < str.length; i++) {
                var charcode = str.charCodeAt(i);
                if (charcode < 0x80) utf8.push(charcode);
                else if (charcode < 0x800) {
                    utf8.push(0xc0 | (charcode >> 6),
                        0x80 | (charcode & 0x3f));
                }
                else if (charcode < 0xd800 || charcode >= 0xe000) {
                    utf8.push(0xe0 | (charcode >> 12),
                        0x80 | ((charcode >> 6) & 0x3f),
                        0x80 | (charcode & 0x3f));
                }
                // surrogate pair
                else {
                    i++;
                    // UTF-16 encodes 0x10000-0x10FFFF by
                    // subtracting 0x10000 and splitting the
                    // 20 bits of 0x0-0xFFFFF into two halves
                    charcode = 0x10000 + (((charcode & 0x3ff) << 10)
                        | (str.charCodeAt(i) & 0x3ff));
                    utf8.push(0xf0 | (charcode >> 18),
                        0x80 | ((charcode >> 12) & 0x3f),
                        0x80 | ((charcode >> 6) & 0x3f),
                        0x80 | (charcode & 0x3f));
                }
            }
            return utf8;
        }

        var arrayBufferToBase64 = function (buffer) {
            var binary = '';
            var bytes = new Uint8Array(buffer);
            var len = bytes.byteLength;
            for (var i = 0; i < len; i++) {
                binary += String.fromCharCode(bytes[i]);
            }
            return window.btoa(binary);
        };


        this.PostFile = function (url, pdf) {

            var defered = $q.defer();
            var promise = defered.promise;
            var fileURL;
            var url_pdf = url + pdf;

            $http.post(url_pdf, { responseType: 'arraybuffer' })
                .then(function (response) {
                    var file = new Blob([response.data], { type: 'application/pdf' });
                    fileURL = URL.createObjectURL(file);
                    defered.resolve(fileURL);
                }, function (response) {
                    defered.reject(response.status);
                });
            return promise;
        };

        this.postFileAuthorization = function (url, formData, authorizationHeader) {
            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: url,
                data: formData,
                transformRequest: angular.identity,
                headers: {
                    'Content-Type': undefined,
                    'Authorization': authorizationHeader
                },
            }).then(function (response) {
                defered.resolve(response);
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

        this.getFile = function (url, params, authorizationHeader) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'GET',
                url: url,
                params: params,
                responseType: "blob",
                headers: {
                    'Content-Type': undefined,
                    'Authorization': authorizationHeader
                },
            }).then(function (response) {
                defered.resolve(response);
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

        this.post2 = function (url, data, params, authorizationHeader) {

            var defered = $q.defer();
            var promise = defered.promise;

            var dataJson = JSON.stringify(data);

            $http({
                method: 'POST',
                url: url,
                params: params,
                data: dataJson,
                headers: {
                    'Content-Type': 'application/json; charset=utf-8',  
                    'Data-Type': 'json',
                    'Authorization': authorizationHeader
                },
            }).then(function (response) {
                defered.resolve(response);
            }, function (response) {
                defered.reject(response.status);
            });

            return promise;
        }

    }])