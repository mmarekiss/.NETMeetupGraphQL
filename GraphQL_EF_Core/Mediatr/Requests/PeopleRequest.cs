using GraphQL_EF_Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Requests
{
    public class PeopleRequest : IRequest<IQueryable<Person>>
    {
        public int? City { get; set; } 
    }
}
