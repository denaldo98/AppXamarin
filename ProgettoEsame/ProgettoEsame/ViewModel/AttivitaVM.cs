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
    public class AttivitaVM : INotifyPropertyChanged
    {

        private Attivita selectedAttivita;

        public Attivita SelectedAttivita
        {
            get { return selectedAttivita; }
            set
            {
                selectedAttivita = value;
                OnPropertyChanged("SelectedAttivita");
                if (selectedAttivita != null)
                    App.Current.MainPage.Navigation.PushAsync(new AttivitaDetailsPage(selectedAttivita));
            }
        }


        public ObservableCollection<Attivita> Activities { get; set; }

        public AttivitaVM()
        {

            Activities = new ObservableCollection<Attivita>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadAttivita()
        {

            var activities = await DatabaseToDoHelper.ReadAttivita();
            Activities.Clear();
            foreach (var s in activities)
            {
                Activities.Add(s);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

