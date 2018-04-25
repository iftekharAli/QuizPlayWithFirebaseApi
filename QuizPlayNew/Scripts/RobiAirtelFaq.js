var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('RobiAirtelFaqController',
    function($scope, $http) {
        $http.get(api+'/api/Master/getRobiAirtelFaq').then(function (response) {
            console.log(response);
            $scope.helpline = response.data.helpline;
            $scope.start = response.data.start;
            $scope.stop = response.data.stop;
        });
    });