registrationModule.factory('codeRepository', function ($resource) {
    return $resource(
        "/api/Code/:Id",
        { Id: "@Id" },
        { 'update': { method: "PUT" } }
    );
});