function previewFile() {
    var preview = document.querySelector(".img");
    var file = document.querySelector('input[type=file]').Files[0];
    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
    }

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
    }
}