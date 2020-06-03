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
    public class CorsoVM : INotifyPropertyChanged
    {

        private Corso selectedCorso;

        public Corso SelectedCorso
        {
            get { return selectedCorso; }
            set
            {
                selectedCorso = value;
                OnPropertyChanged("SelectedCorso");
                if (selectedCorso != null)
                    App.Current.MainPage.Navigation.PushAsync(new CorsoDetailsPage(selectedCorso));
            }
        }


        public ObservableCollection<Corso> Corsi { get; set; }

        public CorsoVM()
        {

            Corsi = new ObservableCollection<Corso>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadCorsi()
        {

            var corsi = await DatabaseCorsiHelper.ReadCorsi();
            Corsi.Clear();
            foreach (var c in corsi)
            {
                Corsi.Add(c);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
