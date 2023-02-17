using Application.CQRS.Queries.Request;
using Application.CQRS.Queries.Response;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Dtos.Zone;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Handlers.QueryHandlers
{
    public class GetAllZonesQueryHandler : IRequestHandler<GetAllZonesQueryRequest, DataResult<List<GetAllZonesQueryResponse>>>
    {
        private readonly IZoneService _zoneService;
        public GetAllZonesQueryHandler(IZoneService zoneService)
        {
            _zoneService = zoneService;
        }

        public async Task<DataResult<List<GetAllZonesQueryResponse>>> Handle(GetAllZonesQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _zoneService.GetAll();
            List<GetAllZonesQueryResponse> sResult = new List<GetAllZonesQueryResponse>();
            foreach (var zone in result)
            {
                sResult.Add(new GetAllZonesQueryResponse()
                {
                    Name = zone.Name
                });
            }
            return new DataResult<List<GetAllZonesQueryResponse>>(data: sResult, success: true);
        }
    }
}
