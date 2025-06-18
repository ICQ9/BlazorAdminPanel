// Add this to your JavaScript file (e.g., wwwroot/js/app.js)
// Don't forget to reference this in your _Host.cshtml or index.html file

window.getImageDimensionsFromDataUrl = async function (dataUrl) {
    return new Promise((resolve, reject) => {
        const img = new Image();

        img.onload = function () {
            console.log("Intrinsic size: " + img.width + "x" + img.height);
            resolve({
                Width: img.naturalWidth,
                Height: img.naturalHeight
            });
        };

        img.onerror = function () {
            reject({
                Width: 0,
                Height: 0
            });
        };

        img.src = dataUrl;
    });
};