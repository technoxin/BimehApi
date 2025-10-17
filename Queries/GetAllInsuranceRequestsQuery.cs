using MediatR;
using BimehApi.DTOs;

namespace BimehApi.Queries;

public class GetAllInsuranceRequestsQuery : IRequest<List<InsuranceResponseDto>>
{
}