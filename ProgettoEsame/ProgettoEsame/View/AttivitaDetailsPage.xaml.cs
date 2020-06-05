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
    public partial class AttivitaDetailsPage : ContentPage
    {
        AttivitaDetailsVM vm;
        public AttivitaDetailsPage()
        {
            InitializeComponent();
            

            vm = Resources["vm"] as AttivitaDetailsVM;
        }

        public AttivitaDetailsPage(Attivita selectedAttivita)
        {
            InitializeComponent();
            Title = "Modifica Attività";

            vm = Resources["vm"] as AttivitaDetailsVM;
            vm.Attivita = selectedAttivita;
            

        }
        void OnDateSelected(object sender, DateChangedEventArgs args)
        {

            vm.DateTo = scadenza.Date;

        }
    }



}