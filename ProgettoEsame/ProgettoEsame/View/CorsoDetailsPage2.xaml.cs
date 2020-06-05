using ProgettoEsame.Model;
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
    public partial class CorsoDetailsPage2 : ContentPage
    {
        String idcorso;
        CorsoDetailsVM2 vm;
        public CorsoDetailsPage2()
        {
            InitializeComponent();

            vm = Resources["vm"] as CorsoDetailsVM2;
            
        }

        public CorsoDetailsPage2(Corso selectedCorso)
        {
            InitializeComponent();

            vm = Resources["vm"] as CorsoDetailsVM2;
            vm.Corso = selectedCorso;
            idcorso = selectedCorso.Id;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadAppunti(); //così ogni volta che ritorniamo in questa pag richiamo il metodo   
        }


        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewAppuntoPage(idcorso));
        }

    }
}