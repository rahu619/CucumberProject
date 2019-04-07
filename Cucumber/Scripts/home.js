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
            //beforeSend: function () { $('#loading').show(); },
            //complete: function () { $('#loading').hide(); },
            success: function (data) {
                console.log("response", data);

                $('#outputModal').modal('show');

                $('div.modal-body label.text-info').text(data.Name);
                $('div.modal-body p.text-success').text(data.CurrencyDescription);
            },
            error: function (response, textStatus, xhr) {
                console.log(response.responseText, textStatus, xhr);

                $('#statusDiv b').text(response.responseText);
                $('#statusDiv').show();

            }
        });


    });

    $(document).click(function () {
        $('#statusDiv').hide();

    });

    $("#outputModal").on("hidden.bs.modal", function () {

        $("#txtFirstName").val('');
        $("#txtLastName").val('');
        $("#txtCurrency").val('');

    });


    //validation messages
    $("#txtFirstName").attr("oninvalid", "this.setCustomValidity('Please enter a valid name')");
    $("#txtCurrency").attr("oninvalid", "this.setCustomValidity('Please enter a valid currency')");


    $("input[required]").attr("oninput", "setCustomValidity('')");
});



