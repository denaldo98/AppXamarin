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

        public void email(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            switch(lbl.Text)
            {
                case "denaldo98@gmail.com": Xamarin.Forms.Device.OpenUri(new Uri("mailto:denaldo98@gmail.com")); break;
                case "marco.monini98@gmail.com": Xamarin.Forms.Device.OpenUri(new Uri("mailto:marco.monini98@gmail.com")); break;
                case "antoniofrancesco.politano@gmail.com": Xamarin.Forms.Device.OpenUri(new Uri("mailto:antoniofrancesco.politano@gmail.com")); break;
            }
            
        }
    }
}