$(document).ready(function () {
    $("#searchButton").click(function () {
        var text = $("#txtSearch").val();
        window.location.href = `/House/SearchHouse?specifications=` + text;
    });
});