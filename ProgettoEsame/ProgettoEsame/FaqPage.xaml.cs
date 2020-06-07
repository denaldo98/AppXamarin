using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProgettoEsame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FaqPage : ContentPage
    {
        public FaqPage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            Title = "FAQ";
        }
    }
}