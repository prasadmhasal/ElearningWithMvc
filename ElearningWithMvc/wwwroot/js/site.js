$(document).ready(function () {
    // Activate the tabs with Bootstrap's Tab plugin
    $('#ex1 a[data-bs-toggle="tab"]').on('click', function (e) {
        e.preventDefault();
        $(this).tab('show');
    });
});