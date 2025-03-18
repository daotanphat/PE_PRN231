using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Q1.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PE_PRN_24FallB5_231Context>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// using Odata
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Project>("Project");

builder.Services.AddControllers()
	.AddOData(options =>
		options.Filter().Select().Count().AddRouteComponents(
				"odata", modelBuilder.GetEdmModel())
		)
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
