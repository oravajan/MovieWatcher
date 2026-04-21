using Microsoft.EntityFrameworkCore;
using MovieWatcher.Core.Data;
using MovieWatcher.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/movies", async (AppDbContext db) =>
{
    var movies = await db.MediaItems.ToListAsync();
    return Results.Ok(movies);
});

app.MapPost("/api/movies", async (AppDbContext db, MovieItem newMovie) =>
{
    db.MediaItems.Add(newMovie);
    await db.SaveChangesAsync();
    return Results.Created($"/api/movies/{newMovie.Id}", newMovie);
});

app.Run();