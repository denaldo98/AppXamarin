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
    public partial class NewAppuntoPage : ContentPage
    {
        NewAppuntoVM vm;
        public NewAppuntoPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as NewAppuntoVM;
        }

        public NewAppuntoPage(string id)
        {
            InitializeComponent();
            vm = Resources["vm"] as NewAppuntoVM;
            vm.IdCorso = id;
        }
    }
}