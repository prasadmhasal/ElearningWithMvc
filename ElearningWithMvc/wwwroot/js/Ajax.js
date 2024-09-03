$(document).ready(function () {
    $.ajax({
        url: '/Admin/CourseNames', // Adjust the URL based on your route
        type: 'GET',
        dataType: 'json',
        success: function (result, staus, xhr) {
            var options = "";
             options += '<option value="">Select CourseName</option>';

            $.each(result, function (index, entry) {
                options += "<option value='" + entry.courseId + " ' name='CourseId' >" + entry.courseName + "</options>";
            });
            $('#Coursename').html(options);
        },
        error: function (ex) {
            alert('Failed to retrieve course names: ' + ex);
        }
    });
});


$('#Coursename').change(function () {
    var data = $('#Coursename').val();
    $.ajax({
        url: '/Admin/GetSubCourse?data=' + data, // Adjust the URL based on your route
        type: 'GET',
        dataType: 'json',
        success: function (result, staus, xhr) {
            console.log(result);
            var options = "";
            options += '<option value="">Select CourseName</option>';

            $.each(result, function (index, entry) {
                options += "<option value='" + entry.subCourseId + " ' name='subCourseId' >" + entry.subcourse + "</options>";
            });
            $('#SubCourseId').html(options);
        },
        error: function (ex) {
            alert('Failed to retrieve course names: ' + ex);
        }
    });
})


$(document).ready(function () { });

$('#bynow').click(function () {
   
    var formData = $('#SubCourseId').val();
    $.ajax({
        url: '/Userdashboard/ByNow',
        type: 'POST',
        data: formData,
        ContainType: 'Application/x-www form-urlencoded;charset=utf8',
        success: function (response) {

            alert('Course added to cart successfully!');
        },
        error: function (xhr, status, error) {

            alert('An error occurred while adding to cart.');
        }
    });
});



$(document).ready(function () { });

    $.ajax({
        url: '/Userdashboard/MyCourse',
        type: 'Get',
        data: 'json',
        ContainType: 'Application/x-www form-urlencoded;charset=utf8',
        success: function (response) {

          /*  alert('Course added to cart successfully!');*/
        },
        error: function (xhr, status, error) {

            alert('An error occurred while adding to cart.');
        }
  
});


$(document).ready(function () {
   
    $('#MyVideo').click(function () {
        
        var videoUrl = $(this).siblings('#url').val();

        
        if (videoUrl) {
           
            var videoId = videoUrl.split('v=')[1];
            var ampersandPosition = videoId.indexOf('&');
            if (ampersandPosition != -1) {
                videoId = videoId.substring(0, ampersandPosition);
            }

           
            var embedUrl = 'https://www.youtube.com/embed/' + videoId;

           
            $('#playvideo').attr('src', embedUrl);

            
            $('#videoContainer').show();
            $('#noVideosMessage').hide();
        } else {
       
            $('#playvideo').attr('src', '');
            $('#videoContainer').hide();
            $('#noVideosMessage').show();
        }
    });

    
    $('#videoContainer').hide();
    $('#noVideosMessage').show();
});
