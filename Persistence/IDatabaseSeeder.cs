using System.Threading.Tasks;

namespace Basics.Persistence
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}
