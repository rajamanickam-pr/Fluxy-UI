$('#loggingTable').dataTable();

function getbyID(url) {
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ApplicationObject').val(result.ApplicationObject);
            $('#FullMessage').val(result.FullMessage);
            $('#ControllerName').val(result.ControllerName);
            $('#Method').val(result.Method);
            $('#ExceptionStackTrace').val(result.ExceptionStackTrace);
            $('#InnerException').val(result.InnerException);
            $('#HelpLink').val(result.HelpLink);
            $('#LogTime').val(result.LogTime);
            $('#loggingModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Delele(url) {

    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                location.reload();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
