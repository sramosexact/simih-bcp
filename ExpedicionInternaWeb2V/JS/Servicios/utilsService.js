angular.module('simihApp').service('UtilsService',['$filter',function($filter){

	this.isUndefinedOrNull = function(obj) {
         return !angular.isDefined(obj) || obj===null;
    }

    this.isUndefinedOrNullOrEmpty = function(obj) {
         return !angular.isDefined(obj) || obj===null || obj.length === 0;
    }

    this.UniqueArraybyId  = function(collection, keyname) {
              var output = [], 
                  keys = [];

              angular.forEach(collection, function(item) {
                  var key = item[keyname];
                  if(keys.indexOf(key) === -1) {
                      keys.push(key);
                      output.push(item);
                  }
              });
        return output;
   	};

    this.convertirFechaHoraToDate = function(fecha, hora){

      sFecha = $filter('date')(fecha, 'yyyy-MM-dd');

      return moment(sFecha+'T'+hora).toDate(); 

    };

    this.ListarObjetoPorValorDeLlave = function(llave, valor, lista){

      return lista.find(function(objeto){

        return objeto[llave] == valor;

      });
      
    };

    this.ListarAtributoPorValorDeLlave = function(atributo, llave, valor, lista){

      return lista.find(function(objeto){

        return objeto[llave] == valor;

      })[atributo];

    };

    this.reemplazarNulo = function(objeto, nuevoValor){

      return this.isUndefinedOrNull(objeto) ? nuevoValor : objeto ;

    };

    this.tieneIgualAtributo = function(objeto1, objeto2){

      for (var property in objeto1) {
        if (objeto1.hasOwnProperty(property)) {
          for (var property2 in objeto2){
            if (objeto2.hasOwnProperty(property2)) {
              if (objeto1[property].length != 0 && objeto1[property] == objeto2[property2]) {
                return true;
              }
            }
          }
        }
      }

      return false;

    };

    this.toUTF8Array = function (str) {
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

    this.arrayBufferToBase64 = function (buffer) {
        var binary = '';
        var bytes = new Uint8Array(buffer);
        var len = bytes.byteLength;
        for (var i = 0; i < len; i++) {
            binary += String.fromCharCode(bytes[i]);
        }
        return window.btoa(binary);
    };

    this.stringToBase64 = function (string) {

        var utf8 = this.toUTF8Array(string);
        return this.arrayBufferToBase64(utf8);
    };

    this.MaysPrimera = function (string) {

        return string.charAt(0).toUpperCase() + string.slice(1);

    };

    this.getJsDateFromExcel = function(serial) {
        var utc_days = Math.floor(serial - 25568);
        var utc_value = utc_days * 86400;
        var date_info = new Date(utc_value * 1000);

        var fractional_day = serial - Math.floor(serial) + 0.0000001;

        var total_seconds = Math.floor(86400 * fractional_day);

        var seconds = total_seconds % 60;

        total_seconds -= seconds;

        var hours = Math.floor(total_seconds / (60 * 60));
        var minutes = Math.floor(total_seconds / 60) % 60;

        return new Date(date_info.getFullYear(), date_info.getMonth(), date_info.getDate(), hours, minutes, seconds);
    }

}]);