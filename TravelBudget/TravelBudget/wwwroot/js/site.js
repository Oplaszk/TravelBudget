
//function DeleteTravel(actionUrl) {
//    console.log(actionUrl);
//    Swal.fire({
//        title: 'Confirm Deletion',
//        text: 'Are you sure you want to delete your travel?',
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonText: 'Yes, delete it!',
//        cancelButtonText: 'No, cancel!',
//        reverseButtons: true
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: actionUrl,
//                type: 'DELETE',
//                success: function () {
//                    console.log('here success')
//                    Swal.fire({
//                        icon: 'success',
//                        title: 'Deleted!',
//                        text: 'Your travel has been deleted.',
//                        showConfirmButton: false,
//                        timer: 2000
//                    });
//                    setTimeout(function () {
//                        location.reload();
//                    }, 2000);
//                },
//                error: function () {
//                    console.log('here error')
//                    Swal.fire('Error', 'An error occurred while deleting the travel.', 'error');
//                }
//            });
//        }
//        else if (result.dismiss === Swal.DismissReason.cancel) {
//            Swal.fire('Cancelled', 'Your travel is safe :)', 'info');
//        }
//    });
//}

function DeleteTravel(actionUrl) {
    console.log(actionUrl);
    Swal.fire({
        title: 'Confirm Deletion',
        text: 'Are you sure you want to delete your travel?',
        icon: 'question',
        showCancelButton: true
    }).then(result => {
        if (result.isConfirmed) {
            $.ajax({
                url: actionUrl,
                type: 'POST',
                success: function (result) {
                    localStorage.setItem('travelDeletedMessage', 'Your travel has been deleted successfully');
                    location.reload();
                },
                error: function (error) {
                    alert("failure");
                }
            });

        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire('Cancelled', 'operation has been canceled', 'info');
        }
    });
}

function DeleteExpense(actionUrl) {
    console.log(actionUrl);
    Swal.fire({
        title: 'Confirm Deletion',
        text: 'Are you sure you want to delete your expense?',
        icon: 'question',
        showCancelButton: true
    }).then(result => {
        if (result.isConfirmed) {
            $.ajax({
                url: actionUrl,
                type: 'POST',
                success: function (result) {
                    localStorage.setItem('expenseDeletedMessage', 'Your expense has been deleted successfully');
                    location.reload();
                },
                error: function (error) {
                    alert("failure");
                }
            });

        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire('Cancelled', 'operation has been canceled', 'info');
        }
    });
}




