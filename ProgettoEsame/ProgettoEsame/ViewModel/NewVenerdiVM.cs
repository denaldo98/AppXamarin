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
    public class NewVenerdiVM : INotifyPropertyChanged
    {
        private TimeSpan timeStart;
        public TimeSpan TimeStart
        {
            get { return timeStart; }
            set
            {
                timeStart = value;
                OraI = timeStart.ToString("c");
                OnPropertyChanged("TimeStart");
            }

        }

        private TimeSpan timeEnd;
        public TimeSpan TimeEnd
        {
            get { return timeEnd; }
            set
            {
                timeEnd = value;
                OraF = timeEnd.ToString("c");
                OnPropertyChanged("TimeEnd");
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


        private string luogo;
        public string Luogo
        {
            get
            {
                return luogo;
            }
            set
            {
                luogo = value;
                OnPropertyChanged("Luogo");
            }
        }

        private string oraI;
        public string OraI
        {
            get
            {
                return oraI;
            }
            set
            {
                oraI = value;
                OnPropertyChanged("OraI");
            }
        }

        private string oraF;
        public string OraF
        {
            get
            {
                return oraF;
            }
            set
            {
                oraF = value;
                OnPropertyChanged("OraF");
            }
        }

        public ICommand SaveVenerdiCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewVenerdiVM()
        {
            SaveVenerdiCommand = new Command(SaveVenerdi, SaveVenerdiCanExecute);
        }

        private bool SaveVenerdiCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(Name);

        }

        private void SaveVenerdi(object obj)
        {
            bool result = DatabaseVenerdiHelper.InsertVenerdi(new Model.Evento
            {

                Name = Name,
                Luogo = Luogo,
                OraI = OraI,
                OraF = OraF
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