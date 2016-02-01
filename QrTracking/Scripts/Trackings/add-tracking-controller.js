'use strict';

registrationModule.controller("AddTrackingController", function ($scope, $window, $location, trackingRepository) {
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