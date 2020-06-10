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
    public partial class VenerdiDetailsPage : ContentPage
    {
        VenerdiDetailsVM vm;
        public VenerdiDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as VenerdiDetailsVM;
        }

        public VenerdiDetailsPage(Evento selectedVenerdi)
        {
            InitializeComponent();
            Title = "Modifica Evento";

            vm = Resources["vm"] as VenerdiDetailsVM;
            vm.Venerdi = selectedVenerdi;

        }

    }
}