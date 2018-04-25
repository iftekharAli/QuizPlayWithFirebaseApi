var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('FinishedController',
    function ($scope, $http) {
        $scope.t = 0;
        $scope.te = 0;
        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));

            
        }
        var id = getParameterByName('id');
       
        if (id == 1) {
            $scope.t = 1;
            $scope.img = "http://quizplay.mobi/Images/Quizplay_graphics/threetimes.jpg";
            $scope.text = "http://quizplay.mobi/Images/Quizplay_graphics/threetimestext.png";
        }
        else if (id == 3) {
            $scope.te = 1;
            $scope.img = "http://quizplay.mobi/Images/Quizplay_graphics/cartoon2.gif";
        }
    });