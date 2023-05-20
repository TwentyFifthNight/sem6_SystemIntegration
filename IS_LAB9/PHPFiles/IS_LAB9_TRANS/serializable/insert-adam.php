<?php
$servername = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Databse connected successfully, username " . $username . "<br><br>";


$sql = "INSERT INTO actor (first_name, last_name) VALUES('ADAM','KRÓL')";
$conn->query($sql);


echo "Table actor updated";

$conn->close();
?>