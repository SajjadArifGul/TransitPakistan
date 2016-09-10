<?php
/* Attempt MySQL server connection. Assuming you are running MySQL
server with default setting (user 'root' with no password) */

$link = mysqli_connect("localhost", "sajjadgu_King", "Gul12345", "sajjadgu_University");
 
// Check connection
if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
 
// Escape user inputs for security
$first_name = mysqli_real_escape_string($link, $_POST['firstname']);
$last_name = mysqli_real_escape_string($link, $_POST['lastname']);
$user_id = mysqli_real_escape_string($link, $_POST['id']);
$email_address = mysqli_real_escape_string($link, $_POST['email']);
 
// attempt insert query execution
$sql = "INSERT INTO Students (firstname, lastname, id, email) VALUES ('$first_name', '$last_name', '$user_id', '$email_address')";
if(mysqli_query($link, $sql)){
    echo "Records added successfully.";
} else{
    echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
 
// close connection
mysqli_close($link);
?>