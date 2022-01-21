function rectangle(width, height, color) {
    
    let rect = {
        width : Number(width),
        height : Number(height),
        color : color.charAt(0).toUpperCase() + color.slice(1),
        calcArea() {
            return Number(this.width * this.height);
        }
    }

    return rect;
}
