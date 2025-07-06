Dropzone.autoDiscover = false;

$(document).ready(function () {
    // هنا نقرأ من data attribute
    var existingImageUrl = $("#myDropzone").data("existing");

    var myDropzone = new Dropzone("#myDropzone", {
        url: "/fake", 
        autoProcessQueue: false,
        maxFiles: 1,
        acceptedFiles: "image/*",
        addRemoveLinks: true,
        init: function () {
            var dz = this;

            if (existingImageUrl) {
                var mockFile = { name: "Current Image", size: 12345 };

                dz.emit("addedfile", mockFile);
                dz.emit("thumbnail", mockFile, existingImageUrl);
                dz.emit("complete", mockFile);
                dz.files.push(mockFile);
            }

            dz.on("addedfile", function (file) {
                if (dz.files[1] != null) {
                    dz.removeFile(dz.files[0]);
                }
            });

            dz.on("click", function () {
                $("#fileInput").click();
            });
        }
    });

    $("#fileInput").on("change", function () {
        var files = this.files;
        if (files.length > 0) {
            myDropzone.addFile(files[0]);
        }
    });
});
