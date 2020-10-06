using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Responses
{
    public class PersonSurnamesResponse
    {
        public int CityId { get; set; }
        public String Surname { get; set; } = "";
    }
}
