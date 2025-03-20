using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Q1;
using Q1.Models;
using System.Text.Json.Serialization;
using WebAPI_ContentNegotiation.CustomFormatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(config =>
{
	config.OutputFormatters.Add(new CsvOutputFormatter());
});
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Product>("Product");

builder.Services.AddControllers()
	.AddOData(options =>
		options.Select().Filter().OrderBy().Count().AddRouteComponents(
				"odata", modelBuilder.GetEdmModel())
		)
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

	// Add CSV to supported response content types
	c.OperationFilter<AddCsvResponseContentTypeOperationFilter>();
});
builder.Services.AddDbContext<PE_PRN_23SumContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
