

function updateDate(input, id) {
    var data = timeElapsed(input, id);
    var target = document.getElementById(id);
    target.innerHTML = data;
}


function timeElapsed(input, id) {
    //2017-01-30 22:46:20.217 - sql date(23 char)
    //2/1/2017 3:05:32 AM - c# date(22 char)
    // current date (0-60)seconds/(1-60)minutes/(1-24)hours/(1-3)daysago/(>3)date 259200
    
    var published = new Date(Date.parse(input)).getTime();
    var now = new Date().getTime();
    var elapsedTime = (now - published) / 1000;
    
    //debugger;
    if (elapsedTime < 60) {
        return Math.trunc(elapsedTime) + " seconds ago";
    }

    else if (elapsedTime < 3600) {
        elapsedTime = elapsedTime / 60;
        elapsedTime = Math.trunc(elapsedTime);
        return elapsedTime.toString() + (elapsedTime === 1 ? " minute ago" : " minutes ago");
    }
    else if (elapsedTime > 3600 && elapsedTime < 86400) {
        elapsedTime = elapsedTime / 3600;
        elapsedTime = Math.trunc(elapsedTime);
        return elapsedTime.toString() + (elapsedTime === 1 ? " hour ago" : " hours ago");
    }
    else if (elapsedTime > 86400 && elapsedTime < 259200) {
        elapsedTime = elapsedTime / 86400;
        elapsedTime = Math.trunc(elapsedTime);
        return elapsedTime.toString() + (elapsedTime === 1 ? " day ago" : " days ago");
    }
    else if (elapsedTime > 259200) {
        return input.toLocaleDateString();
    } else {
        return "";
    }
}