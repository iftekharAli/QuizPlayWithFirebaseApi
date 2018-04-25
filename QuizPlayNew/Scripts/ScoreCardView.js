var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('ScoreCardViewController',
    function ($scope, $http) {
        $scope.month = 1;
        $http.get(api+'/api/Master/GetUserResultDailyWeekly').then(function(response) {
            console.log(response);
            $scope.DailyWeekly = response;
        });
        $http.get(api+'/api/Master/GetTodayScoreCard').then(function (response) {
            console.log(response);
            $scope.TodayScoreCard = response;
        });
        $http.get(api+'/api/Master/GetWeeklyWiner').then(function (response) {
            console.log(response);
            $scope.WeeklyWinner = response;
        });
        $http.get(api+'/api/Master/GetMonthlyWiner').then(function (response) {
            console.log(response);
            $scope.MonthlyWiner = response;
            if (response.data[0].type === 'N') {
                $scope.month = 0;
            }
        });
    })