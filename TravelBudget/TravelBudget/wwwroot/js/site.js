
function DeleteTravel(actionUrl, name, description, startingDate, finishDate)
{
    Swal.fire({
        title: 'Confirm Deletion',
        html: `
            <h4 style="color: red;">Are you sure you want to delete this travel?</h4>
            <div>
            <hr class="horizontal-line">
            <h2>Travel Details:</h2>
            <strong>Name:</strong> ${name}<br>
            <strong>Description:</strong> ${description}<br>
            <strong>Starting Date:</strong> ${startingDate}<br>
            <strong>Finish Date:</strong> ${finishDate}
            </div>
        `,
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
            Swal.fire('Cancelled', 'Your travel is safe :)', 'info');
        }
    });
}

function DeleteExpense(actionUrl, price, descriprion, date, categoryType, countryName, countryCode) {
    Swal.fire({
        title: 'Confirm Deletion',
        html: `
            <h4 style="color: red;">Are you sure you want to delete this expense?</h4>
            <div>
            <hr class="horizontal-line">
            <h2>Expense Details:</h2>
            <strong>Price:</strong> ${price}<br>
            <strong>Description:</strong> ${descriprion}<br>
            <strong>Starting Date:</strong> ${date}<br>
            <strong>Category Type:</strong> ${categoryType}<br>
            <strong>Country Name:</strong> ${countryName}(${countryCode})
            </div>
        `,
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
            Swal.fire('Cancelled', 'Your expense is safe :)', 'info');
        }
    });
}




