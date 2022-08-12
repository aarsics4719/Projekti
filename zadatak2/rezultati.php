<?php
include "dbconn.php"; // Ukljucujemo bazu , bez ovoga ne bi nista radilo


?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Rezultati</title>
</head>
<body>

<h2>RN bodovi</h2>
<table>
<tr>
<th>Ime i prezime</th>
<th>Broj bodova</th>
<th>Status</th>
</tr>
<?php $st = $pdo->query("SELECT * FROM kandidati WHERE smer='RN' ")->fetchAll(); // Prikaz podataka po smeru
foreach($st as $rn){
?>
<tr>
<td><?= $rn["ime"] , $rn["prezime"] ?> </td>
<td><?= $rn["bodovi"] ?> </td>
<td> <?php if($rn["bodovi"] < 60) { echo "Pao" ; } else echo "Polozio"  // u koloni 
// ispisujemo ako ima manje od 60 bodova student je pao a ako ima vise onda polozio ?>  </td> 

</tr>
<?php } // Sve je isto za sledece 2 tabele ?>
</table>








<h2>RI bodovi</h2>
<table>
<tr>
<th>Ime i prezime</th>
<th>Broj bodova</th>
<th>Status</th>
</tr>
<?php $st = $pdo->query("SELECT * FROM kandidati WHERE smer='RI' ")->fetchAll();
foreach($st as $rn){
?>
<tr>
<td><?= $rn["ime"] , $rn["prezime"] ?> </td>
<td><?= $rn["bodovi"] ?> </td>
<td> <?php if($rn["bodovi"] < 60) { echo "Pao" ; } else echo "Polozio" ?>  </td>
</tr>
<?php } ?>

</table>


<h2>S bodovi</h2>
<table>
<tr>
<th>Ime i prezime</th>
<th>Broj bodova</th>
<th>Status</th>
</tr>
<?php $st = $pdo->query("SELECT * FROM kandidati WHERE smer='S' ")->fetchAll();
foreach($st as $rn){
?>
<tr>
<td><?= $rn["ime"] , $rn["prezime"] ?> </td>
<td><?= $rn["bodovi"] ?> </td>
<td> <?php if($rn["bodovi"] < 60) { echo "Pao" ; } else echo "Polozio" ?>  </td>
</tr>
<?php } ?>

</table>


</body>
</html>