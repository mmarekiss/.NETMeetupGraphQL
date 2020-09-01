using AutoMapper;
using GraphQL_EF_Core.Mediatr.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mappings
{
    public class PersonMap : Profile
    {
        public PersonMap()
        {
            CreateMap<DAL.Person, DTO.Person>()
                .ForMember(x => x.IsBigId, x => x.MapFrom(s => s.Id > 90));

            CreateMap<AddPersonRequest, DAL.Person>();
            CreateMap<PersonInCity, DAL.Person>();
        }
    }
}
