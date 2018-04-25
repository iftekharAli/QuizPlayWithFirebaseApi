var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('QuizPlayBonusHourController',
    function($scope, $http) {
        $scope.TotalQues = 0;
        $scope.TotalRight = 0;


        $scope.LoadQuestion = (themeid) => {
            $http.get(api + '/api/Master/getQuestionBonus').then(function (response) {


                $scope.Questions = response.data[0];
                console.log(response.data[0]);

                $scope.TQ();
            });
        }
        $scope.TQ = () => {
            $http.get(api + '/api/Master/getQuestionCountBonus').then(function (response) {

                $scope.TotalQues = response.data;

            });
        }
        $scope.LoadQuestion();

        $scope.answer = (answer) => {



            $http.post(api + '/api/Master/InsertanswerBonus?response=' + answer +
                '&quesionid=' + $scope.Questions.ID +
                '&time=' + $scope.time).then(
                function (response) {
                    $scope.TotalRight = response.data;

                    if (response.statusText === "OK") {

                        if ($scope.TotalQues <= 4) {
                            $scope.LoadQuestion();
                        } else {
                            window.location.href = '../Home/ScoreViewBonus';
                        }
                        //$scope.LoadQuestion();
                    }
                });


        }
    });