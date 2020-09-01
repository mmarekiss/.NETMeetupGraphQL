using GraphQL_EF_Core.DTO;
using HotChocolate.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Requests
{
    public class AddCityWithPeopleRequest : IRequest<DTO.City>
    {
        public String Name { get; set; } = "";
        public List<PersonInCity> Persons { get; set; } = new List<PersonInCity>();
    }

    public class PersonInCity
    {
        public String Name { get; set; }
    }
}
