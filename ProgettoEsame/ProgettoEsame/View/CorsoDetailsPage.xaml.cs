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
    public partial class CorsoDetailsPage : ContentPage
    {
        CorsoDetailsVM vm;
        public CorsoDetailsPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as CorsoDetailsVM;
        }

        public CorsoDetailsPage(Corso selectedCorso)
        {
            InitializeComponent();

            vm = Resources["vm"] as CorsoDetailsVM;
            vm.Corso = selectedCorso;

        }
    }
}