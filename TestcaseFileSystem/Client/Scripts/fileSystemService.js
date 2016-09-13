(function (app) {

    var fileSystemService = function ($http) {
       
        var getSizesInfo = function ($directory) {
            return $http({ method: 'GET', url: "/api/fileSystem/GetSizesInfo", params: { 'directory': $directory } });
        };

        return {
            getSizesInfo: getSizesInfo
        };
    };

    fileSystemService.$inject = ["$http"];

    app.factory("fileSystemService", fileSystemService);

}(angular.module("fileSystem")))