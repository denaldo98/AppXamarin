using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProgettoEsame.ViewModel.Helpers;

namespace ProgettoEsame
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {

        
        public SignUpPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        async void BtnRegistra_Clicked(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string pass = txtPass.Text;
            string confpass = txtConfPass.Text;
            string nome = txtnome.Text;
            string cognome = txtCognome.Text;

            if(string.IsNullOrWhiteSpace(nome))
            {
                await DisplayAlert("SignUp non riuscito", "Per favore, inserisci un nome!", "OK");
            } 
            else if (string.IsNullOrWhiteSpace(mail))
            {
                await DisplayAlert("SignUp non riuscito", "Per favore, inserisci l'e-mail!", "OK");
            }
            else if (string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("SignUp non riuscito", "Per favore, inserisci la password!", "OK");
            }
            else if (pass.Length < 6)
            {
                await DisplayAlert("SignUp non riuscito", "Password troppo corta, inserisci almeno 6 caratteri!", "OK");
            }
            else if (!string.Equals(pass, confpass))
            {
                await DisplayAlert("SignUp non riuscito", "Le password non coincidono!", "OK");
            } else
            {
                string token = await Auth.DoRegisterWithEP(string.Concat(nome, " ", cognome), mail, pass);
                if (token != "") //registrazione OK
                {
                    await DisplayAlert("SignUp riuscito", "Premi OK per continuare verso l'Home Page", "OK");
                    App.Current.MainPage = new HomePage();
                }
                else //errore nella registrazione
                {
                    await DisplayAlert("SignUp non riuscito", "L'e-mail o la password non sono corrette. Riprova!", "OK");
                }

            }
            
            
            
        }

        async void BtnToLogin_Clicked(object sender, EventArgs e)
        {

           App.Current.MainPage = new LoginPage2();
            
        }
    }
}