<?php 

include "dbconn.php";  // Ukljucujemo bazu , bez ovoga ne bi nista radilo



?>

<?php 

if(isset($_POST["login"])){   // Proveravamo da li je forma pod imenom login poslata
    $st = $pdo->prepare("SELECT * FROM users WHERE username=? AND password=?");  // Da li postoje uneseni podaci u bazi
    $st->execute([ $_POST["user"],$_POST["password"] ]);  // Izvrsavamo unesene podatke iz forme
    $u = $st->fetch(); // Hvatamo ih u novu varijablu $u
    
    if($u){  // Pomocu $u imamo rezultat da li je pronasao korisnika ili ne
        $_SESSION["ulogovan"] = true; // Ukoliko jeste, postavljamo sesiju pod imenom "ulogovan"
        header("Location: prijave.php"); // Redirektujemo korisnika na prijave.php
    }
    else  
    echo "Login failed";  // Ukoliko nije ispisace login failed i formu
 
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
</head>
<body>
    <form action="login.php" method="post">
   Username: <input type="text" name="user" > <br>
   Lozinka: <input type="password" name="password" > <br>
   <input type="submit" name="login" value="Prijavi se">
    </form>
</body>
</html>