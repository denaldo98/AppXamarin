using ProgettoEsame.Model;
using ProgettoEsame.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProgettoEsame.ViewModel
{
    class AppelloDetailsVM : INotifyPropertyChanged
    {


        private Appello appello;

        public Appello Appello
        {
            get { return appello; }
            set
            {
                appello = value;
                Name = appello.Name;
                Date = appello.Date;
                OnPropertyChanged("Attivita");
            }
        }

        private DateTime dateTo;
        public DateTime DateTo
        {
            get { return dateTo; }
            set
            {
                if (dateTo != value)
                {
                    dateTo = value;
                    Date = dateTo.ToString("dd-MM-yyyy");
                    OnPropertyChanged("DateTo");
                }


            }

        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Appello.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Appello");
            }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                Appello.Date = date;
                OnPropertyChanged("Date");
                OnPropertyChanged("Appello");
            }
        }


        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AppelloDetailsVM()
        {
            UpdateCommand = new Command(Update, UpdateCanExecute);
            DeleteCommand = new Command(Delete);
        }

        private bool UpdateCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private async void Update(object parameter)
        {
            bool result = await DatabaseAppelliHelper.UpdateAppello(Appello);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "There was an error, please try again", "Ok");
        }

        private async void Delete(object parameter)
        {
            bool result = await DatabaseAppelliHelper.DeleteAppello(Appello);

            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "There was an error, please try again", "Ok");
        }



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
