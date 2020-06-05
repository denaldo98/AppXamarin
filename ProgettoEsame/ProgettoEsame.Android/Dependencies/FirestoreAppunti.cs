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
[assembly: Dependency(typeof(ProgettoEsame.Droid.Dependencies.FirestoreAppunti))]
namespace ProgettoEsame.Droid.Dependencies
{
    class FirestoreAppunti : Java.Lang.Object, ViewModel.Helpers.AppuntiFirestore, IOnCompleteListener
    {

        List<Appunto> appuntiList;
        bool hasReadAppunti = false;

        public FirestoreAppunti()
        {
            appuntiList = new List<Appunto>();
        }



        public async Task<bool> DeleteAppunto(Appunto appunto)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi").Document(appunto.IdCorso).Collection("Appunti");
                collection.Document(appunto.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertAppunto(Appunto appunto)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi").Document(appunto.IdCorso).Collection("Appunti");
                var appuntoDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"name", appunto.Name },
                    {"description", appunto.Description },
                    {"idCorso", appunto.IdCorso }
                };
                collection.Add(appuntoDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IList<Appunto>> ReadAppunti(Corso corso)
        {
            hasReadAppunti = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi").Document(corso.Id).Collection("Appunti");
            //var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            //query.Get().AddOnCompleteListener(this);  //ritorna i documenti della collezione. Quando il metodo get è completato viene chiamato l'OnComplete
            //var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions"); //per noi va bene così
            //collection.Get().AddOnCompleteListener(this);
            collection.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)  //per aspettare che vengano lette . Aumentare eventualmente 
            {
                await System.Threading.Tasks.Task.Delay(100);  //aspettiamo 100 millisecondi, in totale 2.5 secondi. Aumentare eventualmente
                if (hasReadAppunti)
                    break;
            }

            return appuntiList;

        }

        public async Task<bool> UpdateAppunto(Appunto appunto)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Corsi").Document(appunto.IdCorso).Collection("Appunti");
                collection.Document(appunto.Id).Update("name", appunto.Name, "description", appunto.Description, "idCorso", appunto.IdCorso);
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


                appuntiList.Clear();
                foreach (var doc in documents.Documents)
                {
                    string description;
                    if (doc.Get("description") == null)
                    {
                        description = "";
                    }
                    else
                    {
                        description = doc.Get("description").ToString();
                    }
                    Appunto appunto = new Appunto
                    {
                        Name = doc.Get("name").ToString(),
                        Description = description,
                        IdCorso = doc.Get("idCorso").ToString(),
                        Id = doc.Id
                    };

                    appuntiList.Add(appunto);

                }
            }
            else
            {
                appuntiList.Clear();

            }
            hasReadAppunti = true;
        }
    }
}