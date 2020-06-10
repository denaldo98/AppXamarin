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
    public partial class MercolediDetailsPage : ContentPage
    {
        MercolediDetailsVM vm;
        public MercolediDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as MercolediDetailsVM;
        }

        public MercolediDetailsPage(Evento selectedMercoledi)
        {
            InitializeComponent();
            Title = "Modifica Evento";

            vm = Resources["vm"] as MercolediDetailsVM;
            vm.Mercoledi = selectedMercoledi;

        }

    }
}