$("#startButton").click(function () {
    stopwatch.start();
})

$("#stopButton").click(function () {
    stopwatch.stop();
    var elapsedTime = $(".stopwatch").text();
    var projectId = $("#stopButton").attr("data-projectId");

    $.ajax({
        url: "/Projects/ReportElapsedTime/" + projectId,
        type: "POST",
        data: { "elapsedTime": elapsedTime },
        success: function (result) {
            $("#totalTimeSpan").text(result);
        }
    });
})