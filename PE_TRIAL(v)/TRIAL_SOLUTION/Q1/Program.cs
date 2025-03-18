using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Q1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Movie>("Movie");

builder.Services.AddControllers();
builder.Services.AddDbContext<PE_PRN_Fall2023B1Context>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddOData(
	options => options.Select().Filter().OrderBy().Count().AddRouteComponents(
		"odata",
		modelBuilder.GetEdmModel()));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
