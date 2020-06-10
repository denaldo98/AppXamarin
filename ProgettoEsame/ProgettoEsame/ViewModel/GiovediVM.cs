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
    public class GiovediVM : INotifyPropertyChanged
    {

        private Evento selectedGiovedi;

        public Evento SelectedGiovedi
        {
            get { return selectedGiovedi; }
            set
            {
                selectedGiovedi = value;
                OnPropertyChanged("SelectedGiovedi");
                if (selectedGiovedi != null)
                    App.Current.MainPage.Navigation.PushAsync(new GiovediDetailsPage(selectedGiovedi));
            }
        }


        public ObservableCollection<Evento> GiovediColl { get; set; }

        public GiovediVM()
        {

            GiovediColl = new ObservableCollection<Evento>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadGiovedi()
        {

            var giovedi = await DatabaseGiovediHelper.ReadGiovedi();
            GiovediColl.Clear();
            foreach (var a in giovedi)
            {
                GiovediColl.Add(a);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}