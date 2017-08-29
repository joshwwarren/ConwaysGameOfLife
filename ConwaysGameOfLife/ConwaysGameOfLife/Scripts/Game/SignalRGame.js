var life = $.connection.lifeHub;

life.client.hello = function (response) {
    alert(response);
}

function init() {
    life.server.hello();
}

$.connection.hub.start().done(init);