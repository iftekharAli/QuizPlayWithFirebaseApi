var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);

app.controller('Controller',
    function($scope, $http) {
        $scope.TotalQues = 0;
        $scope.TotalRight = 0;
        $scope.spin = 0;
        $scope.spinner = 1;
        $scope.fullPage = 0;

        $scope.LoadQuestion = (themeid) => {
            $http.get(api+'/api/Master/getQuestion').then(function (response) {

                //console.log(response);
                if (response.statusText === "OK") {
                    $scope.spinner = 0;
                    $scope.fullPage = 1;
                }

                $scope.spin = 0;
                $scope.Questions = response.data[0];
                //console.log(response.data[0]);
                
                $scope.TQ();
            });
        }
        $scope.TQ = () => {
            $http.get(api+'/api/Master/getQuestionCount').then(function (response) {
                
                $scope.TotalQues = response.data;

            });
        }
        $scope.LoadQuestion();
        //$scope.LoadQuestion();
        $scope.answer = (answer) => {
            $scope.spin = 1;
           
            
            $http.post(api+'/api/Master/Insertanswer?response=' + answer +
                '&quesionid=' + $scope.Questions.ID +
                '&time='+$scope.time).then(
                function (response) {

                    $scope.TotalRight = response.data;
                   
                    if (response.statusText === "OK") {
                        
                        if ($scope.TotalQues <= 39) {
                            $scope.LoadQuestion();
                        } else {
                            window.location.href = '../Home/ScoreView';
                        }
                        //$scope.LoadQuestion();
                    }
                });
            
           
        }

    });
