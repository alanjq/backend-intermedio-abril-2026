const pool = require("../db_config")

// Consultar todos los autores
async function listar(req, res) {
    console.log('pool', process.env.DB_USER)

    const [rows] = await pool.execute("SELECT id, nombre, apellido FROM autor")
    console.log('filas',  rows.length)
    res.json( rows);
}


module.exports = { listar }
