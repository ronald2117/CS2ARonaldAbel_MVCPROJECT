﻿const AddStudent = async (student) => {
    try {
        const result = await AjaxPOST("/Student/AddStudent", student);
        if (result.success) {
            alert('Student added successfully!');
            window.location.href = "/Student/Index"; //Babalik sa index kapag nag add ng student
        } else {
            alert('Failed to add student: ' + result.message);
        }
    } catch (error) {
        console.error('Error adding student: ' + error);
        alert('An error occurred while adding student. Please try again later.');
    }
}