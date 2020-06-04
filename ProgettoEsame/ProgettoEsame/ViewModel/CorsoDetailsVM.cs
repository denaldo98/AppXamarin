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
    class CorsoDetailsVM : INotifyPropertyChanged
    {


        private Corso corso;

        public Corso Corso
        {
            get { return corso; }
            set
            {
                corso = value;
                Name = corso.Name;
                NameProf = corso.NameProf;
                EmailProf = corso.EmailProf;
                NumCFU = corso.NumCFU;
                OnPropertyChanged("Corso");
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Corso.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Corso");
            }
        }

        private string nameProf;
        public string NameProf
        {
            get { return nameProf; }
            set
            {
                nameProf = value;
                Corso.NameProf = nameProf;
                OnPropertyChanged("NameProf");
                OnPropertyChanged("Corso");
            }
        }

        private string emailProf;
        public string EmailProf
        {
            get { return emailProf; }
            set
            {
                emailProf = value;
                Corso.EmailProf = emailProf;
                OnPropertyChanged("EmailProf");
                OnPropertyChanged("Corso");
            }
        }

        private string numCFU;
        public string NumCFU
        {
            get { return numCFU; }
            set
            {
                numCFU = value;
                Corso.NumCFU = numCFU;
                OnPropertyChanged("NumCFU");
                OnPropertyChanged("Corso");
            }
        }


        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CorsoDetailsVM()
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
            bool result = await DatabaseCorsiHelper.UpdateCorso(Corso);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "There was an error, please try again", "Ok");
        }

        private async void Delete(object parameter)
        {
            bool result = await DatabaseCorsiHelper.DeleteCorso(Corso);

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
