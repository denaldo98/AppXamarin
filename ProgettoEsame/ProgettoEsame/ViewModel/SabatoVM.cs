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
    public class SabatoVM : INotifyPropertyChanged
    {

        private Evento selectedSabato;

        public Evento SelectedSabato
        {
            get { return selectedSabato; }
            set
            {
                selectedSabato = value;
                OnPropertyChanged("SelectedSabato");
                if (selectedSabato != null)
                    App.Current.MainPage.Navigation.PushAsync(new SabatoDetailsPage(selectedSabato));
            }
        }


        public ObservableCollection<Evento> SabatoColl { get; set; }

        public SabatoVM()
        {

            SabatoColl = new ObservableCollection<Evento>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadSabato()
        {

            var sabato = await DatabaseSabatoHelper.ReadSabato();
            SabatoColl.Clear();
            foreach (var a in sabato)
            {
                SabatoColl.Add(a);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}