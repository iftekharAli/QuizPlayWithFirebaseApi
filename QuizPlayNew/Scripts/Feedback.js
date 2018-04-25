var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('FeedbackController',
    function ($scope, $http) {
        $scope.n = 0;
        $http.get(api+'/api/Master/getMSISDN').then(function (response) {
            $scope.msisdn = response.data;
        });

        $scope.submit = () => {
            
            var feed = {
                msisdn:$scope.msisdn,
                message:$scope.message
            }
            $http.post(api+'/api/Master/PostFeedback', feed).then(
                function(response) {
                    $scope.message = '';
                    $scope.n = 1;
                    $scope.msg = 'Your feedback submitted successfully. Thanks for your response';
                });
        }

        
    });