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
    public class LunediVM : INotifyPropertyChanged
    {

        private Lunedi selectedLunedi;

        public Lunedi SelectedLunedi
        {
            get { return selectedLunedi; }
            set
            {
                selectedLunedi = value;
                OnPropertyChanged("SelectedLunedi");
                if (selectedLunedi != null)
                    App.Current.MainPage.Navigation.PushAsync(new LunediDetailsPage(selectedLunedi));
            }
        }


        public ObservableCollection<Lunedi> LunediColl { get; set; }

        public LunediVM()
        {

            LunediColl = new ObservableCollection<Lunedi>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadLunedi()
        {

            var lunedi = await DatabaseLunediHelper.ReadLunedi();
            LunediColl.Clear();
            foreach (var a in lunedi)
            {
                LunediColl.Add(a);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
