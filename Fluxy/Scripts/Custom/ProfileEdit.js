$('#dpSelecter').change(function () {
    readURL(this);
});

function DateChange(event) {
    var d = new Date(event.target.value);
    var birthYear = d.getFullYear();
    var currentDate = new Date();
    var age = currentDate.getFullYear() - birthYear;
    $('#Age').val(age);
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#displayPicture').attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}