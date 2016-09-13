(function (app) {
    var ContentController = function ($scope, $routeParams, fileSystemService) {

        var $directory = $routeParams.directory;

        fileSystemService
        .getSizesInfo($directory)
        .success(function (data) {

            $scope.error = data.error;

            $scope.parentDir = data.parentDir;

            $scope.s_0_10 = data.s_0_10;
            $scope.s_10_50 = data.s_10_50;
            $scope.s_100plus = data.s_100plus;

            $scope.curPath = data.curPath;

            var files = [];

            data.files.forEach(function (item, i) {

                var info = {
                    fullpath: item,
                    label: item.substring(item.lastIndexOf("\\") + 1)
                };

                files.push(info);

            });

            $scope.files = files;

            var folders = [];

            data.folders.forEach(function (item, i) {

                var info = {
                    fullpath: item,
                    label: item.substring(item.lastIndexOf("\\") + 1)
                };

                folders.push(info);

            });

            $scope.folders = folders;

        });

    };

    ContentController.$inject = ["$scope", "$routeParams", "fileSystemService"];

    app.controller("ContentController", ContentController);

}(angular.module("fileSystem")));