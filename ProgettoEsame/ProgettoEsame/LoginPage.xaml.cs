﻿using ProgettoEsame.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProgettoEsame
{

    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string pass = txtPass.Text;

            var fbLogin = DependencyService.Get<IFirebaseAuth>();
            string token = await fbLogin.DoLoginWithEP(mail, pass);
            await DisplayAlert("ok",token,"OK");
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string pass = txtPass.Text;

            var fbLogin = DependencyService.Get<IFirebaseAuth>();
            string token = await fbLogin.DoRegisterWithEP(mail, pass);
            await DisplayAlert("ok", token, "OK");
            
           
            
       
      
        }


    }
}
