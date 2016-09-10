<?php
/* Attempt MySQL server connection. Assuming you are running MySQL
server with default setting (user 'root' with no password) */

/* load configuration */
require_once('myconfig.php');

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$TeacherID = intval($_GET['TeacherID']);

$sql = "SELECT * FROM Teachers WHERE ID = '$TeacherID'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "ID: " . $row["ID"]. " - Name: " . $row["Name"]. " - Contact: " . $row["Contact"]. " - Rank: " . $row["Rank"]."<br>";
    }
} else {
    echo "0 results";
}
$conn->close();
?>