document.addEventListener("DOMContentLoaded", function () {
    const deleteButtons = document.querySelectorAll(".delete-button");

    deleteButtons.forEach(function (button) {
        button.addEventListener("click", function (e) {
            e.preventDefault();

            const form = button.closest("form");

            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: "btn btn-danger",
                    cancelButton: "btn btn-success"
                },
                buttonsStyling: false
            });

            swalWithBootstrapButtons.fire({
                title: "Are you sure you want to delete this employee?",
                text: "This action cannot be undone.",
                icon: "warning",
                iconColor: "#e74c3c",
                showCancelButton: true,
                confirmButtonText: "Yes, delete it!",
                cancelButtonText: "No, cancel!",
                reverseButtons: true
            }).then((result) => {
                if (result.isConfirmed) {
                  
                    swalWithBootstrapButtons.fire({
                        title: "Deleted!",
                        text: "The employee was deleted successfully.",
                        icon: "success",
                        confirmButtonText: "OK",
                        customClass: {
                            confirmButton: "btn btn-success"
                        },
                        buttonsStyling: false
                    }).then(() => {
                      
                        form.submit();
                    });
                }
               
            });
        });
    });
});
