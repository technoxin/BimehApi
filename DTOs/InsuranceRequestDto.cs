using BimehApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BimehApi.DTOs;

public class InsuranceRequestDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Coverage type is required")]
    public CoverageType Coverage { get; set; }
    
    [Required(ErrorMessage = "Capital amount is required")]
    [Range(1, long.MaxValue, ErrorMessage = "Capital must be a positive number")]
    public long Capital { get; set; }
}