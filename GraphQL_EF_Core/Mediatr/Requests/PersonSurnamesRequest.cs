using GraphQL_EF_Core.Mediatr.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Requests
{
    public class PersonSurnamesRequest : IRequest<List<PersonSurnamesResponse>>
    {
        public IEnumerable<int> Cities { get; set; } = Enumerable.Empty<int>();
    }
}
