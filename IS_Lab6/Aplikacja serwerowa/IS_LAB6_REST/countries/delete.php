<?php

header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../class/Countries.php';


$database = new Database();
$db = $database->getConnection();
$countries = new Countries($db);

$countries->id = (isset($_GET['code']) && $_GET['code']) ?
$_GET['code'] : null;


$result = $countries->delete();

if($result === 0){
    http_response_code(200);
    echo json_encode(
        array("message" => "Item deleted.")
    );
}
else if($result === 1){
    http_response_code(409);
    echo json_encode(
        array("message" => "Invalid Code.")
    );
}
else if($result === 2){
    http_response_code(404);
    echo json_encode(
        array("message" => "No item found.")
    );
}
