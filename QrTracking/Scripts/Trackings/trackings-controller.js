'use strict';

registrationModule.controller("TrackingsController", function($scope, trackingRepository, $location) {
    $scope.trackings = trackingRepository.query();
   
    $scope.addTracking = function() {
        $location.path('/Trackings/Add');
    };
});