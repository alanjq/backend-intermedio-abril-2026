<section>
    <h1>Formulario</h1>
    <form action="formulario.php" method="post">
        <input type="text" placeholder="Ingresa la búsqueda" name="busqueda" value="<?=@$textoBusqueda?>" />
        <input type="text" name="nombre" placeholder="Tu nombre" value="<?=@$textoNombre?>">
        <select name="opciones">
            <option <?=@$opcionSeleccionada=='a' ? 'selected' : '' ?> value="a">Opción A</option>
            <option <?=@$opcionSeleccionada=='b' ? 'selected' : '' ?> value="b">Opción B</option>
        </select>
        <button type="button" onClick="enviarFormulario()">Buscar</button>
    </form>
</section>
