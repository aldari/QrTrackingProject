var registrationModule = angular.module("registrationModule", ['ngRoute', 'ngResource', 'ngAnimate', 'ngSanitize', 'ui.bootstrap'])
    .config(function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);
        $routeProvider.when('/Trackings', { templateUrl: '/templates/trackings.html', controller: 'TrackingsController' });
        $routeProvider.when('/Trackings/Add', { templateUrl: '/templates/addtracking.html', controller: 'AddTrackingController' });
        $routeProvider.when('/Trackings/:id', { templateUrl: '/templates/tracking.html', controller: 'TrackingController' });
        $routeProvider.when('/Trackings/Edit/:id', { templateUrl: '/templates/edittracking.html', controller: 'EditTrackingController' });
        $routeProvider.when('/Search', { templateUrl: '/templates/search.html', controller: 'SearchController' });
        $routeProvider.otherwise({ redirectTo: "/Trackings" });
    });