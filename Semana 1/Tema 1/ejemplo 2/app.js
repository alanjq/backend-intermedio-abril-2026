function enviarFormulario() {
    let formulario = document.querySelector("form")
    console.log('formulario', formulario);

    let { busqueda, nombre, opciones } = formulario

    const formData = new FormData(formulario)
    formData.append("busqueda", busqueda.value)
    formData.append("nombre", nombre.value)
    formData.append("opciones", opciones.value)

    console.table([busqueda, nombre, opciones])



    // Se hace el envío de datos por la API usando JS
    console.log('Envío de datos', formData);

    fetch('http://localhost/tema1/formulario.php', {
        method: 'POST',
        body: formData,
    })
        .then((r) => {
            console.log(r)
        })

}
