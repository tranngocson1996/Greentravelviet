// JavaScript Document
function startclock() {
    var curTime = new Date();
    var nhours = curTime.getHours();
    var nmins = curTime.getMinutes();
    var nsecn = curTime.getSeconds();
    var nday = curTime.getDay();
    var nmonth = curTime.getMonth();
    var ntoday = curTime.getDate();
    var nyear = curTime.getYear();
    var AMorPM = " ";
    if (nhours >= 12)
        AMorPM = "am";
    else
        AMorPM = "pm";
    if (nhours >= 13)
        nhours -= 12;
    if (nhours == 0)
        nhours = 12;
    if (nsecn < 10)
        nsecn = "0" + nsecn;
    if (nmins < 10)
        nmins = "0" + nmins;
    if (nday == 0)
        nday = "воскресенье";
    if (nday == 1)
        nday = "понедельник";
    if (nday == 2)
        nday = "вторник";
    if (nday == 3)
        nday = "среда";
    if (nday == 4)
        nday = "четверг";
    if (nday == 5)
        nday = "пятница";
    if (nday == 6)
        nday = "суббота";
    nmonth += 1;
    if (nyear <= 99)
        nyear = "19" + nyear;
    if ((nyear > 99) && (nyear < 2000))
        nyear += 1900;
    var d;
    var Str0 = "";
    if (nhours > 9) Str0 = "";
    else Str0 = "0";
    d = document.getElementById("clock");
    d.innerHTML = " <span class='hour'>" + Str0 + nhours + ":" + nmins + " " + AMorPM + "</span>" + " - " + nday + " " + ntoday + "/" + nmonth + "/" + nyear;

    setTimeout('startclock()', 1000);
}