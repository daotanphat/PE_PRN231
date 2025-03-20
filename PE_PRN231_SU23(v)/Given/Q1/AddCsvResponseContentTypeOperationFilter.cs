using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Q1
{
	public class AddCsvResponseContentTypeOperationFilter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			foreach (var response in operation.Responses)
			{
				response.Value.Content.Add("text/csv", new OpenApiMediaType());
			}
		}
	}
}
