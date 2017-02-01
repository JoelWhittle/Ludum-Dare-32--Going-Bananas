<?php
//Should probably put this in a seperate file then include it.
define('DATABASE_USERNAME', 'willdevf_Client' );
define('DATABASE_PASSWORD', 'clientpassword' );
define('DATABASE_ADDRESS', 'localhost');
define('DATABASE_DB' , 'willdevf_GoingBananas');
 
#include('db_settings.php');
 
 
function connect()
{
 
    $dsn = 'mysql:host='.DATABASE_ADDRESS.';dbname='.DATABASE_DB;
    $username = DATABASE_USERNAME;
    $password = DATABASE_PASSWORD;
    $options = array(
        PDO::MYSQL_ATTR_INIT_COMMAND => 'SET NAMES utf8',
        PDO::ATTR_ERRMODE            => PDO::ERRMODE_EXCEPTION,
        PDO::ATTR_DEFAULT_FETCH_MODE => PDO::FETCH_ASSOC
    );
 
    $dbh = new PDO($dsn, $username, $password, $options);
    
    return $dbh;
}