using ProgettoEsame.ViewModel;
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
    public partial class GiovediPage : ContentPage
    {
        GiovediVM vm;

        public GiovediPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as GiovediVM; //accedo alla risorsa tramite chiave
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadGiovedi();
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewGiovediPage());
        }
    }
}