using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.DTO
{
    public class Person
    {
        public int? Id { get; set; }

        public String Name { get; set; } = "";
        public City? City { get; set; }

        public bool IsBigId { get; set; } 
    }
}
