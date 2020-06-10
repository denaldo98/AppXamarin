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
    public partial class MartediDetailsPage : ContentPage
    {
        MartediDetailsVM vm;
        public MartediDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as MartediDetailsVM;
        }

        public MartediDetailsPage(Evento selectedMartedi)
        {
            InitializeComponent();
            Title = "Modifica Evento";

            vm = Resources["vm"] as MartediDetailsVM;
            vm.Martedi = selectedMartedi;

        }

    }
}