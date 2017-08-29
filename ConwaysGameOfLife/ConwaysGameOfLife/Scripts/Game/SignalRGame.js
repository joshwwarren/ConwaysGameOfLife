var life = $.connection.lifeHub;

life.client.hello = function (response) {
    alert(response);
}

angular.module('lifeApp', []).controller('lifeController', function($scope, $http) {
    life.client.pushMatrix = function (matrix) {
        $scope.matrix = matrix;
        console.log($scope.matrix);
    }

    $scope.judge = function () { life.server.judge($scope.matrix); }
    $scope.startOver = function () { life.server.createMatrix(50); }

    function init() {
        life.server.hello();
        $scope.startOver();
    }

    $.connection.hub.start().done(init);
});