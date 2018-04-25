var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('PrizesController',
    function($scope, $http) {
        $scope.d = 0;
        $scope.m = 0;
        $http.get(api+'/api/Master/getMSISDN').then(function (response) {
            $scope.msisdn = response.data;
            if ($scope.msisdn.substring(0, 5) === '88016' || $scope.msisdn.substring(0, 5) === '88018') {
                $scope.d = 0;
                $scope.m = 1;
            }
            else if ($scope.msisdn.substring(0, 5) === '88019') {
                $scope.m = 0;
                $scope.d = 1;
            }
        });
        $http.get(api+'/api/Master/GetWeeklyBigImage').then(function (response) {
            $scope.weekly = response.data[0];
            
        });
        $http.get(api+'/api/Master/GetMonthlyBigImage').then(function (response) {
            $scope.monthly = response.data[0];

        });
    });