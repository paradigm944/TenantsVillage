setInterval(function () {
    var myImageElement = document.getElementById('myImage');
    myImageElement.src = 'screen.jpg?rand=' + Math.random();
}, 5000);