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
    public class NewAppuntoVM : INotifyPropertyChanged
    {
        
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
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private string idCorso;
        public string IdCorso
        {
            get
            {
                return idCorso;
            }
            set
            {
                idCorso = value;
                OnPropertyChanged("IdCorso");
            }
        }



        public ICommand SaveAppuntoCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewAppuntoVM()
        {
            SaveAppuntoCommand = new Command(SaveAppunto, SaveAppuntoCanExecute);
        }

        private bool SaveAppuntoCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void SaveAppunto(object obj)
        {
            bool result = DatabaseAppuntiHelper.InsertAppunto(new Model.Appunto
            {

                Name = Name,
                Description = Description,
                IdCorso = IdCorso
                
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
