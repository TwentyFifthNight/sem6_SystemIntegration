<?php
    $servername = "localhost";
    $username = "sakila1";
    $password = "pass";
    $database = "sakila";
    
    $conn = new mysqli($servername, $username, 
                        $password, $database);

    if ($conn->connect_error) {
        die("Database connection failed: " . $conn->connect_error);
    }

    echo "Databse connected successfully, username " .
        $username . "<br><br>";
    
    // Change the default isolation level (default is REPEATABLE READ)
    $conn->query("SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
    
    // Start transaction
    $conn->begin_transaction();
    
    $sql = "SELECT actor_id, first_name, last_name FROM actor WHERE first_name = 'CHRIS'";
    $result = $conn->query($sql);
    
    if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
            echo "id: " . $row["actor_id"]. " - Name: " .
            $row["first_name"]. " " . $row["last_name"]. "<br>";
        }
    } else {
        echo "0 results<br>";
    }
    
    $conn->commit();
    $conn->close();
?>
