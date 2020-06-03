using ProgettoEsame.Model;
using ProgettoEsame.View;
using ProgettoEsame.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ProgettoEsame.ViewModel
{
    public class AppelloVM : INotifyPropertyChanged
    {

        private Appello selectedAppello;

        public Appello SelectedAppello
        {
            get { return selectedAppello; }
            set
            {
                selectedAppello = value;
                OnPropertyChanged("SelectedAppello");
                if (selectedAppello != null)
                    App.Current.MainPage.Navigation.PushAsync(new AppelloDetailsPage(selectedAppello));
            }
        }


        public ObservableCollection<Appello> Appelli { get; set; }

        public AppelloVM()
        {

            Appelli = new ObservableCollection<Appello>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadAppelli()
        {

            var appelli = await DatabaseAppelliHelper.ReadAppelli();
            Appelli.Clear();
            foreach (var a in appelli)
            {
                Appelli.Add(a);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
