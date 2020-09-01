﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQL_EF_Core.DAL;
using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.Mediatr.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Mediatr.Queries
{
    public class CitiesQuery : IRequestHandler<CitiesRequest, IQueryable<DTO.City>>
    {
        public CitiesQuery() //SAMPLE inject DB and mapper
        {
        }

        public Task<IQueryable<DTO.City>> Handle(CitiesRequest request, CancellationToken cancellationToken)
        {
            //SAMPLE load Cities from DB. Be aware of Task an IQueryable.
            return Task.FromResult( Enumerable.Empty<DTO.City>().AsQueryable());
        }
    }
}
