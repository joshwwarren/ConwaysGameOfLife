var life = $.connection.lifeHub;

function init() {
    life.hello = function() {
        alert("hello");
    }
}
$.connection.hub.start().done(init);