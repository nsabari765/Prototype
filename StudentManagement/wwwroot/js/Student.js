document.getElementById('registrationForm').addEventListener('submit', function (event) {
    event.preventDefault(); // Prevent default form submission

    // Add your form validation logic here
    // For example, check if all required fields are filled
    const name = document.getElementById('name').value;
    const email = document.getElementById('email').value;
    const studentID = document.getElementById('studentID').value;

    if (name && email && studentID) {
        // If validation passes, you can potentially submit the form data here (using fetch or other methods)
        // In this example, we'll just show an alert
        alert('Form submitted successfully! (This is a simulated submission)');
    } else {
        alert('Please fill out all required fields.');
    }
});
