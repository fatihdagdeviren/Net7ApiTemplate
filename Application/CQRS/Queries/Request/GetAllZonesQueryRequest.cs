using Application.CQRS.Queries.Response;
using Core.Utilities.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries.Request
{
    public class GetAllZonesQueryRequest : IRequest<DataResult<List<GetAllZonesQueryResponse>>>
    {
    }
}
