using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CourseSignUp.Api.Courses;
using CourseSignUp.Application.Interface;
using CourseSignUp.Application.Service;
using CourseSignUp.Infra.Ioc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CourseSignUp.Received
{

    public class Program
    {
        private const string connectionString = "Endpoint";
        private const string queueName = "coursequeue";
        private static IQueueClient _queueClient;
        private static ICourseService _courseService;



        static async Task Main(string[] args)
        {
            BombProcess();
            _queueClient = new QueueClient(connectionString, queueName);

            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);

            Console.ReadLine();

            await _queueClient.CloseAsync();
        }
        private static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            _courseService = Configurations();
            var messageBody = Encoding.UTF8.GetString(message.Body);
            var course = JsonSerializer.Deserialize<SignUpToCourseDto>(messageBody);

            var result = await _courseService.SignUpToCourse(course);

            Console.WriteLine($"####################################################################");
            Console.WriteLine($"Sucess: {result.Success},  Error: {result.Error},  Data: {result.Data?.Message}");
            Console.WriteLine($"####################################################################");

            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }
        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
        {
            Console.WriteLine($"Message handler exception: { arg.Exception }");
            return Task.CompletedTask;
        }
        private static ICourseService Configurations()
        {
            var servicesColections = new ServiceCollection();
            Services(servicesColections);
            var provider = servicesColections.BuildServiceProvider();

            return provider.GetService<ICourseService>();
        }
        private static void Services(IServiceCollection services)
        {
            bootstrapper.RegisterServices(services);
        }


        private static async Task BombProcess()
        {
            for (var i = 0; i < 50; i++)
            {
                var singUp = Utils.GetRandonValues();
                await SendSingUpsCourses(singUp);
            }
        }

        private static async Task SendSingUpsCourses(SignUpToCourseDto singUp)
        {
            try
            {
                var json = JsonConvert.SerializeObject(singUp);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "https://localhost:5001/Courses/sign-up";
                using var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                var result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
