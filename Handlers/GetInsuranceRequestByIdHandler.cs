using MediatR;
using BimehApi.Data;
using BimehApi.DTOs;
using BimehApi.Extensions;
using BimehApi.Queries;

namespace BimehApi.Handlers;

public class GetInsuranceRequestByIdHandler : IRequestHandler<GetInsuranceRequestByIdQuery, InsuranceResponseDto?>
{
    private readonly AppDbContext _context;

    public GetInsuranceRequestByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<InsuranceResponseDto?> Handle(GetInsuranceRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var insuranceRequest = await _context.InsuranceRequests.FindAsync(new object[] { request.Id }, cancellationToken);
        
        if (insuranceRequest == null)
        {
            return null;
        }
        
        return insuranceRequest.ToResponseDto();
    }
}