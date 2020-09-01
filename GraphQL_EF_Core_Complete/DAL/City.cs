using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.DAL
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public String Name { get; set; } = "";
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
