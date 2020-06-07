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
                await DisplayAlert("SignUp failed", "Please enter name!", "OK");
            } 
            else if (string.IsNullOrWhiteSpace(mail))
            {
                await DisplayAlert("SignUp failed", "Please enter email!", "OK");
            }
            else if (string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("SignUp failed", "Please enter password!!", "OK");
            }
            else if (pass.Length < 6)
            {
                await DisplayAlert("SignUp failed", "Password too short, enter minimum 6 characters!", "OK");
            }
            else if (!string.Equals(pass, confpass))
            {
                await DisplayAlert("SignUp failed", "Le password non coincidono!", "OK");
            } else
            {
                string token = await Auth.DoRegisterWithEP(string.Concat(nome, " ", cognome), mail, pass);
                //await DisplayAlert("ok", token, "OK");
                if (token != "") //registrazione OK
                {
                    await DisplayAlert("SignUp successfull", "Press OK to continue to Home Page", "OK");
                    App.Current.MainPage = new HomePage();
                }
                else //errore nella registrazione
                {
                    await DisplayAlert("Sign Up Failed", "E-mail or password are incorrect. Try again!", "OK");
                }

            }
            
            
            
        }

        async void BtnToLogin_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new LoginPage2());
            //Navigation.RemovePage(this);
           App.Current.MainPage = new LoginPage2();
            
        }
    }
}