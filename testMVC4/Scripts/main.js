$(document).ready(function () {
    $('#toggle_doctor').hide();
    $('#arrow_toggle').click(function () {
        $('#toggle_doctor').slideToggle("slow");
    });
});