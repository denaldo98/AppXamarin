using ProgettoEsame.Model;
using ProgettoEsame.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoEsame.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SabatoDetailsPage : ContentPage
    {
        SabatoDetailsVM vm;
        public SabatoDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as SabatoDetailsVM;
        }

        public SabatoDetailsPage(Evento selectedSabato)
        {
            InitializeComponent();
            Title = "Modifica Evento";

            vm = Resources["vm"] as SabatoDetailsVM;
            vm.Sabato = selectedSabato;

        }

    }
}