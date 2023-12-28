
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
        text: 'Are you sure you want to delete your expense?',
        icon: 'question',
        showCancelButton: true
    }).then(result => {
        if (result.isConfirmed) {
            $.ajax({
                url: actionUrl,
                type: 'POST'
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire('Cancelled', 'everything is save :)', 'info');
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
                type: 'GET'
            });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            Swal.fire('Cancelled', 'everything is save :)', 'info');
        }
    });
}

//function DeleteExpense(actionUrl) {
//    console.log(actionUrl);
//    Swal.fire({
//        title: 'Confirm Deletion',
//        text: 'Are you sure you want to delete this Expense?',
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
//                        text: 'Your Expense has been deleted.',
//                        showConfirmButton: false,
//                        timer: 2000
//                    });
//                    setTimeout(function () {
//                        location.reload();
//                    }, 2000);
//                },
//                error: function () {
//                    console.log('here error')
//                    Swal.fire('Error', 'An error occurred while deleting the Expense.', 'error');
//                }
//            });
//        }
//        else if (result.dismiss === Swal.DismissReason.cancel) {
//            Swal.fire('Cancelled', 'Your Expense is safe :)', 'info');
//        }
//    });
//}
//function ExpenseSaved(actionUrl) {
//    Swal.fire({
//        position: "top-end",
//        icon: "success",
//        title: "Your work has been saved",
//        showConfirmButton: false,
//        timer: 2000,
//});
//}


