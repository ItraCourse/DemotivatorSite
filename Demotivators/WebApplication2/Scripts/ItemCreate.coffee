# CoffeeScript
canvas = new fabric.Canvas("canvas")
canvas.cli
document.getElementById('textin').onclick = ->
  upStr = document.getElementById("Header-Text").value
  canvas.add new (fabric.IText)(upStr,
    fontFamily: 'Georgia'
    originX: 'center'
    left: 450
    top: 0
    z_index: 1
    fontSize: 50
    lockScalingX: true
    lockScalingY: true
    editable: false
    hasRotatingPoint: false
    transparentCorners: false)
  lowStr = document.getElementById("Text").value
  canvas.add new (fabric.IText)(lowStr,
    fontFamily: 'Georgia'
    top: 470
    fontSize: 50
    originX: 'center'
    left: 450
    editable: false
    lockScalingX: true
    lockScalingY: true
    hasRotatingPoint: false
    transparentCorners: false)
  imgsrc = document.getElementById("OriginalImage").value
  fabric.Image.fromURL imgsrc, (oImg) ->
      canvas.setBackgroundImage oImg
      canvas.backgroundImage.width = canvas.getWidth() - 10
      canvas.backgroundImage.height = canvas.getHeight() - 10
      canvas.renderAll()
      