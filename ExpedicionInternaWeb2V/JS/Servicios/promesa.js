'use strict';

angular.module('simihApp').service('Promesa', ['$http', '$q', function ($http, $q) {

    this.post = function (url) {

        var defered = $q.defer();
        var promise = defered.promise;

        $http({
            method: 'POST',
            withCredentials: true,
            url: url,
            data: 'json'
        }).then(function (data, status, headers, config) {
            defered.resolve(data.data);
        }, function (data, status, headers, config) {
            defered.reject(status);
        });

        return promise;
    };

    

}])