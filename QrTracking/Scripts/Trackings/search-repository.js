registrationModule.factory('searchRepository', function ($resource) {
    return $resource(
        "/api/Search/:Id",
        { Id: "@Id" }
    );
});