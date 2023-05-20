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

//Make sure that database has ADAM actors at the beginning

// Start transaction
$conn->begin_transaction();

$sql = "UPDATE actor SET first_name = 'CHRIS' WHERE first_name = 'ADAM'";
$conn->query($sql);

echo "Table actor updated";

// To test how to isolation level works you should invoke
//dirty-read at this moment to see
// that the output will contain uncommitted data from this
//transaction
sleep(20);

//End transaction
$conn->commit();
$conn->close();
?>