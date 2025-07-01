$(document).ready(function () {
    $(".js-example-tags").select2({
        placeholder: "Select your position",
        allowClear: true,
        language: {
            noResults: function () {
                return "No results found";
            }
        },
        escapeMarkup: function (markup) {
            return markup; // عرض رسالة No results كما هي بدون تعديل
        },
        matcher: function (params, data) {
            // إذا لا يوجد نص بحث، نعرض فقط أول 4 خيارات
            if (!params.term) {
                var index = $(data.element).index();
                if (index < 4) {
                    return data;
                }
                return null; // إخفاء باقي الخيارات
            }
            // عند وجود بحث نعرض فقط النتائج المطابقة
            if (data.text.toLowerCase().indexOf(params.term.toLowerCase()) > -1) {
                return data;
            }
            return null;
        }
    });
});
