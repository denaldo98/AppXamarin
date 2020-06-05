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
    public partial class ToDoPage : ContentPage
    {
        AttivitaVM vm;
        
        public ToDoPage()
        {
            InitializeComponent();
            Title = "To do";

            vm = Resources["vm"] as AttivitaVM; //accedo alla risorsa tramite chiave
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadAttivita(); //così ogni volta che ritorniamo in questa pag richiamo il metodo   
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewAttivitaPage());
        }
    }
}