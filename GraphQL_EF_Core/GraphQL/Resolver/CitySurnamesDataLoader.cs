using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using GreenDonut;
using HotChocolate.DataLoader;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.GraphQL.Resolver
{
    public class CitySurnamesDataLoader : GroupedDataLoader<int, String>
    {
        private readonly IMediator mediator;

        public CitySurnamesDataLoader(IMediator mediator)
        {
            this.mediator = mediator;
        }


        protected override async Task<ILookup<int, string>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var personCounts = await mediator.Send(new PersonSurnamesRequest() { Cities = keys });

            return personCounts.ToLookup(x => x.CityId, x => x.Surname);
        }
    }
}
