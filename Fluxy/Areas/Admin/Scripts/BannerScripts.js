$('#bannerTable').dataTable();

function Add(url) {
    var bannerObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Headline: $('#Headline').val(),
        Slogans: $('#Slogans').val(),
        ButtonText: $('#ButtonText').val()
    }
   
    var formdata = new FormData($("#bannerModalForm").get(0));

    $.ajax({
        url: url,
        data: formdata,
        type: "POST",
        processData: false,
        contentType: false,
        success: function (result) {
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

$('#bannerModal').on('hide.bs.modal', function () {
    $(this)
        .find('input,textarea')
        .val('')
        .end()
        .find('input[type=checkbox],input[type=radio]')
        .prop('checked', '')
        .end()
        .find('select')
        .find('option')
        .remove()
        .end();
})

function getbyID(url) {
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#Headline').val(result.Headline);
            $('#Slogans').val(result.Slogans);
            $('#ButtonText').val(result.ButtonText);
            $('#bannerModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update(url) {
    var bannerObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Headline: $('#Headline').val(),
        Slogans: $('#Slogans').val(),
        ButtonText: $('#ButtonText').val()
    }
    var file = Request.Files["file"];

    $.ajax({
        url: url,
        data: JSON.stringify(bannerObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//function for deleting employee's record
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