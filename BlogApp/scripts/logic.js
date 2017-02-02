$(document).ready(function () {
    //initializing tooltip
    $('[data-toggle="tooltip"]').tooltip();

    //Displaying logout successfull message;
    $("#logout_message").css({ "display": "none", "transition": "2s" });
    
    //setting user account name from localstorage;
    if (localStorage.getItem('userInfo')) {
        $("#user_name").text(JSON.parse(localStorage.getItem('userInfo'))['name']);
    }

    //dynamic username exits check module
    var typingtimer;

    $('.userExistcheck').keyup(function () {
        var self = $(this);
        clearTimeout(typingtimer);
        if (self.val().length > 4) {
            $('#dynamicUsername').text("checking in db...").css({ 'display': 'block', 'color': 'orange' });
            //waiting .5 seconds i.e. sending reuqest when user stops typing;
            typingtimer = setTimeout(checkAvailability.bind(null, self), 500);


        } else {
            $('#dynamicUsername').css('display', 'none');
        }
        function checkAvailability(txtBox) {
            var dataToPost = "{ _username:'" + txtBox.val() + "'}";

            $.ajax({
                url: '/Auth/ValidateUsername',
                type: 'POST',
                data: dataToPost,
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                error: function (result) {
                    $('#dynamicUsername').css('display', 'block');
                    if (result.responseText == "True") {
                        $('#dynamicUsername').text("Username not available").css('color', 'red');
                    } else if (result.responseText == "False") {
                        $('#dynamicUsername').text("Username available").css('color', 'forestgreen');
                    }
                },
                success: function (result) {
                }
            });
        }
    })

});

//overlay on div;
function showOverlay() {
    $('#overlayDiv').css('display', 'inline-block');
};

//hide overlay on div;
function hideOverlay() {
    $('#overlayDiv').css('display', 'none');
}

//hide overlay on div + fetching username and setting localstorage for userInfo
function hideOverlayandRedirect(data) {
    var userInfo = {
        'name': '',
        'id': ''
    }

    $('#overlayDiv').css('display', 'none');
    var dataToPost = "{ userid:'" + getCookie('user') + "'}";
    $.ajax({
        url: '/Auth/GetUsername',
        type: 'POST',
        data: dataToPost,
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        error: function (result) {
            console.log('error', result);
        },
        success: function (result) {
            userInfo.name = result;
            userInfo.id = getCookie('user');
            localStorage.setItem('userInfo', JSON.stringify(userInfo));
            setTimeout(window.location.reload(), 1000);
        }
    });    
}

//get a cookie by it's name on client side;
function getCookie(cookiename) {
    // Get name followed by anything except a semicolon
    var cookiestring = RegExp("" + cookiename + "[^;]+").exec(document.cookie);
    // Return everything after the equal sign, or an empty string if the cookie name not found
    return unescape(!!cookiestring ? cookiestring.toString().replace(/^[^=]+./, "") : "");
}
