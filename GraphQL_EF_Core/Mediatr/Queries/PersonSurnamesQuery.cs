using GraphQL_EF_Core.DAL;
using GraphQL_EF_Core.Mediatr.Requests;
using GraphQL_EF_Core.Mediatr.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Queries
{
    public class PersonSurnamesQuery : IRequestHandler<PersonSurnamesRequest, List<PersonSurnamesResponse>>
    {
        private readonly QLContext context;

        public PersonSurnamesQuery(QLContext context)
        {
            this.context = context;
        }

        public async Task<List<PersonSurnamesResponse>> Handle(PersonSurnamesRequest request, CancellationToken cancellationToken)
            => await context.People.Select(x => new PersonSurnamesResponse() { CityId = x.CityId, Surname = x.Name}).Distinct().ToListAsync();
    }
}
