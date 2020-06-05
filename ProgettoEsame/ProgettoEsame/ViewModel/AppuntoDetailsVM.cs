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
    class AppuntoDetailsVM : INotifyPropertyChanged
    {


        private Appunto appunto;

        public Appunto Appunto
        {
            get { return appunto; }
            set
            {
                appunto = value;
                Name = appunto.Name;
                Description = appunto.Description;
                OnPropertyChanged("Appunto");
            }
        }

   

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Appunto.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Appunto");
            }
        }


        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                Appunto.Description = description;
                OnPropertyChanged("Description");
                OnPropertyChanged("Appunto");
            }
        }




        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AppuntoDetailsVM()
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
            bool result = await DatabaseAppuntiHelper.UpdateAppunto(Appunto);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "There was an error, please try again", "Ok");
        }

        private async void Delete(object parameter)
        {
            bool result = await DatabaseAppuntiHelper.DeleteAppunto(Appunto);

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
