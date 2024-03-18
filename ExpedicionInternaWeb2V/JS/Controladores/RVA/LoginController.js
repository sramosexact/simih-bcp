app.controller('LoginCtrl', ['$scope', 'msalAuthenticationService',
    function ($scope, msalService) {

        $scope.concatenar = '';
        $scope.setActiveNavBar(false);
        $scope.frmDatosLogin = {};

        if (!$scope.isUndefinedOrNullOrEmpty(msalService.getUser())) {
            $scope.validarCuentaAzureADRegistrada();
        }

        $scope.logInAzureAD = function () {            
            msalService.loginRedirect();
        }
        
        $scope.Limpiar = function () {
            $scope.frmDatosLogin.usuario = undefined;
            $scope.frmDatosLogin.password = undefined;
            $scope.frmLogin.usuario.$pristine = true;
            $scope.frmLogin.usuario.$valid = true;
            $scope.frmLogin.password.$pristine = true;
            $scope.frmLogin.password.$valid = true;
            $scope.frmLogin.password.$touched = false;
            $scope.frmLogin.password.$touched = false;
        };

    }]);