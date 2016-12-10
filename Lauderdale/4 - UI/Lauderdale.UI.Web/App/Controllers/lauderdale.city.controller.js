(function () {
    'use strict';
    angular.module('lauderdale').controller('cityController', CityController);
    CityController.$inject = ['$scope', 'cityService'];

    function CityController($scope, cityService) {

        $scope.city = {};
        $scope.cities = [];
        $scope.show = false;

        $scope.getAll = function () {
            cityService.getAll().success(function (data) {
                if (data.notes) {
                    response.notes.forEach(function (msg) {
                        alertify.error(msg.description);
                    });
                    return;
                }
                $scope.cities = data;
            }).error(function (response) {
                if (!response.notes) return;
                response.notes.forEach(function (msg) {
                    alertify.error(msg.description);
                });
            });
        };

        $scope.save = function () {
            cityService.save($scope.city).success(function (data) {
                $scope.city = {};
                $scope.getAll();               
                data.notes.forEach(function (msg) {
                    alertify.success(msg.description);
                });
            }).error(function (response) {
                response.Notes.forEach(function (msg) {
                    alertify.error(msg.description);
                });
            });
        };

        $scope.remove = function (id) {
            cityService.remove(id).success(function (data) {

                data.notes.forEach(function (msg) {
                    alertify.success(msg.description);
                });

                $scope.getAll();

            }).error(function (response) {
                response.Notes.forEach(function (msg) {
                    alertify.error(msg.Description);
                });
            });
        };

        $scope.get = function (id) {
            cityService.get(id).success(function (data) {
                if (data.notes) {
                    response.notes.forEach(function (msg) {
                        alertify.error(msg.description);
                    });
                    return;
                }

                $scope.city = data;
                $scope.show = true;
            }).error(function (response) {
                response.notes.forEach(function (msg) {
                    alertify.error(msg.description);
                });
            });
        };

        activate();

        function activate(){
            $scope.getAll();
        }
    }
})();
