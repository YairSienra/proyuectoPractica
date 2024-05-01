function setCookie(name, value, days) {
    var expiration = "";

    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000))
        expiration = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expiration + "; path=/";
}


function getCookie(name) {
    var na = name + "=";
    var arrayCookie = document.cookie.split(";")

    for (var i = 0; i < arrayCookie.length; i++) {
        var c = arrayCookie[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length)
        if (c.indexOf(na) == 0) return c.substring(na.length, c.length)
    }
}