$(document).ready(function () {

    if (Modernizr.localstorage) {
        var ls = window.localStorage;
        var localInfo = JSON.parse(ls.getItem("Info"));

        if (localInfo) {
            $('#Sum').val(localInfo.Sum);
            $('#Period').val(localInfo.Period);
            $("#RateYear").val(localInfo.RateYear);
            $("#ratevalue").text(localInfo.RateYear);
            $("#DayStep").prop('checked', localInfo.DayStep);
            $("#StepPayment").val(localInfo.StepPayment);
        }
    }

    $(".btn-submit").click(function () {
        var info = {
            "Sum": $("#Sum").val(),
            "Period": $("#Period").val(),
            "RateYear": $("#RateYear").val(),
            "DayStep": $("#DayStep").is(':checked'),
            "StepPayment": $("#StepPayment").val()
        };

        if (Modernizr.localstorage) {
            var ls = window.localStorage;
            var calculatorInfo = JSON.stringify(info);
            ls.setItem("Info", calculatorInfo);
        }
    });

    $(".btn-reset").click(function () {
        if (Modernizr.localstorage) {
            localStorage.clear();
            location.reload();
        }
    });

    if ($('.days_step input[type="checkbox"]').is(':checked')) {
        $(".step_payment_wrap").show();
    }

    $('.days_step input[type="checkbox"]').click(function () {
        if ($(this).is(':checked')) {
            $(".step_payment_wrap").show();
        } else {
            $(".step_payment_wrap").hide();
        }
    });
});