using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Commands
{
    public class AddCityCommand : IRequestHandler<AddCityRequest, DTO.City>
    {
        private readonly DAL.QLContext context;
        private readonly IMapper mapper;

        public AddCityCommand(DAL.QLContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<City> Handle(AddCityRequest request, CancellationToken cancellationToken)
        {
            var city = mapper.Map<DAL.City>(request);
            context.Cities.Add(city);
            if (await context.SaveChangesAsync() > 0)
                return context.Cities.ProjectTo<DTO.City>(mapper.ConfigurationProvider).FirstOrDefault(x => x.Id == city.Id);

            throw new ApplicationException("Invalid city for insert");
        }
    }
}
