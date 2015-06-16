$(document).ready(function () {
    $('#toggle_doctor').hide();
    $('#arrow_toggle').click(function () {
        $('#toggle_doctor').slideToggle("slow");
    });
    $('body').on('click','#getOrder',function () {
        $('#form_wrap').hide();
        $(this).closest('.pop_up_padding').find('.error').show();
        $('#getPrint').show();
        $(window).trigger('resize');
    });
    

});