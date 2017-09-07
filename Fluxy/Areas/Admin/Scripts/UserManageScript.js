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
            debugger
            $('#EmailDetail').val(result.ApplicationUser.Email);
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
    var userObj = {
        Username: $('#Username').val(),
        Email: $('#Email').val(),
        Password: $('#Password').val(),
        ConfirmPassword: $('#ConfirmPassword').val(),

    };
    var form = $('#AddUserModalForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    $.ajax({
        url: url,
        type: 'POST',
        data: {
            __RequestVerificationToken: token,
            model: userObj
        },
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

$('#userRoleModal').on('show.bs.modal', function () {
    var url = "UserManagement/GetRoleList";
    $.get(url)
        .done(function (data) {
            helpers.buildDropdown(data,
                $("#SelectedRole"),
                'Select an option'
            );
        })
        .fail(function (errormessage) {
            alert(errormessage.responseText);
        })
})

function ShowRoleModal(userExistingRole, userId)
{
    $('#userRoleModal').modal('show');
    $('#Id').val(userId);
    $('#userRoleModal').on('shown.bs.modal', function () {
        $("#SelectedRole option").filter(function () {
            return this.text == userExistingRole;
        }).attr('selected', true);
    })
}

function ChangeRole(url)
{
    var form = $('#UserRoleModalForm');
    var token = $('input[name="__RequestVerificationToken"]', form).val();
    var userId = $('#Id').val();
    var userRole = $('#SelectedRole option:selected').text();
    $.ajax({
        url: url,
        type: 'POST',
        data: {
            __RequestVerificationToken: token,
            id: userId,
            role: userRole
        },
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