<?php

header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../class/Countries.php';


$database = new Database();
$db = $database->getConnection();
$countries = new Countries($db);


$countries->id = (isset($_POST['code']) && $_POST['code']) ?
$_POST['code'] : null;

$countries->name = (isset($_POST['name']) && $_POST['name']) ?
$_POST['name'] : null;

$countries->continent = (isset($_POST['continent']) && $_POST['continent']) ?
$_POST['continent'] : null;

$countries->region = (isset($_POST['region']) && $_POST['region']) ?
$_POST['region'] : null;

$countries->surfaceArea = (isset($_POST['surfaceArea']) && $_POST['surfaceArea']) ?
$_POST['surfaceArea'] : null;

$countries->indepYear = (isset($_POST['indepYear']) && $_POST['indepYear']) ?
$_POST['indepYear'] : null;

$countries->population = (isset($_POST['population']) && $_POST['population']) ?
$_POST['population'] : null;

$countries->lifeExpectancy = (isset($_POST['lifeExpectancy']) && $_POST['lifeExpectancy']) ?
$_POST['lifeExpectancy'] : null;

$countries->gnp = (isset($_POST['GNP']) && $_POST['GNP']) ?
$_POST['GNP'] : null;

$countries->gnpOld = (isset($_POST['GNPOld']) && $_POST['GNPOld']) ?
$_POST['GNPOld'] : null;

$countries->localName = (isset($_POST['localName']) && $_POST['localName']) ?
$_POST['localName'] : null;

$countries->governmentForm = (isset($_POST['governmentForm']) && $_POST['governmentForm']) ?
$_POST['governmentForm'] : null;

$countries->headOfState = (isset($_POST['headOfState']) && $_POST['headOfState']) ?
$_POST['headOfState'] : null;

$countries->capital = (isset($_POST['capital']) && $_POST['capital']) ?
$_POST['capital'] : null;

$countries->code2 = (isset($_POST['code2']) && $_POST['code2']) ?
$_POST['code2'] : null;

$result = $countries->update();

if($result === 0){
    http_response_code(200);
    echo json_encode(
        array("message" => "Item updated.")
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