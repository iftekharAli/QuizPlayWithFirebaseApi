var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('DownloadController',
    function ($scope, $http, $location) {
        $scope.count = 6;
        $scope.m = 1;
       var flag = 1;
       


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

        console.log(id);

        $('video').on('play', function (e) {

            if (flag === 1) {
                flag = 2;
                $http.post(api+'/api/Master/VideoLog?id='+id).then(
                    function(response) {
                      flag=2;
                    });
            }


        });

        //$scope.play = () => {
        //    if ($scope.flag === 1) {
        //        $http.post('../api/Master/VideoLog?id=', id).then(
        //            function (response) {
        //                $scope.flag += 1;
        //            });
        //    }
        //}

        
        $http.get(api+'/api/Master/GetRelatedVideo?num=6').then(function (response) {
            console.log(response);
            $scope.rel = response.data;
            //$http.get(api + '/api/Master/GetVideo?id=' + id).then(function (response) {
            //    console.log(response);
            //    $scope.x = response.data[0];

            //});
        });
        $scope.more = () => {
            
            
            $http.get(api+'/api/Master/GetRelatedVideoCount').then(function (response) {
                console.log(response.data[0]);
                if (response.data[0] <= ($scope.count+6)) {
                    $scope.m = 0;
                }
            });
            $scope.count += 6;
            $http.get(api+'/api/Master/GetRelatedVideo?num=' + $scope.count).then(function (response) {
               
                console.log(response);
                $scope.rel = response.data;

            });
        }
       
    });