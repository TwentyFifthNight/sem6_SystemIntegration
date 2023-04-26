<?php
$servername = "localhost";
$username = "sakila1";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Databse connected successfully, username " . $username . "<br><br>";

$sql = "INSERT INTO actor (first_name, last_name) VALUES ('ROBERT','MAKŁOWICZ')";
$conn->query($sql);

echo "Actor created";

$sql = "DELETE FROM actor WHERE (first_name='ROBERT' AND last_name='MAKŁOWICZ')";
$conn->query($sql);

echo "Actor deleted";
$conn->close();
?>