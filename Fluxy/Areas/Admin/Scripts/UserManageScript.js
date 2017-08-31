$('#usersTable').dataTable();

function FindRoleById(url) {
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            alert(result);
            console.log(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}