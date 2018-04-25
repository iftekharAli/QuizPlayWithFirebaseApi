var api = 'http://wap.shabox.mobi/quizplaynew';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);

app.controller('ThemeController',
    function ($scope, $http) {

        $scope.spinner = 1;
        $scope.fulltheme = 0;
        $scope.khelun = 1;
        $scope.spinnerkhelun = 0;

        $http.get(api+'/api/Master/getTodayTheme').then(function (response) {

            if (response.statusText === "OK") {
                $scope.spinner = 0;
                $scope.fulltheme = 1;
                $scope.ThemeImage = "http://wap.shabox.mobi/cms/content/QuizPlay/Theme/" + response.data[0].HomeThemeImage;
                $scope.ThemeName = response.data[0].HomeTheme;
                $scope.ID = response.data[0].ID;
            }

            //console.log("http://wap.shabox.mobi/cms/content/QuizPlay/Theme/" + response.data[0].HomeThemeImage);
            
        });

        

        $scope.addSession = (id) => {

            $scope.khelun = 0;
            $scope.spinnerkhelun = 1;

            $http.post(api+'/api/Master/QuizPlay?themeid='+id).then(
                function (response) {


                    if (response.statusText === "OK") {
                       
                        window.location.href = api+'/Home/QuizPlay';
                    }
                });
          
        }
    });