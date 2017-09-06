$('#usersTable').dataTable();

function FindDetailsById(url) {
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Firstname').val(result.Firstname);
            $("#Lastname").val(result.Lastname);
            $('#Gender').val(result.Gender);
            $('#Hobbies').val(result.Hobbies);
            $('#About').val(result.About);
            $("#displayPicture").attr("src", "data:image/png;base64," + result.DisplayPictureString);
            $('#UserName').val(result.ApplicationUser.UserName);
            $('#Email').val(result.ApplicationUser.Email);
            $('#PhoneNumber').val(result.ApplicationUser.PhoneNumber);
            $('#userModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function AddUser(url) {
    var formdata = new FormData($("#AddUserModalForm").get(0));

    $.ajax({
        url: url,
        data: formdata,
        type: "POST",
        processData: false,
        contentType: false,
        success: function (response) {
            if (response != null && response.success) {
                location.reload();
            } else {
                alert(response.responseText);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

