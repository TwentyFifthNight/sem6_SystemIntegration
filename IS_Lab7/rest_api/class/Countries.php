<?php

class Countries{

    private $continents = array("Asia","Europe","North America","Africa","Oceania",
    "Antarctica","South America");
    private $countriesTable = "country";
    private $conn;
    public $id;
    public $name;
    public $continent;
    public $region;
    public $surfaceArea;
    public $indepYear;
    public $population;
    public $lifeExpectancy;
    public $gnp;
    public $gnpOld;
    public $localName;
    public $governmentForm;
    public $headOfState;
    public $capital;
    public $code2;
    public function __construct($db){
        $this->conn = $db;
    }

    function read(){
        if($this->id) {
            $stmt = $this->conn->prepare("SELECT * FROM ".$this->countriesTable." WHERE Code = ?");
            $stmt->bind_param("s", $this->id);
        } else {
            $stmt = $this->conn->prepare("SELECT * FROM ".$this->countriesTable);
        }

        $stmt->execute();
        $result = $stmt->get_result();
        return $result;
    }

    function post(){
        if(!($this->id))    return 1; 

        $result = $this->read();
        if(!($result->num_rows === 0))  return 2;

        if(!($this->name && $this->name && $this->continent && $this->region 
            && $this->surfaceArea && $this->population && $this->lifeExpectancy
            && $this->gnp && $this->gnpOld && $this->localName
            && $this->governmentForm && $this->headOfState && $this->capital && $this->code2))
            return 3;

        if(!array_search($this->continent,$this->continents))   return 4;

        $stmt = $this->conn->prepare("INSERT INTO ".$this->countriesTable." 
            VALUES ('$this->id', '$this->name', '$this->continent', '$this->region', 
                    '$this->surfaceArea', '$this->indepYear', '$this->population', '$this->lifeExpectancy', '$this->gnp', 
                    '$this->gnpOld', '$this->localName', '$this->governmentForm', '$this->headOfState',
                    '$this->capital', '$this->code2')");
        $stmt->execute();
        return 0;
    }

    function delete(){
        if(!$this->id)   return 1;
        
        $result = $this->read();
        if($result->num_rows === 1){
            $stmt = $this->conn->prepare("DELETE FROM ".$this->countriesTable." WHERE Code = ?");
            $stmt->bind_param("s", $this->id);
            $stmt->execute();
            return 0;
        }
        return 2;
        
    }

    function update(){
        if(!$this->id)   return 1;
            
        $result = $this->read();
        if(!($result->num_rows === 1))  return 2; 

        $fields = array("Name","Continent","Region","SurfaceArea","IndepYear",
                "Population","LifeExpectancy","GNP","GNPOld","LocalName","GovernmentForm",
                "HeadOfState","Capital","Code2");
        $values = array($this->name,$this->continent,$this->region,$this->surfaceArea,
                $this->indepYear, $this->population, $this->lifeExpectancy, $this->gnp,
                $this->gnpOld, $this->localName, $this->governmentForm, $this->headOfState,
                $this->capital, $this->code2);
        
        
        for($i = 0; $i < count($values); $i++){
            if($values[$i] !== null){
                $stmt = $this->conn->prepare("UPDATE ".$this->countriesTable." SET `".$fields[$i]."` = '".$values[$i]."' WHERE Code = ?");
                $stmt->bind_param("s", $this->id);
                $stmt->execute();
            }
        }
        return 0;
        
    }
}