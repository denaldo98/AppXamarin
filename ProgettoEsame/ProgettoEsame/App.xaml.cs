using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoEsame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            if(Application.Current.Properties.ContainsKey("logged")) //portare alla homepage
            {
               MainPage = new HomePage();
            }
            else //utente non loggato: portare alla pagina di login
            {
                MainPage = new  NavigationPage( new LoginPage());
            }
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
