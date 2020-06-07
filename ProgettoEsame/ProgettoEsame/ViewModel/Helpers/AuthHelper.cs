using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel.Helpers
{
    public interface IAuth
    {
        Task<string> DoLoginWithEP(string E, string P);
        Task<string> DoRegisterWithEP(string N, string E, string P);
        //Task<bool> RegisterUser(string name, string email, string password);
        //Task<bool> AuthenticateUser(string email, string password);
        Task<bool> Logout();
        bool IsAuthenticated();
        string GetCurrentUserId();
    }


    public class Auth
    {

        private static IAuth auth = DependencyService.Get<IAuth>();


        public static async Task<string> DoRegisterWithEP(string N, string E, string P)
        {
            try
            {
                return await auth.DoRegisterWithEP(N, E, P);
            }
            catch (Exception ex)
            {
                //await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return "";
            }

        }

        public static async Task<string> DoLoginWithEP(string E, string P)
        {
            try
            {
                return await auth.DoLoginWithEP(E, P);
            }
            catch (Exception ex)
            {
                //await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return "";
            }

        }


        public static async Task<bool> Logout()
        {
            try
            {
                return await auth.Logout();
               
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }
        }







        public static bool IsAuthenticated()
        {
            return auth.IsAuthenticated();
        }

        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }

    }
}
