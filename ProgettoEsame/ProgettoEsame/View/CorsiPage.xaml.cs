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
    public partial class CorsiPage : ContentPage
    {
        CorsoVM vm;

        public CorsiPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as CorsoVM; //accedo alla risorsa tramite chiave
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadCorsi(); //così ogni volta che ritorniamo in questa pag richiamo il metodo   
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewCorsoPage());
        }
    }
}