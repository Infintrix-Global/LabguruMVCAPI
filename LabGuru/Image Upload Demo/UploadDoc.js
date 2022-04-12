function StudentProfilePic(file) {
    var formData = new FormData();

    formData.append('files', $('#pro_img')[0].files[0]);
    $.ajax({
        type: 'post',
        url: `https://localhost:44353/api/Document/ImprestionUpload`,

        data: formData,
        dataType: 'json',
        success: function (status) {
            console.log(status)
            if (status.isSuccess) {
                alert('File Uploaded');
            }
        },
        processData: false,
        contentType: false,
        error: function (err) {
            //$('#spn_proimg').html(text.error.replace(text.replace, 'Something  wrong!'))
            notify(AlertStatus.error, 'Something  wrong!')
        }
    });
}
var _URL = window.URL || window.webkitURL;

$(document).ready(function () {
    $("#pro_img").on('change', function () {

        var file, img;
        if ((file = this.files[0])) {

            StudentProfilePic(file);
        }
    });
})