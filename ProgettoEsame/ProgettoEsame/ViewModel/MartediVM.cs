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
    public class MartediVM : INotifyPropertyChanged
    {

        private Evento selectedMartedi;

        public Evento SelectedMartedi
        {
            get { return selectedMartedi; }
            set
            {
                selectedMartedi = value;
                OnPropertyChanged("SelectedMartedi");
                if (selectedMartedi != null)
                    App.Current.MainPage.Navigation.PushAsync(new MartediDetailsPage(selectedMartedi));
            }
        }


        public ObservableCollection<Evento> MartediColl { get; set; }

        public MartediVM()
        {

            MartediColl = new ObservableCollection<Evento>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadMartedi()
        {

            var martedi = await DatabaseMartediHelper.ReadMartedi();
            MartediColl.Clear();
            foreach (var a in martedi)
            {
                MartediColl.Add(a);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}