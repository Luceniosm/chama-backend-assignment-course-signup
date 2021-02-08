using System.Threading.Tasks;

namespace CourseSignUp.Messege.Interface
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T servicesBusMessage, string queueName);
    }
}
