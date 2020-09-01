using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.DAL
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public String Name { get; set; } = "";
        public int CityId { get; set; }
        [Column(nameof(CityId))]
        public City? City { get; set; }
    }
}
