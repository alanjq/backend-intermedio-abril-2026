using APIREST.Models;
using Microsoft.Extensions.ObjectPool;

#region No modificar
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSingleton<LibroService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

#endregion

#region Libro


var libros = app.MapGroup("/libros");

libros.MapGet("/", (LibroService service) =>
{
    return Results.Ok(service.GetAll());
});

libros.MapGet("/byId/{id}", (int id, LibroService service) =>
{
    Libro r = service.GetById(id);
    if (r.id != 0)
    {
        return Results.Ok(r);
    }
    return Results.NotFound();
});


libros.MapGet("/title/{titulo}", (string titulo, LibroService service) =>
{
    // Consultar si existe el titulo del libro
    List<Libro> resultados = new List<Libro>();
    resultados = (List<Libro>)service.SearchByTitle(titulo);
    if (resultados.Count > 0)
    {
        return Results.Ok(resultados);
    }
    return Results.NotFound();

});

libros.MapPost("/create", (Libro book, LibroService service) =>
{
    // Consultar si existe el titulo del libro
    List<Libro> resultados = new List<Libro>();
    resultados = (List<Libro>)service.SearchByTitle(book.titulo);
    if (resultados.Count > 0)
    {
        return Results.Text("El libro ya existe.");
    }

    service.Create(book);
    if (book.id != 0)
    {
        return Results.Created("Libro creado.", book);
    }
    return Results.Ok("Hubo un error al crear el libro.");
});

libros.MapDelete("/{id}", (int id, LibroService service) =>
{
    service.delete(id);
    return Results.StatusCode(StatusCodes.Status204NoContent);
});

libros.MapPut("/{id}", (int id, Libro lib, LibroService service) =>
{
    lib.id = id;
    service.Update(lib);
    return Results.Ok(lib);
});

#endregion

#region Autor

#endregion

app.MapGet("/", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
