using carCRBackend.Contexts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var AutoCORS = "_myAllowSpecificOrigins"; //CORS

builder.Logging.AddJsonConsole();

// Add services to the container.
builder.Services.AddDbContext<CarDataSQLiteDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLite"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(AutoCORS, builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

//Root 'api' returns
app.MapGet("/", () => "Autotietokanta!");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

//app.UseHttpsRedirection();

app.UseCors(AutoCORS);

app.UseAuthorization();

app.MapControllers();

app.Urls.Add("http://0.0.0.0:5011");

app.Run();

