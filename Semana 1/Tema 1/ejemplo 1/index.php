<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sitio en HTML + PHP</title>
    <link rel="stylesheet" href="index.css">
</head>
<body>
    <section>

    <h1>Selectores</h1>
        Etiqueta
        Clase

    <hr />
    <?php
        echo "hola";
        // Este comentario no es visible del lado del cliente
        function imprimirSaludo($mensaje){
            return $mensaje;
        }
    ?>

    </section>

        <br>

    <?php
        echo imprimirSaludo("Hola desde la función PHP");
    ?>
    <section class="con-formulario seccion">

        <h1>Sitio de ejemplo</h1>

        <form>
            <?php
                // La opción actual desactiva el opction que sea igual
                $opcionActual = "b";

                function validarActual($valor, $opcionActual){
                    return $valor === $opcionActual ? 'disabled' : '';
                }
            ?>
            <label>
                Elige una ubicación
            </label>
            <select>
                <option selected="<?=$opcionActual=="a" ? 'selected': ''?>" value="a" <?=validarActual("a", $opcionActual); ?> >A</option>
                <option selected="<?=$opcionActual=="b" ? 'selected': ''?>" value="b" <?=validarActual("b", $opcionActual); ?>>B</option>
                <option selected="<?=$opcionActual=="c" ? 'selected': ''?>" value="c" <?=validarActual("c", $opcionActual); ?>>C</option>
            </select>

            <label>
                Ingresa tu nombre
            </label>
            <input placeholder="Nombre" />
        </form>
    </section>
    <!-- Este es un comentario -->
</body>
</html>
