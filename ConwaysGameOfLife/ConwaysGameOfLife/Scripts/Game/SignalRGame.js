var life = $.connection.lifeHub;

life.client.hello = function (response) {
    alert(response);
}

function init() {
    life.server.hello();
    life.server.createMatrix(50);
}


angular.module('lifeApp', []).controller('lifeController', function($scope, $http) {
    life.client.pushMatrix = function (matrix) {
        $scope.matrix = matrix;
        console.log($scope.matrix);
    }

    $.connection.hub.start().done(init);
});