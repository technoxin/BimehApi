using MediatR;
using BimehApi.DTOs;

namespace BimehApi.Queries;

public class GetInsuranceRequestByIdQuery : IRequest<InsuranceResponseDto?>
{
    public int Id { get; set; }
    
    public GetInsuranceRequestByIdQuery(int id)
    {
        Id = id;
    }
}