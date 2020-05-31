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
    public partial class ListaToDo2 : ContentPage
    {
        public ListaToDo2()
        {
            InitializeComponent();
            Title = "To Do";
            BindingContext = new ListaToDo2Model(DisplayAlert);
        }
        async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            ListItem item = (ListItem)e.Item;
            await DisplayAlert("Tapped", item.Title + " was selected.", "OK");
            ((ListView)sender).SelectedItem = null;
        }

        public class ListItem : BindableObject
        {
            public string Source { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Date { get; set; }
        }

        public class ListaToDo2Model : BindableObject
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

            public ListaToDo2Model(Func<string, string, string, Task> displayAlertAction)
            {
                this.displayAlertAction = displayAlertAction;

                ListItems = new List<ListItem> {
                    new ListItem {Source = "verde.png", Title = "First", Description="1st item", Date="$100.00"},
                    new ListItem {Source = "giallo.png", Title = "Second", Description="2nd item", Date="$200.00"},
                    new ListItem {Source = "rosso.png", Title = "Third", Description="3rd item", Date="$300.00"},
                    new ListItem {Source = "verde.png", Title = "First", Description="1st item", Date="$100.00"},
                    new ListItem {Source = "giallo.png", Title = "Second", Description="2nd item", Date="$200.00"},
                    new ListItem {Source = "rosso.png", Title = "Third", Description="3rd item", Date="$300.00"},
                    new ListItem {Source = "verde.png", Title = "First", Description="1st item", Date="$100.00"},
                    new ListItem {Source = "giallo.png", Title = "Second", Description="2nd item", Date="$200.00"},
                    new ListItem {Source = "rosso.png", Title = "Third", Description="3rd item", Date="$300.00"},
                    new ListItem {Source = "verde.png", Title = "First", Description="1st item", Date="$100.00"},
                    new ListItem {Source = "giallo.png", Title = "Second", Description="2nd item", Date="$200.00"},
                    new ListItem {Source = "rosso.png", Title = "Third", Description="3rd item", Date="$300.00"}
                };
            }
        }
    }



}