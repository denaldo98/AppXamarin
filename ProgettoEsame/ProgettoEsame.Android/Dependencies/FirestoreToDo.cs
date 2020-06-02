using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Google.Type;
using Java.Util;
using ProgettoEsame.Model;
using ProgettoEsame.ViewModel.Helpers;
using Xamarin.Forms;
using Firebase.Firestore;
using Android.Gms.Tasks;
using Android.Service.VR;
using Org.W3c.Dom;
[assembly: Dependency(typeof(ProgettoEsame.Droid.Dependencies.FirestoreToDo))]
namespace ProgettoEsame.Droid.Dependencies
{
    class FirestoreToDo : Java.Lang.Object, ViewModel.Helpers.ToDoFirestore, IOnCompleteListener
    {

        List<Attivita> attivitaList;
        bool hasReadAttivita = false;

        public FirestoreToDo()
        {
            attivitaList = new List<Attivita>();
        }



        public async Task<bool> DeleteAttivita(Attivita attivita)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("ToDo");
                collection.Document(attivita.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertAttivita(Attivita attivita)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("ToDo");
                var attivitaDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"name", attivita.Name },
                    {"description", attivita.Description },
                    {"priority", attivita.Priority },
                    {"data", attivita.Scadenza },
                };
                collection.Add(attivitaDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IList<Attivita>> ReadAttivita()
        {
            hasReadAttivita = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("ToDo");
            //var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            //query.Get().AddOnCompleteListener(this);  //ritorna i documenti della collezione. Quando il metodo get è completato viene chiamato l'OnComplete
            //var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions"); //per noi va bene così
            //collection.Get().AddOnCompleteListener(this);
            collection.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)  //per aspettare che vengano lette . Aumentare eventualmente 
            {
                await System.Threading.Tasks.Task.Delay(100);  //aspettiamo 100 millisecondi, in totale 2.5 secondi. Aumentare eventualmente
                if (hasReadAttivita)
                    break;
            }

            return attivitaList;

        }

        public async Task<bool> UpdateAttivita(Attivita attivita)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("ToDo");
                collection.Document(attivita.Id).Update("name", attivita.Name, "description", attivita.Description, "priority", attivita.Priority, "data", attivita.Scadenza);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void OnComplete(Android.Gms.Tasks.Task task)  //qui otteniani il risultato della query
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;  //bisognerebbe verificare che tipo di documento è
                                                             //var doc = documents.Documents[0]; //verificare il tipo di documento


                attivitaList.Clear();
                foreach (var doc in documents.Documents)
                {
                    string desc, priority, dat;
                    if(doc.Get("description") == null) {
                        desc = "";
                    } else
                    {
                        desc = doc.Get("description").ToString();
                    }
                    if (doc.Get("priority") == null)
                    {
                        priority = "";
                    }
                    else
                    {
                       priority = doc.Get("priority").ToString();
                    }
                    if (doc.Get("data") == null)
                    {
                        dat = "";
                    }
                    else
                    {
                        dat = doc.Get("data").ToString();
                    }


                    Attivita attivita = new Attivita
                    {
                        Name = doc.Get("name").ToString(),
                        Description = desc,  
                        Priority = priority,
                        Scadenza = dat,
                        Id = doc.Id
                    };

                    attivitaList.Add(attivita);

                }
            }
            else
            {
                attivitaList.Clear();

            }
            hasReadAttivita = true;
        }
    }
}