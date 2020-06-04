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
using Java.Lang;
using Exception = Java.Lang.Exception;

[assembly: Dependency(typeof(ProgettoEsame.Droid.Dependencies.FirestoreCorsi))]
namespace ProgettoEsame.Droid.Dependencies
{
    class FirestoreCorsi : Java.Lang.Object, ViewModel.Helpers.CorsiFirestore, IOnCompleteListener
    {

        List<Corso> corsiList;
        bool hasReadCorsi = false;

        public FirestoreCorsi()
        {
            corsiList = new List<Corso>();
        }



        public async Task<bool> DeleteCorso(Corso corso)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi");
                collection.Document(corso.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertCorso(Corso corso)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi");
                var corsoDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"name", corso.Name },
                    {"nameProf", corso.NameProf },
                    {"emailProf", corso.EmailProf },
                    {"numCFU", corso.NumCFU }
                };
                collection.Add(corsoDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IList<Corso>> ReadCorsi()
        {
            hasReadCorsi = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi");
            //var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            //query.Get().AddOnCompleteListener(this);  //ritorna i documenti della collezione. Quando il metodo get è completato viene chiamato l'OnComplete
            //var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions"); //per noi va bene così
            //collection.Get().AddOnCompleteListener(this);
            collection.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)  //per aspettare che vengano lette . Aumentare eventualmente 
            {
                await System.Threading.Tasks.Task.Delay(100);  //aspettiamo 100 millisecondi, in totale 2.5 secondi. Aumentare eventualmente
                if (hasReadCorsi)
                    break;
            }

            return corsiList;

        }

        public async Task<bool> UpdateCorso(Corso corso)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi");
                collection.Document(corso.Id).Update("name", corso.Name, "nameProf", corso.NameProf, "emailProf", corso.EmailProf, "numCFU", corso.NumCFU);
                return true;
            }
            catch (Java.Lang.Exception ex)
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


                corsiList.Clear();
                foreach (var doc in documents.Documents)
                {
                    string nameProf;
                    if (doc.Get("nameProf") == null)
                    {
                        nameProf = "";
                    }
                    else
                    {
                        nameProf = doc.Get("nameProf").ToString();
                    }

                    string numCFU;
                    if (doc.Get("numCFU") == null)
                    {
                        numCFU = "";
                    }
                    else
                    {
                        numCFU = doc.Get("numCFU").ToString();
                    }
                    string emailProf;
                    if (doc.Get("emailProf") == null)
                    {
                        emailProf = "";
                    }
                    else
                    {
                        emailProf = doc.Get("emailProf").ToString();
                    }
                    Corso corso = new Corso
                    {
                        Name = doc.Get("name").ToString(),
                        NameProf = nameProf,
                        EmailProf = emailProf,
                        NumCFU = numCFU,
                        Id = doc.Id
                    };

                    corsiList.Add(corso);

                }
            }
            else
            {
                corsiList.Clear();

            }
            hasReadCorsi = true;
        }
    }
}