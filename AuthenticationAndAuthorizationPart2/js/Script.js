function ShowImagePreview(ImageUploader, previewImage) {
    if (ImageUploader.files && ImageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);

        }
        reader.readAsDataURL(ImageUploader.files[0]);
    }
}

//var pwd = $('#pwd').val();
//var cpwd = $('#cpwd').val();
function Register() {
    var res = validate();
    if (res == false) {

        return false;
    }
    else {
            var obj = {
                Username: $('#username').val(),
                Password: $('#pwd').val(),
                Email: $('#email').val(),
                Address: $('#address').val(),
                ConfirmPassword: $('#cpwd').val(),
                AdditionalPhoneNumber: $('#additionalphone').val(),   
        };
        $.ajax({
            url: "/Account/Regis",
            data: JSON.stringify(obj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {

                Swal.fire({
                    icon: 'success',
                    title: 'Registered',
                    text: 'User Registered successfully!',
                })
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function validate() {
    var isValid = true;
    if ($('#username').val().trim() == "") {
        $('#username1').html('! Username Required');
        $('#username1').css('color', 'Red');
        isValid = false;
    }
    else {
        $('#username').css('border-color', 'lightgrey');

    }
    if ($('#email').val().trim() == "") {
        $('#email1').html('! Email Required');
        $('#email1').css('color', 'red');
        isValid = false;
    }
    else {
        $('#email').css('border-color', 'lightgrey');

    }
    if ($('#phone').val().trim() == "") {
        $('#phone1').html('! Phone Number  Required');
        $('#phone1').css('color', 'red');
        isValid = false;
    }
    else {
        $('#phone').css('border-color', 'lightgrey');

    }
    if ($('#address').val().trim() == "") {
        $('#address1').html('! Address Required');
        $('#address1').css('color', 'red');
        isValid = false;
    }
    else {
        $('#address').css('border-color', 'lightgrey');

    }
    if ($('#pwd').val().trim() == "") {
        $('#pwd1').html('! Password Required');
        $('#pwd1').css('color', 'Red');
        isValid = false;
    }
    else {
        $('#pwd').css('border-color', 'lightgrey');

    }
    if ($('#cpwd').val().trim() == "") {
        $('#cpwd1').html('! Confirm Password Required');
        $('#cpwd1').css('color', 'Red');
        isValid = false;
    }
    else {
        $('#cpwd').css('border-color', 'lightgrey');

    }
    //if (cpwd != pwd) {
    //    isValid = false;
    //}
    //else {
    //    $('#cpwd').css('border-color', 'lightgrey');

    //}
    return isValid;

}

function addtocart(produId) {
    $.ajax({
        url: "/Shopping/shop/" + produId,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (data) {
            $.notify(data.message, {
                globalPosition: "top center",
                className: "success"
            })                     

        },
            error: function (errormessage) {
                Swal.fire({
                    icon: 'error',
                    title: 'Please login',
                    text: 'To add to cart login is required!',
                })
        }
    });
}

function Remove(removeId)
{
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })
    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
    $.ajax({
        url: "/Shopping/RemoveFromCart/" + removeId,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (data) {
            swalWithBootstrapButtons.fire(
                'Deleted!',
                data.Message,
                'success'
            )
            $('#row-' + data.DeleteId).fadeOut('slow');
            var val1 = parseInt($('#grandtotal').val());;
            var val2 = parseInt($('#Total-' + data.DeleteId).val());
            $('#grandtotal').val(val1 - val2 );


        }
    

        

    });
        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your Food Item is safe :)',
                'error'
            )
        }
    })
}
/*---------------------------for Grand Total---------------------*/
//$(document).ready(function () {
//    Total();   
//});
//function Total() {

//    $.ajax({
//        url: "/Shopping/total/",
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (data) {
////var total = 0;
////$.each(data, function (index, value) {
////    total += value.quantity * value.price;
////    //$('#grandtotal').val() = total;


//});
//$('#grandtotal').val() = total;
////            var val1 = 0;
////            $('#grandtotal').val()=val1;

////            for (var i = 0; i < 5; i++) {

////                $('#grandtotal').val() = $('#grandtotal').val() + $('#Total-' + data[0]).val();

////            }
////            data.forEach(add);
////            function add(item, index) {
               
////                var val1 = 0;
////                $('#grandtotal').val() = parseInt(val1);
////                for (var i = 0; i < (parseInt(item-1)); i++) {

////                    $('#grandtotal').val() = $('#grandtotal').val() + $('#Total-' + data[i]).val();

////                }  
                                  


////            }
//        },
//        error: function (errormessage) {
//            Swal.fire({
//                icon: 'error',
//                title: 'Please login',
//                text: 'To add to cart login is required!',
//            })
//        }
//    });
//} 



/*---------------------------for quantity and total---------------------*/

function Quan(produId) {
    $.ajax({
        url: "/Shopping/Quan/" + produId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (data) {
            var id = data.CartId;
            if ($('#Quantity-' + id).val() > 1 && $('#Quantity-' + id).val() < 3) {
                var val1 = parseInt($('#Price-' + id).val());
                var val2 = parseInt($('#Quantity-' + id).val());
                //$('#Total-' + id).val() = val1*val2
                var val6=$('#Total-' + id).val();
                 var val5 = val1 * val2;
                var val4 = parseInt($('#grandtotal').val());;
                $('#grandtotal').val(val4 - val6 + val5);
                $('#Total-' + id).val(val5);
;


            };
            $('#Quantity-' + id).on("change", (function () {
                var val1 = parseFloat($('#Price-' + id).val());
                var val2 = parseInt($('#Quantity-' + id).val());
                var val5 = val1 * val2;
                var val6 = parseInt($('#Total-' + id).val());;
                var val4 = parseInt($('#grandtotal').val());;
                $('#grandtotal').val(val4 - val6 + val5);
                $('#Total-' + id).val(val5);


               


            }));
            $('#Quantity-' + id).keyup(function () {
                var val1 = parseFloat($('#Price-' + id).val());
                var val2 = parseInt($('#Quantity-' + id).val());
                if (val2 >= 1 && val < 21) {
                    var val5 = val1 * val2;
                    $('#Total-' + id).val(val1 * val2);
                    var val4 = parseInt($('#grandtotal').val());;
                    $('#grandtotal').val(val4 - val1 + val5);


                }

                else if ($('#Quantity-' + id).val().trim() == "") {
                    $('#Total-' + id).val(val1);
                }

                else {
                    $.notify(data.message, {
                        globalPosition: "top center",
                        className: "error"
                    })
                    $('#Total-' + id).val(val1);
                }
            }


            )
        },
        
        error: function (errormessage) {
            Swal.fire({
                icon: 'error',
                title: 'error',
                text: 'Something must be wrong check quantity!',
            })
        }
    });
}
function checkout() {
    var obj = {
        Total: $('#grandtotal').val(),
        orderlist: $('#itemslist').val()

    };
    $.ajax({
        url: "/Shopping/checkout",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            Swal.fire({
                icon: 'success',
                title: 'Ordered successfuly',
                text: 'User ordered successfully!',
            })
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}