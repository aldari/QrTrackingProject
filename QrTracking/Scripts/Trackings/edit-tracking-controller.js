'use strict';

registrationModule.controller("EditTrackingController", function ($scope, $window, $location, $routeParams, trackingRepository) {

    $scope.tracking = trackingRepository.get({}, { 'Id': $routeParams.id }, function (_data) {
        _data.orderDate = new Date(_data.orderDate);
    });
    $scope.submitForm = function (tracking) {
        $scope.error = false;
        trackingRepository.save(tracking).$promise.then(
            function () { $location.url('/Trackings'); },
            function () { $scope.error = true; });
    };
    $scope.cancelForm = function () {
        $window.history.back();
    };
    
    $scope.popup1 = {
        opened: false
    };
    
    $scope.open1 = function () {
        $scope.popup1.opened = true;
    };
    
    $scope.shifts = ["Day", "Swing", "Grave"];
});