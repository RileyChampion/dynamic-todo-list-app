using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoApp.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Cors Policies
builder.Services.AddCors(options => {
   options.AddPolicy("AllowAll", policy => {
    policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
   });
});
// Add Feature Factory to Scope
builder.Services.AddScoped<TodoFeatureFactory>();
// Add Controllers to services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoAppDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
