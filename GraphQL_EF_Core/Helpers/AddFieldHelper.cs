﻿using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_EF_Core.Helpers
{
    public static class AddFieldHelper
    {
        public static void AddField<T>(this IObjectTypeDescriptor descriptor, string? name)
        {
            var type = typeof(T);
            descriptor.Field(name ?? type.Name).Type(type).Resolver(
                      (ctx) =>
                      {
                          var provider = ctx.Service<IServiceProvider>();
                          return Task.FromResult(ActivatorUtilities.CreateInstance(provider, type));
                      });
        }
    }
}
