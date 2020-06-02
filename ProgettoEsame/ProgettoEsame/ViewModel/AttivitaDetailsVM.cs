using ProgettoEsame.Model;
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
    class AttivitaDetailsVM : INotifyPropertyChanged
    {

        

        public List<Priorita> prioritaList { get; set; }

        public List<Priorita> getPriorita()
        {
            var priorities = new List<Priorita>()
            {
                new Priorita() {Key = 1, Value = "Bassa"},
                new Priorita() {Key = 2, Value = "Media"},
                new Priorita() {Key = 3, Value = "Alta"}
            };
            return priorities;
        }


        private Priorita selectedPriorita { get; set; }
        public Priorita SelectedPriorita
        {
            get { return selectedPriorita; }
            set
            {
                if (selectedPriorita != value)
                {
                    selectedPriorita = value;

                    Priority = selectedPriorita.Value;

                    //Do whatever functionality you want when a selectedItem is Changed

                }
            }
        }

        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                if (priority != value)
                {
                    priority = value;
                    Attivita.Priority = priority;
                    OnPropertyChanged("Priority");
                    OnPropertyChanged("Attivita");
                }
            }
        }


        private string scadenza;
        public string Scadenza
        {
            get { return scadenza; }
            set
            {
                if (scadenza != value)
                {
                    scadenza = value;
                    Attivita.Scadenza = scadenza;
                    OnPropertyChanged("Scadenza");
                    OnPropertyChanged("Attivita");
                }

            }
        }

        private DateTime dateTo;
        public DateTime DateTo
        {
            get { return dateTo; }
            set
            {
                if(dateTo != value)
                {
                    dateTo = value;
                    Scadenza = dateTo.ToString("dd-MM-yyyy");
                    OnPropertyChanged("DateTo");
                }
                
                
            }

        }

        




        private Attivita attivita;

        public Attivita Attivita
        {
            get { return attivita; }
            set
            {
                attivita = value;
                Name = attivita.Name;
                Description = attivita.Description;
                Priority = attivita.Priority;
                Scadenza = attivita.Scadenza;
                OnPropertyChanged("Attivita");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Attivita.Name = name;
                OnPropertyChanged("Name");
                OnPropertyChanged("Attivita");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                Attivita.Description = description;
                OnPropertyChanged("Description");
                OnPropertyChanged("Attivita");
            }
        }


        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AttivitaDetailsVM()
        {
            UpdateCommand = new Command(Update, UpdateCanExecute);
            DeleteCommand = new Command(Delete);
            prioritaList = getPriorita().ToList();
        }

        private bool UpdateCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private async void Update(object parameter)
        {
            bool result = await DatabaseToDoHelper.UpdateAttivita(Attivita);
            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "There was an error, please try again", "Ok");
        }

        private async void Delete(object parameter)
        {
            bool result = await DatabaseToDoHelper.DeleteAttivita(Attivita);

            if (result)
                await App.Current.MainPage.Navigation.PopAsync();
            else
                await App.Current.MainPage.DisplayAlert("Error", "There was an error, please try again", "Ok");
        }



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}