var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('ScoreViewController',
    function($scope, $http) {
        $http.get(api+'/api/Master/GetScore').then(function (response) {


            console.log(response);
            $scope.time = response.data[0].time;
            $scope.totalright = response.data[0].TotalRight;
        });
    })