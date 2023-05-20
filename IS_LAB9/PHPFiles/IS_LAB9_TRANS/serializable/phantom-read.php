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
   
    echo "Databse connected successfully, username " . $username . "<br><br>";
    
    $conn->query("SET SESSION TRANSACTION ISOLATION LEVEL SERIALIZABLE");
    // Start transaction
    $conn->begin_transaction();

    echo "Before sleep<br>";
    $sql = "SELECT actor_id, first_name, last_name FROM actor WHERE first_name = 'ADAM'";
    $result = $conn->query($sql);
    if ($result->num_rows > 0) {
        // output data of each row
        while($row = $result->fetch_assoc()) {
            echo "id: " . $row["actor_id"]. " - Name: " . $row["first_name"]. " " . $row["last_name"]. "<br>";
        }
    } else {
        echo "0 results<br>";
    }
    
    // To test how to isolation level works you should invoke
    //insert-adam at this moment
    
    sleep(20);

    // You should see different result of the query even though
    //both queries are executed during one transaciton.
    
    echo "After sleep<br>";
    $sql = "UPDATE actor SET last_update = now() WHERE first_name = 'ADAM'";
    $conn->query($sql);
    echo "Actors updated";

    $sql = "SELECT actor_id, first_name, last_name FROM actor WHERE first_name = 'ADAM'";
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

    //End transaction
    $conn->commit();
    $conn->close();
?>