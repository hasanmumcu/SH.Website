$(function () {

    $("input,textarea").jqBootstrapValidation({
        preventSubmit: true,
        submitError: function ($form, event, errors) {
            // additional error messages or events
        },
        submitSuccess: function ($form, event) {
            event.preventDefault(); // prevent default submit behaviour
            // get values from FORM
            var name = $("input#name").val();
            var email = $("input#email").val();
            var phone = $("input#phone").val();
            var message = $("textarea#message").val();
            var firstName = name; // For Success/Failure Message
            // Check for white space in name for Success/Fail message
            if (firstName.indexOf(' ') >= 0) {
                firstName = name.split(' ').slice(0, -1).join(' ');
            }
            //curl--request POST \
            //--url https://account.sendinblue.com/advanced/api \
            //--header 'Authorization: Bearer <<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>>' \
            //--header 'Content-Type: application/json' \
            //--data '{"personalizations":[{"to":[{"email":"john.doe@example.com","name":"John Doe"}],"subject":"Hello, World!"}],"content": [{"type": "text/plain", "value": "Heya!"}],"from":{"email":"sam.smith@example.com","name":"Sam Smith"},"reply_to":{"email":"sam.smith@example.com","name":"Sam Smith"}}'
//            var SibApiV3Sdk = require('sib-api-v3-sdk');
//            var defaultClient = SibApiV3Sdk.ApiClient.instance;
////# ınstantiate the client\
//            var apiKey = defaultClient.authentications['api-key'];
//            apiKey.apiKey = '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';
//            var apiInstance = new SibApiV3Sdk.EmailCampaignsApi();
//            var emailCampaigns = new SibApiV3Sdk.CreateEmailCampaign();
////# Define the campaign settings\
//            emailCampaigns.name = "Campaign sent via the API";
//            emailCampaigns.subject = "My subject";
//            emailCampaigns.sender = { "name": "From name", "email": "hasan.mumcu@ceng.deu.edu.tr" };
//            emailCampaigns.type = "classic";
////# Content that will be sent\
//            htmlContent: 'Congratulations! You successfully sent this example campaign via the Sendinblue API.',
////# Select the recipients\
//            recipients: { listIds: [2, 7] },
////# Schedule the sending in one hour\
//            scheduledAt: '2018-01-01 00:00:01'
//        }
////# Make the call to the client\
//        //apiInstance.createEmailCampaign(emailCampaigns).then(function (data) {
//        //    console.log('API called successfully. Returned data: ' + data);
//        //}, function (error) {
//        //    console.error(error);
//        //});
            $.ajax({
                request : POST,
                url: 'https://api.sendgrid.com/v3/mail/send',
                Authorization: 'Bearer <<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>>',
                contentType: application / json,
                data: {
                    "personalizations": [{ "to": [{ "email": "mumcu.hasan@hotmail.com", "name": "Hasan Mumcu" }], "subject": subject }], "content": message, "from": email, "reply_to": {
                        "email": email, "name": name          
                },
                cache: false,
                success: function () {
                    // Success message
                    $('#success').html("<div class='alert alert-success'>");
                    $('#success > .alert-success').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
                        .append("</button>");
                    $('#success > .alert-success')
                        .append("<strong>Your message has been sent. </strong>");
                    $('#success > .alert-success')
                        .append('</div>');

                    //clear all fields
                    $('#contactForm').trigger("reset");
                },
                error: function () {
                    // Fail message
                    $('#success').html("<div class='alert alert-danger'>");
                    $('#success > .alert-danger').html("<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;")
                        .append("</button>");
                    $('#success > .alert-danger').append("<strong>Sorry " + firstName + ", it seems that my mail server is not responding. Please try again later!");
                    $('#success > .alert-danger').append('</div>');
                    //clear all fields
                    $('#contactForm').trigger("reset");
                },
            })
        },
        filter: function () {
            return $(this).is(":visible");
        },
    });

    $("a[data-toggle=\"tab\"]").click(function (e) {
        e.preventDefault();
        $(this).tab("show");
    });
});


/*When clicking on Full hide fail/success boxes */
$('#name').focus(function () {
    $('#success').html('');
});