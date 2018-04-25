var api = 'http://wap.shabox.mobi/quizplaynew/';
var app = angular.module('App', []);
app.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);
app.controller('DefaultController',
    function ($scope, $http) {
        $scope.ram = 0;
        $scope.bd = 0;
        $scope.b = 0;
        $scope.r = 0;
        $scope.ra = 0;
        $scope.un = 0;
        $scope.protidin = 0;
        $scope.bonus = 0;
        $scope.ravideo = 0;
        $http.get(api + '/api/Master/getMSISDN').then(function (response) {

            $scope.msisdn = response.data;
            if ($scope.msisdn.substring(0, 4) === '8801') {
                $scope.msisdn = response.data;
            } else {
                $scope.msisdn = "Mobile Number not Found,Please Use mobile Apn";
            }



            $http.get(api +'/api/Master/CheckSubscription').then(function (response) {
               // console.log(response);
                if (response.data === 0) {

                    if ($scope.msisdn.substring(0, 5) === '88018') {

                        $scope.b = 0;
                        $scope.ra = 1;
                        $scope.r = 1;
                    }
                    else if ($scope.msisdn.substring(0, 5) === '88016') {
                        $scope.b = 0;
                        $scope.ra = 1;
                        $scope.r = 0;
                    }
                    else if ($scope.msisdn.substring(0, 5) === '88019') {
                        $scope.b = 1;
                        $scope.ra = 0;
                        $scope.r = 0;

                    }
                    else {
                        $scope.b = 0;
                        $scope.ra = 0;
                        $scope.r = 0;

                    }
                } else {

                    if ($scope.msisdn.substring(0, 5) === '88018') {
                        $scope.b = 0;
                        $scope.ra = 0;
                        $scope.r = 0;
                        $scope.un = 1;
                    }
                    else if ($scope.msisdn.substring(0, 5) === '88016') {
                        $scope.b = 0;
                        $scope.ra = 0;
                        $scope.r = 0;
                        $scope.un = 1;
                    }
                    else if ($scope.msisdn.substring(0, 5) === '88019') {

                        $scope.b = 0;
                        $scope.ra = 0;
                        $scope.r = 0;
                        $scope.un = 1;
                    } else {
                        $scope.b = 0;
                        $scope.ra = 0;
                        $scope.r = 0;
                        $scope.un = 1;
                    }
                }
            });


            if ($scope.msisdn.substring(0, 5) == '88018') {
                $scope.ram = 1;
                $scope.bd = 0;
                $scope.b = 0;
                $scope.ra = 1;
                $scope.r = 1;
                $scope.ravideo = 1;
            }
            else if ($scope.msisdn.substring(0, 5) == '88016') {
                $scope.b = 0;
                $scope.ra = 1;
                $scope.r = 0;
                $scope.ram = 1;
                $scope.ravideo = 1;
            }
            else if ($scope.msisdn.substring(0, 5) == '88019') {
                $scope.b = 1;
                $scope.ra = 0;
                $scope.r = 0;
                $scope.ram = 0;
                $scope.bd = 1;
                $scope.protidin = 1;
                $scope.ravideo = 0;
            } else {
                $scope.b = 0;
                $scope.ra = 0;
                $scope.r = 0;
                $scope.ram = 0;
                $scope.bd = 1;
                $scope.protidin = 1;
                $scope.ravideo = 0;
            }
        });
        

        $http.get(api +'/api/Master/GetWeeklyImage').then(function (response) {
            //console.log(response);
            $scope.week = response.data[0];
        });
        $http.get(api +'/api/Master/GetMonthlyImage').then(function (response) {
            //console.log(response);
            $scope.month = response.data[0];
        });
        $http.get(api +'/api/Master/GetVideo').then(function (response) {
            //console.log(response);
            $scope.video = response.data;
        });
        $http.get(api +'/api/Master/GetNumberOfPlay').then(function (response) {
            console.log(response);
            $scope.numberOfPlay = response.data;
            //$scope.video = response.data;
        });
        $http.get(api +'/api/Master/CheckIsBonusHour').then(function (response) {
            console.log(response);
            if (response.data.length!==0) {
                //console.log('here');
                $scope.bonus = 1;
            }
            //$scope.numberOfPlay = response.data;
        });

        $scope.subscribe = (type) => {
            $http.get(api +'/api/Master/GetSubUrl?type='+type).then(function (response) {
                //console.log(response);
                console.log(response);
                window.location.href = response.data;
            });
        }

        $scope.bonushour = () => {
            $http.post(api+'/api/Master/PostBonusLog').then(
                function (response) {
                    console.log(response.status);
                    if (response.statusText === "OK") {

                        window.location.href = api+'/Home/QuizPlayBonusHour';
                    }
                });

        }

        $scope.unsubscribe = () => {
            if ($scope.msisdn.substring(0, 5) === '88016' || $scope.msisdn.substring(0, 5) === '88018') {
                $http.post(api +'/api/Master/Unsubscription').then(
                    function (response) {
                        //console.log(response.status);
                        if (response.statusText === "OK") {

                            window.location.href = api +'/Home/RobiUnsubscriptionSuccessfull';
                        }
                    });
            }
            if ($scope.msisdn.substring(0, 5) === '88019') {
                window.location.href = api +'/Home/UnsubscriptionSuccessfull';
            }
        }
    });