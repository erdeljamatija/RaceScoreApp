using RaceScore.Entities;
using System.Threading.Tasks;

namespace RaceScore.Repositories
{
    public interface IContactRepository
    {
        Task<Contact> SendMessage(Contact contact);
        Task<Contact> Subscribe(string address);
    }
}
