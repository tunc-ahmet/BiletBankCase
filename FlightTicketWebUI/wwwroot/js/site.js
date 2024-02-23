$(function () {
    $('select').selectize({
        normalize: true
    })
});

$(document).ready(function () {
    $('#departureDate, #returnDate').on('click', function () {
        $(this).attr('type', 'date');
    });

    $('#btnSearchRequest').on('click', function () {
        var origin = $('#slctPlaceOfDeparture').val();
        var destination = $('#slctPlaceOfDestionation').val();
        var departureDate = $('#departureDate').val();
        var returnDate = $('#returnDate').val();

        if (!origin || !destination || !departureDate || !returnDate) {
            Swal.fire({
                title: "Uyarı!",
                text: "Lütfen tüm alanları doldurup tekrar deneyiniz!",
                icon: "warning",
                confirmButtonText: "Tamam",
                showClass: {
                    popup: `
                              animate__animated
                              animate__fadeInUp
                              animate__faster
                            `
                },
                hideClass: {
                    popup: `
                              animate__animated
                              animate__fadeOutDown
                              animate__faster
                            `
                }
            });
            return;
        }

        $.ajax({
            url: window.location.origin + '/SearchFlights',
            method: 'POST',
            data: {
                origin: origin,
                destination: destination,
                departureDate: departureDate,
                returnDate: returnDate
            },
            success: function (response) {
                $('#viewComponentContainer').html(response);
            },
            error: function (xhr, status, error) {
            }
        });
    });
});



