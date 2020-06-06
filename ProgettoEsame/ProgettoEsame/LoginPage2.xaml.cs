using ProgettoEsame.Interfaces;
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
        IFirebaseAuth auth;
        public LoginPage2()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseAuth>();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string pass = txtPass.Text;


            string token = await auth.DoLoginWithEP(mail, pass);
            //await DisplayAlert("ok",token,"OK");
            if (token != "")
            {
                
                await DisplayAlert("Authentication successfull", "Press OK to continue to Home Page", "OK");
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
                await DisplayAlert("Authentication Failed", "Empty fields", "OK");
            }
            else if (string.IsNullOrWhiteSpace(txtMail.Text))
            {
                await DisplayAlert("Authentication Failed", "Please enter email!!", "OK");
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                await DisplayAlert("Authentication Failed", "Please enter password!!", "OK");
            }
            else
            {
                await DisplayAlert("Authentication Failed", "E-mail or password are incorrect. Try again!", "OK");
            }
        }

        async void Btn_ToRegister_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SignUpPage());
            //Navigation.RemovePage(this);
            App.Current.MainPage = new SignUpPage();
            
        }


    }
}
