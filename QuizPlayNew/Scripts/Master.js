var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);

app.controller('Controller',
    function($scope, $http) {
        $http.get('../api/Master/getHeaderFooterImage').then(function (response) {


            confirm.log(response);

        });
    });