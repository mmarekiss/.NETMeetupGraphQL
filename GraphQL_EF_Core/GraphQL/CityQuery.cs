using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.GraphQL
{
    public class CityQuery
    {
        private readonly IMediator mediator;

        public CityQuery(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [UseSelection]
        public async Task<IQueryable<City>> GetCities()
        {
            return await mediator.Send(new CitiesRequest());
        }
    }
}
