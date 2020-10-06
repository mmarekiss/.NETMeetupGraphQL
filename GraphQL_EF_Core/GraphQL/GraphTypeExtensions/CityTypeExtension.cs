using GraphQL_EF_Core.DTO;
using GraphQL_EF_Core.GraphQL.Resolver;
using GraphQL_EF_Core.Mediatr.Requests;
using GreenDonut;
using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Filters;
using HotChocolate.Types.Relay;
using HotChocolate.Utilities;
using MediatR;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.GraphQL.GraphTypesExtensions
{
    public class CityTypeExtension : ObjectTypeExtension<DTO.City>
    {
        protected override void Configure(IObjectTypeDescriptor<City> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field<CityPeopleResolver>(x => x.GetPeople(default, default))
                .Name("residents")
                .UsePaging<ObjectType<Person>>()
                .UseFiltering()
                .UseSorting();

            descriptor.Field("cityNames")
                .Type<NonNullType<ListType<NonNullType<StringType>>>>()
                .Resolver(ctx =>
                {
                    IDataLoader<int, String[]> dataLoader = ctx.DataLoader<CitySurnamesDataLoader>();

                    return dataLoader.LoadAsync(ctx.Parent<DTO.City>().Id.Value, CancellationToken.None);
                });
                //There is not allowed to use an filter or pagination, because of string.
                //When you need it, need to create an object for return

        }
    }
}
