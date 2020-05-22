
using System.Threading.Tasks;

namespace ProgettoEsame.Interfaces
{
    public interface IFirebaseAuth
    {
        Task<string> DoLoginWithEP(string E, string P);

        Task<string> DoRegisterWithEP(string E, string P);
    }
}
