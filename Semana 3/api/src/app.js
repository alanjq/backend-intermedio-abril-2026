const express = require("express")
const cors = require("cors")
const helmet = require("helmet")

const endpointsAutor = require("./routes/autor")
const endpointsLibro = require("./routes/libro")

const app = express()

app.use(helmet())
app.use(cors())
app.use(express.json())

app.get("/", (req, res)=> {
    res.json({ ok: true, message: "API funcionando correctamente."})
})


app.get("/libros", endpointsLibro.listar)
app.get("/libro/:id", endpointsLibro.buscarId)
app.post("/libro/agregar", endpointsLibro.agregar)
// app.put("/libro/:id", endpointsLibro.actualizar)
// app.delete("/libro/:id", endpointsLibro.actualizar)

module.exports = app
