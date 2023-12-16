
function Delete(actionUrl) {
    console.log(actionUrl);
        Swal.fire({
            title: 'Confirm Deletion',
            text: 'Are you sure you want to delete',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: actionUrl,
                    type: 'DELETE',
                    success: function () {
                        console.log('here success')
                        Swal.fire({
                            icon: 'success',
                            title: 'Deleted!',
                            text: 'Your travel has been deleted.',
                            showConfirmButton: false,
                            timer: 2000
                        });
                        setTimeout(function () {
                            location.reload();
                        }, 2000);
                    },
                    error: function () {
                        console.log('here error')
                        Swal.fire('Error', 'An error occurred while deleting the travel.', 'error');
                    }
                });
            }
            else if (result.dismiss === Swal.DismissReason.cancel) {
                Swal.fire('Cancelled', 'Your travel is safe :)', 'info');
            }
        });
    }


