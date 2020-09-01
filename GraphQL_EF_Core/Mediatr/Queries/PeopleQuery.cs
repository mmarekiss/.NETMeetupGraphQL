using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQL_EF_Core.DAL;
using GraphQL_EF_Core.Mediatr.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Queries
{
    public class PeopleQuery : IRequestHandler<PeopleRequest, IQueryable<DTO.Person>>
    {
        private readonly QLContext dbContext;
        private readonly IMapper mapper;

        public PeopleQuery(QLContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Task<IQueryable<DTO.Person>> Handle(PeopleRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DAL.Person> source = dbContext.People.Where(x => !request.City.HasValue || request.City.Value == x.CityId);

            return Task.FromResult(source.ProjectTo<DTO.Person>(mapper.ConfigurationProvider));
        }
    }
}
