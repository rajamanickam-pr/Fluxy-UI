function GetThumbunailUrl() {
    debugger;
    var urlValue = $('#Url').val();
    if (urlValue) {
        if (urlValue.indexOf("youtube") >= 0) {
            $('#VideoId').val(Getvideoid(urlValue));
            return true
        } else {
            alert('Url should be from youtube.');
            return false;
        }
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