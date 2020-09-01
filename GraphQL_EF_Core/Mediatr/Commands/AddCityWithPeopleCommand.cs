using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQL_EF_Core.DAL;
using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using HotChocolate.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Commands
{
    public class AddCityWithPeopleCommand : IRequestHandler<AddCityWithPeopleRequest, DTO.City>
    {
        private readonly QLContext context;
        private readonly IMapper mapper;

        public AddCityWithPeopleCommand(QLContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<DTO.City> Handle(AddCityWithPeopleRequest request, CancellationToken cancellationToken)
        {
            var city = mapper.Map<DAL.City>(request);
            context.Add(city);

            if (await context.SaveChangesAsync() > 0)
                return await context.Cities.ProjectTo<DTO.City>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == city.Id);

                throw new ApplicationException("Invalid city for insert");

        }
    }
}
