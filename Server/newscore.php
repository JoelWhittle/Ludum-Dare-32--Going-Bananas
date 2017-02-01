<?php
 
require_once 'app_config.php';
 
$dbh = connect();

 
$name = $_GET['name'];
$score = $_GET['score'];


    $query = 
       " INSERT INTO `Scores`(`User`, `Score`) VALUES ('$name','$score')";

$result = $dbh->query($query);

 



 