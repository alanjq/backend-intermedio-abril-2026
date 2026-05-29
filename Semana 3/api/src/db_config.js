const mysql = require("mysql2/promise")

const pool = mysql.createPool({
    host: process.env.DB_HOST || 'localhost',
    user: process.env.DB_USER || 'root',
    password: process.env.DB_PSWD || 'root',
    database: process.env.DB_NAME || 'libros',
    port: Number(process.env.DB_PORT || 3306),
    waitForConnections: true,
    connectionLimit: 5,
    queueLimit: 0
})

module.exports = pool
