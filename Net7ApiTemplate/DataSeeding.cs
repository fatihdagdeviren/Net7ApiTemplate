﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Concrete.EntityFramework.Context;
using System.Linq;

namespace Net7ApiTemplate
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DataAccess.Concrete.EntityFramework.Context.MyDbContext>();
            context.Database.Migrate();
            if (context.OperationClaims.Count() == 0)
            {
                context.OperationClaims.Add(new Core.Entities.Concrete.OperationClaim()
                {
                    Id= 1,
                    Name="User"
                });
            }

            context.SaveChanges();
        }

    }
}
