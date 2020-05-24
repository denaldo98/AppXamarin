using ProgettoEsame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoEsame
{
  
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        
        IFirebaseAuth auth;
        public SignUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseAuth>();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        async void BtnRegistra_Clicked(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string pass = txtPass.Text;
            //string confpass = txtConfPass.Text;
            //string nome = txtnome.Text;
            //string cognome = txtCognome.Text;

            string token = await auth.DoRegisterWithEP(mail, pass);
            //await DisplayAlert("ok", token, "OK");
            if (token != "") //registrazione OK
            {
                await DisplayAlert("SignUp successfull", "Press OK to continue to Home Page", "OK");
                //await Navigation.PushAsync(new Page1());
                //Navigation.RemovePage(this);
                Application.Current.MainPage = new HomePage();
            }
            else //errore nella registrazione
            {
                ShowError();
            }
        }



        /*async void BtnRegistra_Clicked((object sender, EventArgs e)
        {
            bool created = auth.DoRegisterWithEP(mail, pass);
            if (created)
            {
                await DisplayAlert("Success", "Registration completed", "OK");
                await Navigation.PushAsync(new Page1());
                Navigation.RemovePage(this);
            }
            else
            {
                await DisplayAlert("Sign Up Failed", "Something went wrong. Try again!", "OK");
            }
        }*/





        async private void ShowError() //inserire controlli
        {
            // Validations for email and password
            if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                await DisplayAlert("SignUp failed", "Please enter email!", "OK");
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                await DisplayAlert("SignUp failed", "Please enter password!!", "OK");
            }
            else if (txtPass.Text.Length < 6)
            {
                await DisplayAlert("SignUp failed", "Password too short, enter minimum 6 characters!", "OK");
            } else
            {
                await DisplayAlert("Sign Up Failed", "E-mail or password are incorrect. Try again!", "OK");
            }

          
        }

        async void BtnToLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            Navigation.RemovePage(this);
        }
    }
}