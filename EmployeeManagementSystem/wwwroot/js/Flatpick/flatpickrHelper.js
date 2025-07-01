function setupDatePicker({
    selector,
    dateFormat = "Y-m-d",
    maxDate = null,
    minDate = null,
    disable = []
}) {
    if (typeof flatpickr === 'undefined') {
        console.error("Flatpickr is not loaded.");
        return;
    }

    flatpickr(selector, {
        dateFormat: dateFormat,
        maxDate: maxDate,
        minDate: minDate,
        disable: disable
    });
}
