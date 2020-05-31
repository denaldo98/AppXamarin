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
    public partial class ListaAppelli : ContentPage
    {
        public ListaAppelli()
        {
            InitializeComponent();
            Title = "Appelli";
            BindingContext = new ListaAppelliModel(DisplayAlert);
        }
        async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListItem item = (ListItem)e.Item;
            await DisplayAlert("Tapped", item.Name + " was selected.", "OK");
            ((ListView)sender).SelectedItem = null;
        }

        public class ListItem : BindableObject
        {
            public string Name { get; set; }
            public string Date { get; set; }
        }

        public class ListaAppelliModel : BindableObject
        {

            readonly Func<string, string, string, Task> displayAlertAction;

            List<ListItem> listItems;
            public List<ListItem> ListItems
            {
                get
                {
                    return listItems;
                }
                set
                {
                    listItems = value;
                    OnPropertyChanged("ListItems");
                }
            }

            public ListaAppelliModel(Func<string, string, string, Task> displayAlertAction)
            {
                this.displayAlertAction = displayAlertAction;

                ListItems = new List<ListItem> {
                    new ListItem {Name = "Analisi 1", Date = "12/12/20"},
                    new ListItem {Name = "Analisi 2", Date = "25/12/20"},
                    new ListItem {Name = "Fisica 1", Date = "15/08/20"},
                    new ListItem {Name = "Fisica 2", Date = "01/10/20"}
                };
            }
        }
    }



}