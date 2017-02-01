<?php
require_once 'app_config.php';
$dbh = connect();

$query = "SELECT * FROM Scores" ;
$allresult = $dbh->query($query)->fetchAll();
if (is_array($allresult)) 
{
    foreach($allresult as $result)
    {
 echo $result[User];
    echo (",");
    echo $result[Score];
 
    echo ("@");

}
}
else {
    die('nope');
}


