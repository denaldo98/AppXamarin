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
    public partial class GiovediDetailsPage : ContentPage
    {
        GiovediDetailsVM vm;
        public GiovediDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as GiovediDetailsVM;
        }

        public GiovediDetailsPage(Evento selectedGiovedi)
        {
            InitializeComponent();
            Title = "Modifica Evento";

            vm = Resources["vm"] as GiovediDetailsVM;
            vm.Giovedi = selectedGiovedi;

        }

    }
}