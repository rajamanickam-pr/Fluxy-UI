function Add(url) {
    var languageObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        LanguageCulture: $('#LanguageCulture').val(),
        Rtl: $('#Rtl').is(':checked'),
        DefaultCurrency: $('#DefaultCurrency').val()
    }
    $.ajax({
        url: url,
        data: JSON.stringify(languageObj),
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

function getbyID(url) {
    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            $('#LanguageCulture').val(result.LanguageCulture);
            $('#Rtl').val(result.Rtl);
            $('#DefaultCurrency').val(result.DefaultCurrency);
            $('#myModal').modal('show');
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
    var languageObj = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        LanguageCulture: $('#LanguageCulture').val(),
        Rtl: $("input[type='checkbox']").is(':checked'),
        DefaultCurrency: $('#DefaultCurrency').val()
    }
    debugger;
    $.ajax({
        url: url,
        data: JSON.stringify(languageObj),
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

