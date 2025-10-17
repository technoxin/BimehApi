using MediatR;
using BimehApi.Commands;
using BimehApi.Data;
using BimehApi.DTOs;
using BimehApi.Models;
using BimehApi.Services;

namespace BimehApi.Handlers;

public class CreateInsuranceRequestHandler : IRequestHandler<CreateInsuranceRequestCommand, InsuranceResponseDto>
{
    private readonly AppDbContext _context;
    private readonly InsuranceCalculatorService _calculator;

    public CreateInsuranceRequestHandler(AppDbContext context, InsuranceCalculatorService calculator)
    {
        _context = context;
        _calculator = calculator;
    }

    public async Task<InsuranceResponseDto> Handle(CreateInsuranceRequestCommand request, CancellationToken cancellationToken)
    {
        var coverageType = (CoverageType)request.coverage;
        
        if (!_calculator.IsValidCapital(coverageType, request.capital))
        {
            throw new ArgumentException("Capital amount is outside the valid range for the selected coverage type.");
        }

        var premium = _calculator.CalculatePremium(coverageType, request.capital);
        
        var insuranceRequest = new InsuranceRequest
        {
            Title = request.title,
            Coverage = coverageType,
            Capital = request.capital,
            Premium = premium,
            CreatedAt = DateTime.UtcNow
        };
        
        _context.InsuranceRequests.Add(insuranceRequest);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new InsuranceResponseDto
        {
            Id = insuranceRequest.Id,
            Title = insuranceRequest.Title,
            Coverage = insuranceRequest.Coverage,
            Capital = insuranceRequest.Capital,
            Premium = insuranceRequest.Premium,
            CreatedAt = insuranceRequest.CreatedAt
        };
    }
}