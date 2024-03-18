angular.module('simihApp').service("ImportarService", function () {


    this.importarData = function (file, callback) {

        var reader = new FileReader();

        reader.onload = function (e) {
            /* read workbook */
            var bstr = e.target.result;
            var wb = XLSX.read(bstr, { type: 'binary' });
            var d = XLSX.utils.sheet_to_json(wb.Sheets[wb.SheetNames[0]]);

            /* DO SOMETHING WITH workbook HERE */

            callback(d);
        };

        reader.readAsBinaryString(file);

    };


});