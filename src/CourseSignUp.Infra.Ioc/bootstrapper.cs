using CourseSignUp.Application.Interface;
using CourseSignUp.Application.Service;
using CourseSignUp.Domain.Interface.Service;
using CourseSignUp.Domain.Uow;
using CourseSignUp.Infra.Data.Context;
using CourseSignUp.Infra.Data.Migrations.Seed;
using CourseSignUp.Infra.Data.Repository;
using CourseSignUp.Infra.Data.Uow;
using CourseSignUp.Messege.Interface;
using CourseSignUp.Messege.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CourseSignUp.Infra.Ioc
{
    public class bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Aplication
            services.AddScoped<ICourseService, CourseService>();
            #endregion

            #region Infra
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ISignUpToCourseRepository, SignUpToCourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            #endregion

            #region Messege
            services.AddTransient<IQueueService, QueueService>();
            #endregion

            services.AddScoped<CourseSignUpContext>();
        }
        public static void InitializeMigrations(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            if (serviceScope == null) return;
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<CourseSignUpContext>();
            dbContext.Database.Migrate();
            new Seeds(dbContext).SeedData();
            dbContext.SaveChanges();
        }
    }
}
