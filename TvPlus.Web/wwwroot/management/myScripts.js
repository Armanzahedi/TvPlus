var KTAppSettings = {
    breakpoints: {
        sm: 576,
        md: 768,
        lg: 992,
        xl: 1200,
        xxl: 1400,
    },
    colors: {
        theme: {
            base: {
                white: "#ffffff",
                primary: "#3699FF",
                secondary: "#E5EAEE",
                success: "#1BC5BD",
                info: "#8950FC",
                warning: "#FFA800",
                danger: "#F64E60",
                light: "#E4E6EF",
                dark: "#181C32",
            },
            light: {
                white: "#ffffff",
                primary: "#E1F0FF",
                secondary: "#EBEDF3",
                success: "#C9F7F5",
                info: "#EEE5FF",
                warning: "#FFF4DE",
                danger: "#FFE2E5",
                light: "#F3F6F9",
                dark: "#D6D6E0",
            },
            inverse: {
                white: "#ffffff",
                primary: "#ffffff",
                secondary: "#3F4254",
                success: "#ffffff",
                info: "#ffffff",
                warning: "#ffffff",
                danger: "#ffffff",
                light: "#464E5F",
                dark: "#ffffff",
            },
        },
        gray: {
            "gray-100": "#F3F6F9",
            "gray-200": "#EBEDF3",
            "gray-300": "#E4E6EF",
            "gray-400": "#D1D3E0",
            "gray-500": "#B5B5C3",
            "gray-600": "#7E8299",
            "gray-700": "#5E6278",
            "gray-800": "#3F4254",
            "gray-900": "#181C32",
        },
    },
    "font-family": "Poppins",
};
var navActive = $('#nav_active').val();
var navItemActive = $('#nav_item_active').val();
if (navActive != null && navActive != "") {
    $('#nav_' + navActive + '').addClass("menu-item-open");
    if ($('#subnav_' + navActive + '').length) {
        $('#subnav_' + navActive + '').css("display", "");
        $('#subnav_' + navActive + '').css("overflow", "");
    }
}
if (navItemActive != null && navItemActive != "") {
    $('#nav_item_' + navItemActive + '').addClass("menu-item-active");
}
function accessDenied() {
    Swal.fire("Error!", "شما دسترسی لازم برای ورود به این بخش را ندارید", "error");
}

$.extend(true, $.fn.dataTable.defaults, {
    dom: `<'row'<'col-sm-6 text-left'f><'col-sm-6 text-right'>>
			<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
    serverSide: true,
    processing: true,
    responsive: true,
    //pagingType: "full_numbers",
    "language": {
        "url": "//cdn.datatables.net/plug-ins/1.10.18/i18n/Persian.json"
    },
    "initComplete": function (settings, json) {
        $("[name='datatable_length']").css("margin-left","0.5rem")
    }
});
toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": true,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

$(document).ajaxError(function (event, xhr, ajaxOptions, thrownError) {
    if (xhr.status == 403 || xhr.status == 401) {
        toastr.error("شما دسترسی لازم برای ورود به این بخش را ندارید.", "خطا");
    } else {
        toastr.error(thrownError, "Error");
    }
});
function openModal(link) {
    $.get(link, function (result) {
        $("#myModal").modal();
        //if (title != null) {
        //    $("#myModalLabel").html(title);
        //}
        $("#myModalBody").html(result);
        var title = $("#title").val();
        if (title != null && title != undefined) {
            $("#myModalLabel").html(title);
        } else {
            $("#myModalLabel").html("");
        }
    });
}
Dropzone.prototype.defaultOptions.dictDefaultMessage = "آپلود فایل";
Dropzone.prototype.defaultOptions.dictFallbackMessage = "مرورگر شما درگ و دراپ را پشتیبانی نمیکند";
Dropzone.prototype.defaultOptions.dictFallbackText = "لطفا از اینجا آپلود کنید";
Dropzone.prototype.defaultOptions.dictFileTooBig = "حجم فایل آپلود شده زیاد است ({{filesize}}MiB) . سقف حج مجاز {{maxFilesize}}";
Dropzone.prototype.defaultOptions.dictInvalidFileType = "شما نمی توانید این نوع فایل را آپلود کنید.";
Dropzone.prototype.defaultOptions.dictResponseError = "سرور با کد {{statusCode}} پاسخ داد";
Dropzone.prototype.defaultOptions.dictCancelUpload = "لغو آپلود";
Dropzone.prototype.defaultOptions.dictCancelUploadConfirmation = "آیا اطمینان دارید؟";
Dropzone.prototype.defaultOptions.dictRemoveFile = "حذف فایل";
Dropzone.prototype.defaultOptions.dictMaxFilesExceeded = "شما نمیتوانید فایل دیگری آپلود کنید";


//$(document).ajaxStart(function () {
//    $("#loading").css("display","block");
//});
//$(document).ajaxComplete(function () {
//    $("#loading").hide();
//});

