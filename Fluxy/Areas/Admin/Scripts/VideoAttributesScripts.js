$('#videoAttributesTable').dataTable();

$('#videoAttributesModal').on('show.bs.modal', function () {
    var urlList = ['SubCategory/GetList', 'Language/GetList', 'VideoSettings/GetList'];
    var dropdownList = ['SelectedSubCategory', 'SelectedLanguage', 'SelectedSettings'];
    for (var i = 0; i < 3; i++) {
        var url = urlList[i];
        var dropdown = dropdownList[i];
        $.ajax({
            url: url,
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            async:false,
            success: function (data) {
                helpers.buildDropdown(data,
                    $("#" + dropdown),
                    'Select an option'
                );
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
})

$('#videoAttributesModal').on('hide.bs.modal', function () {
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

function Add(url) {
    var videoAttributesObj = {
        Id: $('#Id').val(),
        Title: $('#Title').val(),
        ShortName: $('#ShortName').val(),
        Url: $('#Url').val(),
        Tags: $('#Tags').val(),
        Description: $('#Description').val(),
        IsPublicVideo: $('#IsPublicVideo').is(':checked'),
        IsAdultContent: $('#IsAdultContent').is(':checked'),
        IsAllowFullScreen: $('#IsAllowFullScreen').is(':checked'),
        SubCategoryId: $('#SelectedSubCategory').val(),
        LanguageId: $('#SelectedLanguage').val(),
        VideoSettingsId: $('#SelectedSettings').val(),
        VideoId: Getvideoid($('#Url').val())
    }

    $.ajax({
        url: url,
        data: JSON.stringify(videoAttributesObj),
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
    $('#videoAttributesModal').modal('show');

    $.ajax({
        url: url,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Title').val(result.Title);
            $('#ShortName').val(result.ShortName);
            $('#Url').val(result.Url);
            $('#Tags').val(result.Tags);
            $('#Description').val(result.Description);
            $('#IsPublicVideo').prop('checked',result.IsPublicVideo);
            $('#IsAdultContent').prop('checked',result.IsAdultContent);
            $('#IsAllowFullScreen').prop('checked', result.IsAllowFullScreen);
            $('#SelectedSubCategory').val(result.SubcategoryId);
            $('#SelectedLanguage').val(result.LanguageId);
            $('#SelectedSettings').val(result.VideoSettingsId);
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
    var videoAttributesObj = {
        Id: $('#Id').val(),
        Title: $('#Title').val(),
        ShortName: $('#ShortName').val(),
        Url: $('#Url').val(),
        Tags: $('#Tags').val(),
        Description: $('#Description').val(),
        IsPublicVideo: $('#IsPublicVideo').is(':checked'),
        IsAdultContent: $('#IsAdultContent').is(':checked'),
        IsAllowFullScreen: $('#IsAllowFullScreen').is(':checked'),
        SubCategoryId: $('#SelectedSubCategory').val(),
        LanguageId: $('#SelectedLanguage').val(),
        VideoSettingsId: $('#SelectedSettings').val(),
        VideoId: Getvideoid($('#Url').val())
    }


    $.ajax({
        url: url,
        data: JSON.stringify(videoAttributesObj),
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

function Getvideoid(videolink) {
    var regExp = /^.*((youtu.be\/)|(v\/)|(\/u\/\w\/)|(embed\/)|(watch\?))\??v?=?([^#\&\?]*).*/;
    var match = videolink.match(regExp);

    if (match && match[7].length == 11) {
        return match[7];
    }
    regExp = "vimeo\\.com/(?:.*#|.*/videos/)?([0-9]+)";
    match = videolink.match(regExp);
    if (match) {
        var videoid = videolink.split('/')[videolink.split('/').length - 1];
       return videoid;
    }
}