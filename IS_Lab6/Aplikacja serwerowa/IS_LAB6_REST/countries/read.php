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

$result = $countries->read();

if($result->num_rows > 0){
    $countryRecords=array();
    $countryRecords["countries"]=array();
    
    while ($country = $result->fetch_assoc()) {
        extract($country);
        $countryDetails=array(
            "Code" => $Code,
            "Name" => $Name,
            "Continent" => $Continent,
            "Region" => $Region,
            "SurfaceArea" => $SurfaceArea,
            "IndepYear" => $IndepYear,
            "Population" => $Population,
            "LifeExpectancy" => $LifeExpectancy,
            "GNP" => $GNP,
            "GNPOld" => $GNPOld,
            "LocalName" => $LocalName,
            "GovernmentForm" => $GovernmentForm,
            "HeadOfState" => $HeadOfState,
            "Capital" => $Capital,
            "Code2" => $Code2
        );
        array_push($countryRecords["countries"], $countryDetails);
    }
    http_response_code(200);
    echo json_encode($countryRecords);
}
else{
    http_response_code(404);
    echo json_encode(
        array("message" => "No item found.")
    );
}
