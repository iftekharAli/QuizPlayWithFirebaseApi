var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('MyAccountController',
    function($scope, $http) {
        $http.get(api+'/api/Master/getMyAccount').then(function(response) {
            $scope.account = response.data;
        });
        $http.get(api+'/api/Master/getMSISDN').then(function (response) {
            $scope.msisdn = response.data;
        });
    });