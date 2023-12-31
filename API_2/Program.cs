using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using API_2.Models;

var services = new ServiceCollection();

services.AddMvc();

services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<APIcontext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringName")));

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
	builder.Services.AddSwaggerGen(); // Add SwaggerGen only once here
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
