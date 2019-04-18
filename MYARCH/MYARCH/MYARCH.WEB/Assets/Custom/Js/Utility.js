function ShowMessage(messageType, title, content) {
    //Success     Info     Warning    Error
    Command: toastr[messageType](content, title)

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "700",
        "hideDuration": "1000",
        "timeOut": "10000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}
//if ($(window).width() > 990) {
//    $(".admin-body").height($(window).height() - 80);
//}