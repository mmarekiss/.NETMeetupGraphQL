using AutoMapper;
using GraphQL_EF_Core.Mediatr.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mappings
{
    public class CityMap :Profile
    {
        public CityMap()
        {
            CreateMap<DAL.City, DTO.City>();
            CreateMap<AddCityRequest, DAL.City>();

            CreateMap<AddCityWithPeopleRequest, DAL.City>();
        }
    }
}
