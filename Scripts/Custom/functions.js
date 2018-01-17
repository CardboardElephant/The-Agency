$(document).ready(function () {
    /* Calls - Start */
    $('[data-toggle="tooltip"]').tooltip();
    $('[type=date]').datepicker({
        dateFormat: 'mm-dd-yy'
    });
    $('#Professionalism').barrating({
        showSelectedRating: true
    });
    $('#ValueForMoney').barrating({
        showSelectedRating: true
    });
    $('#Enjoyment').barrating({
        showSelectedRating: true
    });
    $('#Attire').barrating({
        showSelectedRating: true
    });

    /* Calls - End */

    /* Functions - Start */

    function getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(geocodeLatLng);
        } else {
            $('#notice').text("Geolocation is not supported by this browser.");
        }
    }
    function geocodeLatLng(position) {
        var geocoder = new google.maps.Geocoder;
        var latlng = { lat: parseFloat(position.coords.latitude), lng: parseFloat(position.coords.longitude) };
        geocoder.geocode({ 'location': latlng }, function (results, status) {
            if (status === 'OK') {
                if (results[0]) {
                    var span = $('<span class="header-location">').text(' (' + results[0].address_components[2].long_name + ')');
                    $('#header').append(span);
                } else {
                    console.log('No results found.');
                }
            } else {
                console.log('Geocoder failed due to: ' + status);
            }
        });
    }
    //getLocation();

    var onAjaxRequestSuccess = function (result) {
        if (result.EnableError) {
            alert(result.ErrorMsg);
        } else if (result.EnableSuccess) {
            alert(result.SuccessMsg);
            $('#AjaxformId').get(0).reset();
        }
    };
    /* Functions - End */
});