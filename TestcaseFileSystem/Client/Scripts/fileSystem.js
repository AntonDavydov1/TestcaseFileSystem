(function (app) {

    var config = function ($routeProvider) {
        $routeProvider
            .when("/list/:directory*?", {
                templateUrl: "/Client/Views/filesystem.html",
                controller: "ContentController"
            })
            .otherwise({ redirectTo: "/list" });
    };
    config.$inject = ["$routeProvider"];

    app.config(config);
    
}(angular.module("fileSystem", ["ngRoute", "ngResource"])));