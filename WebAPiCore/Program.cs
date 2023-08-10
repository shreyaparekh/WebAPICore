using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPiCore.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(cors => cors.AddPolicy("MyPloicy", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));//bcz angualr port and core project is running in diffrent port so it will featch all alow

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(db =>
    db.UseSqlServer(builder.Configuration.GetConnectionString("ConEmp")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPloicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
