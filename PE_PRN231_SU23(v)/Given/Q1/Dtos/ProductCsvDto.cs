namespace Q1.Dtos
{
	public class ProductCsvDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int? CategoryId { get; set; }
		public string CategoryName { get; set; }
		public string QuantityPerUnit { get; set; }
		public decimal? UnitPrice { get; set; }
		public short? UnitsInStock { get; set; }
		public int TotalUnitOrdered { get; set; }
	}
}
