using BimehApi.Models;
using BimehApi.DTOs;

namespace BimehApi.Extensions;

public static class InsuranceExtensions
{
    public static InsuranceResponseDto ToResponseDto(this InsuranceRequest request)
    {
        return new InsuranceResponseDto
        {
            Id = request.Id,
            Title = request.Title,
            Coverage = request.Coverage,
            Capital = request.Capital,
            Premium = request.Premium,
            CreatedAt = request.CreatedAt
        };
    }
    
    public static IQueryable<InsuranceResponseDto> ToResponseDto(this IQueryable<InsuranceRequest> requests)
    {
        return requests.Select(r => new InsuranceResponseDto
        {
            Id = r.Id,
            Title = r.Title,
            Coverage = r.Coverage,
            Capital = r.Capital,
            Premium = r.Premium,
            CreatedAt = r.CreatedAt
        });
    }
}