using ProgettoEsame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoEsame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Orario : TabbedPage
    {
        public Orario()
        {
            InitializeComponent();
            Title = "Orario";

            ToolbarItem item = new ToolbarItem
            {
                Text = "Faq",   
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item.Clicked += (sender, args) => {
                Navigation.PushAsync(new FaqPage());
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(item);

            ToolbarItem item2 = new ToolbarItem
            {
                Text = "Contatti",
                IconImageSource = ImageSource.FromFile("example_icon.png"),
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item2.Clicked += (sender, args) => {
                Navigation.PushAsync(new ContattiPage());
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(item2);

            ToolbarItem item3 = new ToolbarItem
            {
                Text = "Item3",
                IconImageSource = ImageSource.FromFile("example_icon.png"),
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item3.Clicked += (sender, args) => {
                Navigation.PushAsync(new Page1());
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(item3);


            ToolbarItem item4 = new ToolbarItem
            {
                Text = "Logout",
                IconImageSource = ImageSource.FromFile("example_icon.png"),
                Order = ToolbarItemOrder.Secondary,
                Priority = 0
            };

            item4.Clicked += async (sender, args) => {
                IFirebaseAuth auth = DependencyService.Get<IFirebaseAuth>();
                bool logout  = await auth.Logout();
                if (logout)
                {
                    Application.Current.Properties["logged"] = "false";
                    await Application.Current.SavePropertiesAsync();

                    //Application.Current.Properties.Clear();
                    await DisplayAlert("Attenzione!", "Il logout è stato eseguito, l'app verrà chiusa!", "Ok");
                    await System.Threading.Tasks.Task.Delay(1000);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();

                }
                else await DisplayAlert("Attenzione!", "Non è stato possibile effettuare il logout", "Ok");
               
            };

            // "this" refers to a Page object
            this.ToolbarItems.Add(item4);





        }
    }
}