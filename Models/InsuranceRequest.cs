using System.ComponentModel.DataAnnotations;

namespace BimehApi.Models;

public class InsuranceRequest
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;
    
    public CoverageType Coverage { get; set; }
    
    public long Capital { get; set; }
    
    public decimal Premium { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}