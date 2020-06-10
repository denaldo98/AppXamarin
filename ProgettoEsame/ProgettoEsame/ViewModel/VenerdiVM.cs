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
    public class VenerdiVM : INotifyPropertyChanged
    {

        private Evento selectedVenerdi;

        public Evento SelectedVenerdi
        {
            get { return selectedVenerdi; }
            set
            {
                selectedVenerdi = value;
                OnPropertyChanged("SelectedVenerdi");
                if (selectedVenerdi != null)
                    App.Current.MainPage.Navigation.PushAsync(new VenerdiDetailsPage(selectedVenerdi));
            }
        }


        public ObservableCollection<Evento> VenerdiColl { get; set; }

        public VenerdiVM()
        {

            VenerdiColl = new ObservableCollection<Evento>();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void ReadVenerdi()
        {

            var venerdi = await DatabaseVenerdiHelper.ReadVenerdi();
            VenerdiColl.Clear();
            foreach (var a in venerdi)
            {
                VenerdiColl.Add(a);
            }

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}