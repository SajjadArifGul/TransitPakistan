<?php
$host = "localhost";
$username="websited_RideAdm";
$password="RideAdm";
$database="websited_Ride";

    $server = mysql_connect($host, $username, $password);
    $connection = mysql_select_db($database, $server);

    $myquery = " SELECT  `Name`, `Latitude`, `Longitude` FROM  `BusStops` WHERE `Latitude` <> 0";
    $query = mysql_query($myquery);
    
    if ( ! $query ) {
        echo mysql_error();
        die;
    }
    
    $data = array();
 
    echo "var BusStopsCordinates = [";
    
    for ($x = 0; $x < mysql_num_rows($query); $x++) {
        $data[] = mysql_fetch_assoc($query);
        echo "[",$data[$x]['Latitude'],",",$data[$x]['Longitude'],",'",$data[$x]['Name'],"']";
        if ($x <= (mysql_num_rows($query)-2) ) {
            echo ",";
        }
    }
    
        echo "];";
     
    mysql_close($server);
?>