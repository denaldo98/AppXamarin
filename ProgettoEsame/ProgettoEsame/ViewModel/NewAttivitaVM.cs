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
    public class NewAttivitaVM : INotifyPropertyChanged

    {

        private DateTime dateTo;
        public DateTime DateTo
        {
            get { return dateTo; }
            set { 
                dateTo = value;
                Scadenza = dateTo.ToString("dd-MM-yyyy");
                OnPropertyChanged("DateTo");
            }

        }

        private string scadenza;
        public string Scadenza
        {
            get { return scadenza; }
            set
            {
                scadenza = value;
                OnPropertyChanged("Scadenza");
            }
        }

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
                if(selectedPriorita != value)
                {
                    selectedPriorita = value;
                    string color = selectedPriorita.Value;
                    Priority = color;

                    if (string.Equals(color, "Bassa"))
                    {
                        Source = "verde.png";
                    }
                    else if (string.Equals(color, "Alta"))
                    {
                        Source = "rosso.png";
                    }
                    else Source = "giallo.png";
                }
            }
        }

        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                if(priority != value)
                {
                    priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }


        private string source;
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;            }
            }


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

        





        public ICommand SaveAttivitaCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewAttivitaVM()
        {
            SaveAttivitaCommand = new Command(SaveAttivita, SaveAttivitaCanExecute);

            prioritaList = getPriorita().ToList();
        }

        private bool SaveAttivitaCanExecute(object arg)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void SaveAttivita(object obj)
        {
            bool result = DatabaseToDoHelper.InsertAttivita(new Model.Attivita
            {

                Name = Name,
                Description = Description,
                Source = Source,
                Scadenza = Scadenza
                
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


    public class Priorita
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

}