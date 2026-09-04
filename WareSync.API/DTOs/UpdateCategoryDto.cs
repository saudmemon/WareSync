using System.ComponentModel.DataAnnotations;

namespace WareSync.API.DTOs;

public class UpdateCategoryDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}