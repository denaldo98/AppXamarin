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
[assembly: Dependency(typeof(ProgettoEsame.Droid.Dependencies.FirestoreSabato))]
namespace ProgettoEsame.Droid.Dependencies
{
    class FirestoreSabato : Java.Lang.Object, ViewModel.Helpers.SabatoFirestore, IOnCompleteListener
    {

        List<Evento> sabatoList;
        bool hasReadSabato = false;

        public FirestoreSabato()
        {
            sabatoList = new List<Evento>();
        }



        public async Task<bool> DeleteSabato(Evento sabato)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Sabato");
                collection.Document(sabato.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertSabato(Evento sabato)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Sabato");
                var sabatoDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"nome", sabato.Name },
                    {"luogo", sabato.Luogo },
                    {"ora inizio", sabato.OraI },
                    {"ora fine", sabato.OraF }

                };
                collection.Add(sabatoDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IList<Evento>> ReadSabato()
        {
            hasReadSabato = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Sabato");
            //var query = collection.WhereEqualTo("author", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
            //query.Get().AddOnCompleteListener(this);  //ritorna i documenti della collezione. Quando il metodo get è completato viene chiamato l'OnComplete
            //var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("subscriptions"); //per noi va bene così
            //collection.Get().AddOnCompleteListener(this);
            collection.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)  //per aspettare che vengano lette . Aumentare eventualmente 
            {
                await System.Threading.Tasks.Task.Delay(100);  //aspettiamo 100 millisecondi, in totale 2.5 secondi. Aumentare eventualmente
                if (hasReadSabato)
                    break;
            }

            return sabatoList;

        }

        public async Task<bool> UpdateSabato(Evento sabato)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Sabato");
                collection.Document(sabato.Id).Update("nome", sabato.Name, "luogo", sabato.Luogo, "ora inizio", sabato.OraI, "ora fine", sabato.OraF);
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


                sabatoList.Clear();
                foreach (var doc in documents.Documents)
                {
                    string luogo, oraI, oraF;
                    if (doc.Get("luogo") == null)
                    {
                        luogo = "";
                    }
                    else
                    {
                        luogo = doc.Get("luogo").ToString();
                    }
                    if (doc.Get("ora inizio") == null)
                    {
                        oraI = "";
                    }
                    else
                    {
                        oraI = doc.Get("ora inizio").ToString();
                    }
                    if (doc.Get("ora fine") == null)
                    {
                        oraF = "";
                    }
                    else
                    {
                        oraF = doc.Get("ora fine").ToString();
                    }
                    Evento sabato = new Evento
                    {
                        Name = doc.Get("nome").ToString(),
                        Luogo = luogo,
                        OraI = oraI,
                        OraF = oraF,

                        Id = doc.Id
                    };

                    sabatoList.Add(sabato);

                }
            }
            else
            {
                sabatoList.Clear();

            }
            hasReadSabato = true;
        }
    }
}