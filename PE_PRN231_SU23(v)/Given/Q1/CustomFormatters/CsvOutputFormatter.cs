using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using Q1.Models;
using Q1.Dtos;

namespace WebAPI_ContentNegotiation.CustomFormatters
{
	public class CsvOutputFormatter : TextOutputFormatter
	{
		public CsvOutputFormatter()
		{
			SupportedMediaTypes.Add("text/csv");
			SupportedEncodings.Add(Encoding.UTF8);
		}
		protected override bool CanWriteType(Type? type)
		{
			return typeof(IEnumerable<ProductCsvDto>).IsAssignableFrom(type);
		}
		public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
		{
			var response = context.HttpContext.Response;
			var products = (IEnumerable<ProductCsvDto>)context.Object;
			await using (var writer = new StreamWriter(response.Body, selectedEncoding))
			{
				foreach (var product in products)
				{
					writer.WriteLine($"{product.ProductId}; " +
						$"{product.ProductName}; " +
						$"{product.CategoryId}; " +
						$"{product.CategoryName}; " +
						$"{product.QuantityPerUnit}; " +
						$"{product.UnitPrice}; " +
						$"{product.UnitsInStock}; " +
						$"{product.TotalUnitOrdered}"
						);
				}
			}
		}
	}
}
