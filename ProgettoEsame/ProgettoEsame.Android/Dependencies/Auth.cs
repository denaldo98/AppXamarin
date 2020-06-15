using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using ProgettoEsame.ViewModel.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(ProgettoEsame.Droid.Dependencies.Auth))]
namespace ProgettoEsame.Droid.Dependencies
{
    public class Auth : IAuth
    {
        public Auth()
        {
        }
        public async Task<string> DoLoginWithEP(string E, string P)    //login con email e password
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(E, P);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (FirebaseAuthInvalidUserException notFound)
            {

                notFound.PrintStackTrace();
                return "";


            }
            catch (Exception err)
            {

                return "";
            }

        }


        public async Task<bool> Logout()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public string GetCurrentUserId()
        {
            return Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
             return Firebase.Auth.FirebaseAuth.Instance.CurrentUser != null;
        }

       
        public async Task<string> DoRegisterWithEP(string N, string E, string P)   //registrazione con email e password
        {
            try
            {
                var create = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(E, P);
                var profileUpdates = new Firebase.Auth.UserProfileChangeRequest.Builder();
                profileUpdates.SetDisplayName(N);
                var build = profileUpdates.Build();

                var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
                await user.UpdateProfileAsync(build);
                var token = await create.User.GetIdTokenAsync(false);
                return token.Token;

            }
            catch (Exception err)
            {

                return "";
            }

        }


    }
}