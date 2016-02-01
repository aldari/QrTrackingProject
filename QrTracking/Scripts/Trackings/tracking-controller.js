'use strict';

registrationModule.controller("TrackingController", function ($scope, trackingRepository, codeRepository, $location, $routeParams) {
    $scope.data = {};
    $scope.data.tracking = {};
    $scope.data.codes = [];
    $scope.data.lastCodes = [];
    if ($routeParams.id) {
        $scope.data.tracking = trackingRepository.get({}, { 'Id': $routeParams.id });
        $scope.data.codes = codeRepository.query({},{ 'Id': $routeParams.id });
    }
    
    $scope.clear = function() {
        $scope.data.lastCodes.splice(0, $scope.data.lastCodes.length);
    };

    $scope.barcodeChanged = function() {
        angular.element('#qrCodeInput').trigger('focus');
    };
    
    $scope.qrCodeChanged = function () {
        var code = new codeRepository();
        code.barcode = $scope.data.barcodeInput;
        code.qrCodeLine = $scope.data.qrCodeInput;
        var newCode = codeRepository.save({ id: $routeParams.id }, code);
        $scope.data.codes.push(newCode);
        $scope.data.lastCodes.push(newCode);
        angular.element('#barcodeInput').trigger('focus');
        $scope.data.barcodeInput = "";
        $scope.data.qrCodeInput = "";
    };

    $scope.deleteScan = function(barcode) {
        if (confirm('Are you sure you want to delete?')) {
            codeRepository.delete({ id: barcode.id }, function (success) {
                var index = $scope.data.codes.indexOf(barcode);
                $scope.data.codes.splice(index, 1);
                var index2 = $scope.data.lastCodes.indexOf(barcode);
                if (index2!=-1)
                    $scope.data.lastCodes.splice(index2, 1);
            });
        } else {
            //Do nothing!
        }
    };
});