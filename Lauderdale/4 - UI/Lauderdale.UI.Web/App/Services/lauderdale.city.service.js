(function () {
    'use strict';

    angular.module('lauderdale').factory('cityService', CityService);
    CityService.$inject = ['$http'];

    function CityService($http) {

        var baseUrl = 'http://localhost:50338/api/cities';

        return {
            getAll: function () {
                return $http({
                    method: 'GET',
                    url: baseUrl
                });
            },

            save: function (city) {
                return $http({
                    method: 'POST',
                    url: baseUrl,
                    data: city
                });
            },

            remove: function (id) {
                return $http({
                    method: 'DELETE',
                    url: baseUrl + '/' + id
                });
            },

            get: function (id) {
                return $http({
                    method: 'GET',
                    url: baseUrl + '/' + id
                });
            }
        };
    }
})();