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
    public class MercolediVM : INotifyPropertyChanged
    {

        private Evento selectedMercoledi;

        public Evento SelectedMercoledi
        {
            get { return selectedMercoledi; }
            set
            {
                selectedMercoledi = value;
                OnPropertyChanged("SelectedMercoledi");
                if (selectedMercoledi != null)
                    App.Current.MainPage.Navigation.PushAsync(new MercolediDetailsPage(selectedMercoledi));
            }
        }


        public ObservableCollection<Evento> MercolediColl { get; set; }

        public MercolediVM()
        {

            MercolediColl = new ObservableCollection<Evento>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadMercoledi()
        {

            var mercoledi = await DatabaseMercolediHelper.ReadMercoledi();
            MercolediColl.Clear();
            foreach (var a in mercoledi)
            {
                MercolediColl.Add(a);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}