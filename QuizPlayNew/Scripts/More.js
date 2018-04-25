var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('MoreController',
    function ($scope, $http) {
        $scope.count = 10;
        $scope.m = 1;
        $http.get(api+'/api/Master/GetRelatedVideo?num=10').then(function (response) {
            console.log(response);
            $scope.video = response.data;

        });
        $scope.more = () => {


            $http.get(api+'/api/Master/GetRelatedVideoCount').then(function (response) {
                console.log(response.data[0]);
                if (response.data[0] <= ($scope.count +10)) {
                    $scope.m = 0;
                }
            });
            $scope.count += 10;
            $http.get(api+'/api/Master/GetRelatedVideo?num=' + $scope.count).then(function (response) {

                console.log(response);
                $scope.video = response.data;

            });
        }
    });