using ProgettoEsame.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace ProgettoEsame.ViewModel
{
    public class NewAppelloVM : INotifyPropertyChanged
    {
        private DateTime dateTo;
        public DateTime DateTo
        {
            get { return dateTo; }
            set
            {
                dateTo = value;
                Date = dateTo.ToString("dd-MM-yyyy");
                OnPropertyChanged("DateTo");
            }

        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public ICommand SaveAppelloCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewAppelloVM()
        {
            SaveAppelloCommand = new Command(SaveAppello, SaveAppelloCanExecute);
        }

        private bool SaveAppelloCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void SaveAppello(object obj)
        {
            bool result = DatabaseAppelliHelper.InsertAppello(new Model.Appello
            {

                Name = Name,
                Date = Date
            });
            if (result)
                App.Current.MainPage.Navigation.PopAsync();
            else
                App.Current.MainPage.DisplayAlert("Error", "Something went wrong, please try again", "Ok");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
