$(document).ready(function () {
    $("#logout_message").css({ "display": "none", "transition": "2s" });
    var typingtimer;

    $('.userExistcheck').keyup(function () {
        var self = $(this);
        clearTimeout(typingtimer);
        if (self.val().length > 4) {
            $('#dynamicUsername').text("checking in db...").css({ 'display': 'block', 'color': 'orange' });
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

function showOverlay() {
    $('#overlayDiv').css('display', 'inline-block');
};

function hideOverlay() {
    $('#overlayDiv').css('display', 'none');
}