using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Requests
{
    public class AddPersonRequest : IRequest<DTO.Person>
    {
        [Required]
        public String Name { get; set; } = "";
        [Required]
        public Int32 CityId { get; set; }

    }
}
