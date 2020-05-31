using ProgettoEsame.ViewModel;
using ProgettoEsame.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoEsame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubscriptionsPage : ContentPage
    {
        SubscriptionsVM vm;
        public SubscriptionsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as SubscriptionsVM; //accedo alla risorsa tramite chiave
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!Auth.IsAuthenticated())
            {
                await Task.Delay(300);
                await Navigation.PushAsync(new LoginPage());

            }
            else
            {
                vm.ReadSubscriptions(); //così ogni volta che ritorniamo in questa pag richiamo il metodo
            }

        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewSubscriptionPage());
        }
    }
}