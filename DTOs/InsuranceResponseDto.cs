using BimehApi.Models;

namespace BimehApi.DTOs;

public class InsuranceResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public CoverageType Coverage { get; set; }
    public long Capital { get; set; }
    public decimal Premium { get; set; }
    public DateTime CreatedAt { get; set; }
}