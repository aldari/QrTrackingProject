registrationModule.factory('trackingRepository', function ($resource) {
    return $resource(
        "/api/Tracking/:Id",
        { Id: "@Id" },
        {
            "update": { method: "PUT" },
//            "reviews": { 'method': 'GET', 'params': { 'reviews_only': "true" }, isArray: true }
        }
    );
});