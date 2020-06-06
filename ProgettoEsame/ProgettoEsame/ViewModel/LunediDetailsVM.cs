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
    class LunediDetailsVM : INotifyPropertyChanged
    {


        private Evento lunedi;

        public Evento Lunedi
        {
            get { return lunedi; }
            set
            {
                lunedi = value;
                Name = lunedi.Name;
                Luogo = lunedi.Luogo;
                OraI = lunedi.OraI;
                OraF = lunedi.OraF;
                OnPropertyChanged("Evento");
            }
        }

        private TimeSpan timeStart;
        public TimeSpan TimeStart
        {
            get { return timeStart; }
            set
            {
                if (timeStart != value)
                {
                    timeStart = value;
                    OraI = timeStart.ToString("c");
                    OnPropertyChanged("TimeStart");
                }


            }

        }


        private TimeSpan timeEnd;
        public TimeSpan TimeEnd
        {
            get { return timeEnd; }
            set
            {
                if (timeEnd != value)
                {
                    timeEnd = value;
                    OraF = timeEnd.ToString("c");
                    OnPropertyChanged("TimeEnd");
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
                Lunedi.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Evento");
            }
        }

        private string luogo;

        public string Luogo
        {
            get { return luogo; }
            set
            {
                luogo = value;
                Lunedi.Luogo = luogo;
                OnPropertyChanged("Luogo");
                OnPropertyChanged("Evento");
            }
        }


        private string oraI;
        public string OraI
        {
            get { return oraI; }
            set
            {
                oraI = value;
                lunedi.OraI = oraI;
                OnPropertyChanged("OraI");
                OnPropertyChanged("Evento");
            }
        }

        private string oraF;
        public string OraF
        {
            get { return oraF; }
            set
            {
                oraF = value;
                lunedi.OraF = oraF;
                OnPropertyChanged("OraF");
                OnPropertyChanged("Evento");
            }
        }


        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LunediDetailsVM()
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
            bool result = await DatabaseLunediHelper.UpdateLunedi(Lunedi);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "There was an error, please try again", "Ok");
        }

        private async void Delete(object parameter)
        {
            bool result = await DatabaseLunediHelper.DeleteLunedi(Lunedi);

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
