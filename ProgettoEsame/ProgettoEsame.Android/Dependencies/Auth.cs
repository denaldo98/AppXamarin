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

        /*public async Task<bool> AuthenticateUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An unknown erro occurred, please try again.");
            }
        }*/

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

        /*public async Task<bool> RegisterUser(string name, string email, string password)
        {
            try { 
            await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var profileUpdates = new Firebase.Auth.UserProfileChangeRequest.Builder();
            profileUpdates.SetDisplayName(name);
            var build = profileUpdates.Build();

            var user = Firebase.Auth.FirebaseAuth.Instance.CurrentUser;
            await user.UpdateProfileAsync(build);

            return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An unknown erro occurred, please try again.");
            }
        }*/

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
                //return err.Message;
                return "";
            }

        }


    }
}