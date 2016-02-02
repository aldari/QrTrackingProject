'use strict';

registrationModule.controller("SearchController", function ($scope, searchRepository) {
    $scope.model = {};
    $scope.model.searchPattern = '';
    $scope.search = function() {
        $scope.model.trackings = searchRepository.query({}, { 'Id': $scope.model.searchPattern });
    };
});