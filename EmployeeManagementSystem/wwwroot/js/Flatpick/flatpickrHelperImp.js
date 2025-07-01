document.addEventListener('DOMContentLoaded', function () {
    const today = new Date();

    const maxDobDate = new Date(today.getFullYear() - 18, today.getMonth(), today.getDate());
    const minDobDate = new Date(today.getFullYear() - 60, today.getMonth(), today.getDate());
    const maxDob = maxDobDate.toISOString().split('T')[0];
    const minDob = minDobDate.toISOString().split('T')[0];

    setupDatePicker({
        selector: '.datepicker-dob',
        dateFormat: "Y-m-d",
        maxDate: maxDob,
        minDate: minDob,
        disable: [
            { from: "2025-04-01", to: "2025-05-01" },
            { from: "2025-09-01", to: "2025-12-01" }
        ]
    });

    const hireInput = document.querySelector('.datepicker-booking');
    const dobInput = document.querySelector('.datepicker-dob');

    if (dobInput && hireInput) {
        dobInput.addEventListener('change', function () {
            const dobValue = dobInput.value;
            if (!dobValue) return;

            const dobDate = new Date(dobValue);
            const minHireDateObj = new Date(
                dobDate.getFullYear() + 18,
                dobDate.getMonth(),
                dobDate.getDate()
            );
            const minHireDate = minHireDateObj.toISOString().split('T')[0];

            const maxHireDate = today.toISOString().split('T')[0];

            
            setupDatePicker({
                selector: '.datepicker-booking',
                dateFormat: "Y-m-d",
                minDate: minHireDate,
                maxDate: maxHireDate
            });
        });
    }
});
