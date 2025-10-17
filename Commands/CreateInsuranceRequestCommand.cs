using MediatR;
using BimehApi.DTOs;
using System.ComponentModel.DataAnnotations;

namespace BimehApi.Commands;

public class CreateInsuranceRequestCommand : IRequest<InsuranceResponseDto>
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Coverage is required")]
    [Range(1, 3, ErrorMessage = "Coverage must be 1, 2, or 3")]
    public int coverage { get; set; }
    
    [Required(ErrorMessage = "Capital is required")]
    [Range(1, long.MaxValue, ErrorMessage = "Capital must be a positive number")]
    public long capital { get; set; }
}