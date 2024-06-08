$(document).ready(function () {
    $('#togglePassword').click(function () {
        const passwordField = $('#password');
        const fieldType = passwordField.attr('type');
        if (fieldType === 'password') {
            passwordField.attr('type', 'text');
            $('#togglePassword i').removeClass('fa-eye').addClass('fa-eye-slash');
        } else {
            passwordField.attr('type', 'password');
            $('#togglePassword i').removeClass('fa-eye-slash').addClass('fa-eye');
        }
    });
});