<?php
    $textoBusqueda = $_REQUEST['busqueda'];
    $textoNombre = $_REQUEST['nombre'];
    $opcionSeleccionada = $_REQUEST['opciones'];

    // echo 'Texto búsqueda: ' . $textoBusqueda .'<br/>';
    // echo 'Nombre: ' . $textoNombre .'<br/>';
    // echo 'Opción seleccionada: ' . $opcionSeleccionada .'<br/>';

    include  './formBusqueda.php'
?>
