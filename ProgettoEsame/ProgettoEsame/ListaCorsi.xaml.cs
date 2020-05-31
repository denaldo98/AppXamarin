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
    public partial class ListaCorsi : ContentPage
    {
        public ListaCorsi()
        {
            InitializeComponent();
            Title = "Corsi";
            BindingContext = new ListaCorsiModel(DisplayAlert);
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
        }

        public class ListaCorsiModel : BindableObject
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

            public ListaCorsiModel(Func<string, string, string, Task> displayAlertAction)
            {
                this.displayAlertAction = displayAlertAction;

                ListItems = new List<ListItem> {
                    new ListItem {Name = "Analisi 1"},
                    new ListItem {Name = "Analisi 2"},
                    new ListItem {Name = "Fisica 1"},
                    new ListItem {Name = "Fisica 2"}
                };
            }
        }
    }



}