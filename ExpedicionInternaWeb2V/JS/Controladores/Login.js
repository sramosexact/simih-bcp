angular.module('simihApp').controller('loginCtrol', ['$scope', 'localStorageService', '$rootScope',
    function ($scope, localStorageService, $rootScope) {
        $rootScope.mostroNoti = false;
        $rootScope.iNotificaciones = [];
        $scope.recuerdame = false;
        //$rootScope.menuEnabled = false;
        $scope.menuEnabledv = false;

        $rootScope.verMensajeAzure = false;
        $rootScope.mensajeAzure = "";

        localStorageService.remove('viu');
        localStorageService.remove('recordar');
        $rootScope.recordar = [];
        $rootScope.MenuGuardado = [];
        $rootScope.Bandejals = [];
        $rootScope.Usuariols = [];
        $rootScope.Configuracionls = [];
        $rootScope.barraNotificacion = false;
        $rootScope.userWinAuth = "";        

        $rootScope.spinnerLogin = false;
                
        $scope.logInAzureAD =  function() {            

            $scope.client.loginRedirect($scope.request);

        };

        $scope.logOutAD = function () {
            $scope.client.logout();
        };

        if (!$scope.isUndefinedOrNullOrEmpty(localStorageService.get('msalTokenId'))) {
            //console.log("msalTokenId : ----> ", localStorageService.get('msalTokenId'));
            $scope.validarCuentaAzureADRegistrada(localStorageService.get('msalTokenId'));
        }

    }]);

