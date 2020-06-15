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
    public partial class ToDoPage : ContentPage
    {
        AttivitaVM vm;
        
        public ToDoPage()
        {
            InitializeComponent();
            Title = "To do list";

            vm = Resources["vm"] as AttivitaVM; //accedo alla risorsa tramite chiave

            ToolbarItem item = new ToolbarItem
            {
                Text = "Contatti",
                IconImageSource = ImageSource.FromFile("example_icon.png"),
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item.Clicked += (sender, args) => {
                Navigation.PushAsync(new ContattiPage());
            };
            this.ToolbarItems.Add(item);


            ToolbarItem item2 = new ToolbarItem
            {
                Text = "Faq",
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item2.Clicked += (sender, args) => {
                Navigation.PushAsync(new FaqPage());
            };
            this.ToolbarItems.Add(item2);

            ToolbarItem item4 = new ToolbarItem
            {
                Text = "Informativa Privacy",
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item4.Clicked += (sender, args) => {
                Navigation.PushAsync(new PrivacyPage());
            };
            this.ToolbarItems.Add(item4);

            ToolbarItem item3 = new ToolbarItem
            {
                Text = "Logout",
                IconImageSource = ImageSource.FromFile("example_icon.png"),
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };
            item3.Clicked += async (sender, args) => {
                bool logout = await Auth.Logout();
                if (logout)
                {
                    Application.Current.Properties["logged"] = "false";
                    await Application.Current.SavePropertiesAsync();
                    await DisplayAlert("Attenzione!", "Il logout è stato eseguito, l'app verrà chiusa!", "Ok");
                    await System.Threading.Tasks.Task.Delay(1000);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();

                }
                else await DisplayAlert("Attenzione!", "Non è stato possibile effettuare il logout", "Ok");

            };
            this.ToolbarItems.Add(item3);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadAttivita();
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewAttivitaPage());
        }
    }
}