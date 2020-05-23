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
    public partial class LoginPage : ContentPage
    {
        IFirebaseAuth auth;
        public LoginPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IFirebaseAuth>();
        }

        async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string pass = txtPass.Text;

         
            string token = await auth.DoLoginWithEP(mail, pass);
            //await DisplayAlert("ok",token,"OK");
            if(token != "")
            {
                //await Navigation.PushAsync(new Page1());
                //Navigation.RemovePage(this);
               
                Application.Current.MainPage = new HomePage();
                
            }
            else
            {
                ShowError();
            }

        }

        async private void ShowError() //inserire controlli su nome e password (la pass almeno di 6)
        {
            await DisplayAlert("Authentication Failed", "E-mail or password are incorrect. Try again!", "OK");
        }



        async void Btn_ToRegister_Clicked(object sender, EventArgs e)
        {
                await Navigation.PushAsync(new SignUpPage());
                Navigation.RemovePage(this);
        }


    }
}
