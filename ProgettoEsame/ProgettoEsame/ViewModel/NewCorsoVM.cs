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
    public class NewCorsoVM : INotifyPropertyChanged
    {
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

        private string nameProf;
        public string NameProf
        {
            get
            {
                return nameProf;
            }
            set
            {
                nameProf = value;
                OnPropertyChanged("NameProf");
            }
        }

        private string emailProf;
        public string EmailProf
        {
            get
            {
                return emailProf;
            }
            set
            {
                emailProf = value;
                OnPropertyChanged("EmailProf");
            }
        }

        private string numCFU;
        public string NumCFU
        {
            get
            {
                return numCFU;
            }
            set
            {
                numCFU = value;
                OnPropertyChanged("NumCFU");
            }
        }

        public ICommand SaveCorsoCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewCorsoVM()
        {
            SaveCorsoCommand = new Command(SaveCorso, SaveCorsoCanExecute);
        }

        private bool SaveCorsoCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void SaveCorso(object obj)
        {
            bool result = DatabaseCorsiHelper.InsertCorso(new Model.Corso
            {

                Name = Name,
                NameProf = NameProf,
                EmailProf = EmailProf,
                NumCFU = NumCFU
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
