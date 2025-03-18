using System.ComponentModel.DataAnnotations;

namespace PE_PRN231_FA24_NguyenThuongHuyen_SE161803_FE.Dtos
{
    public class CosmeticCreateRequest
    {
        [Required]
        public string CosmeticId { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z0-9@#\s]*$", ErrorMessage = "CosmeticName must start with an uppercase letter and only contain letters, numbers, @, #, and spaces.")]
        public string CosmeticName { get; set; }

        [Required]
        public string SkinType { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string CosmeticSize { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "DollarPrice must be greater than 0.")]
        public decimal DollarPrice { get; set; }

        [Required]
        public string CategoryId { get; set; } 
    }
}
