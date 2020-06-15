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
[assembly: Dependency(typeof(ProgettoEsame.Droid.Dependencies.FirestoreGiovedi))]
namespace ProgettoEsame.Droid.Dependencies
{
    class FirestoreGiovedi : Java.Lang.Object, ViewModel.Helpers.GiovediFirestore, IOnCompleteListener
    {

        List<Evento> giovediList;
        bool hasReadGiovedi = false;

        public FirestoreGiovedi()
        {
            giovediList = new List<Evento>();
        }



        public async Task<bool> DeleteGiovedi(Evento giovedi)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Giovedi");
                collection.Document(giovedi.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertGiovedi(Evento giovedi)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Giovedi");
                var giovediDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"nome", giovedi.Name },
                    {"luogo", giovedi.Luogo },
                    {"ora inizio", giovedi.OraI },
                    {"ora fine", giovedi.OraF }

                };
                collection.Add(giovediDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IList<Evento>> ReadGiovedi()
        {
            hasReadGiovedi = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Giovedi");
            collection.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadGiovedi)
                    break;
            }

            return giovediList;

        }

        public async Task<bool> UpdateGiovedi(Evento giovedi)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Giovedi");
                collection.Document(giovedi.Id).Update("nome", giovedi.Name, "luogo", giovedi.Luogo, "ora inizio", giovedi.OraI, "ora fine", giovedi.OraF);
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
                var documents = (QuerySnapshot)task.Result;
                giovediList.Clear();
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
                    Evento giovedi = new Evento
                    {
                        Name = doc.Get("nome").ToString(),
                        Luogo = luogo,
                        OraI = oraI,
                        OraF = oraF,

                        Id = doc.Id
                    };

                    giovediList.Add(giovedi);

                }
            }
            else
            {
                giovediList.Clear();

            }
            hasReadGiovedi = true;
        }
    }
}