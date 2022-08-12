<?php 

include "dbconn.php"; // Ukljucujemo bazu , bez ovoga ne bi nista radilo


$id = $_REQUEST["id"];  // Hvatamo id koji se nalazio u prethodnom zahtevu

?>

<?php 
if(isset($_POST["sacuvaj"])){
    if($_POST["bodovi"] < 0 || $_POST["bodovi"] > 100 ){ // Validacija podataka
        echo "Neispravan unos bodova!";
        die();
    }
$st = $pdo->prepare("UPDATE kandidati SET bodovi=? , izasao=? WHERE id=$id "); // Obavezno stavljamo id kandidata
$st->execute([ $_POST["bodovi"], $_POST["izasao"] ]);  // Unos podataka sa forme
header("Location: prijave.php");
}

?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Unos bodova</title>
</head>
<body>
<?php   $st = $pdo->query("SELECT * FROM kandidati where id=$id")->fetchAll();
    foreach($st as $kandidati){
         ?>
<h4><?= $kandidati["ime"] ?><?= $kandidati["prezime"] ?> <?= $kandidati["smer"] ?> </h4>
<form action="unos-bodova.php?id=<?= $kandidati["id"] // Ne zaboravljamo nakon url uvek ?id= pa id kandidata ?>" method="post">
Broj bodova: <input type="number" name="bodovi" value= "<?= $kandidati["bodovi"] ?>"> 
Izasao: <input type="checkbox" name="izasao" <?php if($kandidati["izasao"]) echo "checked"  // Stavljamo checked polje ukoliko je kandidat izasao na ispit ?> >  
<input type="submit" value="Sacuvaj" name="sacuvaj">
</form>
<?php } ?>
</body>
</html>