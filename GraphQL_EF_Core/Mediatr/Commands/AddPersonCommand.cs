using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Commands
{
    public class AddPersonCommand : IRequestHandler<AddPersonRequest, DTO.Person>
    {
        private readonly DAL.QLContext qLContext;
        private readonly IMapper mapper;

        public AddPersonCommand(DAL.QLContext qLContext, IMapper mapper)
        {
            this.qLContext = qLContext;
            this.mapper = mapper;
        }
        public async Task<Person> Handle(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var person = mapper.Map<DAL.Person>(request);
            qLContext.People.Add(person);
            if (await qLContext.SaveChangesAsync() > 0)
                return qLContext.People.ProjectTo<DTO.Person>(mapper.ConfigurationProvider).FirstOrDefault(x => x.Id == person.Id);

            throw new ApplicationException("Invalid person for insert");
        }
    }
}
