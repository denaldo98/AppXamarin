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
    public partial class LunediDetailsPage : ContentPage
    {
        LunediDetailsVM vm;
        public LunediDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as LunediDetailsVM;
        }

        public LunediDetailsPage(Lunedi selectedLunedi)
        {
            InitializeComponent();
            Title = "Modifica Evento";

            vm = Resources["vm"] as LunediDetailsVM;
            vm.Lunedi = selectedLunedi;

        }
      
    }
}