
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Student.DbContexts;
using StudentManagementSystem.Student.Helpers;
using StudentManagementSystem.Student.Repositories;
using StudentManagementSystem.Student.Services;
using StudentManagementSystem.Student.Worker;

namespace StudentManagementSystem.Student
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<StudentDbContext>(options =>
                                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IServiceBusListenerHelper, ServiceBusListenerHelper>();
            builder.Services.AddHostedService<ServiceBusListener>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
