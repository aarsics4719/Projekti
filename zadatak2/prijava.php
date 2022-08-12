<?php 

include "dbconn.php"; // Ukljucujemo bazu , bez ovoga ne bi nista radilo


if(isset($_POST["prijava"])){  // Validacije
if(empty($_POST["ime"]) || empty($_POST["prezime"]) || empty($_POST["smer"])  ){
echo "Polja nisu uredno popunjena!";
die();
}
if(strlen($_POST["ime"] && strlen($_POST["prezime"]) < 3  )){
    echo "Manje od 3 slova!";
    die();
}
if($_POST["smer"] != "RN" && $_POST["smer"] != "RI" && $_POST["smer"] != "S"){
    echo "Smer nije dobar!";
    die();
}
$st = $pdo->prepare("INSERT INTO kandidati VALUES(NULL,?,?,?,?,?) ");
$st->execute([ $_POST["ime"], $_POST["prezime"],$_POST["smer"],"",""]);
echo "Prijava prihvacena!";
die();
}

?> 
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Prijava</title>
</head>
<body>

<h2>Prijava za ispit</h2>

<form action="prijava.php" method="post">
Ime: <input type="text" name="ime"> <br>
Prezime: <input type="text" name="prezime"> <br>
Smer: <select name="smer">
<option value="RN">Racunarske nauke</option>
<option value="RI">Racunarski inzenjering</option>
<option value="S">Informacione tehnologije</option>
<option value="D">Dizajn</option>  <!-- Kad se izabere polje dizajn , prijava ce biti odbijena -->
</select>
<input type="submit" name="prijava" value="Prijavi ispit">

</form>
    
</body>
</html>