<?php 

include "dbconn.php"; // Ukljucujemo bazu , bez ovoga ne bi nista radilo




?>

<?php 

if(!isset($_SESSION["ulogovan"])){ // Ukoliko ne postoji sesija pod imenom "ulogovan"
    http_response_code(401); // Izbacice gresku 401 
    die(); // Zavrsavamo konekciju
}



?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Spisak</title>
</head>
<body>
<h2>Kandidati</h2>
<a href="rezultati.php">Rezultati ispita</a>
<br>
    <?php 
    $st = $pdo->query("SELECT * FROM kandidati")->fetchAll(); // Hvatamo sve kandidate
    foreach($st as $kandidati){ // ispisujemo pomocu foreacha
    ?>
    
<a href="unos-bodova.php?id=<?= $kandidati["id"] ?>"> <br><?=  $kandidati["ime"], $kandidati["prezime"] ?></a> 

<?php }   // U linku stavljamo obavezno ?id= pa brojeve kandidata, kako bi svaki kandidat imao svoju stranicu?>
</body>
</html>