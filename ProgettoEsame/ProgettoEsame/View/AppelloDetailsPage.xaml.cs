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
    public partial class AppelloDetailsPage : ContentPage
    {
        AppelloDetailsVM vm;
        public AppelloDetailsPage()
        {
            InitializeComponent();
            

            vm = Resources["vm"] as AppelloDetailsVM;
        }

        public AppelloDetailsPage(Appello selectedAppello)
        {
            InitializeComponent();
            Title = "Modifica Appello";

            vm = Resources["vm"] as AppelloDetailsVM;
            vm.Appello = selectedAppello;

        }
        void OnDateSelected(object sender, DateChangedEventArgs args)
        {

            vm.DateTo = date.Date;

        }
    }
}