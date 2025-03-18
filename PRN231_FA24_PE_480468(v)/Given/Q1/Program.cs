using AutoMapper;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Q1.Mapper;
using Q1.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// using mapper
var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MapperConfig()));
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers(config =>
{
	config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PE_PRN_24FallB1Context>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// using Odata
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Book>("Books").EntityType.Filter("Author");
modelBuilder.EntitySet<Author>("Authors");

builder.Services.AddControllers()
	.AddOData(options =>
		options.Filter().OrderBy().SetMaxTop(100).SkipToken().AddRouteComponents(
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
