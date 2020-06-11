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
    public partial class ContattiPage : ContentPage
    {
        public ContattiPage()
        {
            InitializeComponent();         
            Title = "Contatti";
           
        }

        private async void btnfaq_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FaqPage());
        }
    }
}