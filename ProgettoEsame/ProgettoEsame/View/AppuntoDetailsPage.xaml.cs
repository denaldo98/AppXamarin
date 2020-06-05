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
    public partial class AppuntoDetailsPage : ContentPage
    {
        AppuntoDetailsVM vm;
        public AppuntoDetailsPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as AppuntoDetailsVM;
        }
       
        public AppuntoDetailsPage(Appunto selectedAppunto)
        {
            InitializeComponent();

            vm = Resources["vm"] as AppuntoDetailsVM;
            vm.Appunto = selectedAppunto;

        }
        
    }



}
    