using NiflheimsForge.Data;
using Microsoft.EntityFrameworkCore;
using NiflheimsForge.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", 
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NiflheimsForgeDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionLT")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
