angular.module('simihApp').service('NotificacionService', ['TipoNotificacion', 'swangular', function (TipoNotificacion, swangular) {
    this.mostrarNotificacionSimple = function (mensaje, tipoNotificacion) {
        switch (tipoNotificacion) {
            case TipoNotificacion.SUCCESS:
                swangular.swal({
                    type: 'success',
                    title: 'Éxito!',
                    text: mensaje
                });
                break;
            case TipoNotificacion.INFO:
                swangular.swal({
                    type: 'info',
                    title: 'Información!',
                    text: mensaje
                });
                break;
            case TipoNotificacion.WARNING:
                swangular.swal({
                    type: 'warning',
                    title: 'Advertencia!',
                    text: mensaje                    
                });
                break;
            case TipoNotificacion.ALERT:
                swangular.swal({
                    type: 'alert',
                    title: 'Alerta!',
                    text: mensaje                    
                });
                break;
        }
    };

}]);