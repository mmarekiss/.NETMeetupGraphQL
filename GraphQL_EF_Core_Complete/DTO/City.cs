using GraphQL_EF_Core.GraphQL;
using GraphQL_EF_Core.Mediatr.Requests;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.DTO
{
    public class City
    {
        public int? Id { get; set; }

        public String Name { get; set; } = "";

       

    }
}
