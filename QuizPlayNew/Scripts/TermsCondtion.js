var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('TermsCondtionController',
    function($scope, $http) {
        $scope.name = 'Quiz Play';
        $http.get(api+'/api/Master/getTermsAndConditon').then(function (response) {
            console.log(response);
            $scope.helpline = response.data.helpline;
            $scope.start = response.data.start;
            $scope.stop = response.data.stop;
            $scope.name = response.data.name;
            $scope.pricea = response.data.pricea;
            $scope.pricen = response.data.pricen;
            $scope.samtahik = response.data.samtahik;
            $scope.na = response.data.na;

        });
    });