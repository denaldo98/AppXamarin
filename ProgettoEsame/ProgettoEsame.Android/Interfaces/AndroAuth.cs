using Firebase;
using Firebase.Auth;
using ProgettoEsame.Droid.Interfaces;
using ProgettoEsame.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroAuth))]
namespace ProgettoEsame.Droid.Interfaces
{
    public class AndroAuth : IFirebaseAuth
    {
        public async Task<string> DoLoginWithEP(string E, string P)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(E,P);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;

            }
            catch (FirebaseAuthInvalidUserException notFound)
            {
                //return notFound.Message;
                notFound.PrintStackTrace();
                return "";


            }
            catch (Exception err)
            {

                //return err.Message;
                return "";

            }
            
        }

        public async Task<string> DoRegisterWithEP(string E, string P)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(E, P);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;

            }
            catch (Exception err)
            {

                //return err.Message;
                return "";

            }

        }
    }
}