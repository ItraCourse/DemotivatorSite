window.onload = function () {
    try {
        TagCanvas.Start('myCanvas', 'tags', {
            textColour: '#fffffff',
            outlineColour: '#000',
            reverse: true,
            depth: 1,
            maxSpeed: 0.05
        });
    } catch (e) {
        // something went wrong, hide the canvas container
        document.getElementById('myCanvasContainer').style.display = 'none';
    }
};