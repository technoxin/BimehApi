using MediatR;
using BimehApi.Data;
using BimehApi.DTOs;
using BimehApi.Extensions;
using BimehApi.Queries;
using Microsoft.EntityFrameworkCore;

namespace BimehApi.Handlers;

public class GetAllInsuranceRequestsHandler : IRequestHandler<GetAllInsuranceRequestsQuery, List<InsuranceResponseDto>>
{
    private readonly AppDbContext _context;

    public GetAllInsuranceRequestsHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<InsuranceResponseDto>> Handle(GetAllInsuranceRequestsQuery request, CancellationToken cancellationToken)
    {
        var requests = await _context.InsuranceRequests.ToListAsync(cancellationToken);
        return requests.Select(r => r.ToResponseDto()).ToList();
    }
}