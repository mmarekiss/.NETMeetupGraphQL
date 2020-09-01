using GraphQL_EF_Core.Mediatr.Requests;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.GraphQL.Mutations
{
    public class CityMutation
    {
        public Task<DTO.City> Add([Service] IMediator mediator, AddCityRequest city)
           => mediator.Send(city);

        public Task<DTO.City> AddWithPeople([Service] IMediator mediator, AddCityWithPeopleRequest city)
          => mediator.Send(city);
    }

}
