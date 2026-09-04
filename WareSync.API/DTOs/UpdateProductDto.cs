using System.ComponentModel.DataAnnotations;

namespace WareSync.API.DTOs;

public class UpdateProductDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string SKU { get; set; } = string.Empty;

    [Range(1, 1000000)]
    public decimal Price { get; set; }

    [Range(0, 100000)]
    public int Quantity { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int SupplierId { get; set; }
}