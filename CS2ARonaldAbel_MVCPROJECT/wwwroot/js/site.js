const AddStudent = async (student) => {
    try {
        const result = await AjaxPOST("/Student/AddStudent", student);
        if (result.success) {
            alert('Student added successfullyy!');
            window.location.href = "/Student/Index"; //Babalik sa index kapag nag add ng studentx`
        } else {
            alert('Failed to add student: ' + result.message);
        }
    } catch (error) {
        console.error('Error adding student: ' + error);
        alert('An error occurred while adding student. Please try again later.');
    }
}

$(document).ready(function () {
    $('#addStudentForm').on('submit', function (e) {
        e.preventDefault();
        const student = {
            FirstName: $('#FirstName').val(),
            LastName: $('#LastName').val(),
            Age: $('#Age').val(),
            Course: $('#Course').val(),
        };
        AddStudent(student);
    })
});

const GetStudentById = async (studentId) => {
    try {
        const result = await AjaxGET(`/Student/GetStudent/${studentId}`);
        if (result.success) {
            const student = result.data;
            // Do something with the student data
        } else {
            alert('Failed to get student: ' + result.message);
        }
    } catch (error) {
        console.error('Error getting student: ' + error);
        alert('An error occurred while getting student. Please try again later.');
    }
}


const UpdateStudent = async (studentId, updatedStudent) => {
    try {
        const result = await AjaxPOST(`/Student/UpdateStudent/${studentId}`, updatedStudent);
        if (result.success) {
            alert('Student updated successfully!');
            window.location.href = "/Student/Index";
        } else {
            alert('Failed to update student: ' + result.message);
        }
    } catch (error) {
        console.error('Error updating student: ' + error);
        alert('An error occurred while updating student. Please try again later.');
    }
}
