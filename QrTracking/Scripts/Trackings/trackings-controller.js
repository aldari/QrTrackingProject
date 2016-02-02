'use strict';

registrationModule.controller("TrackingsController", function($scope, trackingRepository, $location) {
    $scope.trackings = trackingRepository.query();
   
    $scope.addTracking = function() {
        $location.path('/Trackings/Add');
    };
    
    $scope.popup1 = {
        opened: false
    };

    $scope.open1 = function () {
        $scope.popup1.opened = true;
    };
    
    $scope.popup2 = {
        opened: false
    };

    $scope.open2 = function () {
        $scope.popup2.opened = true;
    };
});