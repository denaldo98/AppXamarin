using ProgettoEsame.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame
{
    [DesignTimeVisible(true)]
    public partial class LoginPage2 : ContentPage
    {
        public LoginPage2()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string pass = txtPass.Text;


            string token = await Auth.DoLoginWithEP(mail, pass);

            if (token != "")
            {
                
                await DisplayAlert("Autenticazione eseguita con successo", "Premi OK per continuare verso l'Home Page", "OK");
                App.Current.MainPage = new HomePage();

            }
            else
            {
                ShowError();
            }

        }

        async private void ShowError()
        {
            if (string.IsNullOrWhiteSpace(txtMail.Text) && string.IsNullOrWhiteSpace(txtPass.Text))
            {
                await DisplayAlert("Autenticazione fallita!", "Per favore, riempire i campi", "OK");
            }
            else if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                await DisplayAlert("Autenticazione fallita!", "Per favore, inserisci l'e-mail!", "OK");
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                await DisplayAlert("Autenticazione fallita!", "Per favore, inserisci lla password!", "OK");
            }
            else
            {
                await DisplayAlert("Autenticazione fallita!", "L'e-mail o la password non sono corrette. Riprova!", "OK");
            }
        }

        async void Btn_ToRegister_Clicked(object sender, EventArgs e)
        {
            

            App.Current.MainPage = new SignUpPage();
            
        }


    }
}
