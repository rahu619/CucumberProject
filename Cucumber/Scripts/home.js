$(function () {


    $("#inputForm").submit(function (e) {
        e.preventDefault();

        var inputModel = {
            FirstName: $('#txtFirstName').val(),
            LastName: $('#txtLastName').val(),
            Currency: $('#txtCurrency').val()

        };

        console.log("array", JSON.stringify(inputModel));

        $.ajax({
            type: "POST",
            url: '/Home/ProcessInput',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(inputModel),
            success: function (data) {
                console.log("response", data);

                $('#outputModal').modal('show');

                //$('.modal-title').html(data.Name);
                $('div.modal-body label.text-info').text(data.Name);
                $('div.modal-body p.text-success').text(data.CurrencyDescription);
            },
            error: function (textStatus, errorThrown) {
                $('.alert').alert();
            }
        });


    });

    $("#outputModal").on("hidden.bs.modal", function () {

        $("#txtFirstName").val('');
        $("#txtLastName").val('');
        $("#txtCurrency").val('');

    });


});


