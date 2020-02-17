function readURL(input) {
    console.log("Hello!!!!!!!");
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#profile-img-tag').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}
$("#Filename").change(function () {
    console.log("Hello");
    readURL(this);
});
