﻿$("#startButton").click(function () {
    stopwatch.start();
})

$("#stopButton").click(function () {
    var elapsedTime = $(".stopwatch").text();
    stopwatch.stop();
    var projectId = $("#stopButton").attr("data-projectId");
    $.ajax({
        url: "/Projects/ReportElapsedTime/" + projectId,
        type: "POST",
        data: { "elapsedTime": elapsedTime },
        success: function (result) {
            $("#totalTimeSpan").text(result);
            
        }
    });
    stopwatch.reset();
    var timer = document.getElementById("myStopwatch");
    timer.innerHTML = "00:00:00";
})