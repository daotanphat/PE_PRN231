using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Dtos;
using Q1.Models;

namespace Q1.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly PE_PRN_23SumContext _context;
		public ProductController(PE_PRN_23SumContext context)
		{
			_context = context;
		}
		[HttpGet("index")]
		public async Task<IActionResult> GetProducts()
		{
			var products = await _context.Products
				.Include(p => p.Category)
				.Include(p => p.OrderDetails)
				.ToListAsync();

			var response = products.Select(p => new ProductCsvDto
			{
				ProductId = p.ProductId,
				ProductName = p.ProductName,
				CategoryId = p.CategoryId,
				CategoryName = p.Category.CategoryName,
				QuantityPerUnit = p.QuantityPerUnit,
				UnitPrice = p.UnitPrice,
				UnitsInStock = p.UnitsInStock,
				TotalUnitOrdered = p.OrderDetails.Sum(o => o.Quantity),
			});

			return Ok(response);
		}

		[HttpGet("lsit/{minprice}/{maxprice}")]
		public async Task<IActionResult> GetProductsByPrice([FromRoute] decimal minprice, [FromRoute] decimal maxprice)
		{
			if (minprice < 0 || maxprice < 0) return BadRequest();
			if (minprice > maxprice) return BadRequest();

			var products = await _context.Products
				.Include(p => p.Category)
				.Include(p => p.OrderDetails)
				.Where(p => p.UnitPrice >= minprice && p.UnitPrice <= maxprice)
				.ToListAsync();

			var response = products.Select(p => new
			{
				productId = p.ProductId,
				productName = p.ProductName,
				categoryId = p.CategoryId,
				categoryName = p.Category.CategoryName,
				quantityPerUnit = p.QuantityPerUnit,
				unitPrice = p.UnitPrice,
				unitsInStock = p.UnitsInStock,
				totalUnitOrdered = p.OrderDetails.Sum(o => o.Quantity),
			});

			return Ok(response);
		}
		[HttpDelete("/delete/{id}")]
		public async Task<IActionResult> DeleteByid([FromRoute] int id)
		{
			try
			{
				var product = await _context.Products
					.Include(p => p.OrderDetails)
								.SingleOrDefaultAsync(p => p.ProductId == id);

				if (product == null) return NotFound();

				_context.OrderDetails.RemoveRange(product.OrderDetails);
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500);
			}
		}
	}
}
