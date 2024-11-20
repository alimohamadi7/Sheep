var SinglePage = {};

SinglePage.LoadModal = function () {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            alert("خطایی رخ داده، لطفا با مدیر سیستم تماس بگیرید.");
        });
};

function showModal() {
    $("#MainModal").modal("show");
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).ready(function () {
    window.onhashchange = function () {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
        });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");
            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function (data) {
    
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                        Swal.fire({
                            icon: "error",
                            title: "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید",
                            showConfirmButton: false,
                            timer: 1500
                        });
                       // alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
                    }
                });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSuccedded) {
                var delayInMilliseconds = 1000;
                Swal.fire({
                    icon: "success",
                    title: data.message,
                    showConfirmButton: false,
                    timer: 1500
                });
                setTimeout(function () {
                    window.location.reload();
                }, delayInMilliseconds)
              
            } else {
                Swal.fire({
                    icon: "warning",
                    title: data.message,
                    showConfirmButton: false,
                    timer: 1500
                });
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $("#" + refereshDiv).html(result);
        });
}

function makeSlug(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(convertToSlug(value));
    //checkSlugDuplication(url, dist);
}

var convertToSlug = function (str) {
    var $slug = '';
    const trimmed = $.trim(str);
    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};

function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function (data) {
            if (data) {
                sendNotification('error', 'top right', "خطا", "اسلاگ نمی تواند تکراری باشد");
            }
        }
    });
}

function fillField(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(value);
}

$(document).on("click",
    'button[data-ajax="true"]',
    function () {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function (data) {

            }).fail(function (error) {
                alert("خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.");
            });
    }
}

//////////////
jQuery.validator.addMethod("iraniannationalcode",
    function (value, element, params) {
        let input = fixNumbers(element.value);

        if (!/^\d{10}$/.test(input)) return false;
        const check = +input[9];
        const sum = input.split('').slice(0, 9).reduce((acc, x, i) => acc + +x * (10 - i), 0) % 11;
        return sum < 2 ? check === sum : check + sum === 11;
    });
jQuery.validator.unobtrusive.adapters.addBool("iraniannationalcode");
jQuery.validator.addMethod("iranianmobilenumber",
    function (value, element, params) {
        mobile = fixNumbers(element.value);
        let regx1 = /^(((98)|(\+98)|(0098)|0)(9){1}[0-9]{9})+$/;
        let regx2 = /^(9){1}[0-9]{9}$/;
        return (regx1.test(mobile || regx2.test(regx2)));
    });
jQuery.validator.unobtrusive.adapters.addBool("iranianmobilenumber");

jQuery.validator.addMethod("uploadfile",
    function (value, element, params) {
        if (CheckFileLength(element))
            return true;
        let filename01 = element.value.split('.')[1];
        let filename = element.files[0].type.split('/')[1];
        const fileformat = ["jpeg", "jpg", "png"];
        if (!fileformat.includes(filename))
            return false;
        else {
            return true;
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("uploadfile");
jQuery.validator.addMethod("uploadpdf",
    function (value, element, params) {
        if (CheckFileLength(element))
            return true;
        let filename01 = element.value.split('.')[1];
        let filename = element.files[0].type.split('/')[1];
        const fileformat = ["pdf"];
        if (!fileformat.includes(filename))
            return false;
        else {
            return true;
        }
    });
jQuery.validator.unobtrusive.adapters.addBool("uploadpdf");
//jQuery.validator.addMethod("maxfilesize",
//    function (value, element, params) {
//        const fileInput = document.getElementById('fileInput');
//        if (CheckFileLength(element))
//            return true;
//        var size = element.files[0].size;
//        var maxSize = 1 * 1024 * 1024;
//        if (size > maxSize)
//            return false;
//        else {
//            return true;
//        }

//    });
//jQuery.validator.unobtrusive.adapters.addBool("maxfilesize");
function fixNumbers(str) {
    var persianNumbers = [/۰/g, /۱/g, /۲/g, /۳/g, /۴/g, /۵/g, /۶/g, /۷/g, /۸/g, /۹/g];
    var arabicNumbers = [/٠/g, /١/g, /٢/g, /٣/g, /٤/g, /٥/g, /٦/g, /٧/g, /٨/g, /٩/g];

    if (typeof str === 'string') {
        for (var i = 0; i < 10; i++) {
            str = str.replace(persianNumbers[i], i).replace(arabicNumbers[i], i);
        }
    }
    return str;
};
function CheckFileLength(element) {
    var length = element.value.length;
    return (length === 0);
}
// show picture before upload
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgPhoto').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}
function ChengePhoto(val) {
    readURL(val);
}


window.addEventListener("load", function () {
    const searchParams = new URLSearchParams(window.location.search);
    if (searchParams.has('IsSuccedded')) {
        var data = searchParams.get('Message');
        const urlObj = new URL(window.location.href);
        urlObj.search = '';
        const newUrl = urlObj.toString();
        Swal.fire({
            icon: "success",
            title: data,
            showConfirmButton: false,
            timer: 2000,
        });
        window.history.pushState("", "", newUrl);
      
    }
});
