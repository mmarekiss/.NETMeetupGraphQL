using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Requests
{
    public class AddCityRequest : IRequest<DTO.City>
    {
        [Required]
        public String Name { get; set; } = "";
    }
}
