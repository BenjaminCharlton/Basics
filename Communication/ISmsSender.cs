using System.Threading.Tasks;

namespace Basics.Communications
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
