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
[assembly: Dependency(typeof(ProgettoEsame.Droid.Dependencies.FirestoreAppelli))]
namespace ProgettoEsame.Droid.Dependencies
{
    class FirestoreAppelli : Java.Lang.Object, ViewModel.Helpers.AppelliFirestore, IOnCompleteListener
    {

        List<Appello> appelliList;
        bool hasReadAppelli = false;

        public FirestoreAppelli()
        {
            appelliList = new List<Appello>();
        }



        public async Task<bool> DeleteAppello(Appello appello)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Appelli");
                collection.Document(appello.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool InsertAppello(Appello appello)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Appelli");
                var appelloDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"name", appello.Name },
                    {"date", appello.Date }
                };
                collection.Add(appelloDocument);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<IList<Appello>> ReadAppelli()
        {
            hasReadAppelli = false;
            var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Appelli");
            collection.Get().AddOnCompleteListener(this);
            for (int i = 0; i < 25; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadAppelli)
                    break;
            }

            return appelliList;

        }

        public async Task<bool> UpdateAppello(Appello appello)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("users").Document(Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid).Collection("Appelli");
                collection.Document(appello.Id).Update("name", appello.Name, "date", appello.Date);
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
                appelliList.Clear();
                foreach (var doc in documents.Documents)
                {
                    string date;
                    if (doc.Get("date") == null)
                    {
                        date = "";
                    }
                    else
                    {
                        date = doc.Get("date").ToString();
                    }
                    Appello appello = new Appello
                    {
                        Name = doc.Get("name").ToString(),
                        Date = date,
                        Id = doc.Id
                    };

                    appelliList.Add(appello);

                }
            }
            else
            {
                appelliList.Clear();

            }
            hasReadAppelli = true;
        }
    }
}