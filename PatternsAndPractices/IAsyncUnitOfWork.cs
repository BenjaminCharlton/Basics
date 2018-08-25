using System.Threading.Tasks;

namespace Basics.PatternsAndPractices
{
    public interface IAsyncUnitOfWork
    {
        Task<int> CompleteAsync();
        void Dispose();
    }
}