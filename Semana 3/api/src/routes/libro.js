const pool = require("../db_config")

// Consultar todos los libros
async function listar(req, res) {
    console.log('pool', process.env.DB_USER)

    const [rows] = await pool.execute("SELECT id, titulo, descripcion, portada, idautor FROM libro")
    console.log('filas',  rows.length)
    res.json( rows);
}

async function buscarId(req, res) {
    console.log('id solicitado libro:',req.params.id)
    const [rows] = await pool.execute("SELECT id, titulo, descripcion, portada, idautor FROM libro WHERE id = ?", [Number(req.params.id)])
    console.log('filas',  rows.length)
    res.json( rows);
}


async function agregar(req, res) {
    // INSERT INTO `libros`.`libro` (`titulo`, `descripcion`, `idautor`) VALUES ('El Alquimista', 'Santiago, un joven pastor andaluz, emprende un viaje por el desierto buscando un tesoro en El Alquimista de Paulo Coelho. Lo que encuentra no es oro: es una comprensión más profunda de sí mismo y del mundo.', '5');
    const [result] = await pool.execute("INSERT INTO libro (titulo, descripcion, portada, idautor) VALUES (?, ?, ?, ?)", [req.body.titulo, req.body.descripcion, req.body.portada, Number(req.body.idautor)])
    res.json(result.insertId)
}



module.exports = { listar, buscarId, agregar }